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
    public partial class frmChangePassword : Form
    {
        public frmChangePassword()
        {
            InitializeComponent();
        }

        private void btnDoi_Click(object sender, EventArgs e)
        {
            if (txtMoi.Text != txtNhapLai.Text)
            {
                MessageBox.Show("Hai mật khẩu mới không giống nhau", "Thông báo");
                return;
            }

            Result kq = new AuthService().DoiMatKhau(
                SessionManager.CurrentUser.TenDangNhap, txtCu.Text, txtMoi.Text);

            MessageBox.Show(kq.Message, kq.Success ? "Thành công" : "Lỗi");
            if (kq.Success) Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            ThemeManager.Load();
            ThemeManager.Apply(this);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtCu.UseSystemPasswordChar =!txtCu.UseSystemPasswordChar;

            btnHienMatKhauCu.Text = txtCu.UseSystemPasswordChar ? "👁" : "🙈";
        }

        private void txtMoi_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnHienMatKhauMoi_Click(object sender, EventArgs e)
        {
            txtMoi.UseSystemPasswordChar = !txtMoi.UseSystemPasswordChar;

            btnHienMatKhauMoi.Text = txtMoi.UseSystemPasswordChar ? "👁" : "🙈";
        }

        private void btnXacNhanMatKhau_Click(object sender, EventArgs e)
        {
            txtNhapLai.UseSystemPasswordChar =!txtNhapLai.UseSystemPasswordChar;

            btnXacNhanMatKhau.Text = txtNhapLai.UseSystemPasswordChar ? "👁" : "🙈";
        }
    }
}
