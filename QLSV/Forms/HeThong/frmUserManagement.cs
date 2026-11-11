using QLSV.DTOs;
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
    public partial class frmUserManagement : Form
    {
        private readonly UserService _user = new UserService();
        private readonly RoleService _role = new RoleService();


        public frmUserManagement()
        {
            InitializeComponent();
        }

        private void frmUserManagement_Load(object sender, EventArgs e)
        {
            cboNhom.DisplayMember = "TenNhom";
            cboNhom.ValueMember = "MaNhom";
            cboNhom.DataSource = _role.GetAllNhom();
            TaiLai();
        }

        private void TaiLai()
        {
            dgvUser.DataSource = _user.GetAll(txtTim.Text.Trim());
        }

        private NguoiDungDTO DongDangChon()
        {
            if (dgvUser.CurrentRow == null) return null;
            return (NguoiDungDTO)dgvUser.CurrentRow.DataBoundItem;
        }

        private void HienKetQua(Result kq)
        {
            MessageBox.Show(kq.Message, kq.Success ? "Thành công" : "Lỗi");
            if (kq.Success) TaiLai();
        }

        private void dgvUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvUser_SelectionChanged(object sender, EventArgs e)
        {
            NguoiDungDTO u = DongDangChon();
            if (u == null) return;
            txtTenDangNhap.Text = u.TenDangNhap;
            cboNhom.SelectedIndex = cboNhom.FindStringExact(u.TenNhom);
            txtDoiTuong.Text = u.DoiTuong;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            NguoiDungDTO u = DongDangChon();
            if (u == null) return;
            if (MessageBox.Show("Xóa tài khoản " + u.TenDangNhap + "?",
                "Xác nhận", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            HienKetQua(_user.Xoa(u.MaND));
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            NguoiDungDTO u = DongDangChon();
            if (u == null) return;
            if (MessageBox.Show("Đặt lại mật khẩu của " + u.TenDangNhap + " về 123456?",
                "Xác nhận", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            HienKetQua(new AuthService().ResetMatKhau(u.MaND));
        }

        private void btnKhoa_Click(object sender, EventArgs e)
        {
            NguoiDungDTO u = DongDangChon();
            if (u == null) return;
            bool dangKhoa = u.TrangThai == "Đã khóa";
            HienKetQua(_user.DatTrangThai(u.MaND, dangKhoa));
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            NguoiDungDTO u = DongDangChon();
            if (u == null) return;
            HienKetQua(_user.CapNhat(u.MaND, (string)cboNhom.SelectedValue, txtDoiTuong.Text));
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            HienKetQua(_user.Tao(txtTenDangNhap.Text, (string)cboNhom.SelectedValue, txtDoiTuong.Text));
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            TaiLai();
        }
    }
}
