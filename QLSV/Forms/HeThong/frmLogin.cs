using QLSV.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLSV.Forms.Finance;
using QLSV.Helpers;

namespace QLSV.Forms.HeThong
{
    public partial class frmLogin : Form
    {
        private readonly AuthService _auth = new AuthService();
        //filenho nho ten dang nhap , neu nguoi dung tick vao checkbox "ghi nho"
        private static readonly string FileNho = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), 
            "QLSV_tendangnhap.txt");
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

            ThemeManager.Load();
            ThemeManager.Apply(this);
            btnTheme.Text = ThemeManager.IsDark ? "🌙Tối" : "☀Sáng";
            try
            {
                if (File.Exists(FileNho))
                {
                    txtTenDangNhap.Text = File.ReadAllText(FileNho).Trim();
                    chkNho.Checked = true;
                    txtMatKhau.Focus();
                    return;
                }
            }
            catch (Exception) { }//ko quan tam loi, chi hien thi ten dang nhap
            txtTenDangNhap.Focus();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            
            var r = _auth.DangNhap(txtTenDangNhap.Text, txtMatKhau.Text);

            if (!r.Success)
            {
                errorProvider1.SetError(txtMatKhau, r.Message);
                txtMatKhau.Clear();
                txtMatKhau.Focus();
                return;
            }

            LuuTenDangNhap();
            DialogResult = DialogResult.OK;
        }

        private void LuuTenDangNhap()
        {
            try
            {
                if (chkNho.Checked) File.WriteAllText(FileNho, txtTenDangNhap.Text.Trim());
                else if (File.Exists(FileNho)) File.Delete(FileNho);
            }
            catch (Exception) { }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void lnkDangKy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (var f = new frmRegister())
            {
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    txtTenDangNhap.Text = f.TenDangNhapMoi;   
                    txtMatKhau.Clear();
                    txtMatKhau.Focus();
                }
            }
        }

        private void btnSQL_Click(object sender, EventArgs e)
        {

        }

        private void lnkQuenMatKhau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmForgotPassword().ShowDialog();
        }

        private void lnkSQL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmConnectionConfig f = new frmConnectionConfig();
            f.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnHienMatKhau_Click(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = !txtMatKhau.UseSystemPasswordChar;

            btnHienMatKhau.Text = txtMatKhau.UseSystemPasswordChar ? "👁" : "🙈";
        }

        private void btnTheme_Click(object sender, EventArgs e)
        {
            ThemeManager.Toggle();

            ThemeManager.Apply(this);

            btnTheme.Text = ThemeManager.IsDark ? "🌙Tối" : "☀Sáng";
        }
    }
}
