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
using System.Windows.Forms.DataVisualization.Charting;

namespace QLSV.Forms.Finance
{
    public partial class frmThongKeDoanhThu : Form
    {
        private readonly DoanhThuService _thongKeService = new DoanhThuService();
        public frmThongKeDoanhThu()
        {
            InitializeComponent();
        }

        private void frmThongKeDoanhThu_Load(object sender, EventArgs e)
        {
            dtpTuNgay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpDenNgay.Value = DateTime.Now;
        }
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date;

            if (tuNgay > denNgay)
            {
                MessageBox.Show("Từ ngày không được lớn hơn Đến ngày!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var r = _thongKeService.ThongKeTheoNgay(tuNgay, denNgay);
            if (!r.Success)
            {
                MessageBox.Show(r.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var data = r.Data; 

            dgvDoanhThu.DataSource = data;
            if (dgvDoanhThu.Columns.Count > 0)
            {
                dgvDoanhThu.Columns["TieuDe"].HeaderText = "Ngày";
                dgvDoanhThu.Columns["SoGiaoDich"].HeaderText = "Số Phiếu Thu";
                dgvDoanhThu.Columns["TongDoanhThu"].HeaderText = "Tổng Doanh Thu (VNĐ)";
                dgvDoanhThu.Columns["TongDoanhThu"].DefaultCellStyle.Format = "N0"; 
                dgvDoanhThu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            chartDoanhThu.Series.Clear();

            Series series = new Series("Doanh Thu");
            series.ChartType = SeriesChartType.Column;
            series.IsValueShownAsLabel = true;

            foreach (var item in data)
            {
                series.Points.AddXY(item.TieuDe, item.TongDoanhThu);
            }
            chartDoanhThu.Series.Add(series);

            //tổng tất cả
            decimal tongTatCa = data.Sum(x => x.TongDoanhThu);
            lblTongCong.Text = $"Tổng cộng: {tongTatCa:N0} VNĐ";
        }

        private void chartDoanhThu_Click(object sender, EventArgs e)
        {

        }
    }
}
