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
    public partial class frmMonHoc : Form
    {
        private readonly MonHocService _svc = new MonHocService();
        private bool _dangThem = true;

        public frmMonHoc()
        {
            InitializeComponent();
            GanSuKien();
        }

        private void GanSuKien()
        {
            Load += frmMonHoc_Load;
            btnTim.Click += btnTim_Click;
            btnThem.Click += btnThem_Click;
            btnLuu.Click += btnLuu_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamMoi.Click += btnLamMoi_Click;
            dgvMonHoc.CellClick += dgvMonHoc_CellClick;
            cboLocKhoa.SelectionChangeCommitted += cboLocKhoa_SelectionChangeCommitted;
        }

        private void frmMonHoc_Load(object sender, EventArgs e)
        {
            
            bool q = SessionManager.HasPermission(MaChucNang.QL_MONHOC);
            btnThem.Enabled = btnLuu.Enabled = btnXoa.Enabled = q;


            var ds = new KhoaService().GetAll();

            cboLocKhoa.DataSource = new List<Khoa>(ds);
            cboLocKhoa.DisplayMember = "TenKhoa";
            cboLocKhoa.ValueMember = "MaKhoa";

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
            dgvMonHoc.AutoGenerateColumns = false;
            dgvMonHoc.Columns.Clear();
            dgvMonHoc.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaMon", HeaderText = "Mã môn" });
            dgvMonHoc.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TenMon", HeaderText = "Tên môn" });
            dgvMonHoc.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SoTinChi", HeaderText = "Tín chỉ" });
            dgvMonHoc.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaKhoa", HeaderText = "Khoa" });
        }

        private void LoadData()
        {
            string khoa = cboLocKhoa.SelectedValue == null ? "" : cboLocKhoa.SelectedValue.ToString();
            dgvMonHoc.DataSource = _svc.Search(txtTim.Text.Trim(), khoa);
        }

        private void btnTim_Click(object sender, EventArgs e) { LoadData(); }
        private void cboLocKhoa_SelectionChangeCommitted(object sender, EventArgs e) { LoadData(); }

        // maMonDangSua: bỏ môn này khỏi danh sách (không tự là tiên quyết của chính nó)
        // daChon: các mã môn cần tick sẵn
        private void NapTienQuyet(string maMonDangSua, List<string> daChon)
        {
            clbTienQuyet.DisplayMember = "TenMon";
            clbTienQuyet.Items.Clear();
            foreach (MonHoc m in _svc.Search("", ""))
            {
                if (m.MaMon == maMonDangSua) continue;
                clbTienQuyet.Items.Add(m, daChon.Contains(m.MaMon));
            }
        }

        private void LamMoi()
        {
            txtMaMon.Clear();
            txtTenMon.Clear();
            txtMaMon.ReadOnly = false;
            numTinChi.Value = 3;
            if (cboLocKhoa.Items.Count > 0) cboLocKhoa.SelectedIndex = 0;
            NapTienQuyet("", new List<string>());
            _dangThem = true;
            txtMaMon.Focus();
        }

        private void dgvMonHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var m = dgvMonHoc.Rows[e.RowIndex].DataBoundItem as MonHoc;
            if (m == null) return;
            txtMaMon.Text = m.MaMon;
            txtMaMon.ReadOnly = true;
            txtTenMon.Text = m.TenMon;
            numTinChi.Value = m.SoTinChi;
            cboLocKhoa.SelectedValue = m.MaKhoa;
            NapTienQuyet(m.MaMon, _svc.GetTienQuyet(m.MaMon));
            _dangThem = false;
        }

        private List<string> LayTienQuyetDaTick()
        {
            var ds = new List<string>();
            foreach (MonHoc m in clbTienQuyet.CheckedItems) ds.Add(m.MaMon);
            return ds;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var m = new MonHoc
            {
                MaMon = txtMaMon.Text.Trim(),
                TenMon = txtTenMon.Text.Trim(),
                SoTinChi = (byte)numTinChi.Value,
                MaKhoa = cboLocKhoa.SelectedValue == null ? "" : cboLocKhoa.SelectedValue.ToString().Trim()
            };

            List<string> tq = LayTienQuyetDaTick();

            Result r = _svc.ThemMoi(m, tq);
            HienThongBao(r);

            if (r.Success)
            {
                LoadData();
                LamMoi();
            }
        }
        private void btnLamMoi_Click(object sender, EventArgs e) { txtTim.Clear(); LamMoi(); LoadData(); }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            var m = new MonHoc
            {
                MaMon = txtMaMon.Text.Trim(),
                TenMon = txtTenMon.Text.Trim(),
                SoTinChi = (byte)numTinChi.Value,   // nếu cột là byte: (byte)numTinChi.Value
                MaKhoa = cboLocKhoa.SelectedValue == null ? "" : cboLocKhoa.SelectedValue.ToString()
            };
            List<string> tq = LayTienQuyetDaTick();
            Result r = _svc.Luu(m, tq);
            HienThongBao(r);
            if (r.Success) { LoadData(); LamMoi(); }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaMon.Text)) { MessageBox.Show("Hãy chọn môn cần xóa."); return; }
            if (MessageBox.Show("Xóa môn " + txtMaMon.Text + "?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            Result r = _svc.Xoa(txtMaMon.Text.Trim());
            HienThongBao(r);
            if (r.Success) { LoadData(); LamMoi(); }
        }

        private void HienThongBao(Result r)
        {
            MessageBox.Show(r.Message, "Thông báo", MessageBoxButtons.OK,
                r.Success ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {

        }

        private void frmMonHoc_Load_1(object sender, EventArgs e)
        {

        }
    }
}
