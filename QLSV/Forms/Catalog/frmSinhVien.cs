using QLSV.Data;
using QLSV.DTOs;
using QLSV.Helpers;
using QLSV.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV.Forms.Catalog
{
    public partial class frmSinhVien : Form
    {
        private readonly SinhVienService _svc = new SinhVienService();

        private const int PAGE_SIZE = 20;   // số dòng mỗi trang
        private int _page = 1;
        private int _tongTrang = 1;

        private bool _dangThem = true;
        private byte[] _anhMoi = null;      // ảnh vừa chọn từ máy; null = chưa chọn (khi sửa sẽ giữ ảnh cũ)

        public frmSinhVien()
        {
            InitializeComponent();
            GanSuKien();
        }

        private void GanSuKien()
        {
            Load += frmSinhVien_Load;
            btnTim.Click += btnTim_Click;
            btnTruoc.Click += btnTruoc_Click;
            btnSau.Click += btnSau_Click;
            btnChonAnh.Click += btnChonAnh_Click;
            btnImport.Click += btnImport_Click;
            btnExport.Click += btnExport_Click;
            btnThem.Click += btnThem_Click;
            btnLuu.Click += btnLuu_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamMoi.Click += btnLamMoi_Click;
            dgvSinhVien.CellClick += dgvSinhVien_CellClick;
            cboLocLop.SelectionChangeCommitted += cboLocLop_SelectionChangeCommitted;
        }

        private void frmSinhVien_Load(object sender, EventArgs e)
        {
           
            bool q = SessionManager.HasPermission(MaChucNang.QL_SINHVIEN);
            btnThem.Enabled = btnLuu.Enabled = btnXoa.Enabled = q;
            btnImport.Enabled = btnExport.Enabled = q;

            

            NapCboLop();
            SetupGrid();
            LoadData();
            LamMoi();
        }

        private void NapCboLop()
        {
            var ds = new LopSinhHoatService().GetAll();

            cboLocLop.DataSource = new List<LopSinhHoat>(ds);
            cboLocLop.DisplayMember = "TenLop";
            cboLocLop.ValueMember = "MaLop";

            var locDs = new List<LopSinhHoat>(ds);
            locDs.Insert(0, new LopSinhHoat { MaLop = "", TenLop = "-- Tất cả --" });
            cboLocLop.DataSource = locDs;
            cboLocLop.DisplayMember = "TenLop";
            cboLocLop.ValueMember = "MaLop";
        }

        private void SetupGrid()
        {
            dgvSinhVien.AutoGenerateColumns = false;
            dgvSinhVien.Columns.Clear();
            Action<string, string> them = (prop, head) =>
                dgvSinhVien.Columns.Add(new DataGridViewTextBoxColumn
                { Name = prop, DataPropertyName = prop, HeaderText = head });

            them("MaSV", "MSSV");
            them("HoTen", "Họ tên");
            them("NgaySinh", "Ngày sinh");
            them("TenLop", "Lớp");
            them("TenNganh", "Ngành");
            them("TenKhoa", "Khoa");
            dgvSinhVien.Columns["NgaySinh"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        private string LopDangLoc()
        {
            return cboLocLop.SelectedValue == null ? "" : cboLocLop.SelectedValue.ToString();
        }

        //Phân trang 
        private void LoadData()
        {
            string kw = txtTim.Text.Trim();
            string lop = LopDangLoc();

            int tong = _svc.Count(kw, lop);   //  đếm tổng dòng
            //tổng trang = làm tròn LÊN; chia cho double để không bị chia nguyên
            _tongTrang = Math.Max(1, (int)Math.Ceiling(tong / (double)PAGE_SIZE));
            if (_page > _tongTrang) _page = _tongTrang;   // giữ trang trong khoảng hợp lệ
            if (_page < 1) _page = 1;

            dgvSinhVien.DataSource = _svc.Search(kw, lop, _page, PAGE_SIZE);   // lấy đúng 1 trang

            lblTrang.Text = "Trang " + _page + "/" + _tongTrang + "  (" + tong + " SV)";  
            btnTruoc.Enabled = _page > 1;
            btnSau.Enabled = _page < _tongTrang;
        }

        // Tìm kiếm hoặc đổi bộ lọc thì quay về trang 1
        private void btnTim_Click(object sender, EventArgs e) { _page = 1; LoadData(); }
        private void cboLocLop_SelectionChangeCommitted(object sender, EventArgs e) { _page = 1; LoadData(); }
        private void btnTruoc_Click(object sender, EventArgs e) { _page--; LoadData(); }
        private void btnSau_Click(object sender, EventArgs e) { _page++; LoadData(); }

        // Ảnh đại diện
        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog { Filter = "Ảnh|*.jpg;*.jpeg;*.png;*.bmp" })
            {
                if (ofd.ShowDialog() != DialogResult.OK) return;
                _anhMoi = File.ReadAllBytes(ofd.FileName);
                picAnh.Image = ByteToImage(_anhMoi);
            }
        }

        // Không đóng MemoryStream vì Image còn cần nó để vẽ
        private Image ByteToImage(byte[] b)
        {
            var ms = new MemoryStream(b);
            return Image.FromStream(ms);
        }

       
        private void dgvSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var dto = dgvSinhVien.Rows[e.RowIndex].DataBoundItem as SinhVienDTO;
            if (dto == null) return;

            SinhVien s = _svc.GetById(dto.MaSV);   
            if (s == null) return;

            txtMaSV.Text = s.MaSV;
            txtMaSV.ReadOnly = true;
            txtHoTen.Text = s.HoTen;
            dtpNgaySinh.Value = s.NgaySinh;            
            // Đổ dữ liệu Giới tính ra RadioButton trong GroupBox
            if (s.GioiTinh != null && s.GioiTinh.Trim() == "Nữ")
            {
                radNu.Checked = true;
            }
            else
            {
                radNam.Checked = true;
            }
            txtEmail.Text = s.Email;
            txtSDT.Text = s.SDT;
            txtDiaChi.Text = s.DiaChi;
            cboLocLop.SelectedValue = s.MaLop;

            _anhMoi = null;
            picAnh.Image = (s.AnhDaiDien != null) ? ByteToImage(s.AnhDaiDien.ToArray()) : null;
            _dangThem = false;
        }

        private void LamMoi()
        {
            txtMaSV.Clear();
            txtMaSV.ReadOnly = false;
            txtHoTen.Clear();
            txtEmail.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            dtpNgaySinh.Value = DateTime.Today.AddYears(-18);
            radNam.Checked = true;
            if (cboLocLop.Items.Count > 0) cboLocLop.SelectedIndex = 0;
            picAnh.Image = null;
            _anhMoi = null;
            _dangThem = true;
        }

        private void btnLamMoi_Click(object sender, EventArgs e) { LamMoi(); }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var s = new SinhVien
            {
                MaSV = txtMaSV.Text.Trim(),
                HoTen = txtHoTen.Text.Trim(),
                NgaySinh = dtpNgaySinh.Value.Date,
                GioiTinh = radNu.Checked ? "Nữ" : "Nam", // Đọc giá trị từ RadioButton
                Email = txtEmail.Text.Trim(),
                SDT = txtSDT.Text.Trim(),
                DiaChi = txtDiaChi.Text.Trim(),
                MaLop = cboLocLop.SelectedValue == null ? "" : cboLocLop.SelectedValue.ToString().Trim(),
                AnhDaiDien = _anhMoi == null ? null : new Binary(_anhMoi)
            };

            Result r = _svc.ThemMoi(s);
            HienThongBao(r);

            if (r.Success)
            {
                LoadData();
                LamMoi();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            var s = new SinhVien
            {
                MaSV = txtMaSV.Text.Trim(),
                HoTen = txtHoTen.Text.Trim(),
                NgaySinh = dtpNgaySinh.Value.Date,
                GioiTinh = radNu.Checked ? "Nữ" : "Nam", // Đọc giá trị từ RadioButton
                Email = txtEmail.Text.Trim(),
                SDT = txtSDT.Text.Trim(),
                DiaChi = txtDiaChi.Text.Trim(),
                MaLop = cboLocLop.SelectedValue == null ? "" : cboLocLop.SelectedValue.ToString(),
                AnhDaiDien = _anhMoi == null ? null : new Binary(_anhMoi)   // null = giữ ảnh cũ
            };
            Result r = _svc.Luu(s);
            HienThongBao(r);
            if (r.Success) { LoadData(); LamMoi(); }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSV.Text)) { MessageBox.Show("Hãy chọn sinh viên cần xóa."); return; }
            if (MessageBox.Show("Xóa sinh viên " + txtMaSV.Text + "?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            Result r = _svc.Xoa(txtMaSV.Text.Trim());
            HienThongBao(r);
            if (r.Success) { LoadData(); LamMoi(); }
        }

        // Excel 
        private void btnImport_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog { Filter = "Excel|*.xlsx" })
            {
                if (ofd.ShowDialog() != DialogResult.OK) return;

                Result<ImportReport> r = _svc.ImportExcel(ofd.FileName);
                if (!r.Success)
                {
                    MessageBox.Show(r.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string chiTiet = r.Message;
                if (r.Data.DanhSachLoi.Count > 0)
                    chiTiet += "\n\nCác dòng lỗi:\n" + string.Join("\n", r.Data.DanhSachLoi.Take(15));
                MessageBox.Show(chiTiet, "Kết quả nhập", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _page = 1;
                LoadData();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog { Filter = "Excel|*.xlsx", FileName = "DanhSachSinhVien.xlsx" })
            {
                if (sfd.ShowDialog() != DialogResult.OK) return;
                Result r = _svc.ExportExcel(sfd.FileName, LopDangLoc());
                HienThongBao(r);
            }
        }

        private void HienThongBao(Result r)
        {
            MessageBox.Show(r.Message, "Thông báo", MessageBoxButtons.OK,
                r.Success ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
        }

        private void frmSinhVien_Load_1(object sender, EventArgs e)
        {

        }
    }
}

