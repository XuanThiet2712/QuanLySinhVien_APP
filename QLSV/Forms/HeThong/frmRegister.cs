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
    public partial class frmRegister : Form
    {
        private readonly AuthService _auth = new AuthService();

        //Tên đăng nhập vừa tạo , frmLogin điền sẵn
        public string TenDangNhapMoi { get; private set; }
        public frmRegister()
        {
            InitializeComponent();

            dtpNgaySinh.Format = DateTimePickerFormat.Short;
            dtpNgaySinh.Value = new DateTime(2006, 1, 1);
        }

        private void frmRegister_Load(object sender, EventArgs e)
        {

        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            lblThongBao.Text = "";

            if (txtMatKhau.Text != txtNhapLai.Text)
            {
                lblThongBao.Text = "Mật khẩu nhập lại không khớp.";
                return;
            }

            var r = _auth.DangKyTaiKhoan(txtMaSV.Text, dtpNgaySinh.Value, txtTenDangNhap.Text, txtMatKhau.Text);
            if (!r.Success)
            {
                lblThongBao.Text = r.Message;
                return;
            }

            MessageBox.Show(r.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            TenDangNhapMoi = txtTenDangNhap.Text.Trim();
            DialogResult = DialogResult.OK;
        }
    }
}
