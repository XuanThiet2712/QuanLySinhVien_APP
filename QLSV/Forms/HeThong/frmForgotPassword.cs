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

        private void btnGuiMa_Click(object sender, EventArgs e)
        {
            btnGuiMa.Enabled = false;
            Cursor = Cursors.WaitCursor;
            Result kq = _otp.GuiOtp(txtTenDangNhap.Text);   // gửi mail mất vài giây
            Cursor = Cursors.Default;
            btnGuiMa.Enabled = true;
            MessageBox.Show(kq.Message, kq.Success ? "Thành công" : "Lỗi");
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
    }
}
