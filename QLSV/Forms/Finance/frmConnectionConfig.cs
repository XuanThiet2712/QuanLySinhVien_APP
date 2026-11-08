using QLSV.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV.Forms.Finance
{
    public partial class frmConnectionConfig : Form
    {
        public frmConnectionConfig()
        {
            InitializeComponent();
        }

        private void frmConnectionConfig_Load(object sender, EventArgs e)
        {
            txtUser.Enabled = false;
            txtPassword.Enabled = false;
        }
        // Sự kiện khi chọn thay đổi loại xác thực
        private void rdoWindowsAuth_CheckedChanged(object sender, EventArgs e)
        {
            bool isSqlAuth = rdoSqlAuth.Checked;
            txtUser.Enabled = isSqlAuth;
            txtPassword.Enabled = isSqlAuth;
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            Result r = AppConfig.TestConnection(
                txtServer.Text.Trim(),
                txtDatabase.Text.Trim(),
                rdoWindowsAuth.Checked,
                txtUser.Text.Trim(),
                txtPassword.Text
            );

            if (r.Success)
            {
                MessageBox.Show(r.Message, "Thử kết nối", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(r.Message, "Thử kết nối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            Result r = AppConfig.Save(
                txtServer.Text.Trim(),
                txtDatabase.Text.Trim(),
                rdoWindowsAuth.Checked,
                txtUser.Text.Trim(),
                txtPassword.Text
            );

            if (r.Success)
            {
                MessageBox.Show(r.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(r.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
