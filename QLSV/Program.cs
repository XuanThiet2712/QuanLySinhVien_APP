using QLSV.Data;
using QLSV.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                using (QLSVDataContext db = DbFactory.Create())
                {
                    NguoiDung u = db.NguoiDungs.FirstOrDefault(x => x.TenDangNhap == "admin");
                    bool ok = u != null && PasswordHasher.Verify("123456", u.Salt, u.MatKhauHash);
                    int soSinhVien = db.SinhViens.Count();
                    MessageBox.Show(
                        ok ? "OK: kết nối được CSDL, mật khẩu admin khớp. Số sinh viên: " 
                        + soSinhVien : "LỖI: kết nối được nhưng không thấy admin hoặc mật khẩu không khớp",
                        "Kiểm tra khung dự án");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi kết nối");
            }
            Application.Run(new Form1());
        }
    }
}
