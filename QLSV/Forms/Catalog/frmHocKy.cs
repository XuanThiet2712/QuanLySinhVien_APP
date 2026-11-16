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

namespace QLSV.Forms.Catalog
{
    public partial class frmHocKy : Form
    {
        private readonly HocKyService _svc = new HocKyService();
        private bool _dangThem = true;

        public frmHocKy()
        {
            InitializeComponent();
            dgvHocKy.AutoGenerateColumns = false;
        }

  

        private void frmHocKy_Load(object sender, EventArgs e)
        {
            bool coQuyen = SessionManager.HasPermission(
      MaChucNang.QL_LOPHOCPHAN);

            if (!coQuyen)
            {
                MessageBox.Show(
                    "Bạn không có quyền quản lý học kỳ.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                Close();
                return;
            }

            btnThem.Enabled = true;
            btnLuu.Enabled = true;
            btnXoa.Enabled = true;

            LoadData();
            LamMoi();
        }



        private void LoadData() { dgvHocKy.DataSource = _svc.GetAll(); }

        private void LamMoi()
        {
            txtMaHK.Clear();
            txtTenHK.Clear();
            txtNamHoc.Clear();
            txtMaHK.ReadOnly = false;
            dtpTuNgay.Value = DateTime.Today;
            dtpDenNgay.Value = DateTime.Today.AddMonths(4);
            numDonGia.Value = 500000;
            _dangThem = true;
            txtMaHK.Focus();
        }

        private void dgvHocKy_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var h = dgvHocKy.Rows[e.RowIndex].DataBoundItem as HocKy;
            if (h == null) return;

            txtMaHK.Text = h.MaHK;
            txtMaHK.ReadOnly = true;
            txtTenHK.Text = h.TenHK;
            txtNamHoc.Text = h.NamHoc;
            dtpTuNgay.Value = h.TuNgay;     
            dtpDenNgay.Value = h.DenNgay;
            numDonGia.Value = h.DonGiaTinChi;   // numDonGia.Maximum phải đủ lớn (10000000)
            _dangThem = false;
        }

        private void btnThem_Click(object sender, EventArgs e) {
            var h = new HocKy
            {
                MaHK = txtMaHK.Text.Trim(),
                TenHK = txtTenHK.Text.Trim(),
                NamHoc = txtNamHoc.Text.Trim(),
                TuNgay = dtpTuNgay.Value.Date,
                DenNgay = dtpDenNgay.Value.Date,
                DonGiaTinChi = numDonGia.Value
            };
            Result r = _svc.ThemMoi(h);
            HienThongBao(r);
            if (r.Success) { 
                LoadData(); 
                LamMoi(); 
            }
        }
        private void btnLamMoi_Click(object sender, EventArgs e) { LamMoi(); LoadData(); }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            var h = new HocKy
            {
                MaHK = txtMaHK.Text.Trim(),
                TenHK = txtTenHK.Text.Trim(),
                NamHoc = txtNamHoc.Text.Trim(),
                TuNgay = dtpTuNgay.Value.Date,
                DenNgay = dtpDenNgay.Value.Date,
                DonGiaTinChi = numDonGia.Value
            };
            Result r = _svc.Luu(h);
            HienThongBao(r);
            if (r.Success) { LoadData(); LamMoi(); }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaHK.Text)) { 
                MessageBox.Show("Hãy chọn học kỳ cần xóa."); 
                return; 
            }
            if (MessageBox.Show("Xóa học kỳ " + txtMaHK.Text + "?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            Result r = _svc.Xoa(txtMaHK.Text.Trim());
            HienThongBao(r);
            if (r.Success) { 
                LoadData(); 
                LamMoi(); 
            }
        }

        private void HienThongBao(Result r)
        {
            MessageBox.Show(r.Message, "Thông báo", MessageBoxButtons.OK,
                r.Success ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
        }

        private void txtNamHoc_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTenHK_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dgvHocKy_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmLopSinhHoat_Load(object sender, EventArgs e)
        {

        }
    }
}
