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
    public partial class frmNganh : Form
    {
        private readonly NganhService _svc = new NganhService();
        private readonly KhoaService _khoaSvc = new KhoaService();
        private bool _dangThem = true;

        public frmNganh()
        {
            InitializeComponent();
            GanSuKien();
        }

        private void GanSuKien()
        {
            Load += frmNganh_Load;
            btnThem.Click += btnThem_Click;
            btnLuu.Click += btnLuu_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamMoi.Click += btnLamMoi_Click;
            dgvNganh.CellClick += dgvNganh_CellClick;
            // SelectionChangeCommitted chỉ chạy khi NGƯỜI DÙNG chọn (tránh NullReference lúc nạp dữ liệu)
            cboLocKhoa.SelectionChangeCommitted += cboLocKhoa_SelectionChangeCommitted;
        }

        private void frmNganh_Load(object sender, EventArgs e)
        {
            btnThem.Enabled = btnLuu.Enabled = btnXoa.Enabled =
                SessionManager.HasPermission(MaChucNang.QL_NGANH);
            NapKhoa();      // phải nạp ComboBox trước khi tải lưới
            SetupGrid();
            LoadData();
            LamMoi();
        }

        // Nạp 2 ComboBox từ 2 bản sao danh sách để chúng không chọn dính nhau
        private void NapKhoa()
        {
            var ds = _khoaSvc.GetAll();

            cboLocKhoa.DisplayMember = "TenKhoa";
            cboLocKhoa.ValueMember = "MaKhoa";

            cboKhoa.DataSource = new List<Khoa>(ds);
            cboKhoa.DisplayMember = "TenKhoa";
            cboKhoa.ValueMember = "MaKhoa";

            var loc = new List<Khoa>(ds);
            loc.Insert(0, new Khoa { MaKhoa = "", TenKhoa = "-- Tất cả --" });
            cboLocKhoa.DataSource = loc;
            /*cboLocKhoa.DisplayMember = "TenKhoa";
            cboLocKhoa.ValueMember = "MaKhoa";*/
        }

        private void SetupGrid()
        {
            dgvNganh.AutoGenerateColumns = false;
            dgvNganh.Columns.Clear();
            dgvNganh.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaNganh", HeaderText = "Mã ngành", FillWeight = 25 });
            dgvNganh.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TenNganh", HeaderText = "Tên ngành", FillWeight = 50 });
            dgvNganh.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaKhoa", HeaderText = "Mã khoa", FillWeight = 25 });
        }

        // Mã lọc rỗng nghĩa là "Tất cả"
        private void LoadData()
        {
            string maKhoa = cboLocKhoa.SelectedValue == null ? "" : cboLocKhoa.SelectedValue.ToString();
            dgvNganh.DataSource = maKhoa == "" ? _svc.GetAll() : _svc.GetByKhoa(maKhoa);
        }

        private void cboLocKhoa_SelectionChangeCommitted(object sender, EventArgs e) { LoadData(); }

        private void LamMoi()
        {
            txtMaNganh.Clear();
            txtTenNganh.Clear();
            txtMaNganh.ReadOnly = false;
            if (cboKhoa.Items.Count > 0) cboKhoa.SelectedIndex = 0;
            _dangThem = true;
            txtMaNganh.Focus();
        }

        private void dgvNganh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var n = dgvNganh.Rows[e.RowIndex].DataBoundItem as Nganh;
            if (n == null) return;
            txtMaNganh.Text = n.MaNganh;
            txtMaNganh.ReadOnly = true;
            txtTenNganh.Text = n.TenNganh;
            cboKhoa.SelectedValue = n.MaKhoa;   // gán SelectedValue để ComboBox nhảy đúng khoa
            _dangThem = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //Gom dữ liệu từ ô nhập thành 1 đối tượng. Trim() cắt khoảng trắng đầu/cuối.
            var n = new Nganh { MaNganh = txtMaNganh.Text.Trim(), TenNganh = txtTenNganh.Text.Trim(), MaKhoa = cboKhoa.SelectedValue == null ? "" : cboKhoa.SelectedValue.ToString() };
            Result r =  _svc.ThemMoi(n);

            HienThongBao(r);

            //Thành công thì tải lại lưới và xóa ô nhập. Thất bại thì giữ nguyên để sửa.
            if (r.Success)
            {
                LoadData();
                LamMoi();
            }
        }
            //LamMoi(); }
        private void btnLamMoi_Click(object sender, EventArgs e) { LamMoi(); LoadData(); }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            var n = new Nganh
            {
                MaNganh = txtMaNganh.Text.Trim(),
                TenNganh = txtTenNganh.Text.Trim(),
                MaKhoa = cboKhoa.SelectedValue == null ? "" : cboKhoa.SelectedValue.ToString()
            };
            Result r =  _svc.Luu(n); //: _svc.ThemMoi(n);
            HienThongBao(r);
            if (r.Success) { LoadData(); LamMoi(); }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNganh.Text)) { MessageBox.Show("Hãy chọn ngành cần xóa."); return; }
            if (MessageBox.Show("Xóa ngành " + txtMaNganh.Text + "?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            Result r = _svc.Xoa(txtMaNganh.Text.Trim());
            HienThongBao(r);
            if (r.Success) { LoadData(); LamMoi(); }
        }

        private void HienThongBao(Result r)
        {
            MessageBox.Show(r.Message, "Thông báo", MessageBoxButtons.OK,
                r.Success ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
        }
    }
}
