using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace QLSV.Helpers
{
    public static class PasswordHasher
    {
        public static string GenerateSalt()
        {
            byte[] bytes = new byte[16];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(bytes);
            }
            return Convert.ToBase64String(bytes);
        }

        //mật khẩu + salt bằng SHA-256, trả về Base64 ,,44 ki tự
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