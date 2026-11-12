using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLSV.Services;
using QLSV.DTOs;
using QLSV.Helpers;

namespace QLSV.Forms.Report
{
    public partial class frmNhapDiem : Form
    {
        private readonly DiemService _service = new DiemService();
        public frmNhapDiem()
        {
            InitializeComponent();
        }

        private void frmNhapDiem_Load(object sender, EventArgs e)
        {
            try
            {
                if (!SessionManager.HasPermission(MaChucNang.NHAP_DIEM))
                {
                    MessageBox.Show("Bạn không có quyền nhập điểm.");
                    Close();
                    return;
                }
                // cac cot tao trg design
                dgvNhapDiem.AutoGenerateColumns = false;
                // hp dc nhap diem
                cboLopHocPhan.DisplayMember = "MaLHP";
                cboLopHocPhan.ValueMember = "MaLHP";
                cboLopHocPhan.DataSource = _service.GetLopDuocNhapDiem();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private void dgvNhapDiem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cboLopHocPhan_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var lop = cboLopHocPhan.SelectedItem as LopHocPhanDTO;
                if (lop == null)
                {
                    dgvNhapDiem.DataSource = null;
                    return;
                }
                dgvNhapDiem.DataSource = _service.GetDanhSachNhapDiem(lop.MaLHP);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách điểm: " + ex.Message);
            }
        }
    }
}
