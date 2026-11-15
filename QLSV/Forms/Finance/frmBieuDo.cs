using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using QLSV.Services;

namespace QLSV.Forms.Finance
{
    public partial class frmBieuDo : Form
    {
        private readonly DoanhThuService _thongKeService = new DoanhThuService();

        public frmBieuDo()
        {
            InitializeComponent();
        }

        private void frmChartDashboard_Load(object sender, EventArgs e)
        {
            nudNam.Value = DateTime.Now.Year;
            cboHocKy.Items.Add("HK1");
            cboHocKy.Items.Add("HK2");
            cboHocKy.Items.Add("HK3");
            if (cboHocKy.Items.Count > 0)
                cboHocKy.SelectedIndex = 0;
            cboLoaiBieuDo.Items.Add("Số lượng sinh viên theo Khoa");
            cboLoaiBieuDo.Items.Add("Doanh thu học phí 12 tháng");
            cboLoaiBieuDo.Items.Add("Tỉ lệ xếp loại học lực");
            cboLoaiBieuDo.Items.Add("Top 5 môn học đông nhất");
            if (cboLoaiBieuDo.Items.Count > 0)
                cboLoaiBieuDo.SelectedIndex = 0;

        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            int nam = (int)nudNam.Value;
            string namBatDau = (nam % 100).ToString("00");
            string namKetThuc = ((nam + 1) % 100).ToString("00");
            string maHK = $"{cboHocKy.SelectedItem}_{namBatDau}{namKetThuc}";
            chartKhoa.Visible = false;
            chartDoanhThu.Visible = false;
            chartHocLuc.Visible = false;
            chartTopMon.Visible = false;

            // Kiểm tra xem ComboBox đang chọn mục nào thì Load và Mở Visible cho mục đó
            switch (cboLoaiBieuDo.SelectedIndex)
            {
                case 0:
                    LoadBieuDoKhoa();
                    chartKhoa.Visible = true;
                    break;
                case 1:
                    LoadBieuDoDoanhThu(nam);
                    chartDoanhThu.Visible = true;
                    break;
                case 2:
                    LoadBieuDoHocLuc(maHK);
                    chartHocLuc.Visible = true;
                    break;
                case 3:
                    LoadBieuDoTopMon(maHK);
                    chartTopMon.Visible = true;
                    break;
                default:
                    MessageBox.Show("Vui lòng chọn loại biểu đồ cần xem!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }

        private void LoadBieuDoKhoa()
        {
            var data = _thongKeService.SoSinhVienTheoKhoa();

            chartKhoa.Series.Clear();
            Series s = new Series("SinhVien");
            s.ChartType = SeriesChartType.Column;
            s.IsValueShownAsLabel = true;

            foreach (var item in data)
            {
                s.Points.AddXY(item.Nhan, item.GiaTri);
            }

            chartKhoa.Series.Add(s);
            chartKhoa.Titles.Clear();
            chartKhoa.Titles.Add("SỐ SINH VIÊN THEO KHOA");
        }

        private void LoadBieuDoDoanhThu(int nam)
        {
            var data = _thongKeService.DoanhThu12Thang(nam);

            chartDoanhThu.Series.Clear();
            Series s = new Series("DoanhThu");
            s.ChartType = SeriesChartType.Line;
            s.BorderWidth = 3;
            s.MarkerStyle = MarkerStyle.Circle;
            s.IsValueShownAsLabel = true;

            foreach (var item in data)
            {
                s.Points.AddXY(item.TieuDe, item.TongDoanhThu);
            }

            chartDoanhThu.Series.Add(s);
            chartDoanhThu.Titles.Clear();
            chartDoanhThu.Titles.Add($"DOANH THU 12 THÁNG NĂM {nam}");
        }
        private void LoadBieuDoHocLuc(string maHK)
        {
            var data = _thongKeService.TyLeXepLoaiHocLuc(maHK);

            chartHocLuc.Series.Clear();
            Series s = new Series("HocLuc");
            s.ChartType = SeriesChartType.Pie; 
            s.IsValueShownAsLabel = true;

            foreach (var item in data)
            {
                s.Points.AddXY(item.Nhan, item.GiaTri);
            }

            chartHocLuc.Series.Add(s);
            chartHocLuc.Titles.Clear();
            chartHocLuc.Titles.Add($"TỈ LỆ HỌC LỰC - HỌC KỲ {maHK}");
        }

        // Hàm vẽ biểu đồ Top 5 môn (Column hoặc Bar Chart)
        private void LoadBieuDoTopMon(string maHK)
        {
            var data = _thongKeService.Top5MonDongNhat(maHK);

            chartTopMon.Series.Clear();
            Series s = new Series("TopMon");
            s.ChartType = SeriesChartType.Bar;
            s.IsValueShownAsLabel = true;

            foreach (var item in data)
            {
                s.Points.AddXY(item.Nhan, item.GiaTri);
            }

            chartTopMon.Series.Add(s);
            chartTopMon.Titles.Clear();
            chartTopMon.Titles.Add($"TOP 5 MÔN ĐÔNG NHẤT - HỌC KỲ {maHK}");
        }

        private void cboLoaiBieuDo_SelectedIndexChanged(object sender, EventArgs e)
        {
            chartKhoa.Visible = false;
            chartDoanhThu.Visible = false;
            chartHocLuc.Visible = false;
            chartTopMon.Visible = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}