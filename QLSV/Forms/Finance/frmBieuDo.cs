
using QLSV.Services;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QLSV.Forms.Finance
{
    public partial class frmBieuDo : Form
    {
        private readonly ThongKeService _thongKeService = new ThongKeService();

        public frmBieuDo()
        {
            InitializeComponent();

            // Không cho tự sinh cột/dữ liệu không cần thiết
            chartKhoa.Visible = false;
            chartDoanhThu.Visible = false;
            chartHocLuc.Visible = false;
            chartTopMon.Visible = false;
        }


        // LOAD FORM
  
        private void frmChartDashboard_Load(object sender, EventArgs e)
        {
            // Thiết lập năm
            nudNam.Minimum = 2000;
            nudNam.Maximum = 2100;
            nudNam.Value = DateTime.Now.Year;

            // Học kỳ
            cboHocKy.SelectedIndex = 0;

            // Loại biểu đồ

            cboLoaiBieuDo.SelectedIndex = 0;

            // Tự động tải biểu đồ đầu tiên
            btnLoc_Click(null, EventArgs.Empty);
        }

    
        // LỌC DỮ LIỆU
    
        private void btnLoc_Click(object sender, EventArgs e)
        {
            if (cboLoaiBieuDo.SelectedIndex < 0)
            {
                MessageBox.Show(
                    "Vui lòng chọn loại biểu đồ!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                return;
            }

            int nam = (int)nudNam.Value;

            string namBatDau = (nam % 100).ToString("00");
            string namKetThuc = ((nam + 1) % 100).ToString("00");

            string maHK =
                $"{cboHocKy.SelectedItem}_{namBatDau}{namKetThuc}";
            //MessageBox.Show(
            //    $"Mã học kỳ: {maHK}",
            //    "Thông báo",
            //    MessageBoxButtons.OK,
            //    MessageBoxIcon.Information
            //);
            // Ẩn tất cả biểu đồ trước khi hiển thị
            AnTatCaBieuDo();

            try
            {
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải biểu đồ!\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

 
        // ẨN TẤT CẢ BIỂU ĐỒ

        private void AnTatCaBieuDo()
        {
            chartKhoa.Visible = false;
            chartDoanhThu.Visible = false;
            chartHocLuc.Visible = false;
            chartTopMon.Visible = false;
        }

     
        // 1. BIỂU ĐỒ SINH VIÊN THEO KHOA

        private void LoadBieuDoKhoa()
        {
            var data = _thongKeService.SoSinhVienTheoKhoa();

            chartKhoa.Series.Clear();
            chartKhoa.Titles.Clear();

            Series s = new Series("SinhVien");

            s.ChartType = SeriesChartType.Column;
            s.IsValueShownAsLabel = true;
            s.Label = "#VALY";

            foreach (var item in data)
            {
                s.Points.AddXY(item.Nhan, item.GiaTri);
            }

            chartKhoa.Series.Add(s);

            chartKhoa.Titles.Add(
                "SỐ LƯỢNG SINH VIÊN THEO KHOA"
            );
        }


        // 2. BIỂU ĐỒ DOANH THU 12 THÁNG

        private void LoadBieuDoDoanhThu(int nam)
        {
            var data = _thongKeService.DoanhThu12Thang(nam);

            chartDoanhThu.Series.Clear();
            chartDoanhThu.Titles.Clear();

            Series s = new Series("DoanhThu");

            s.ChartType = SeriesChartType.Line;
            s.BorderWidth = 3;
            s.MarkerStyle = MarkerStyle.Circle;
            s.MarkerSize = 8;
            s.IsValueShownAsLabel = true;
            s.Label = "#VALY{N0}";

            foreach (var item in data)
            {
                s.Points.AddXY(
                    item.TieuDe,
                    item.TongDoanhThu
                );
            }

            chartDoanhThu.Series.Add(s);

            chartDoanhThu.Titles.Add(
                $"DOANH THU HỌC PHÍ 12 THÁNG NĂM {nam}"
            );
        }


        // 3. BIỂU ĐỒ TỈ LỆ XẾP LOẠI HỌC LỰC

        private void LoadBieuDoHocLuc(string maHK)
        {
            var data =
                _thongKeService.TyLeXepLoaiHocLuc(maHK);
            if (data.Sum(x => x.GiaTri) == 0)
            {
                chartHocLuc.Series.Clear();
                chartHocLuc.Titles.Clear();
                chartHocLuc.Titles.Add($"Không có dữ liệu điểm cho {maHK}");
                return;
            }
            chartHocLuc.Series.Clear();
            chartHocLuc.Titles.Clear();

            Series s = new Series("HocLuc");

            s.ChartType = SeriesChartType.Pie;
            s.IsValueShownAsLabel = true;
            s.Label = "#VALX: #VALY (#PERCENT{P0})";

            foreach (var item in data)
            {
                s.Points.AddXY(
                    item.Nhan,
                    item.GiaTri
                );
            }

            chartHocLuc.Series.Add(s);

            chartHocLuc.Titles.Add(
                $"TỈ LỆ XẾP LOẠI HỌC LỰC - {maHK}"
            );
        }

    
        // 4. BIỂU ĐỒ TOP 5 MÔN ĐÔNG NHẤT

        private void LoadBieuDoTopMon(string maHK)
        {
            var data =
                _thongKeService.Top5MonDongNhat(maHK);

            chartTopMon.Series.Clear();
            chartTopMon.Titles.Clear();

            Series s = new Series("TopMon");

            s.ChartType = SeriesChartType.Bar;
            s.IsValueShownAsLabel = true;
            s.Label = "#VALY";

            foreach (var item in data)
            {
                s.Points.AddXY(
                    item.Nhan,
                    item.GiaTri
                );
            }

            chartTopMon.Series.Add(s);

            chartTopMon.Titles.Add(
                $"TOP 5 MÔN HỌC ĐÔNG NHẤT - {maHK}"
            );
        }

       
        // THAY ĐỔI LOẠI BIỂU ĐỒ
  
        private void cboLoaiBieuDo_SelectedIndexChanged(object sender,EventArgs e)
        {
            AnTatCaBieuDo();
        }

        private void chartTopMon_Click(object sender, EventArgs e)
        {
        }
        private void cboHocKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
