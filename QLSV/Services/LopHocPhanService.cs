using QLSV.Data;
using QLSV.DTOs;
using QLSV.Helpers;
using QLSV.Repositories;
using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.Services
{
    public class LopHocPhanService
    {
        //ktra trungtiet
        private bool TrungTiet(LopHocPhan a, LopHocPhan b)
        {
            if (a.Thu != b.Thu)
                return false;
            int aBatDau = a.TietBatDau;
            int aKetThuc = aBatDau + a.SoTiet - 1;

            int bBatDau = b.TietBatDau;
            int bKetThuc = bBatDau + b.SoTiet - 1;

            return aBatDau <= bKetThuc && bBatDau <= aKetThuc;
        }
        //lay lhp loc
        public List<LopHocPhanDTO> Search(string MaHK, string MaMon, string MaGV)
        {
            using (var db = DbFactory.Create())
            {
                var repo = new LopHocPhanRepository(db);
                return repo.Search(MaHK, MaMon, MaGV);
            }
        }
        //lay dshk
        public List<HocKy> GetHocKys()
        {
            using (var db = DbFactory.Create())
            {
                var repo = new LopHocPhanRepository(db);
                return repo.GetHocKys();
            }
        }
        //lay ds monhoc
        public List<MonHoc> GetMonHocs()
        {
            using (var db = DbFactory.Create())
            {
                var repo = new LopHocPhanRepository(db);
                return repo.GetMonHocs();
            }
        }
        //lay ds gv
        public List<GiangVien> GetGiangViens()
        {
            using (var db = DbFactory.Create())
            {
                var repo = new LopHocPhanRepository(db);
                return repo.GetGiangViens();
            }
        }
        private Result KiemTra (LopHocPhan lhp)
        {
            if (lhp == null)
                return Result.Fail("Dữ liệu không hợp lệ.");

            if (string.IsNullOrWhiteSpace(lhp.MaLHP))
                return Result.Fail("Chưa nhập mã lớp.");

            if (lhp.MaLHP.Length > 20)
                return Result.Fail("Mã lớp quá 20 ký tự.");

            if (string.IsNullOrWhiteSpace(lhp.MaMon))
                return Result.Fail("Chưa chọn môn học.");

            if (string.IsNullOrWhiteSpace(lhp.MaGV))
                return Result.Fail("Chưa chọn giảng viên.");

            if (string.IsNullOrWhiteSpace(lhp.MaHK))
                return Result.Fail("Chưa chọn học kỳ.");

            if (string.IsNullOrWhiteSpace(lhp.Phong))
                return Result.Fail("Chưa nhập phòng học.");

            if (lhp.Phong.Length > 20)
                return Result.Fail("Tên phòng quá 20 ký tự.");

            if (lhp.SiSoToiDa <= 0)
                return Result.Fail("Sĩ số phải lớn hơn 0.");

            if (lhp.Thu < 2 || lhp.Thu > 8)
                return Result.Fail("Thứ không hợp lệ.");

            if (lhp.TietBatDau < 1 ||
                lhp.TietBatDau > 12 ||
                lhp.SoTiet < 1 || lhp.SoTiet > 6 ||
                lhp.TietBatDau + lhp.SoTiet - 1 > 12)
                return Result.Fail("Tiết học không hợp lệ.");

            return Result.Ok();
        }
        private Result KiemTraTrungLich(LopHocPhan lhp, LopHocPhanRepository repo)
        {
            //lop ton tai cung hk
            var ds = repo.GetByHocky(lhp.MaHK);
            foreach (LopHocPhan x in ds)
            {
                if (x.MaLHP == lhp.MaLHP) continue; //bo qua lop cap nhat
                if (!TrungTiet(lhp, x)) continue; //khac time => kh trung
                if (lhp.MaGV == x.MaGV)
                    return Result.Fail("Giảng viên đã có lịch dạy trùng"); //khong day 2 lop 1h
                if (string.Equals(lhp.Phong.Trim(), (x.Phong ?? "").Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    return Result.Fail("Phòng Học đã có lớp trùng lịch");
                }
            }
            return Result.Ok();
        }

        public Result ThemMoi(LopHocPhan lhp)
        {
            Result kt = KiemTra(lhp);
            if (!kt.Success) return kt;

            if (!SessionManager.HasPermission(
                MaChucNang.QL_LOPHOCPHAN))
                return Result.Fail("Không có quyền thêm lớp.");

            try
            {
                using (var db = DbFactory.Create())
                {
                    var repo = new LopHocPhanRepository(db);

                    // 0 dc trung malop
                    if (repo.GetById(lhp.MaLHP) != null)
                        return Result.Fail("Mã lớp đã tồn tại.");

                    // 0 dc trung lich
                    kt = KiemTraTrungLich(lhp, repo);
                    if (!kt.Success) return kt;

                    repo.Add(lhp);
                    db.SubmitChanges();

                    return Result.Ok("Thêm lớp thành công.");
                }
            }
            catch (Exception ex)
            {
                return Result.Fail("Lỗi: " + ex.Message);
            }
        }

        public Result Luu(LopHocPhan lhp)
        {
            Result kt = KiemTra(lhp);
            if (!kt.Success) return kt;

            if (!SessionManager.HasPermission(
                MaChucNang.QL_LOPHOCPHAN))
                return Result.Fail("Không có quyền sửa lớp.");

            try
            {
                using (var db = DbFactory.Create())
                {
                    var repo = new LopHocPhanRepository(db);

                    LopHocPhan cu = repo.GetById(lhp.MaLHP);
                    if (cu == null)
                        return Result.Fail("Không tìm thấy lớp.");

                    if (lhp.SiSoToiDa <
                        repo.GetSiSoHienTai(lhp.MaLHP))
                        return Result.Fail(
                            "Sĩ số tối đa nhỏ hơn số SV đã đăng ký.");

                    kt = KiemTraTrungLich(lhp, repo);
                    if (!kt.Success) return kt;

                    repo.Update(cu, lhp);
                    db.SubmitChanges();

                    return Result.Ok("Cập nhật thành công.");
                }
            }
            catch (Exception ex)
            {
                return Result.Fail("Lỗi: " + ex.Message);
            }
        }

        public Result Xoa(string maLHP)
        {
            if (!SessionManager.HasPermission(
                MaChucNang.QL_LOPHOCPHAN))
                return Result.Fail("Không có quyền xóa lớp.");

            try
            {
                using (var db = DbFactory.Create())
                {
                    var repo = new LopHocPhanRepository(db);

                    LopHocPhan lhp = repo.GetById(maLHP);

                    if (lhp == null)
                        return Result.Fail("Không tìm thấy lớp.");

                    if (repo.GetSiSoHienTai(maLHP) > 0)
                        return Result.Fail(
                            "Lớp đã có sinh viên đăng ký.");

                    repo.Delete(lhp);
                    db.SubmitChanges();

                    return Result.Ok("Xóa thành công.");
                }
            }
            catch (Exception ex)
            {
                return Result.Fail("Lỗi: " + ex.Message);
            }
        }
    }
}
