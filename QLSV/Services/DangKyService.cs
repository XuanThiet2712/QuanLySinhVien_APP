using QLSV.Data;
using QLSV.DTOs;
using QLSV.Helpers;
using QLSV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.Services
{
    public class DangKyService
    {
        public List<HocKy> GetHocKy()
        {
            using (var db = DbFactory.Create())
            {
                return new DangKyRepository(db).GetHocKy();
            }
        }

        public List<LopDangKyDTO> GetLopMo(string maHK)
        {
            using (var db = DbFactory.Create())
            {
                return new DangKyRepository(db).GetLopTheoHocKy(maHK);
            }
        }

        public List<LopDangKyDTO> GetDaDangKy(string maSV, string maHK)
        {
            if (string.IsNullOrWhiteSpace(maSV)) 
                return new List<LopDangKyDTO>();
            using (var db = DbFactory.Create())
            {
                return new DangKyRepository(db).GetDaDangKy(maSV.Trim(), maHK);
            }
        }
        // Phải có quyền DANG_KY
        private static string KiemTraQuyen(string maSV)
        {
            if (!SessionManager.HasPermission(MaChucNang.DANG_KY))
                return "Bạn không có quyền đăng ký học phần.";
            string svCuaToi = SessionManager.CurrentUser.MaSV;
            if (!string.IsNullOrEmpty(svCuaToi) && svCuaToi != maSV)
                return "Bạn chỉ được đăng ký cho chính mình.";
            return null;
        }

        // Hai lớp trùng lịch: cùng thứ và khoảng tiết giao nhau.
        private static bool TrungLich(LopDangKyDTO a, LopDangKyDTO b)
        {
            return a.Thu == b.Thu
                && a.TietBatDau <= b.TietKetThuc
                && b.TietBatDau <= a.TietKetThuc;
        }

        public Result DangKy(string maSV, List<string> dsMaLHP)
        {
            maSV = (maSV ?? "").Trim();
            if (maSV == "") return Result.Fail("Vui lòng nhập mã sinh viên.");
            string loiQuyen = KiemTraQuyen(maSV);
            if (loiQuyen != null) return Result.Fail(loiQuyen);
            if (dsMaLHP == null || dsMaLHP.Count == 0)
                return Result.Fail("Vui lòng chọn ít nhất một lớp học phần.");
            dsMaLHP = dsMaLHP.Distinct().ToList();

            try
            {
                using (var scope = new TransactionScope())
                using (var db = DbFactory.Create())
                {
                    var repo = new DangKyRepository(db);

                    if (!repo.ExistsSinhVien(maSV))
                        return Result.Fail("Không tìm thấy sinh viên " + maSV + ".");

                    List<LopDangKyDTO> lopMoi = repo.GetLop(dsMaLHP);
                    if (lopMoi.Count != dsMaLHP.Count)
                        return Result.Fail("Có lớp học phần không tồn tại.");
                    if (lopMoi.Select(l => l.MaHK).Distinct().Count() > 1)
                        return Result.Fail("Chỉ được đăng ký các lớp trong cùng một học kỳ mỗi lần.");

                    string maHK = lopMoi[0].MaHK;
                    List<LopDangKyDTO> daDK = repo.GetDaDangKy(maSV, maHK);

                    // Luật 1: chưa đăng ký lớp này, và chưa đăng ký môn này ở lớp khác
                    foreach (var l in lopMoi)
                    {
                        if (daDK.Any(x => x.MaLHP == l.MaLHP))
                            return Result.Fail("Bạn đã đăng ký lớp " + l.MaLHP + " rồi.");
                        if (daDK.Any(x => x.MaMon == l.MaMon) || lopMoi.Count(x => x.MaMon == l.MaMon) > 1)
                            return Result.Fail("Môn " + l.TenMon + " chỉ được đăng ký một lớp.");
                    }

                    // Luật 2: lớp còn chỗ
                    foreach (var l in lopMoi)
                    {
                        if (l.DaDangKy >= l.SiSoToiDa)
                            return Result.Fail("Lớp " + l.MaLHP + " (" + l.TenMon + ") đã đầy.");
                    }

                    // Luật 3: đã đạt môn tiên quyết (điểm tổng kết >= 4.0)
                    List<string> daDat = repo.GetMonDaDat(maSV);
                    List<MonTienQuyet> tienQuyet = repo.GetTienQuyet(lopMoi.Select(l => l.MaMon).ToList());
                    foreach (var l in lopMoi)
                    {
                        foreach (var t in tienQuyet.Where(x => x.MaMon == l.MaMon))
                        {
                            if (!daDat.Contains(t.MaMonTienQuyet))
                                return Result.Fail("Lớp " + l.MaLHP + " (" + l.TenMon + ") yêu cầu đã đạt môn "
                                    + repo.GetTenMon(t.MaMonTienQuyet) + ".");
                        }
                    }

                    // Luật 4: không trùng lịch (với lớp đã đăng ký và giữa các lớp mới)
                    var tatCa = daDK.Concat(lopMoi).ToList();
                    foreach (var moi in lopMoi)
                    {
                        foreach (var khac in tatCa.Where(x => x.MaLHP != moi.MaLHP))
                        {
                            if (TrungLich(moi, khac))
                                return Result.Fail("Lớp " + moi.MaLHP + " trùng lịch với lớp " + khac.MaLHP
                                    + " (" + khac.LichHoc + ").");
                        }
                    }

                    // Luật 5: tổng tín chỉ cả học kỳ từ 14 đến 25
                    int tong = tatCa.Sum(x => x.SoTinChi);
                    if (tong < GioiHanTinChi.ToiThieu || tong > GioiHanTinChi.ToiDa)
                        return Result.Fail("Tổng tín chỉ học kỳ phải từ " + GioiHanTinChi.ToiThieu + " đến "
                            + GioiHanTinChi.ToiDa + ". Sau lần đăng ký này bạn có " + tong + " tín chỉ.");

                    // Qua hết các luật: ghi tất cả, rồi xác nhận giao dịch
                    foreach (var l in lopMoi) repo.Add(maSV, l.MaLHP);
                    db.SubmitChanges();
                    scope.Complete();
                    return Result.Ok("Đăng ký thành công " + lopMoi.Count + " lớp. Tổng " + tong + " tín chỉ.");
                }
            }
            catch (Exception ex)
            {
                return Result.Fail("Lỗi CSDL: " + ex.Message);
            }
        }

        public Result Huy(string maSV, string maLHP)
        {
            maSV = (maSV ?? "").Trim();
            string loiQuyen = KiemTraQuyen(maSV);
            if (loiQuyen != null) return Result.Fail(loiQuyen);

            try
            {
                using (var db = DbFactory.Create())
                {
                    var repo = new DangKyRepository(db);
                    DangKyHocPhan dk = repo.Get(maSV, maLHP);
                    if (dk == null) return Result.Fail("Không tìm thấy lượt đăng ký này.");
                    if (repo.CoDiem(dk.MaDK))
                        return Result.Fail("Lớp đã có điểm, không thể hủy đăng ký.");

                    repo.Delete(dk);
                    db.SubmitChanges();
                    return Result.Ok("Đã hủy đăng ký lớp " + maLHP + ".");
                }
            }
            catch (Exception ex)
            {
                return Result.Fail("Lỗi CSDL: " + ex.Message);
            }
        }
    
    }
}
