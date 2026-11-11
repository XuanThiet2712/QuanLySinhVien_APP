using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLSV.Data;
using QLSV.DTOs;
using QLSV.Services;
using QLSV.Helpers;
using System.Runtime.CompilerServices;

namespace QLSV.Forms.Report
{
    public partial class frmLopHocPhan : Form
    {
        private readonly LopHocPhanService _service = new LopHocPhanService();
        private string _maDangChon = null;
        public frmLopHocPhan()
        {
            InitializeComponent();
        }
        private void frmLopHocPhan_Load(object sender, EventArgs e)
        {
            try
            {
                LoadCombobox();
                LoadDanhSach();
                //ktra quyen
                bool coQuyen = SessionManager.HasPermission(MaChucNang.QL_LOPHOCPHAN);
                btnThem.Enabled = coQuyen;
                btnSua.Enabled = coQuyen;
                btnXoa.Enabled = coQuyen;
                LamMoiNhap();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            LopHocPhan lhp = LayDuLieu();
            if (lhp == null) return;
            Result kq = _service.ThemMoi(lhp);
            MessageBox.Show(kq.Message);
            if (kq.Success)
            {
                LoadDanhSach();
                LamMoiNhap();
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_maDangChon == null)
            {
                MessageBox.Show("Vui lòng chọn lớp cần sửa");
                return;
            }
            LopHocPhan lhp = LayDuLieu();
            if (lhp == null) return;

            if (lhp.MaLHP != _maDangChon)
            {
                MessageBox.Show("Không được thay đổi mã lớp.");
                return;
            }
            Result kq = _service.Luu(lhp);
            MessageBox.Show(kq.Message);
            if (kq.Success)
            {
                LoadDanhSach();
                LamMoiNhap();
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_maDangChon == null)
            {
                MessageBox.Show("Vui lòng chọn lớp cần xóa.");
                return;
            }

            DialogResult xacNhan = MessageBox.Show(
                "Bạn có chắc muốn xóa lớp này?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (xacNhan != DialogResult.Yes)
                return;

            Result kq = _service.Xoa(_maDangChon);

            MessageBox.Show(kq.Message);

            if (kq.Success)
            {
                LoadDanhSach();
                LamMoiNhap();
            }

        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoiNhap();
            LoadDanhSach();
        }
        private void LamMoiNhap()
        {
            _maDangChon = null;

            txtMaLHP.Clear();
            txtMaLHP.ReadOnly = false;
            txtPhong.Clear();

            if (cboHocKy.Items.Count > 0)
                cboHocKy.SelectedIndex = 0;

            if (cboMonHoc.Items.Count > 0)
                cboMonHoc.SelectedIndex = 0;

            if (cboGiangVien.Items.Count > 0)
                cboGiangVien.SelectedIndex = 0;

            if (cboThu.Items.Count > 0)
                cboThu.SelectedIndex = 0;

            nudTietBatDau.Value = 1;
            nudSoTiet.Value = 3;
            nudSiSoToiDa.Value = 40;

            dgvLopHocPhan.ClearSelection();
        }
        private void LoadDanhSach()
        {
            dgvLopHocPhan.AutoGenerateColumns = false;
            dgvLopHocPhan.DataSource = _service.Search(null, null, null);
            dgvLopHocPhan.ClearSelection();
        }
        private void LoadCombobox()
        {
            //hk
            cboHocKy.DisplayMember = "TenHK";
            cboHocKy.ValueMember = "MaHK";
            cboHocKy.DataSource = _service.GetHocKys();
            //mon
            cboMonHoc.DisplayMember = "TenMon";
            cboMonHoc.ValueMember = "MaMon";
            cboMonHoc.DataSource = _service.GetMonHocs();
            //gv
            cboGiangVien.DisplayMember = "TenGV";
            cboGiangVien.ValueMember = "MaGV";
            cboGiangVien.DataSource = _service.GetGiangViens();
        }
        private LopHocPhan LayDuLieu()
        {
            if (cboHocKy.SelectedValue == null ||
                cboMonHoc.SelectedValue == null ||
                cboGiangVien.SelectedValue == null ||
                cboThu.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ thông tin");
                return null;
            }
            return new LopHocPhan
            {
                MaLHP = txtMaLHP.Text.Trim(),
                Phong = txtPhong.Text.Trim(),
                MaHK = cboHocKy.SelectedValue.ToString(),
                MaMon = cboMonHoc.SelectedValue.ToString(),
                MaGV = cboGiangVien.SelectedValue.ToString(),
                Thu = (byte)(cboThu.SelectedIndex),

                TietBatDau = (byte)nudTietBatDau.Value,
                SoTiet = (byte)nudSoTiet.Value,
                SiSoToiDa = (short)nudSiSoToiDa.Value,
            };
        }

        private void dgvLopHocPhan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                if (e.RowIndex < 0) return;

                var dto = dgvLopHocPhan.Rows[e.RowIndex]
                    .DataBoundItem as LopHocPhanDTO;

                if (dto == null) return;

                _maDangChon = dto.MaLHP;

                txtMaLHP.Text = dto.MaLHP;
                txtMaLHP.ReadOnly = true;
                txtPhong.Text = dto.Phong;

                cboHocKy.SelectedValue = dto.MaHK;
                cboMonHoc.SelectedValue = dto.MaMon;
                cboGiangVien.SelectedValue = dto.MaGV;

                // thu2 = vt 0
                cboThu.SelectedIndex = dto.Thu - 2;

                nudTietBatDau.Value = dto.TietBatDau;
                nudSoTiet.Value = dto.SoTiet;
                nudSiSoToiDa.Value = dto.SiSoToiDa;
            }
        }
    }
}
