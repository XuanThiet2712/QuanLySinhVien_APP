using QLSV.DTOs;
using QLSV.Helpers;
using QLSV.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace QLSV.Forms.Enroll
{
    public partial class frmDangKyHocPhan : Form
    {
        private readonly DangKyService _sv = new DangKyService();

        private List<LopDangKyDTO> _tatCa = new List<LopDangKyDTO>();   // tất cả lớp mở của học kỳ
        private List<LopDangKyDTO> _daDK = new List<LopDangKyDTO>();    // lớp sinh viên đã đăng ký
        private List<string> _daChon = new List<string>();              // mã lớp đang được tích

        public frmDangKyHocPhan()
        {
            InitializeComponent();
            dgvLopMo.AutoGenerateColumns = false;
            dgvDaDangKy.AutoGenerateColumns = false;
        }

        private void frmDangKyHocPhan_Load(object sender, EventArgs e)
        {
            string maSV = SessionManager.CurrentUser.MaSV;
            if (!string.IsNullOrEmpty(maSV))
            {
                txtMaSV.Text = maSV;
                txtMaSV.ReadOnly = true;
            }

            cboThu.Items.AddRange(new object[] { "Tất cả thứ", "Thứ 2", "Thứ 3", "Thứ 4", "Thứ 5", "Thứ 6", "Thứ 7" });
            cboThu.SelectedIndex = 0;
            cboTrangThai.Items.AddRange(new object[] { "Tất cả trạng thái", "Còn chỗ", "Đã đầy", "Đã đăng ký" });
            cboTrangThai.SelectedIndex = 0;

            cboHocKy.DisplayMember = "MaHK";
            cboHocKy.ValueMember = "MaHK";
            cboHocKy.DataSource = _sv.GetHocKy();

            NapThongTinSV();
            TaiLai();
        }

        // Thông tin sinh viên: họ tên, khoa, lớp, ảnh
        private void NapThongTinSV()
        {
            picAnh.Image = null;
            txtHoTen.Text = txtKhoa.Text = txtLop.Text = "";

            ThongTinSvDangKyDTO tt = _sv.GetThongTinSV(txtMaSV.Text);
            if (tt == null) return;

            txtHoTen.Text = tt.HoTen;
            txtKhoa.Text = tt.TenKhoa;
            txtLop.Text = tt.TenLop;
            if (tt.Anh != null) picAnh.Image = Image.FromStream(new MemoryStream(tt.Anh));
        }

        // Tải lớp mở + lớp đã đăng ký của học kỳ đang chọn
        private void TaiLai()
        {
            string maHK = cboHocKy.SelectedValue as string;
            if (maHK == null) return;

            _tatCa = _sv.GetLopMo(maHK);
            _daDK = _sv.GetDaDangKy(txtMaSV.Text, maHK);

            // Gán trạng thái cho từng lớp
            foreach (var l in _tatCa)
            {
                if (_daDK.Any(d => d.MaLHP == l.MaLHP)) l.TrangThai = "Đã đăng ký";
                else if (l.DaDangKy >= l.SiSoToiDa) l.TrangThai = "Đã đầy";
                else l.TrangThai = "Còn chỗ";
            }

            _daChon.Clear();
            LocDanhSach(null, EventArgs.Empty);

            dgvDaDangKy.DataSource = _daDK;
            CapNhatTongKet();
        }

        // Lọc theo ô tìm kiếm + thứ + trạng thái
        private void LocDanhSach(object sender, EventArgs e)
        {
            string kw = txtTim.Text.Trim().ToLower();
            IEnumerable<LopDangKyDTO> q = _tatCa;

            if (kw != "")
                q = q.Where(x => x.MaLHP.ToLower().Contains(kw)
                              || x.MaMon.ToLower().Contains(kw)
                              || x.TenMon.ToLower().Contains(kw));
            if (cboThu.SelectedIndex > 0)
                q = q.Where(x => "Thứ " + x.Thu == cboThu.Text);
            if (cboTrangThai.SelectedIndex > 0)
                q = q.Where(x => x.TrangThai == cboTrangThai.Text);

            List<LopDangKyDTO> ds = q.ToList();
            dgvLopMo.DataSource = ds;
            lblTong.Text = "Tổng " + ds.Count + " lớp học phần";
        }

        // Sau khi bảng nạp xong: tích lại ô đã chọn, khoá ô của lớp đã đăng ký / đã đầy
        private void dgvLopMo_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow r in dgvLopMo.Rows)
            {
                var l = (LopDangKyDTO)r.DataBoundItem;
                DataGridViewCell o = r.Cells[colChon.Index];

                if (l.TrangThai == "Còn chỗ")
                {
                    o.Value = _daChon.Contains(l.MaLHP);
                }
                else
                {
                    o.Value = false;
                    o.ReadOnly = true;
                    r.DefaultCellStyle.ForeColor = (l.TrangThai == "Đã đăng ký") ? Color.SeaGreen : Color.Firebrick;
                }
            }
            dgvLopMo.ClearSelection();
            CapNhatNutDangKy();
        }

        // Bấm vào ô checkbox là ghi nhận ngay
        private void dgvLopMo_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvLopMo.IsCurrentCellDirty)
                dgvLopMo.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        // Tích / bỏ tích thì cập nhật danh sách đã chọn
        private void dgvLopMo_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != colChon.Index) return;

            var l = (LopDangKyDTO)dgvLopMo.Rows[e.RowIndex].DataBoundItem;
            bool tich = Convert.ToBoolean(dgvLopMo.Rows[e.RowIndex].Cells[colChon.Index].Value);

            if (tich && !_daChon.Contains(l.MaLHP)) _daChon.Add(l.MaLHP);
            if (!tich) _daChon.Remove(l.MaLHP);
            CapNhatNutDangKy();
        }

        private void CapNhatNutDangKy()
        {
            btnDangKy.Text = "+ Đăng ký lớp đã chọn (" + _daChon.Count + ")";
            btnDangKy.Enabled = _daChon.Count > 0;
        }

        // Tổng tín chỉ + thanh tiến độ
        private void CapNhatTongKet()
        {
            int tong = _daDK.Sum(x => x.SoTinChi);
            int pct = Math.Min(100, (int)Math.Round(tong * 100.0 / GioiHanTinChi.ToiDa));

            lblDaDK.Text = "Đã đăng ký : " + tong + " Tín chỉ";
            lblToiThieu.Text = "Tối thiểu : " + GioiHanTinChi.ToiThieu + " tín chỉ";
            lblToiDa.Text = "Tối đa : " + GioiHanTinChi.ToiDa + " tín chỉ";
            pgTinChi.Value = pct;
            lblPhanTram.Text = pct + "%";
            lblTienDo.Text = "Bạn đã đăng ký " + tong + "/" + GioiHanTinChi.ToiDa + " tín chỉ";
        }

        private void cboHocKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            TaiLai();
        }

        private void btnTai_Click(object sender, EventArgs e)
        {
            NapThongTinSV();
            TaiLai();
        }

        private void txtMaSV_Leave(object sender, EventArgs e)
        {
            NapThongTinSV();
            TaiLai();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            Result kq = _sv.DangKy(txtMaSV.Text, _daChon.ToList());
            MessageBox.Show(kq.Message, kq.Success ? "Thành công" : "Không đăng ký được");
            if (kq.Success) TaiLai();
        }

        private void btnHuyDK_Click(object sender, EventArgs e)
        {
            if (dgvDaDangKy.CurrentRow == null) return;
            var lop = (LopDangKyDTO)dgvDaDangKy.CurrentRow.DataBoundItem;

            if (MessageBox.Show("Hủy đăng ký lớp " + lop.MaLHP + " - " + lop.TenMon + "?",
                "Xác nhận", MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            Result kq = _sv.Huy(txtMaSV.Text, lop.MaLHP);
            MessageBox.Show(kq.Message);
            if (kq.Success) TaiLai();
        }
    }
}