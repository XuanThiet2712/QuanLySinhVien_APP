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
    public partial class frmGiangVien : Form
    {
        private readonly GiangVienService _svc = new GiangVienService();
        private bool _dangThem = true;

        public frmGiangVien()
        {
            InitializeComponent();
            GanSuKien();
        }

        private void GanSuKien()
        {
            Load += frmGiangVien_Load;
            btnTim.Click += btnTim_Click;
            btnThem.Click += btnThem_Click;
            btnLuu.Click += btnLuu_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamMoi.Click += btnLamMoi_Click;
            dgvGiangVien.CellClick += dgvGiangVien_CellClick;
            cboLocKhoa.SelectionChangeCommitted += cboLocKhoa_SelectionChangeCommitted;
        }

        private void frmGiangVien_Load(object sender, EventArgs e)
        {
            btnThem.Enabled = btnLuu.Enabled = btnXoa.Enabled =
                SessionManager.HasPermission(MaChucNang.QL_GIANGVIEN);

            var ds = new KhoaService().GetAll();

            cboKhoa.DataSource = new List<Khoa>(ds);
            cboKhoa.DisplayMember = "TenKhoa";
            cboKhoa.ValueMember = "MaKhoa";

            var loc = new List<Khoa>(ds);
            loc.Insert(0, new Khoa { MaKhoa = "", TenKhoa = "-- Tất cả --" });
            cboLocKhoa.DataSource = loc;
            cboLocKhoa.DisplayMember = "TenKhoa";
            cboLocKhoa.ValueMember = "MaKhoa";

            SetupGrid();
            LoadData();
            LamMoi();
        }

        private void SetupGrid()
        {
            dgvGiangVien.AutoGenerateColumns = false;
            dgvGiangVien.Columns.Clear();
            dgvGiangVien.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaGV", HeaderText = "Mã GV" });
            dgvGiangVien.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "HoTen", HeaderText = "Họ tên" });
            dgvGiangVien.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Email", HeaderText = "Email" });
            dgvGiangVien.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SDT", HeaderText = "SĐT" });
            dgvGiangVien.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaKhoa", HeaderText = "Khoa" });
        }

        // Từ khóa và khoa cùng áp dụng
        private void LoadData()
        {
            string khoa = cboLocKhoa.SelectedValue == null ? "" : cboLocKhoa.SelectedValue.ToString();
            dgvGiangVien.DataSource = _svc.Search(txtTimKiem.Text.Trim(), khoa);
        }

        private void btnTim_Click(object sender, EventArgs e) { LoadData(); }
        private void cboLocKhoa_SelectionChangeCommitted(object sender, EventArgs e) { LoadData(); }

        private void LamMoi()
        {
            txtMaGV.Clear();
            txtHoTen.Clear();
            txtEmail.Clear();
            txtSDT.Clear();
            txtMaGV.ReadOnly = false;
            if (cboKhoa.Items.Count > 0) cboKhoa.SelectedIndex = 0;
            _dangThem = true;
            txtMaGV.Focus();
        }

        private void dgvGiangVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var g = dgvGiangVien.Rows[e.RowIndex].DataBoundItem as GiangVien;
            if (g == null) return;
            txtMaGV.Text = g.MaGV;
            txtMaGV.ReadOnly = true;
            txtHoTen.Text = g.HoTen;
            txtEmail.Text = g.Email;
            txtSDT.Text = g.SDT;
            cboKhoa.SelectedValue = g.MaKhoa;
            _dangThem = false;
        }

        private void btnThem_Click(object sender, EventArgs e) {
            var g = new GiangVien
            {
                MaGV = txtMaGV.Text.Trim(),
                HoTen = txtHoTen.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                SDT = txtSDT.Text.Trim(),
                MaKhoa = cboKhoa.SelectedValue == null ? "" : cboKhoa.SelectedValue.ToString().Trim()
            };

            Result r = _svc.ThemMoi(g);
            HienThongBao(r);

            if (r.Success)
            {
                LoadData();
                LamMoi();
            }
        }
        private void btnLamMoi_Click(object sender, EventArgs e) { txtTimKiem.Clear(); LamMoi(); LoadData(); }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            var g = new GiangVien
            {
                MaGV = txtMaGV.Text.Trim(),
                HoTen = txtHoTen.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                SDT = txtSDT.Text.Trim(),
                MaKhoa = cboKhoa.SelectedValue == null ? "" : cboKhoa.SelectedValue.ToString()
            };
            Result r = _svc.Luu(g);
            HienThongBao(r);
            if (r.Success) { LoadData(); LamMoi(); }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaGV.Text)) { MessageBox.Show("Hãy chọn giảng viên cần xóa."); return; }
            if (MessageBox.Show("Xóa giảng viên " + txtMaGV.Text + "?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            Result r = _svc.Xoa(txtMaGV.Text.Trim());
            HienThongBao(r);
            if (r.Success) { LoadData(); LamMoi(); }
        }

        private void HienThongBao(Result r)
        {
            MessageBox.Show(r.Message, "Thông báo", MessageBoxButtons.OK,
                r.Success ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
        }

        private void frmGiangVien_Load_1(object sender, EventArgs e)
        {

        }

        private void dgvGiangVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtMaGV_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtHoTen_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboLocKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnTim_Click_1(object sender, EventArgs e)
        {

        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void cboKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {

        }

        private void btnLamMoi_Click_1(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {

        }
    }
}
