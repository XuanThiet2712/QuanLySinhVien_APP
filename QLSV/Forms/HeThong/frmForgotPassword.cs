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
    public partial class frmForgotPassword : Form
    {
        private readonly OtpService _otp = new OtpService();
        public frmForgotPassword()
        {
            InitializeComponent();
        }

        private async void btnGuiMa_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtTenDangNhap.Text.Trim();

            btnGuiMa.Enabled = false;
            Cursor = Cursors.WaitCursor;

            try
            {
                Result kq = await Task.Run(() => _otp.GuiOtp(tenDangNhap));

                MessageBox.Show(
                    kq.Message,
                    kq.Success ? "Thành công" : "Lỗi",
                    MessageBoxButtons.OK,
                    kq.Success ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi gửi OTP: " + ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
                btnGuiMa.Enabled = true;
            }
        }

        private void btnDoi_Click(object sender, EventArgs e)
        {
            if (txtMoi.Text != txtNhapLai.Text)
            {
                MessageBox.Show("Hai mật khẩu mới không giống nhau.", "Thông báo");
                return;
            }
            Result kq = _otp.DatLaiMatKhau(txtTenDangNhap.Text, txtOtp.Text, txtMoi.Text);
            MessageBox.Show(kq.Message, kq.Success ? "Thành công" : "Lỗi");
            if (kq.Success) Close();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmForgotPassword_Load(object sender, EventArgs e)
        {
            ThemeManager.Load();
            ThemeManager.Apply(this);
        }

        private void btnHienMatKhauMoi_Click(object sender, EventArgs e)
        {
            txtMoi.UseSystemPasswordChar = !txtMoi.UseSystemPasswordChar;

            btnHienMatKhauMoi.Text = txtMoi.UseSystemPasswordChar ? "👁" : "🙈";
        }

        private void btnHienMauKhauCu_Click(object sender, EventArgs e)
        {
            txtNhapLai.UseSystemPasswordChar = !txtNhapLai.UseSystemPasswordChar;

            btnXacNhanMatKhau.Text = txtNhapLai.UseSystemPasswordChar ? "👁" : "🙈";
        }
    }
}
