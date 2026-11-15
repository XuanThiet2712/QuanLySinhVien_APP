
using QLSV.Helpers;
using QLSV.Services;
using System;
using System.Linq;
using System.Windows.Forms;

using QLSV.Forms.Catalog;
using QLSV.Forms.Enroll;
using QLSV.Forms.Finance;
using QLSV.Forms.Report;

namespace QLSV.Forms.HeThong
{
    public partial class frmMain : Form
    {
        private readonly AuthService _auth = new AuthService();

        public bool DangXuat { get; private set; } = false;

        public frmMain()
        {
            InitializeComponent();
        }

        // =========================
        // KHỞI TẠO FORM CHÍNH
        // =========================

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

            lblNguoiDung.Text =
                "Người dùng: " + nd.TenDangNhap +
                "   |   Nhóm quyền: " + nd.MaNhom;

            PhanQuyenMenu();
        }

        // =========================
        // PHÂN QUYỀN MENU
        // =========================

        private void PhanQuyenMenu()
        {
            // Hệ thống
            mnuQuanLyNguoiDung.Visible =
                SessionManager.HasPermission(MaChucNang.QL_USER);

            mnuPhanQuyen.Visible =
                SessionManager.HasPermission(MaChucNang.QL_ROLE);

            mnuCauHinh.Visible =
                SessionManager.HasPermission(MaChucNang.CAU_HINH);

            // Danh mục
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

        // =========================
        // HÀM MỞ FORM MDI DÙNG CHUNG
        // =========================

        private void OpenMdiChild<T>(Func<T> createForm) where T : Form
        {
            // Kiểm tra Form đã được mở chưa
            foreach (Form f in MdiChildren)
            {
                if (f is T)
                {
                    f.Activate();
                    f.BringToFront();
                    return;
                }
            }

            // Chỉ tạo Form mới khi chưa tồn tại
            T frm = createForm();

            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;

            // Chỉ áp dụng giao diện một lần khi tạo Form
            ThemeManager.Apply(frm);

            frm.Show();
        }

        // =========================
        // ĐĂNG XUẤT - THOÁT
        // =========================

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

        // =========================
        // THÔNG TIN QUYỀN
        // =========================

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

        // =========================
        // HỆ THỐNG
        // =========================

        private void mnuDoiMatKhau_Click(object sender, EventArgs e)
        {
            using (frmChangePassword f = new frmChangePassword())
            {
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
                frm.ShowDialog(this);
            }
        }

        private void mnuCauHinh_Click(object sender, EventArgs e)
        {
            OpenMdiChild(() => new frmConnectionConfig());
        }

        // =========================
        // DANH MỤC
        // =========================

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
            OpenMdiChild(() => new frmHocKy());
        }

        // =========================
        // HỌC VỤ
        // =========================

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

        // =========================
        // TÀI CHÍNH
        // =========================

        private void mnuThuHocPhi_Click(object sender, EventArgs e)
        {
            OpenMdiChild(() => new frmThuHocPhi());
        }

        private void inDoanhThuToolStripMenuItem_Click(
            object sender, EventArgs e)
        {
            OpenMdiChild(() => new frmInDoanhThu());
        }

        // =========================
        // BÁO CÁO - THỐNG KÊ
        // =========================

        private void mnuBangDiem_Click(object sender, EventArgs e)
        {
            OpenMdiChild(() => new frmReportBangDiem());
        }

        private void mnuBieuDo_Click(object sender, EventArgs e)
        {
            OpenMdiChild(() => new frmThongKeDoanhThu());
        }

        private void mnuBaoCaoDoanhThu_Click(object sender, EventArgs e)
        {
            OpenMdiChild(() => new frmThongKeDoanhThu());
        }

        // =========================
        // GIAO DIỆN
        // =========================

        private void mnuTheme_Click(object sender, EventArgs e)
        {
            ThemeManager.Toggle();
        }

        private void frmMain_MdiChildActivate(object sender, EventArgs e)
        {
            // Không gọi ThemeManager.Apply() tại đây.
            // Theme đã được áp dụng khi Form con được tạo.
            // Tránh vẽ lại toàn bộ giao diện mỗi lần chuyển Form.
        }
    }
}
