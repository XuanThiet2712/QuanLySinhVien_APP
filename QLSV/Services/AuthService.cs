using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
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
                using (var db = DbFactory.Create())
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
    }
}
