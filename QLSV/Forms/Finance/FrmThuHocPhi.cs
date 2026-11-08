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

namespace QLSV.Forms.Finance
{
    public partial class FrmThuHocPhi : Form
    {
        private readonly FeeService _feeService = new FeeService();
        public FrmThuHocPhi()
        {
            InitializeComponent();
        }

        private void lblHoTen_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void lblPhaiThu_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmThuHocPhi_Load(object sender, EventArgs e)
        {
            btnLapPhieu.Enabled = SessionManager.HasPermission(MaChucNang.THU_HOC_PHI);
        }

        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            var r = _feeService.TinhHocPhi(txtMaSV.Text.Trim(), txtMaHK.Text.Trim());

            if (!r.Success)
            {
                MessageBox.Show(r.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Reset lại giao diện nếu nhập sai mã
                lblHoTen.Text = "...";
                lblTongTC.Text = "0";
                lblPhaiThu.Text = "0 đ";
                lblDaThu.Text = "0 đ";
                lblConNo.Text = "0 đ";
                nudSoTienThu.Value = 0;
                return;
            }

            var hp = r.Data; // Lấy HocPhiDTO ra khỏi Result

            // In dữ liệu lên các Label
            lblHoTen.Text = hp.HoTen;
            lblTongTC.Text = hp.TongTinChi.ToString();
            lblPhaiThu.Text = hp.PhaiThu.ToString("N0") + " đ";
            lblDaThu.Text = hp.DaThu.ToString("N0") + " đ";
            lblConNo.Text = hp.ConNo.ToString("N0") + " đ";

            // Tự động điền số tiền gợi ý vào ô nhập tiền bằng đúng số còn nợ
            if (hp.ConNo > 0)
            {
                nudSoTienThu.Maximum = hp.ConNo;
                nudSoTienThu.Value = hp.ConNo;
            }
            else
            {
                nudSoTienThu.Maximum = 100000000;
                nudSoTienThu.Value = 0;
            }
        }

        private void btnLapPhieu_Click(object sender, EventArgs e)
        {
            decimal soTien = nudSoTienThu.Value;
            if (soTien <= 0)
            {
                MessageBox.Show("Vui lòng nhập số tiền thu lớn hơn 0.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy mã người dùng đang đăng nhập. Nếu test trực tiếp bỏ qua Form Login thì mặc định gán là 1
            int maNguoiLap = SessionManager.IsLoggedIn ? SessionManager.CurrentUser.MaND : 1;

            // Gọi hàm lập phiếu
            var r = _feeService.LapPhieuThu(
                txtMaSV.Text.Trim(),
                txtMaHK.Text.Trim(),
                soTien,
                txtGhiChu.Text.Trim(),
                maNguoiLap
            );

            if (r.Success)
            {
                MessageBox.Show(r.Message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Thu thành công thì làm sạch ô ghi chú và tự động bấm nút Tra cứu để load lại công nợ
                txtGhiChu.Text = "";
                btnTraCuu.PerformClick();
            }
            else
            {
                MessageBox.Show(r.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
