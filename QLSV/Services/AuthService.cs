using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLSV.Data;
using QLSV.Helpers;
using QLSV.Repositories;

namespace QLSV.Services
{
    //Đăng nhập, đăng xuất, đổi/reset mật khẩu, tự đăng ký tài khoản sinh viên
    public class AuthService
    {
        /// Đăng nhập
        public Result<NguoiDung> DangNhap(string tenDangNhap, string matKhau)
        {
            if (string.IsNullOrWhiteSpace(tenDangNhap) || string.IsNullOrEmpty(matKhau))
                return Result<NguoiDung>.Fail("Vui lòng nhập tên đăng nhập và mật khẩu.");
            try
            {
                using (var db = DbFactory.Create())
                {
                    NguoiDung user = new NguoiDungRepository(db).GetByUsername(tenDangNhap.Trim());

                    if (user == null || !PasswordHasher.Verify(matKhau, user.Salt, user.MatKhauHash))
                        return Result<NguoiDung>.Fail("Sai tên đăng nhập hoặc mật khẩu.");

                    if (!user.TrangThai)
                        return Result<NguoiDung>.Fail("Tài khoản đã bị khóa hoặc chưa được duyệt. Liên hệ quản trị viên.");

                    List<string> dsQuyen = new PhanQuyenRepository(db).GetMaChucNangByNhom(user.MaNhom);
                    SessionManager.Login(user, dsQuyen);
                    return Result<NguoiDung>.Ok(user, "Đăng nhập thành công.");
                }
            }
            catch (Exception ex)
            {
                return Result<NguoiDung>.Fail("Lỗi kết nối CSDL: " + ex.Message);
            }
        }

        //Đăng xuất, xóa session
        public void DangXuat()
        {
            SessionManager.Logout();
        }

        //Đổi mật khẩu kiểm tra mật khẩu cũ
        public Result DoiMatKhau(string tenDangNhap, string matKhauCu, string matKhauMoi)
        {
            if (string.IsNullOrEmpty(matKhauCu) || string.IsNullOrEmpty(matKhauMoi))
                return Result.Fail("Vui lòng nhập đủ mật khẩu cũ và mật khẩu mới");
            if (matKhauMoi.Length < TaiKhoan.DoDaiMatKhauToiThieu)
                return Result.Fail("Mat khau moi phai co it nhat " + TaiKhoan.DoDaiMatKhauToiThieu + " ký tự.");
            if (matKhauMoi == matKhauCu)
                return Result.Fail("Mat khau moi phai khac mat khau cu");

            try
            {
                using (QLSVDataContext db = DbFactory.Create())
                {
                    NguoiDung user = new NguoiDungRepository(db).GetByUsername(tenDangNhap);
                    if (user == null || !PasswordHasher.Verify(matKhauCu, user.Salt, user.MatKhauHash))
                        return Result.Fail("Mat khau cu ko dung");

                    user.Salt = PasswordHasher.GenerateSalt();
                    user.MatKhauHash = PasswordHasher.Hash(matKhauMoi, user.Salt);
                    db.SubmitChanges();
                    return Result.Ok("Doi mk thanh cog");
                }
            }
            catch (Exception ex)
            {
                return Result.Fail("Lỗi CSDL: " + ex.Message);
            }
        }

        /// Dat lai mk mac dinh, chi nguoi co quyen QL_USER moi lam duoc , admin ay
        public Result ResetMatKhau(int maND)
        {
            if (!SessionManager.HasPermission(MaChucNang.QL_USER))
                return Result.Fail("Ban ko co quyen dat lai mk");

            try
            {
                using (var db = DbFactory.Create())
                {
                    NguoiDung user = new NguoiDungRepository(db).GetById(maND);
                    if (user == null) return Result.Fail("ko tim thay nguoi dung");

                    user.Salt = PasswordHasher.GenerateSalt();
                    user.MatKhauHash = PasswordHasher.Hash(TaiKhoan.MatKhauMacDinh, user.Salt);
                    db.SubmitChanges();
                    return Result.Ok("Đã đặt lại mật khẩu về " + TaiKhoan.MatKhauMacDinh );
                }
            }
            catch (Exception ex)
            {
                return Result.Fail("Lỗi CSDL: " + ex.Message);
            }
        }

        // Sinh viên tự tạo tài khoản
        // Phải nhập đúng mã sinh viên và ngày sinh trùng với dữ liệu trong bảng SinhVien
        public Result DangKyTaiKhoan(string maSV, DateTime ngaySinh, string tenDangNhap, string matKhau)
        {
            if (string.IsNullOrWhiteSpace(maSV) || string.IsNullOrWhiteSpace(tenDangNhap) || string.IsNullOrEmpty(matKhau))
                return Result.Fail("Vui lòng nhập đủ mã sinh viên, tên đăng nhập và mật khẩu");

            maSV = maSV.Trim();
            tenDangNhap = tenDangNhap.Trim();

            if (tenDangNhap.Length < 4 || tenDangNhap.Contains(" "))
                return Result.Fail("Tên đăng nhập phải từ 4 ký tự và không có khoảng trắng");
            if (matKhau.Length < TaiKhoan.DoDaiMatKhauToiThieu)
                return Result.Fail("Mật khẩu phải có ít nhất " + TaiKhoan.DoDaiMatKhauToiThieu + " ký tự");

            try
            {
                using (var db = DbFactory.Create())
                {
                    var repo = new NguoiDungRepository(db);

                    SinhVien sv = repo.GetSinhVien(maSV);
                   
                    if (sv == null || sv.NgaySinh.Date != ngaySinh.Date)
                        return Result.Fail("Mã sinh viên hoặc ngày sinh không đúng");
                    if (repo.ExistsMaSV(maSV))
                        return Result.Fail("Sinh viên này đã có tài khoản");
                    if (repo.ExistsUsername(tenDangNhap))
                        return Result.Fail("Tên đăng nhập đã được dùng, hãy chọn tên khác");

                    string salt = PasswordHasher.GenerateSalt();
                    repo.Add(new NguoiDung
                    {
                        TenDangNhap = tenDangNhap,
                        Salt = salt,
                        MatKhauHash = PasswordHasher.Hash(matKhau, salt),
                        MaNhom = MaNhom.SV,
                        MaSV = maSV,
                        TrangThai = true   
                        // đổi thành false nếu muốn Admin duyệt trước khi dùng
                    });
                    db.SubmitChanges();
                    return Result.Ok("Tạo tài khoản thành công. Bạn có thể đăng nhập.");
                }
            }
            catch (Exception ex)
            {
                return Result.Fail("Lỗi CSDL: " + ex.Message);
            }
        }
    }
}

