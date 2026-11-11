using QLSV.DTOs;
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
namespace QLSV.Forms.Enroll
{
    public partial class frmDangKyHocPhan : Form
    {
        private readonly DangKyService _sv = new DangKyService();
        public frmDangKyHocPhan()
        {
            InitializeComponent();
        }

        private void frmDangKyHocPhan_Load(object sender, EventArgs e)
        {
            string maSV = SessionManager.CurrentUser.MaSV;
            if (!string.IsNullOrEmpty(maSV))
            {
                txtMaSV.Text = maSV;
                txtMaSV.ReadOnly = true;
            }

            cboHocKy.DisplayMember = "MaHK";
            cboHocKy.ValueMember = "MaHK";
            cboHocKy.DataSource = _sv.GetHocKy();
            TaiLai();
        }

        private void TaiLai()
        {
            string maHK = cboHocKy.SelectedValue as string;
            if (maHK == null) return;

            dgvLopMo.DataSource = _sv.GetLopMo(maHK);
            List<LopDangKyDTO> daDK = _sv.GetDaDangKy(txtMaSV.Text, maHK);
            dgvDaDangKy.DataSource = daDK;
            lblTinChi.Text = "Đã đăng ký: " + daDK.Sum(x => x.SoTinChi) + " tín chỉ (cần từ 14 đến 25)";
        }

        private void cboHocKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            TaiLai();
        }

        private void btnTai_Click(object sender, EventArgs e)
        {
            TaiLai();

        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            List<string> dsLop = dgvLopMo.SelectedRows.Cast<DataGridViewRow>()
                                .Select(r => ((LopDangKyDTO)r.DataBoundItem).MaLHP)
                                .ToList();

            Result kq = _sv.DangKy(txtMaSV.Text, dsLop);
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
