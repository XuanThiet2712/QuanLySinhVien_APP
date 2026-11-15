using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using QLSV.Data;
using QLSV.Helpers;
using QLSV.Repositories;

namespace QLSV.Services
{
    public class OtpService
    {
        private class OtpInfo
        {
            public string Ma;
            public DateTime HetHan;
            public int SoLanSai;
        }

        // Mã OTP giữ trong bộ nhớ của app (đủ cho ứng dụng desktop một máy).
        private static readonly Dictionary<string, OtpInfo> _otp = new Dictionary<string, OtpInfo>();
        private const int PhutHieuLuc = 5;
        private const int SoLanSaiToiDa = 5;

        public Result GuiOtp(string tenDangNhap)
        {
            tenDangNhap = (tenDangNhap ?? "").Trim();
            if (tenDangNhap == "") return Result.Fail("Vui lòng nhập tên đăng nhập.");

            try
            {
                string email;
                using (var db = DbFactory.Create())
                {
                    var repo = new NguoiDungRepository(db);
                    NguoiDung u = repo.GetByUsername(tenDangNhap);
                    email = (u == null || !u.TrangThai) ? null : repo.GetEmail(u.MaSV, u.MaGV);
                }
                if (string.IsNullOrWhiteSpace(email))
                    return Result.Fail("Không gửi được mã: tên đăng nhập không đúng hoặc tài khoản chưa có email.");

                string ma = TaoMa();
                Result kq = new EmailService().Gui(email, "Mã xác nhận đặt lại mật khẩu",
                    "Mã OTP của bạn là: " + ma + "\nMã có hiệu lực " + PhutHieuLuc
                    + " phút. Nếu không phải bạn yêu cầu, hãy bỏ qua email này.");
                if (!kq.Success) return kq;

                lock (_otp)
                {
                    _otp[tenDangNhap.ToLower()] = new OtpInfo { Ma = ma, HetHan = DateTime.Now.AddMinutes(PhutHieuLuc) };
                }
                return Result.Ok("Đã gửi mã tới " + AnEmail(email) + ".");
            }
            catch (Exception ex)
            {
                return Result.Fail("Lỗi: " + ex.Message);
            }
        }

        public Result DatLaiMatKhau(string tenDangNhap, string otp, string matKhauMoi)
        {
            tenDangNhap = (tenDangNhap ?? "").Trim();
            string key = tenDangNhap.ToLower();
            if (matKhauMoi == null || matKhauMoi.Length < TaiKhoan.DoDaiMatKhauToiThieu)
                return Result.Fail("Mật khẩu mới phải có ít nhất " + TaiKhoan.DoDaiMatKhauToiThieu + " ký tự.");

            lock (_otp)
            {
                OtpInfo info;
                if (!_otp.TryGetValue(key, out info))
                    return Result.Fail("Chưa có mã OTP. Hãy bấm Gửi mã trước.");
                if (DateTime.Now > info.HetHan)
                {
                    _otp.Remove(key);
                    return Result.Fail("Mã đã hết hạn, hãy gửi mã mới.");
                }
                if (info.Ma != (otp ?? "").Trim())
                {
                    info.SoLanSai++;
                    if (info.SoLanSai >= SoLanSaiToiDa)
                    {
                        _otp.Remove(key);
                        return Result.Fail("Nhập sai quá nhiều lần. Hãy gửi mã mới.");
                    }
                    return Result.Fail("Mã OTP không đúng.");
                }
            }

            try
            {
                using (var db = DbFactory.Create())
                {
                    NguoiDung user = new NguoiDungRepository(db).GetByUsername(tenDangNhap);
                    if (user == null) return Result.Fail("Không tìm thấy tài khoản.");
                    user.Salt = PasswordHasher.GenerateSalt();
                    user.MatKhauHash = PasswordHasher.Hash(matKhauMoi, user.Salt);
                    db.SubmitChanges();
                }
                lock (_otp) { _otp.Remove(key); }
                return Result.Ok("Đã đặt lại mật khẩu. Hãy đăng nhập bằng mật khẩu mới.");
            }
            catch (Exception ex)
            {
                return Result.Fail("Lỗi CSDL: " + ex.Message);
            }
        }

        private static string TaoMa()
        {
            byte[] b = new byte[4];
            using (var rng = new RNGCryptoServiceProvider()) rng.GetBytes(b);
            return (BitConverter.ToUInt32(b, 0) % 1000000).ToString("D6");
        }

        // abc@gmail.com -> a***@gmail.com
        private static string AnEmail(string email)
        {
            int at = email.IndexOf('@');
            return at < 2 ? email : email.Substring(0, 1) + "***" + email.Substring(at);
        }
    }
}