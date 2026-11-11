using Microsoft.Reporting.WinForms;
using QLSV.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV.Forms.Report
{
    public partial class frmInDoanhThu : Form
    {
        private List<DoanhThuDTO> _data;
        private string _tuNgay;
        private string _denNgay;
        public frmInDoanhThu()
        {
            InitializeComponent();
            // Mặc định lấy từ đầu tháng hiện tại đến hôm nay
            _tuNgay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            _denNgay = DateTime.Now;
            
            var service = new DoanhThuService();
            _data = service.ThongKeTheoNgay(_tuNgay, _denNgay);
        }
        public frmInDoanhThu(List<DoanhThuDTO> data, DateTime tuNgay, DateTime denNgay)
        {
            InitializeComponent();
            _data = data;
            _tuNgay = tuNgay.ToString("dd/MM/yyyy");
            _denNgay = denNgay.ToString("dd/MM/yyyy");

            // Tự động tạo và gắn ReportViewer tràn màn hình Form
            reportViewer1 = new ReportViewer();
            reportViewer1.Dock = DockStyle.Fill;
            this.Controls.Add(reportViewer1);
        }

        private void frmInDoanhThu_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.ReportPath = "Reports/rptDoanhThu.rdlc";

            ReportParameter[] param = new ReportParameter[2];
            param[0] = new ReportParameter("TuNgay", _tuNgay);
            param[1] = new ReportParameter("DenNgay", _denNgay);
            reportViewer1.LocalReport.SetParameters(param);

            ReportDataSource rds = new ReportDataSource("DataSet1", _data);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);

            reportViewer1.RefreshReport();
        }
    }
}
