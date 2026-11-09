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
            lblThongBao.Text = "";
            var r = _auth.DangNhap(txtTenDangNhap.Text, txtMatKhau.Text);

            if (!r.Success)
            {
                lblThongBao.Text = r.Message;
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
    }
}
