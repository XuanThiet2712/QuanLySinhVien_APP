using Microsoft.Reporting.WinForms;
using QLSV.DTOs;
using QLSV.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace QLSV.Forms.Report
{
    public partial class frmInDoanhThu : Form
    {
        private List<DoanhThuDTO> _data;
        private DateTime _tuNgay;
        private DateTime _denNgay;

        // Mặc định: đầu tháng -> hôm nay (data sẽ nạp trong Load)
        public frmInDoanhThu()
        {
            InitializeComponent();
            _tuNgay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            _denNgay = DateTime.Now;
        }

        public frmInDoanhThu(List<DoanhThuDTO> data, DateTime tuNgay, DateTime denNgay)
        {
            InitializeComponent();
            _data = data;
            _tuNgay = tuNgay;
            _denNgay = denNgay;
        }

        private void frmInDoanhThu_Load(object sender, EventArgs e)
        {
            if (_data == null)
            {
                var rs = new DoanhThuService().ThongKeTheoNgay(_tuNgay, _denNgay);
                // chỉnh theo class Result của bạn (IsSuccess/Data...)
                if (!rs.Success)
                {
                    MessageBox.Show(rs.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                _data = rs.Data;
            }

            reportViewer1.LocalReport.ReportEmbeddedResource = "QLSV.Forms.Report.rptDoanhThu.rdlc";

            reportViewer1.LocalReport.SetParameters(new[]
            {
                new ReportParameter("TuNgay", _tuNgay.ToString("dd/MM/yyyy")),
                new ReportParameter("DenNgay", _denNgay.ToString("dd/MM/yyyy"))
            });

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", _data));
            reportViewer1.RefreshReport();
        }
    }
}