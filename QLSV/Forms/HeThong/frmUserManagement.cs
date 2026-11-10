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
        //private readonly RoleService _role = new RoleService();

        public frmUserManagement()
        {
            InitializeComponent();
        }

        private void frmUserManagement_Load(object sender, EventArgs e)
        {
            cboNhom.DisplayMember = "TenNhom";
            cboNhom.ValueMember = "MaNhom";
            //cboNhom.DataSource = _role.GetAllNhom();
            TaiLai();
        }

        private void TaiLai()
        {
            throw new NotImplementedException();
        }
    }
}
