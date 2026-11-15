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
    /// Form quản lý lớp sinh hoạt (Khoa -> Ngành -> Lớp).
    /// Lớp chỉ lưu MaNganh; cboKhoa chỉ dùng để lọc danh sách ngành.
    public partial class frmLopSinhHoat : Form
    {
        private readonly LopSinhHoatService _svc = new LopSinhHoatService();
        private readonly NganhService _nganhSvc = new NganhService();
        private bool _dangThem = true;

        public frmLopSinhHoat()
        {
            InitializeComponent();
            GanSuKien();
        }

        private void GanSuKien()
        {
            Load += frmLopSinhHoat_Load;
            btnThem.Click += btnThem_Click;
            btnLuu.Click += btnLuu_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamMoi.Click += btnLamMoi_Click;
            dgvLop.CellClick += dgvLop_CellClick;
            cboNganh.SelectionChangeCommitted += cboKhoa_SelectionChangeCommitted;
            cboLocNganh.SelectionChangeCommitted += cboLocNganh_SelectionChangeCommitted;
        }

        private void frmLopSinhHoat_Load(object sender, EventArgs e)
        {
            btnThem.Enabled = btnLuu.Enabled = btnXoa.Enabled =
                SessionManager.HasPermission(MaChucNang.QL_LOP);

            //  Khoa (cấp cha)
            cboNganh.DataSource = new NganhService().GetAll();
            cboNganh.DisplayMember = "TenNganh";
            cboNganh.ValueMember = "MaNganh";
        

            //  Ngành theo khoa đang chọn (cấp con)
            NapNganhTheoKhoa();

            //  Bộ lọc lưới: mọi ngành + "Tất cả"
            var tatCa = new List<Nganh>(_nganhSvc.GetAll());
            tatCa.Insert(0, new Nganh { MaNganh = "", TenNganh = "-- Tất cả --" });
            cboLocNganh.DataSource = tatCa;
            cboLocNganh.DisplayMember = "TenNganh";
            cboLocNganh.ValueMember = "MaNganh";

            SetupGrid();
            LoadData();
            LamMoi();
        }

        // Chỉ nạp các ngành thuộc khoa đang chọn
        private void NapNganhTheoKhoa()
        {
            
            if (cboNganh.SelectedValue == null) return;
            cboNganh.DataSource = _nganhSvc.GetByKhoa(cboNganh.SelectedValue.ToString());
            cboNganh.DisplayMember = "TenNganh";
            cboNganh.ValueMember = "MaNganh";
        }

        private void cboKhoa_SelectionChangeCommitted(object sender, EventArgs e) { NapNganhTheoKhoa(); }

        private void SetupGrid()
        {
            dgvLop.AutoGenerateColumns = false;
            dgvLop.Columns.Clear();
            dgvLop.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaLop", HeaderText = "Mã lớp" });
            dgvLop.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TenLop", HeaderText = "Tên lớp" });
            dgvLop.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaNganh", HeaderText = "Mã ngành" });
            dgvLop.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NienKhoa", HeaderText = "Niên khóa" });
        }

        private void LoadData()
        {
            string ma = cboLocNganh.SelectedValue == null ? "" : cboLocNganh.SelectedValue.ToString();
            dgvLop.DataSource = ma == "" ? _svc.GetAll() : _svc.GetByNganh(ma);
        }

        private void cboLocNganh_SelectionChangeCommitted(object sender, EventArgs e) { LoadData(); }

        private void LamMoi()
        {
            txtMaLop.Clear();
            txtTenLop.Clear();
            txtNienKhoa.Clear();
            txtMaLop.ReadOnly = false;
            _dangThem = true;
            txtMaLop.Focus();
        }

        // Lớp chỉ biết MaNganh nên phải tìm ngược lên khoa để chọn lại đúng cả 2 ComboBox
        private void dgvLop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var l = dgvLop.Rows[e.RowIndex].DataBoundItem as LopSinhHoat;
            if (l == null) return;

            txtMaLop.Text = l.MaLop;
            txtMaLop.ReadOnly = true;
            txtTenLop.Text = l.TenLop;
            txtNienKhoa.Text = l.NienKhoa.ToString();
            // Gán SelectedValue cho cboNganh an toàn (.Trim() tránh dính khoảng trắng CSDL)
            if (!string.IsNullOrEmpty(l.MaNganh))
            {
                cboNganh.SelectedValue = l.MaNganh.Trim();
            }
            else
            {
                cboNganh.SelectedIndex = -1;
            }
            _dangThem = false;
        }

        private void btnThem_Click(object sender, EventArgs e) {
            var l = new LopSinhHoat
            {
                MaLop = txtMaLop.Text.Trim(),
                TenLop = txtTenLop.Text.Trim(),
                NienKhoa = txtNienKhoa.Text.Trim(),
                MaNganh = cboNganh.SelectedValue == null ? "" : cboNganh.SelectedValue.ToString()
            };

            Result r = _svc.ThemMoi(l);
            HienThongBao(r);

            if (r.Success)
            {
                LoadData();
                LamMoi();
            }

        }
        private void btnLamMoi_Click(object sender, EventArgs e) { LamMoi(); LoadData(); }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            var l = new LopSinhHoat
            {
                MaLop = txtMaLop.Text.Trim(),
                TenLop = txtTenLop.Text.Trim(),
                MaNganh = cboNganh.SelectedValue == null ? "" : cboNganh.SelectedValue.ToString(),
                // Nếu cột NienKhoa trong dbml là int: dùng int.Parse(txtNienKhoa.Text.Trim())
                NienKhoa = txtNienKhoa.Text.Trim()
            };
            Result r =  _svc.Luu(l);
            HienThongBao(r);
            if (r.Success) { LoadData(); LamMoi(); }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaLop.Text)) { MessageBox.Show("Hãy chọn lớp cần xóa."); return; }
            if (MessageBox.Show("Xóa lớp " + txtMaLop.Text + "?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            Result r = _svc.Xoa(txtMaLop.Text.Trim());
            HienThongBao(r);
            if (r.Success) { LoadData(); LamMoi(); }
        }

        private void HienThongBao(Result r)
        {
            MessageBox.Show(r.Message, "Thông báo", MessageBoxButtons.OK,
                r.Success ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
        }

        private void frmLopSinhHoat_Load_1(object sender, EventArgs e)
        {

        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {

        }

        private void cboLocNganh_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
