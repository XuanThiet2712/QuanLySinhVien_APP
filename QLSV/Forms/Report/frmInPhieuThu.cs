using Microsoft.Reporting.WinForms;
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
    public partial class frmInPhieuThu : Form
    {
        private readonly string _maPhieu;
        private readonly string _ngayLap;
        private readonly string _tenSV;
        private readonly string _soTien;
        public frmInPhieuThu(string maPhieu, DateTime ngayLap, string tenSV, decimal soTien)
        {
            InitializeComponent();
            _maPhieu = maPhieu;
            _ngayLap = ngayLap.ToString("dd/MM/yyyy HH:mm");
            _tenSV = tenSV;
            _soTien = soTien.ToString("N0") + " đ";

            reportViewer1.Dock = DockStyle.Fill;
            Load += frmInPhieuThu_Load;
        }

        private void frmInPhieuThu_Load(object sender, EventArgs e)
        {
            try
            {
                reportViewer1.LocalReport.ReportEmbeddedResource = "QLSV.Forms.Report.rptPhieuThu.rdlc";

                reportViewer1.LocalReport.SetParameters(new[]
                {
                    new ReportParameter("MaPhieu", _maPhieu),
                    new ReportParameter("NgayLap", _ngayLap),
                    new ReportParameter("TenSV",   _tenSV),
                    new ReportParameter("SoTien",  _soTien)
                });

                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                Exception root = ex;
                while (root.InnerException != null) root = root.InnerException;
                MessageBox.Show(root.Message, "Lỗi report");
            }
        }
    }
}
