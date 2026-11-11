using QLSV.Data;
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
    public partial class frmRoleManagement : Form
    {
        public frmRoleManagement()
        {
            InitializeComponent();
        }
        private readonly RoleService _role = new RoleService();
        private void frmRoleManagement_Load(object sender, EventArgs e)
        {
            // Nạp danh sách chức năng 1 lần; hiển thị cột TenCN.
            clbQuyen.DisplayMember = "TenCN";
            foreach (ChucNang cn in _role.GetAllChucNang())
                clbQuyen.Items.Add(cn);

            cboNhom.DisplayMember = "TenNhom";
            cboNhom.ValueMember = "MaNhom";
            cboNhom.DataSource = _role.GetAllNhom();
        }

        private void cboNhom_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maNhom = cboNhom.SelectedValue as string;
            if (maNhom == null) return;

            List<string> dangCo = _role.GetQuyenCuaNhom(maNhom);
            for (int i = 0; i < clbQuyen.Items.Count; i++)
            {
                var cn = (ChucNang)clbQuyen.Items[i];
                clbQuyen.SetItemChecked(i, dangCo.Contains(cn.MaCN));
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            var dsMa = new List<string>();
            foreach (object item in clbQuyen.CheckedItems)
                dsMa.Add(((ChucNang)item).MaCN);

            Result kq = _role.LuuQuyen((string)cboNhom.SelectedValue, dsMa);
            MessageBox.Show(kq.Message, kq.Success ? "Thành công" : "Lỗi");

        }
    }
}
