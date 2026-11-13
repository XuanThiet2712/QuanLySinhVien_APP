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
using System.Globalization;

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

        private void dgvNhapDiem_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string tenCot = dgvNhapDiem.Columns[e.ColumnIndex].Name;
            // ktra 3 cot diem
            if (tenCot != "colCC" &&
                tenCot != "colGK" &&
                tenCot != "colCK")
                return;
            string giaTri = Convert.ToString(e.FormattedValue).Trim();
            // de trong
            if (giaTri == "") return;
            decimal diem;
            if (!decimal.TryParse(
                giaTri,
                NumberStyles.Number,
                CultureInfo.CurrentCulture,
                out diem) ||
                diem < 0 || diem > 10)
            {
                MessageBox.Show("Điểm phải là số từ 0 đến 10.");
                e.Cancel = true;
            }
        }

        private void dgvNhapDiem_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var dto = dgvNhapDiem.Rows[e.RowIndex].DataBoundItem as DiemDTO;
            if (dto == null) return;
            // 0 du diem -> 0 tong ket
            if (!dto.DiemCC.HasValue ||
                !dto.DiemGK.HasValue ||
                !dto.DiemCK.HasValue)
            {
                dto.DiemTongKet = null;
                dto.DiemChu = null;
                dto.Diem4 = null;
            }
            else
            {
                double tk = _service.TinhDiemTongKet(
                    (double)dto.DiemCC.Value,
                    (double)dto.DiemGK.Value,
                    (double)dto.DiemCK.Value);
                dto.DiemTongKet = (decimal)tk;
                dto.DiemChu = _service.QuyDoiDiemChu(tk);
                dto.Diem4 = (decimal)_service.QuyDoiHe4(tk);
            }
            dgvNhapDiem.InvalidateRow(e.RowIndex);
        }

        private void dgvNhapDiem_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Giá trị điểm không hợp lệ.");
            e.ThrowException = false;
        }
    }
}
