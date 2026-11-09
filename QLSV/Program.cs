using QLSV.Data;
using QLSV.Forms.Finance;
using QLSV.Forms.HeThong;
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
        /*static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 1. Giả lập đăng nhập để bật full quyền (không bị ẩn nút Lưu/Xóa)
            SessionManager.Login(
                new NguoiDung { MaND = 1, TenDangNhap = "pdt01", MaNhom = "PDT" },
                new List<string> { MaChucNang.QL_KHOA }
            );

            // 2. Chạy trực tiếp frmKhoa làm màn hình chính
            Application.Run(new frmKhoa());
        }*/
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 1. Giả lập đăng nhập để bật full quyền (không bị ẩn nút Lưu/Xóa)
            SessionManager.Login(
                new NguoiDung { MaND = 1, TenDangNhap = "pdt01", MaNhom = "PDT" },
                new List<string> { MaChucNang.QL_KHOA }
            );

            // 2. Chạy trực tiếp frmKhoa làm màn hình chính
            Application.Run(new frmKhoa());
        }
        /*static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            while (true)
            {

                using (var login = new frmLogin())
                {
                    if (login.ShowDialog() != DialogResult.OK) return;
                }

                var main = new frmMain();
                Application.Run(main);

                if (!main.DangXuat) return;   
            }*/




    }
}
