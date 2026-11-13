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

using QLSV.Forms.Catalog;     // frmKhoa, frmNganh... (B)
//using QLSV.Forms.Grade;       // frmLopHocPhan, frmNhapDiem (C)
using QLSV.Forms.Enroll;      // frmDangKyHocPhan (A)
using QLSV.Forms.Finance;
using QLSV.Forms.Report;     // frmThuHocPhi, frmChartDashboard, frmConnectionConfig (D)
using QLSV.Forms.Report;      // frmReportBangDiem, frmReportThongKe

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
            ThemeManager.Apply(this);
            var nd = SessionManager.CurrentUser;
            if (nd == null)
            {
                MessageBox.Show("Chưa đăng nhập. Vui lòng đăng nhập lại.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DangXuat = true;   // để Program.cs quay về form đăng nhập
                Close();
                return;
            }

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

           //mnuDanhMuc.Visible = mnuKhoa.Visible || mnuNganh.Visible
           //    || mnuLopSinhHoat.Visible || mnuSinhVien.Visible
           //    || mnuGiangVien.Visible || mnuMonHoc.Visible;

           // mnuHocVu.Visible = mnuLopHocPhan.Visible || mnuDangKyHocPhan.Visible
           //     || mnuNhapDiem.Visible;

           // mnuTaiChinh.Visible = mnuThuHocPhi.Visible;

           // mnuBaoCao.Visible = mnuBangDiem.Visible || mnuBieuDo.Visible
           //     || mnuBaoCaoDoanhThu.Visible;
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
            frmChangePassword f = new frmChangePassword();
            f.ShowDialog();
        }

        private void mnuQuanLyNguoiDung_Click(object sender, EventArgs e)
        {
            foreach (Form f in MdiChildren)
            {
                if (f is frmUserManagement) { f.Activate(); return; }
            }
            frmUserManagement frm = new frmUserManagement();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            this.Height = frm.Height + 100;
            this.Width = frm.Width + 100;
            frm.Show();
        }

        private void mnuPhanQuyen_Click(object sender, EventArgs e)
        {
            frmRoleManagement frm = new frmRoleManagement();
            frm.ShowDialog();
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
            foreach (Form f in MdiChildren)
            {
                if (f is frmKhoa) { f.Activate(); return; }
            }
            frmKhoa frm = new frmKhoa();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            this.Height = frm.Height + 100;
            this.Width = frm.Width + 100;
            frm.Show();
        }

        private void mnuNganh_Click(object sender, EventArgs e)
        {
            foreach (Form f in MdiChildren)
            {
                if (f is frmNganh) { f.Activate(); return; }
            }
            frmNganh frm = new frmNganh();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            this.Height = frm.Height + 100;
            this.Width = frm.Width + 100;
            frm.Show();
        }

        private void mnuLopSinhHoat_Click(object sender, EventArgs e)
        {
            foreach (Form f in MdiChildren)
            {
                if (f is frmLopSinhHoat) { f.Activate(); return; }
            }
            frmLopSinhHoat frm = new frmLopSinhHoat();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            this.Height = frm.Height + 100;
            this.Width = frm.Width + 100;
            frm.Show();
        }

        private void mnuSinhVien_Click(object sender, EventArgs e)
        {
            foreach (Form f in MdiChildren)
            {
                if (f is frmSinhVien) { f.Activate(); return; }
            }
            frmSinhVien frm = new frmSinhVien();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            this.Height = frm.Height + 100;
            this.Width = frm.Width + 100;
            frm.Show();
        }

        private void mnuGiangVien_Click(object sender, EventArgs e)
        {
            foreach (Form f in MdiChildren)
            {
                if (f is frmGiangVien) { f.Activate(); return; }
            }
            frmGiangVien frm = new frmGiangVien();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            this.Height = frm.Height + 100;
            this.Width = frm.Width + 100;
            frm.Show();
        }

        private void mnuMonHoc_Click(object sender, EventArgs e)
        {
            foreach (Form f in MdiChildren)
            {
                if (f is frmMonHoc) { f.Activate(); return; }
            }
            frmMonHoc frm = new frmMonHoc();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            this.Height = frm.Height + 100;
            this.Width = frm.Width + 100;
            frm.Show();
        }

        private void mnuLopHocPhan_Click(object sender, EventArgs e)
        {
            foreach (Form f in MdiChildren)
            {
                if (f is frmLopHocPhan) { f.Activate(); return; }
            }
            frmLopHocPhan frm = new frmLopHocPhan();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            this.Height = frm.Height + 100;
            this.Width = frm.Width + 100;
            frm.Show();
        }

        private void mnuDangKyHocPhan_Click(object sender, EventArgs e)
        {
            foreach (Form f in MdiChildren)
            {
                if (f is frmDangKyHocPhan) { f.Activate(); return; }
            }
            frmDangKyHocPhan frm = new frmDangKyHocPhan();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            this.Height = frm.Height + 100;
            this.Width = frm.Width + 100;
            frm.Show();
        }

        private void mnuNhapDiem_Click(object sender, EventArgs e)
        {
            foreach (Form f in MdiChildren)
            {
                if (f is frmNhapDiem) { f.Activate(); return; }
            }
            frmNhapDiem frm = new frmNhapDiem();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            this.Height = frm.Height + 100;
            this.Width = frm.Width + 100;
            frm.Show();
        }

        private void mnuThuHocPhi_Click(object sender, EventArgs e)
        {
            foreach (Form f in MdiChildren)
            {
                if (f is frmThuHocPhi) { f.Activate(); return; }
            }
            frmThuHocPhi frm = new frmThuHocPhi();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            this.Height = frm.Height + 100; 
            this.Width = frm.Width + 100;
            frm.Show();
        }

        private void mnuBangDiem_Click(object sender, EventArgs e)
        {
            foreach (Form f in MdiChildren)
            {
                if (f is frmReportBangDiem) { f.Activate(); return; }
            }
            frmReportBangDiem frm = new frmReportBangDiem();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            this.Height = frm.Height + 100;
            this.Width = frm.Width + 100;
            frm.Show();
        }


        private void inDoanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in MdiChildren)
            {
                if (f is frmInDoanhThu) { f.Activate(); return; }
            }
            frmInDoanhThu frm = new frmInDoanhThu();

            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            this.Height = frm.Height + 100;
            this.Width = frm.Width + 100;
            frm.Show();

        }
        private void mnuBieuDo_Click(object sender, EventArgs e)
        {
            foreach (Form f in MdiChildren)
            {
                if (f is frmThongKeDoanhThu) { f.Activate(); return; }
            }
            frmThongKeDoanhThu frm = new frmThongKeDoanhThu();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            this.Height = frm.Height + 100;
            this.Width = frm.Width + 100;
            frm.Show();
        }

        

        private void mnuBaoCaoDoanhThu_Click(object sender, EventArgs e)
        {
            foreach (Form f in MdiChildren)
            {
                if (f is frmThongKeDoanhThu) { f.Activate(); return; }
            }
            frmThongKeDoanhThu frm = new frmThongKeDoanhThu();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            this.Height = frm.Height + 100;
            this.Width = frm.Width + 100;
            frm.Show();
        }


        //private void mnuBieuDo_Click(object sender, EventArgs e)
        //{
        //    foreach (Form f in MdiChildren)
        //    {
        //        if (f is frmBieuDo) { f.Activate(); return; }
        //    }
        //    frmBieuDo frm = new frmBieuDo();
        //}

        //private void mnuBaoCaoDoanhThu_Click(object sender, EventArgs e)
        //{

        //}

  


        private void mnuHocKy_Click(object sender, EventArgs e)
        {
            foreach (Form f in MdiChildren)
            {
                if (f is frmHocKy) { f.Activate(); return; }
            }
            frmHocKy frm = new frmHocKy();

            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            this.Height = frm.Height + 100;
            this.Width = frm.Width + 100;
            frm.Show();
        }

        private void mnuTheme_Click(object sender, EventArgs e)
        {
            ThemeManager.Toggle();
        }

        private void frmMain_MdiChildActivate(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null) 
                ThemeManager.Apply(ActiveMdiChild);
        }
    }
}
