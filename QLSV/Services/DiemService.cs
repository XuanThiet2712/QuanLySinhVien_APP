using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLSV.Data;
using QLSV.DTOs;
using QLSV.Helpers;
using QLSV.Repositories;

namespace QLSV.Services
{
    public class DiemService
    {
        public double TinhDiemTongKet(double cc, double gk, double ck)
        {
            double tk = cc * 0.1 + gk * 0.3 + ck * 0.6;
            return Math.Round(tk, 1, MidpointRounding.AwayFromZero);
        }
        public string QuyDoiDiemChu(double tk)
        {
            if (tk >= 8.5) return "A";
            if (tk >= 8.0) return "B+";
            if (tk >= 7.0) return "B";
            if (tk >= 6.5) return "C+";
            if (tk >= 5.5) return "C";
            if (tk >= 5.0) return "D+";
            if (tk >= 4.0) return "D";
            return "F";
        }
        public double QuyDoiHe4(double tk) { 
            if (tk >= 8.5) return 4.0;
            if (tk >= 8.0) return 3.5;
            if (tk >= 7.0) return 3.0;
            if (tk >= 6.5) return 2.5;
            if (tk >= 5.5) return 2.0;
            if (tk >= 5.0) return 1.5;
            if (tk >= 4.0) return 1.0;
            return 0;
        }
        //ds lop co quyen nhap diem, gv chi thay lop minh
        public List<LopHocPhanDTO> GetLopDuocNhapDiem()
        {
            if (!SessionManager.HasPermission(MaChucNang.NHAP_DIEM))
                return new List<LopHocPhanDTO>();
            using (var db = DbFactory.Create())
            {
                var repo = new LopHocPhanRepository(db);
                if (SessionManager.IsInRole(MaNhom.GV))
                {
                    string MaGV = SessionManager.CurrentUser.MaGV;
                    if (string.IsNullOrWhiteSpace(MaGV))
                        return new List<LopHocPhanDTO>();
                    return repo.Search(null, null, MaGV);
                }
                return repo.Search(null, null, null);
            }
        } 

        public List<DiemDTO> GetDanhSachNhapDiem(string MaLHP)
        {
            if (!SessionManager.HasPermission(MaChucNang.NHAP_DIEM))
                return new List<DiemDTO>();

            using (var db = DbFactory.Create())
            {
                var lop = db.LopHocPhans
                    .FirstOrDefault(x => x.MaLHP == MaLHP);

                if (lop == null)
                    return new List<DiemDTO>();

                if (SessionManager.IsInRole(MaNhom.GV) &&
                    lop.MaGV != SessionManager.CurrentUser.MaGV)
                    return new List<DiemDTO>();

                var repo = new DiemRepository(db);

                return repo.GetByLHP(MaLHP);
            }
        }
        private bool DiemHopLe(decimal? diem)
        {
            return !diem.HasValue || (diem.Value >= 0 && diem.Value <= 10);
        }

        // chuyen sang chuoi
        private string ChuoiDiem(decimal? cc, decimal? gk, decimal? ck)
        {
            return "CC=" + (cc.HasValue ? cc.Value.ToString() : "-")
                + ";GK=" + (gk.HasValue ? gk.Value.ToString() : "-")
                + ";CK=" + (ck.HasValue ? ck.Value.ToString() : "-");
        }

        //Luu diem lop
        public Result LuuDiem(
            string maLHP,
            List<DiemDTO> ds,
            int maNguoiSua)
        {
            //Ktra ng dung
            if (!SessionManager.HasPermission(
                    MaChucNang.NHAP_DIEM))
                return Result.Fail("Không có quyền nhập điểm.");

            if (SessionManager.CurrentUser == null ||
                SessionManager.CurrentUser.MaND != maNguoiSua)
                return Result.Fail("Người sửa không hợp lệ.");

            if (ds == null)
                return Result.Fail("Danh sách điểm không hợp lệ.");

            if (string.IsNullOrWhiteSpace(maLHP))
                return Result.Fail("Chưa chọn lớp học phần.");

            try
            {
                using (var db = DbFactory.Create())
                {
                    //ktra lhp
                    var lop = db.LopHocPhans.FirstOrDefault(x => x.MaLHP == maLHP);
                    if (lop == null)
                        return Result.Fail("Không tìm thấy lớp.");
                
                    //gv chi sua lop minh phu trach
                    if (SessionManager.IsInRole(MaNhom.GV) &&
                        lop.MaGV != SessionManager.CurrentUser.MaGV)
                        return Result.Fail("Không được sửa điểm lớp khác.");
     
                    //ktra madk thuoc dung lop
                    var maHopLe = db.DangKyHocPhans
                        .Where(x => x.MaLHP == maLHP)
                        .Select(x => x.MaDK)
                        .ToList();

                    if (ds.Any(x => !maHopLe.Contains(x.MaDK)))
                        return Result.Fail("Có sinh viên không thuộc lớp.");

                    if (ds.GroupBy(x => x.MaDK).Any(g => g.Count() > 1))
                        return Result.Fail("Danh sách bị trùng MaDK.");

                    var repo = new DiemRepository(db);
                    var nhatKyRepo = new NhatKyDiemRepository(db);

                    //duyet sv
                    foreach (DiemDTO x in ds)
                    {
                        if (!DiemHopLe(x.DiemCC) ||
                            !DiemHopLe(x.DiemGK) ||
                            !DiemHopLe(x.DiemCK))
                            return Result.Fail(
                                "Điểm không hợp lệ: " + x.MaSV);
                        // lay diem cu ss
                        Diem cu = repo.GetByDangKy(x.MaDK);
                        // 0 can tao o trong
                        if (cu == null &&
                            !x.DiemCC.HasValue &&
                            !x.DiemGK.HasValue &&
                            !x.DiemCK.HasValue)
                            continue;
                        bool thayDoi = cu == null || 
                            cu.DiemCC != x.DiemCC || 
                            cu.DiemGK != x.DiemGK || 
                            cu.DiemCK != x.DiemCK;
                        if (!thayDoi) continue;
                        string diemCu = cu == null ? "Chưa nhập" : ChuoiDiem
                            (cu.DiemCC, cu.DiemGK, cu.DiemCK);

                        //tinh lai, pd giao dien
                        decimal? tk = null;
                        string chu = null;
                        decimal? he4 = null;

                        if (x.DiemCC.HasValue &&
                            x.DiemGK.HasValue &&
                            x.DiemCK.HasValue)
                        {
                            double tong = TinhDiemTongKet(
                                (double)x.DiemCC.Value,
                                (double)x.DiemGK.Value,
                                (double)x.DiemCK.Value);

                            tk = (decimal)tong;
                            chu = QuyDoiDiemChu(tong);
                            he4 = (decimal)QuyDoiHe4(tong);
                        }

                        // them/cap nhat diem
                        repo.Upsert(new Diem
                        {
                            MaDK = x.MaDK,
                            DiemCC = x.DiemCC,
                            DiemGK = x.DiemGK,
                            DiemCK = x.DiemCK,
                            DiemTongKet = tk,
                            DiemChu = chu,
                            Diem4 = he4
                        });

                        //luu lich su sua
                        nhatKyRepo.Add(new NhatKyDiem
                        {
                            MaDK = x.MaDK,
                            DiemCu = diemCu,
                            DiemMoi = ChuoiDiem(
                                x.DiemCC, x.DiemGK, x.DiemCK),
                            NguoiSua = maNguoiSua,
                            NgaySua = DateTime.Now
                        });
                    }

                    // luu diem + nhat ki
                    db.SubmitChanges();

                    return Result.Ok("Lưu điểm thành công.");
                }
            }
            catch (Exception ex)
            {
                return Result.Fail("Lỗi lưu điểm: " + ex.Message);
            }
        }
        public List<NhatKyDiem> GetLichSuSuaDiem(int maDK)
        {
            if (!SessionManager.HasPermission(
                MaChucNang.NHAP_DIEM))
                return new List<NhatKyDiem>();

            using (var db = DbFactory.Create())
            {
                var dk = db.DangKyHocPhans
                    .FirstOrDefault(x => x.MaDK == maDK);

                if (dk == null)
                    return new List<NhatKyDiem>();

                // gv chi xem ls lop minh
                if (SessionManager.IsInRole(MaNhom.GV))
                {
                    var lop = db.LopHocPhans
                        .FirstOrDefault(x => x.MaLHP == dk.MaLHP);

                    if (lop == null || lop.MaGV != SessionManager.CurrentUser.MaGV)
                        return new List<NhatKyDiem>();
                }

                var repo = new NhatKyDiemRepository(db);
                return repo.GetByDangKy(maDK);
            }
        }
        private double TinhGPA(QLSVDataContext db, string maSV, string maHK)
        {
            var ds = (from dk in db.DangKyHocPhans
                      join lhp in db.LopHocPhans
                          on dk.MaLHP equals lhp.MaLHP
                      join mon in db.MonHocs
                          on lhp.MaMon equals mon.MaMon
                      join d in db.Diems
                          on dk.MaDK equals d.MaDK
                      where dk.MaSV == maSV
                          && (maHK == null || lhp.MaHK == maHK)
                          && d.Diem4.HasValue
                      select new
                      {
                          Diem4 = d.Diem4.Value,
                          SoTinChi = mon.SoTinChi
                      }).ToList();

            if (ds.Count == 0)
                return 0;

            decimal tongTinChi = ds.Sum(x => (decimal)x.SoTinChi);

            if (tongTinChi == 0)
                return 0;

            decimal tongDiem = ds.Sum(x => x.Diem4 * x.SoTinChi);

            return (double)Math.Round(
                tongDiem / tongTinChi, 2, MidpointRounding.AwayFromZero);
        }
        public double TinhGPA(string maSV, string maHK)
        {
            using (var db = DbFactory.Create())
            {
                return TinhGPA(db, maSV, maHK);
            }
        }
        public string XepLoaiHocLuc(double gpa)
        {
            if (gpa < 0 || gpa > 4)
                return "Không hợp lệ";

            if (gpa >= 3.6) return "Xuất sắc";
            if (gpa >= 3.2) return "Giỏi";
            if (gpa >= 2.5) return "Khá";
            if (gpa >= 2.0) return "Trung bình";
            return "Yếu";
        }

        public Result<string> CanhBaoHocVu(string maSV, string maHK)
        {
            try
            {
                using (var db = DbFactory.Create())
                {
                    var ds = (from dk in db.DangKyHocPhans
                              join lhp in db.LopHocPhans
                                  on dk.MaLHP equals lhp.MaLHP
                              join mon in db.MonHocs
                                  on lhp.MaMon equals mon.MaMon
                              join d in db.Diems
                                  on dk.MaDK equals d.MaDK
                              where dk.MaSV == maSV
                                  && lhp.MaHK == maHK
                                  && d.DiemTongKet.HasValue
                              select new
                              {
                                  d.DiemTongKet,
                                  mon.SoTinChi
                              }).ToList();

                    if (ds.Count == 0)
                        return Result<string>.Ok("Chưa có dữ liệu điểm để đánh giá.");

                    double gpa = TinhGPA(db, maSV, maHK);

                    int tinChiNo = ds
                        .Where(x => x.DiemTongKet.Value < 4m)
                        .Sum(x => (int)x.SoTinChi);

                    if (gpa < 1.0 || tinChiNo > 8)
                    {
                        return Result<string>.Ok(
                            "Cảnh báo học vụ! GPA: " +
                            gpa.ToString("0.00") +
                            ", số tín chỉ nợ: " + tinChiNo);
                    }

                    return Result<string>.Ok("Không bị cảnh báo học vụ.");
                }
            }
            catch (Exception ex)
            {
                return Result<string>.Fail(ex.Message);
            }
        }
        public List<BangDiemItemDTO> GetBangDiem(string maSV, string maHK)
        {
            if (!SessionManager.HasPermission(
                MaChucNang.XEM_DIEM))
                return new List<BangDiemItemDTO>();

            if (SessionManager.IsInRole(MaNhom.SV) &&
                SessionManager.CurrentUser.MaSV != maSV)
                return new List<BangDiemItemDTO>();

            using (var db = DbFactory.Create())
            {
                bool laGV = SessionManager.IsInRole(MaNhom.GV);
                string maGV = SessionManager.CurrentUser.MaGV;

                var ds = from dk in db.DangKyHocPhans
                         join sv in db.SinhViens
                             on dk.MaSV equals sv.MaSV
                         join lhp in db.LopHocPhans
                             on dk.MaLHP equals lhp.MaLHP
                         join mon in db.MonHocs
                             on lhp.MaMon equals mon.MaMon
                         join d in db.Diems
                             on dk.MaDK equals d.MaDK
                             into bangDiem
                         from d in bangDiem.DefaultIfEmpty()

                         where dk.MaSV == maSV
                            && (maHK == null || lhp.MaHK == maHK)
                            && (!laGV || lhp.MaGV == maGV)

                         orderby mon.MaMon

                         select new BangDiemItemDTO
                         {
                             MaSV = sv.MaSV,
                             HoTen = sv.HoTen,
                             MaHK = lhp.MaHK,
                             MaLHP = lhp.MaLHP,
                             MaMon = mon.MaMon,
                             TenMon = mon.TenMon,
                             SoTinChi = mon.SoTinChi,

                             DiemCC = d == null ? null : d.DiemCC,
                             DiemGK = d == null ? null : d.DiemGK,
                             DiemCK = d == null ? null : d.DiemCK,
                             DiemTongKet = d == null
                                 ? null : d.DiemTongKet,
                             DiemChu = d == null
                                 ? null : d.DiemChu,
                             Diem4 = d == null ? null : d.Diem4
                         };

                return ds.ToList();
            }
        }
    }
}
