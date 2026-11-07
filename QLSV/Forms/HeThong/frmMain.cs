using QLSV.Helpers;
using QLSV.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV.Forms.HeThong
{
    public partial class frmMain : Form
    {
        private readonly AuthService _auth = new AuthService();
        // nếu người dùng bấm đăng xuất thì mởl lại màng hình đăng nhập
        public bool DangXuat { get; private set; }
        public frmMain()
        {
            InitializeComponent();
            Text = "Quản lý sinh viên";
            WindowState = FormWindowState.Maximized;
            Load += frmMain_Load;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //test
            var nd = SessionManager.CurrentUser;
            string[] tatCa =
            {
                MaChucNang.QL_USER, MaChucNang.QL_ROLE, MaChucNang.CAU_HINH,
                MaChucNang.QL_KHOA, MaChucNang.QL_NGANH, MaChucNang.QL_LOP,
                MaChucNang.QL_SINHVIEN, MaChucNang.QL_GIANGVIEN, MaChucNang.QL_MONHOC,
                MaChucNang.QL_LOPHOCPHAN, MaChucNang.DANG_KY, MaChucNang.NHAP_DIEM,
                MaChucNang.XEM_DIEM, MaChucNang.THU_HOC_PHI, MaChucNang.THONG_KE
            };
            string[] co = tatCa.Where(SessionManager.HasPermission).ToArray();

            var lbl = new Label
            {
                AutoSize = true,
                MaximumSize = new Size(900, 0),
                Font = new Font("Segoe UI", 12),
                Location = new Point(20, 50),
                Text = "Xin chào, " + nd.TenDangNhap + "  (nhóm " + nd.MaNhom + ")\r\n\r\n"
                     + "Quyền (" + co.Length + "): " + string.Join(", ", co)
            };
            Controls.Add(lbl);

            TaoMenu();
        }

        private void TaoMenu()
        {
            var heThong = new ToolStripMenuItem("Hệ thống");
            heThong.DropDownItems.Add(new ToolStripMenuItem("Đăng xuất", null, (s, e) =>
            {
                _auth.DangXuat();
                DangXuat = true;
                Close();
            }));
            heThong.DropDownItems.Add(new ToolStripMenuItem("Thoát", null, (s, e) =>
            {
                DangXuat = false;
                Close();
            }));

            var menu = new MenuStrip();
            menu.Items.Add(heThong);
            MainMenuStrip = menu;
            Controls.Add(menu);
        }
    }
}
