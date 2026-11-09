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
        private static readonly bool HienMucChuaCo = true;
        private static readonly string[] TatCaQuyen =
       {
            MaChucNang.QL_USER, MaChucNang.QL_ROLE, MaChucNang.CAU_HINH,
            MaChucNang.QL_KHOA, MaChucNang.QL_NGANH, MaChucNang.QL_LOP,
            MaChucNang.QL_SINHVIEN, MaChucNang.QL_GIANGVIEN, MaChucNang.QL_MONHOC,
            MaChucNang.QL_LOPHOCPHAN, MaChucNang.DANG_KY, MaChucNang.NHAP_DIEM,
            MaChucNang.XEM_DIEM, MaChucNang.THU_HOC_PHI, MaChucNang.THONG_KE
        };
        private readonly AuthService _auth = new AuthService();
        // nếu người dùng bấm đăng xuất thì mởl lại màng hình đăng nhập
        public bool DangXuat { get; private set; }
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //test
            var nd = SessionManager.CurrentUser;
            lblNguoiDung.Text = "Người dùng: " + nd.TenDangNhap + "   |   Nhóm quyền: " + nd.MaNhom;

            Gan(mnuDoiMatKhau, null, "QLSV.Forms.HeThong.frmChangePassword");
            Gan(mnuQuanLyNguoiDung, MaChucNang.QL_USER, "QLSV.Forms.HeThong.frmUserManagement");
            Gan(mnuPhanQuyen, MaChucNang.QL_ROLE, "QLSV.Forms.HeThong.frmRoleManagement");
            Gan(mnuCauHinh, MaChucNang.CAU_HINH, "QLSV.Forms.Finance.frmConnectionConfig");

            Gan(mnuKhoa, MaChucNang.QL_KHOA, "QLSV.Forms.Catalog.frmKhoa");
            Gan(mnuNganh, MaChucNang.QL_NGANH, "QLSV.Forms.Catalog.frmNganh");
            Gan(mnuLopSinhHoat, MaChucNang.QL_LOP, "QLSV.Forms.Catalog.frmLopSinhHoat");
            Gan(mnuSinhVien, MaChucNang.QL_SINHVIEN, "QLSV.Forms.Catalog.frmSinhVien");
            Gan(mnuGiangVien, MaChucNang.QL_GIANGVIEN, "QLSV.Forms.Catalog.frmGiangVien");
            Gan(mnuMonHoc, MaChucNang.QL_MONHOC, "QLSV.Forms.Catalog.frmMonHoc");

            Gan(mnuLopHocPhan, MaChucNang.QL_LOPHOCPHAN, "QLSV.Forms.Grade.frmLopHocPhan");
            Gan(mnuDangKyHocPhan, MaChucNang.DANG_KY, "QLSV.Forms.Enroll.frmDangKyHocPhan");
            Gan(mnuNhapDiem, MaChucNang.NHAP_DIEM, "QLSV.Forms.Grade.frmNhapDiem");

            Gan(mnuThuHocPhi, MaChucNang.THU_HOC_PHI, "QLSV.Forms.Finance.frmThuHocPhi");

            Gan(mnuBangDiem, MaChucNang.XEM_DIEM, "QLSV.Forms.Report.frmReportBangDiem");
            Gan(mnuBieuDo, MaChucNang.THONG_KE, "QLSV.Forms.Finance.frmChartDashboard");
            Gan(mnuBaoCaoDoanhThu, MaChucNang.THONG_KE, "QLSV.Forms.Report.frmReportThongKe");

            // Nhóm không còn mục nào hiện thì ẩn cả nhóm
            AnNhomRong(mnuDanhMuc);
            AnNhomRong(mnuHocVu);
            AnNhomRong(mnuTaiChinh);
            AnNhomRong(mnuBaoCao);
        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show(
                "Bạn muốn đăng xuất?", 
                "Xác nhận",
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question);
            if (res != DialogResult.Yes) return;

            _auth.DangXuat();
            DangXuat = true;
            Close();
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            DangXuat = false;
            Close();
        }

        private void mnuQuyenCuaToi_Click(object sender, EventArgs e)
        {
            string[] co = typeof(MaChucNang).GetFields()
              .Select(f => (string)f.GetRawConstantValue())
              .Where(q => SessionManager.HasPermission(q))
              .ToArray();

            MessageBox.Show(
                "Nhóm: " + SessionManager.CurrentUser.MaNhom 
                + "\r\nSố quyền: " + co.Length 
                
                + "\r\n\r\n" + string.Join("\r\n", co),
                "Quyền của tôi", 
                MessageBoxButtons.OK, 
                MessageBoxIcon.Information);
        }

        private void Gan(ToolStripMenuItem muc, string maQuyen, string tenForm)
        {
            bool coQuyen = maQuyen == null || SessionManager.HasPermission(maQuyen);
            bool coForm = TimKieuForm(tenForm) != null;

            muc.Available = coQuyen;    // không có quyền: ẩn mục
            muc.Enabled = coForm;       // chưa có form: mục xám, không bấm được
            if (!coForm) muc.Text += " (chưa có)";

            muc.Click += (s, ev) => MoForm(tenForm);
        }

        private static void AnNhomRong(ToolStripMenuItem nhom)
        {
            nhom.Available = nhom.DropDownItems.Cast<ToolStripItem>().Any(m => m.Available);
        }
        private static Type TimKieuForm(string tenDayDu)
        {
            Type t = typeof(frmMain).Assembly.GetType(tenDayDu);
            return (t != null && typeof(Form).IsAssignableFrom(t)) ? t : null;
        }

        private void MoForm(string tenDayDu)
        {
            // Đang mở rồi thì đưa lên trước, không mở thêm cái nữa
            foreach (Form f in MdiChildren)
            {
                if (f.GetType().FullName == tenDayDu) { f.Activate(); return; }
            }

            try
            {
                var form = (Form)Activator.CreateInstance(TimKieuForm(tenDayDu));
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
               
                // lỗi thật nằm trong InnerException
                MessageBox.Show("Không mở được form: " + ex.Message, 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
