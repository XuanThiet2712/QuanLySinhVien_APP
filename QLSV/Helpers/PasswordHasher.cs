using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace QLSV.Helpers
{
    //Mã hóa mật khẩu bằng SHA-256 + Salt. KHÔNG lưu mật khẩu dạng chữ thường
    //   salt = Base64 của 16 byte ngẫu nhiên
    //   hash = Base64( SHA256( UTF8(matKhau + salt) ) ) Thiet
    public static class PasswordHasher
    {
        //Sinh salt ngẫu nhiên 16 byte, tra ve base64 , 24 ki tự
        public static string GenerateSalt()
        {
            byte[] bytes = new byte[16];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(bytes);
            }
            return Convert.ToBase64String(bytes);
        }

        //(mật khẩu + salt) bằng SHA-256, trả về Base64 ,,44 ki tự
        public static string Hash(string password, string salt)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] data = sha.ComputeHash(Encoding.UTF8.GetBytes(password + salt));
                return Convert.ToBase64String(data);
            }
        }

        // Kiem tra mat khau nguoi dung nhap co khop voi hash trong CSDL hay khong
        public static bool Verify(string password, string salt, string hash)
        {
            if (password == null || salt == null || hash == null)
            {
                return false;
            }
            return Hash(password, salt) == hash;
        }
        
    }
}