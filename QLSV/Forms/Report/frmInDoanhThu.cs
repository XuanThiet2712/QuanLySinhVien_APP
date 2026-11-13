using Microsoft.Reporting.WinForms;
using QLSV.DTOs;
using QLSV.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QLSV.Forms.Report
{
    public partial class frmInDoanhThu : Form
    {
        private List<DoanhThuDTO> _data;
        private DateTime _tuNgay;
        private DateTime _denNgay;

        // Mở mặc định: đầu tháng -> hôm nay
        public frmInDoanhThu()
        {
            InitializeComponent();
            btnXem.Click += btnXem_Click;
            _tuNgay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            _denNgay = DateTime.Now;
        }

        // Mở với dữ liệu có sẵn
        public frmInDoanhThu(List<DoanhThuDTO> data, DateTime tuNgay, DateTime denNgay)
        {
            InitializeComponent();
            _data = data;
            _tuNgay = tuNgay;
            _denNgay = denNgay;
        }

        private void frmInDoanhThu_Load(object sender, EventArgs e)
        {
            dtpTuNgay.Value = _tuNgay;
            dtpDenNgay.Value = _denNgay;
            HienThiReport();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (dtpTuNgay.Value.Date > dtpDenNgay.Value.Date)
            {
                MessageBox.Show("Từ ngày không được lớn hơn Đến ngày.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _tuNgay = dtpTuNgay.Value.Date;
            _denNgay = dtpDenNgay.Value.Date;
            _data = null;      
            HienThiReport();
        }

        private void HienThiReport()
        {
            try
            {
                if (_data == null)
                {
                    var rs = new DoanhThuService().ThongKeTheoNgay(_tuNgay, _denNgay);
                    if (!rs.Success)
                    {
                        MessageBox.Show(rs.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _data = rs.Data;
                }

                reportViewer1.LocalReport.ReportEmbeddedResource =
                    "QLSV.Forms.Report.rptDoanhThu.rdlc";

                reportViewer1.LocalReport.SetParameters(new[]
                {
                    new ReportParameter("TuNgay", _tuNgay.ToString("dd/MM/yyyy")),
                    new ReportParameter("DenNgay", _denNgay.ToString("dd/MM/yyyy"))
                });

                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", _data));
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                Exception root = ex;
                while (root.InnerException != null) root = root.InnerException;
                MessageBox.Show(root.Message, "Lỗi report");
            }
        }

        private void dtpTuNgay_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}