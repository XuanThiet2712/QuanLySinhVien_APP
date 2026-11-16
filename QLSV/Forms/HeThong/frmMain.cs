using QLSV.Helpers;
using QLSV.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

using QLSV.Forms.Catalog;
using QLSV.Forms.Enroll;
using QLSV.Forms.Finance;
using QLSV.Forms.Report;
using QLSV.DTOs;

namespace QLSV.Forms.HeThong
{
    public partial class frmMain : Form
    {
        private readonly AuthService _auth = new AuthService();

        public bool DangXuat { get; private set; } = false;

        public frmMain()
        {
            InitializeComponent();

            // Chống nhấp nháy khi chuyển form: bật vẽ đệm cho form chính và vùng chứa form con.
            DoubleBuffered = true;
            BatDoubleBufferChoVungMdi();
        }

        // Vùng nền chứa các form con (MdiClient) mặc định không bật double buffer
        // và thuộc tính này không public, nên phải bật bằng reflection.
        private void BatDoubleBufferChoVungMdi()
        {
            PropertyInfo pi = typeof(Control).GetProperty(
                "DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (Control c in Controls)
            {
                if (c is MdiClient) pi.SetValue(c, true, null);
            }
        }

  
        // KHỞI TẠO FORM CHÍNH
     

        private void frmMain_Load(object sender, EventArgs e)
        {
            ThemeManager.Apply(this);

            var nd = SessionManager.CurrentUser;

            if (nd == null)
            {
                MessageBox.Show(
                    "Chưa đăng nhập. Vui lòng đăng nhập lại.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                DangXuat = true;
                Close();
                return;
            }

            lblNguoiDung.Text = "Người dùng: " + nd.TenDangNhap + "   |   Nhóm quyền: " + nd.MaNhom;

            PhanQuyenMenu();
            MoFormMacDinh();
        }

    
        // PHÂN QUYỀN MENU
      

        private void PhanQuyenMenu()
        {
            // Hệ thống
            mnuQuanLyNguoiDung.Visible = SessionManager.HasPermission(MaChucNang.QL_USER);
            //MessageBox.Show(SessionManager.HasPermission(MaChucNang.QL_USER).ToString());
            //MessageBox.Show(mnuQuanLyNguoiDung.Visible.ToString());
            mnuPhanQuyen.Visible =
                SessionManager.HasPermission(MaChucNang.QL_ROLE);

            mnuCauHinh.Visible =
                SessionManager.HasPermission(MaChucNang.CAU_HINH);

            // Danh mục
            mnuHocKy.Visible =
                SessionManager.HasPermission(MaChucNang.QL_LOPHOCPHAN);
            mnuKhoa.Visible =
                SessionManager.HasPermission(MaChucNang.QL_KHOA);

            mnuNganh.Visible =
                SessionManager.HasPermission(MaChucNang.QL_NGANH);

            mnuLopSinhHoat.Visible =
                SessionManager.HasPermission(MaChucNang.QL_LOP);

            mnuSinhVien.Visible =
                SessionManager.HasPermission(MaChucNang.QL_SINHVIEN);

            mnuGiangVien.Visible =
                SessionManager.HasPermission(MaChucNang.QL_GIANGVIEN);

            mnuMonHoc.Visible =
                SessionManager.HasPermission(MaChucNang.QL_MONHOC);

            // Học vụ
            mnuLopHocPhan.Visible =
                SessionManager.HasPermission(MaChucNang.QL_LOPHOCPHAN);

            mnuDangKyHocPhan.Visible =
                SessionManager.HasPermission(MaChucNang.DANG_KY);

            mnuNhapDiem.Visible =
                SessionManager.HasPermission(MaChucNang.NHAP_DIEM);

            // Tài chính
            mnuThuHocPhi.Visible =
                SessionManager.HasPermission(MaChucNang.THU_HOC_PHI);

            // Báo cáo
            mnuBangDiem.Visible =
                SessionManager.HasPermission(MaChucNang.XEM_DIEM);

            mnuBieuDo.Visible =
                SessionManager.HasPermission(MaChucNang.THONG_KE);

            mnuBaoCaoDoanhThu.Visible =
                SessionManager.HasPermission(MaChucNang.THONG_KE);
        }

    
  

        // Mở một form con. Form đang mở khác sẽ được đóng, form mới lấp đầy vùng làm việc.
        // Thứ tự: dựng và tô màu form mới -> hiện nó -> rồi mới đóng form cũ,
        // nhờ vậy màn hình không bị nháy trắng ở giữa.
        private void OpenMdiChild<T>(Func<T> createForm) where T : Form
        {
            // Đang mở đúng form này rồi thì chỉ cần kích hoạt.
            foreach (Form f in MdiChildren)
            {
                if (f is T)
                {
                    f.Activate();
                    return;
                }
            }

            List<Form> formCu = MdiChildren.ToList();

            T frm = createForm();
            frm.MdiParent = this;
             // bỏ thanh tiêu đề và viền
            frm.Dock = DockStyle.Fill;

            // Tô màu theo giao diện hiện tại khi form chưa hiện, tránh vẽ lại hai lần.
            ThemeManager.Apply(frm);

            frm.Show();

            foreach (Form f in formCu) f.Close();
        }

        // Form tự mở sau khi đăng nhập: form đầu tiên mà nhóm quyền này được dùng.
        private void MoFormMacDinh()
        {
            if (SessionManager.HasPermission(MaChucNang.DANG_KY))
                OpenMdiChild(() => new frmDangKyHocPhan());

            else if (SessionManager.HasPermission(MaChucNang.NHAP_DIEM))
                OpenMdiChild(() => new frmNhapDiem());

            else if (SessionManager.HasPermission(MaChucNang.QL_SINHVIEN))
                OpenMdiChild(() => new frmSinhVien());

            else if (SessionManager.HasPermission(MaChucNang.THU_HOC_PHI))
                OpenMdiChild(() => new frmThuHocPhi());

            else if (SessionManager.HasPermission(MaChucNang.QL_USER))
                OpenMdiChild(() => new frmUserManagement());

            else
            {
                MessageBox.Show(
                    "Tài khoản hiện tại chưa có quyền mở màn hình mặc định.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }
        


        // ĐĂNG XUẤT - THOÁT


        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show(
                "Bạn muốn đăng xuất?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (res != DialogResult.Yes)
                return;

            _auth.DangXuat();

            DangXuat = true;
            Close();
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            DangXuat = false;
            Close();
        }

   
        // THÔNG TIN QUYỀN
    

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

       
        // HỆ THỐNG
      
        private void mnuDoiMatKhau_Click(object sender, EventArgs e)
        {
            using (frmChangePassword f = new frmChangePassword())
            {
                ThemeManager.Apply(f);
                f.ShowDialog(this);
            }
        }

        private void mnuQuanLyNguoiDung_Click(object sender, EventArgs e)
        {
            OpenMdiChild(() => new frmUserManagement());
        }

        private void mnuPhanQuyen_Click(object sender, EventArgs e)
        {
            using (frmRoleManagement frm = new frmRoleManagement())
            {
                ThemeManager.Apply(frm);
                frm.ShowDialog(this);
            }
        }

        private void mnuCauHinh_Click(object sender, EventArgs e)
        {
            OpenMdiChild(() => new frmConnectionConfig());
        }

        // DANH MỤC


        private void mnuKhoa_Click(object sender, EventArgs e)
        {
            OpenMdiChild(() => new frmKhoa());
        }

        private void mnuNganh_Click(object sender, EventArgs e)
        {
            OpenMdiChild(() => new frmNganh());
        }

        private void mnuLopSinhHoat_Click(object sender, EventArgs e)
        {
            OpenMdiChild(() => new frmLopSinhHoat());
        }

        private void mnuSinhVien_Click(object sender, EventArgs e)
        {
            OpenMdiChild(() => new frmSinhVien());
        }

        private void mnuGiangVien_Click(object sender, EventArgs e)
        {
            OpenMdiChild(() => new frmGiangVien());
        }

        private void mnuMonHoc_Click(object sender, EventArgs e)
        {
            OpenMdiChild(() => new frmMonHoc());
        }

        private void mnuHocKy_Click(object sender, EventArgs e)
        {
            if (!SessionManager.HasPermission(MaChucNang.QL_LOPHOCPHAN))
            {
                MessageBox.Show("Bạn không có quyền quản lý học kỳ.");
                return;
            }

            OpenMdiChild(() => new frmHocKy());
        }

        // HỌC VỤ

        private void mnuLopHocPhan_Click(object sender, EventArgs e)
        {
            OpenMdiChild(() => new frmLopHocPhan());
        }

        private void mnuDangKyHocPhan_Click(object sender, EventArgs e)
        {
            OpenMdiChild(() => new frmDangKyHocPhan());
        }

        private void mnuNhapDiem_Click(object sender, EventArgs e)
        {
            OpenMdiChild(() => new frmNhapDiem());
        }

  
        // TÀI CHÍNH


        private void mnuThuHocPhi_Click(object sender, EventArgs e)
        {
            OpenMdiChild(() => new frmThuHocPhi());
        }

        private void inDoanhThuToolStripMenuItem_Click(
            object sender, EventArgs e)
        {
            OpenMdiChild(() => new frmInDoanhThu());
        }

 
        // BÁO CÁO - THỐNG KÊ


        private void mnuBangDiem_Click(object sender, EventArgs e)
        {
            OpenMdiChild(() => new frmReportBangDiem());
        }

        private void mnuBieuDo_Click(object sender, EventArgs e)
        {
            OpenMdiChild(() => new frmBieuDo());
        }

        private void mnuBaoCaoDoanhThu_Click(object sender, EventArgs e)
        {
            OpenMdiChild(() => new frmThongKeDoanhThu());
        }

   
        // GIAO DIỆN
  

        private void mnuTheme_Click(object sender, EventArgs e)
        {
            ThemeManager.Toggle();
        }

        private void frmMain_MdiChildActivate(object sender, EventArgs e)
        {
 
        }

        private void mnuLichSuDiem_Click(object sender, EventArgs e)
        {
            //OpenMdiChild(() => new frmLichSuDiem());
        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {
            mnuDangXuat_Click(sender, e);
        }
    }
}