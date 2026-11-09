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

//using QLSV.Forms.Catalog;     // frmKhoa, frmNganh... (B)
//using QLSV.Forms.Grade;       // frmLopHocPhan, frmNhapDiem (C)
//using QLSV.Forms.Enroll;      // frmDangKyHocPhan (A)
using QLSV.Forms.Finance;     // frmThuHocPhi, frmChartDashboard, frmConnectionConfig (D)
//using QLSV.Forms.Report;      // frmReportBangDiem, frmReportThongKe

namespace QLSV.Forms.HeThong
{
    public partial class frmMain : Form
    {
        AuthService _auth = new AuthService();
        public bool DangXuat { get; private set; } = false;
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //test
            var nd = SessionManager.CurrentUser;
            lblNguoiDung.Text = "Người dùng: " + nd.TenDangNhap + "   |   Nhóm quyền: " + nd.MaNhom;

            PhanQuyenMenu();
        }

        private void PhanQuyenMenu()
        {
            // Nhóm Hệ thống
            mnuQuanLyNguoiDung.Visible = SessionManager.HasPermission(MaChucNang.QL_USER);
            mnuPhanQuyen.Visible = SessionManager.HasPermission(MaChucNang.QL_ROLE);
            mnuCauHinh.Visible = SessionManager.HasPermission(MaChucNang.CAU_HINH);

            // Nhóm Danh mục
            mnuKhoa.Visible = SessionManager.HasPermission(MaChucNang.QL_KHOA);
            mnuNganh.Visible = SessionManager.HasPermission(MaChucNang.QL_NGANH);
            mnuLopSinhHoat.Visible = SessionManager.HasPermission(MaChucNang.QL_LOP);
            mnuSinhVien.Visible = SessionManager.HasPermission(MaChucNang.QL_SINHVIEN);
            mnuGiangVien.Visible = SessionManager.HasPermission(MaChucNang.QL_GIANGVIEN);
            mnuMonHoc.Visible = SessionManager.HasPermission(MaChucNang.QL_MONHOC);

            // Nhóm Học vụ
            mnuLopHocPhan.Visible = SessionManager.HasPermission(MaChucNang.QL_LOPHOCPHAN);
            mnuDangKyHocPhan.Visible = SessionManager.HasPermission(MaChucNang.DANG_KY);
            mnuNhapDiem.Visible = SessionManager.HasPermission(MaChucNang.NHAP_DIEM);

            // Nhóm Tài chính
            mnuThuHocPhi.Visible = SessionManager.HasPermission(MaChucNang.THU_HOC_PHI);

            // Nhóm Báo cáo
            mnuBangDiem.Visible = SessionManager.HasPermission(MaChucNang.XEM_DIEM);
            mnuBieuDo.Visible = SessionManager.HasPermission(MaChucNang.THONG_KE);
            mnuBaoCaoDoanhThu.Visible = SessionManager.HasPermission(MaChucNang.THONG_KE);

            //Ẩn cả nhóm nếu không còn mục con nào hiện

           mnuDanhMuc.Visible = mnuKhoa.Visible || mnuNganh.Visible
               || mnuLopSinhHoat.Visible || mnuSinhVien.Visible
               || mnuGiangVien.Visible || mnuMonHoc.Visible;

            mnuHocVu.Visible = mnuLopHocPhan.Visible || mnuDangKyHocPhan.Visible
                || mnuNhapDiem.Visible;

            mnuTaiChinh.Visible = mnuThuHocPhi.Visible;

            mnuBaoCao.Visible = mnuBangDiem.Visible || mnuBieuDo.Visible
                || mnuBaoCaoDoanhThu.Visible;
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

   

        private void mnuDoiMatKhau_Click(object sender, EventArgs e)
        {

        }

        private void mnuQuanLyNguoiDung_Click(object sender, EventArgs e)
        {

        }

        private void mnuPhanQuyen_Click(object sender, EventArgs e)
        {

        }

        private void mnuCauHinh_Click(object sender, EventArgs e)
        {
            foreach (Form f in MdiChildren)
            {
                if (f is frmConnectionConfig) { f.Activate(); return; }
            }
            frmConnectionConfig frm = new frmConnectionConfig();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            this.Height = frm.Height + 100;
            this.Width = frm.Width + 100;
            frm.Show();
        }

        private void mnuKhoa_Click(object sender, EventArgs e)
        {

        }

        private void mnuNganh_Click(object sender, EventArgs e)
        {

        }

        private void mnuLopSinhHoat_Click(object sender, EventArgs e)
        {

        }

        private void mnuSinhVien_Click(object sender, EventArgs e)
        {

        }

        private void mnuGiangVien_Click(object sender, EventArgs e)
        {

        }

        private void mnuMonHoc_Click(object sender, EventArgs e)
        {

        }

        private void mnuLopHocPhan_Click(object sender, EventArgs e)
        {

        }

        private void mnuDangKyHocPhan_Click(object sender, EventArgs e)
        {

        }

        private void mnuNhapDiem_Click(object sender, EventArgs e)
        {

        }

        private void mnuThuHocPhi_Click(object sender, EventArgs e)
        {
            foreach (Form f in MdiChildren)
            {
                if (f is FrmThuHocPhi) { f.Activate(); return; }
            }
            FrmThuHocPhi frm = new FrmThuHocPhi();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            this.Height = frm.Height + 100; 
            this.Width = frm.Width + 100;
            frm.Show();
        }
    }
}
