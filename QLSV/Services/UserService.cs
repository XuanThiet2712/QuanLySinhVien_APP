using QLSV.Data;
using QLSV.Helpers;
using QLSV.DTOs;
using QLSV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace QLSV.Services
{
    public class UserService
    {
        public List<NguoiDungDTO> GetAll(string keyword)
        {
            using (var db = DbFactory.Create())
            {
                return new NguoiDungRepository(db).Search(keyword);
            }
        }
        private static string KiemTraQuyen()
        {
            return SessionManager.HasPermission(MaChucNang.QL_USER)
                ? null : "Bạn không có quyền quản lý người dùng.";
        }

        public Result Tao(string tenDangNhap, string maNhom, string doiTuong)
        {
            string loi = KiemTraQuyen();
            if (loi != null) return Result.Fail(loi);

            tenDangNhap = (tenDangNhap ?? "").Trim();
            doiTuong = (doiTuong ?? "").Trim();
            if (tenDangNhap.Length < 3 || tenDangNhap.Contains(" "))
                return Result.Fail("Tên đăng nhập phải từ 3 ký tự và không có khoảng trắng.");
            if (string.IsNullOrEmpty(maNhom)) return Result.Fail("Vui lòng chọn nhóm quyền.");

            try
            {
                using (var db = DbFactory.Create())
                {
                    var repo = new NguoiDungRepository(db);
                    if (!new NhomQuyenRepository(db).ExistsNhom(maNhom)) return Result.Fail("Nhóm quyền không tồn tại.");
                    if (repo.ExistsUsername(tenDangNhap)) return Result.Fail("Tên đăng nhập đã tồn tại.");

                    var user = new NguoiDung { TenDangNhap = tenDangNhap, MaNhom = maNhom, TrangThai = true };
                    string loiDoiTuong = GanDoiTuong(repo, user, maNhom, doiTuong);
                    if (loiDoiTuong != null) return Result.Fail(loiDoiTuong);

                    user.Salt = PasswordHasher.GenerateSalt();
                    user.MatKhauHash = PasswordHasher.Hash(TaiKhoan.MatKhauMacDinh, user.Salt);
                    repo.Add(user);
                    db.SubmitChanges();
                    return Result.Ok("Đã tạo tài khoản. Mật khẩu mặc định: " + TaiKhoan.MatKhauMacDinh);
                }
            }
            catch (Exception ex)
            {
                return Result.Fail("Lỗi CSDL: " + ex.Message);
            }
        }

        public Result CapNhat(int maND, string maNhom, string doiTuong)
        {
            string loi = KiemTraQuyen();
            if (loi != null) return Result.Fail(loi);
            if (maND == SessionManager.CurrentUser.MaND && maNhom != SessionManager.CurrentUser.MaNhom)
                return Result.Fail("Không thể đổi nhóm quyền của chính tài khoản đang đăng nhập.");

            try
            {
                using (var db = DbFactory.Create())
                {
                    var repo = new NguoiDungRepository(db);
                    NguoiDung user = repo.GetById(maND);
                    if (user == null) return Result.Fail("Không tìm thấy người dùng.");
                    if (!new NhomQuyenRepository(db).ExistsNhom(maNhom)) return Result.Fail("Nhóm quyền không tồn tại.");

                    user.MaNhom = maNhom;
                    string loiDoiTuong = GanDoiTuong(repo, user, maNhom, (doiTuong ?? "").Trim());
                    if (loiDoiTuong != null) return Result.Fail(loiDoiTuong);

                    db.SubmitChanges();
                    return Result.Ok("Đã cập nhật. Người dùng cần đăng nhập lại để áp dụng quyền mới.");
                }
            }
            catch (Exception ex)
            {
                return Result.Fail("Lỗi CSDL: " + ex.Message);
            }
        }

        public Result DatTrangThai(int maND, bool hoatDong)
        {
            string loi = KiemTraQuyen();
            if (loi != null) return Result.Fail(loi);
            if (!hoatDong && maND == SessionManager.CurrentUser.MaND)
                return Result.Fail("Không thể khóa chính tài khoản đang đăng nhập.");

            try
            {
                using (var db = DbFactory.Create())
                {
                    NguoiDung user = new NguoiDungRepository(db).GetById(maND);
                    if (user == null) return Result.Fail("Không tìm thấy người dùng.");
                    user.TrangThai = hoatDong;
                    db.SubmitChanges();
                    return Result.Ok(hoatDong ? "Đã mở khóa tài khoản." : "Đã khóa tài khoản.");
                }
            }
            catch (Exception ex)
            {
                return Result.Fail("Lỗi CSDL: " + ex.Message);
            }
        }

        public Result Xoa(int maND)
        {
            string loi = KiemTraQuyen();
            if (loi != null) return Result.Fail(loi);
            if (maND == SessionManager.CurrentUser.MaND)
                return Result.Fail("Không thể xóa chính tài khoản đang đăng nhập.");

            try
            {
                using (var db = DbFactory.Create())
                {
                    var repo = new NguoiDungRepository(db);
                    if (repo.GetById(maND) == null) return Result.Fail("Không tìm thấy người dùng.");
                    if (repo.CoPhatSinhDuLieu(maND))
                        return Result.Fail("Tài khoản này đã nhập điểm hoặc lập phiếu thu, chỉ có thể khóa chứ không xóa.");

                    repo.Delete(maND);
                    db.SubmitChanges();
                    return Result.Ok("Đã xóa tài khoản.");
                }
            }
            catch (Exception ex)
            {
                return Result.Fail("Lỗi CSDL: " + ex.Message);
            }
        }

        // Nhóm SV bắt buộc có mã SV, nhóm GV bắt buộc có mã GV, nhóm khác phải để trống.
        // Trả về thông báo lỗi, hoặc null nếu hợp lệ.
        private static string GanDoiTuong(NguoiDungRepository repo, NguoiDung user, string maNhom, string doiTuong)
        {
            user.MaSV = null;
            user.MaGV = null;

            if (maNhom == MaNhom.SV)
            {
                if (doiTuong == "") return "Nhóm SV phải nhập mã sinh viên.";
                if (repo.GetSinhVien(doiTuong) == null) return "Không tìm thấy sinh viên " + doiTuong + ".";
                NguoiDung tk = repo.GetByMaSV(doiTuong);
                if (tk != null && tk.MaND != user.MaND) return "Sinh viên này đã có tài khoản.";
                user.MaSV = doiTuong;
            }
            else if (maNhom == MaNhom.GV)
            {
                if (doiTuong == "") return "Nhóm GV phải nhập mã giảng viên.";
                if (!repo.GiangVienTonTai(doiTuong)) return "Không tìm thấy giảng viên " + doiTuong + ".";
                NguoiDung tk = repo.GetByMaGV(doiTuong);
                if (tk != null && tk.MaND != user.MaND) return "Giảng viên này đã có tài khoản.";
                user.MaGV = doiTuong;
            }
            else if (doiTuong != "")
            {
                return "Nhóm " + maNhom + " không gắn với sinh viên hay giảng viên, hãy để trống ô này.";
            }
            return null;
        }

    }
}
