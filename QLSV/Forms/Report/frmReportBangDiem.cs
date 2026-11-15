using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.Reporting.WinForms;
using QLSV.Helpers;
using QLSV.Services;

namespace QLSV.Forms.Report
{
    public partial class frmReportBangDiem : Form
    {

        private readonly DiemService _diemService = new DiemService();

        private readonly LopHocPhanService _lopService = new LopHocPhanService();

        public frmReportBangDiem()
        {
            InitializeComponent();
        }

        private void frmReportBangDiem_Load(
            object sender, EventArgs e)
        {
            try
            {
                bool xemBangDiem =SessionManager.HasPermission(
                        MaChucNang.XEM_DIEM);

                bool xemDanhSach =SessionManager.HasPermission(
                        MaChucNang.NHAP_DIEM) ||
                    SessionManager.HasPermission(
                        MaChucNang.QL_LOPHOCPHAN);

                if (!xemBangDiem && !xemDanhSach)
                {
                    MessageBox.Show("Không có quyền xem báo cáo.");
                    Close();
                    return;
                }

                btnXem.Enabled = xemBangDiem;
                txtMaSV.Enabled = xemBangDiem;
                cboHocKy.Enabled = xemBangDiem;

                btnDanhSachLop.Enabled = xemDanhSach;
                cboLopHocPhan.Enabled = xemDanhSach;

                if (xemBangDiem)
                {
                    cboHocKy.DisplayMember = "TenHK";
                    cboHocKy.ValueMember = "MaHK";
                    cboHocKy.DataSource = _lopService.GetHocKys();

                    if (SessionManager.IsInRole(MaNhom.SV))
                    {
                        txtMaSV.Text =SessionManager.CurrentUser.MaSV;
                        txtMaSV.ReadOnly = true;
                    }
                }

                if (xemDanhSach)
                {
                    string maGV = null;

                    if (SessionManager.IsInRole(MaNhom.GV))
                        maGV = SessionManager.CurrentUser.MaGV;

                    cboLopHocPhan.DisplayMember = "MaLHP";
                    cboLopHocPhan.ValueMember = "MaLHP";
                    cboLopHocPhan.DataSource =_lopService.Search(null, null, maGV);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải báo cáo: " + ex.Message);
            }
        }


        private void btnXem_Click(object sender, EventArgs e)
        {
            try
            {
                string maSV = txtMaSV.Text.Trim();
                string maHK = cboHocKy.SelectedValue as string;

                if (maSV == "" || maHK == null)
                {
                    MessageBox.Show("Vui lòng chọn đủ thông tin.");
                    return;
                }

                var ds = _diemService.GetBangDiem(maSV, maHK);

                if (ds.Count == 0)
                {
                    MessageBox.Show("Không có bảng điểm được phép xem.");
                    return;
                }

                string duongDan = Path.Combine(
                    Application.StartupPath,
                    "Forms",
                    "Report",
                    "rptBangDiem.rdlc");

                if (!File.Exists(duongDan))
                {
                    MessageBox.Show("Không tìm thấy rptBangDiem.rdlc");
                    return;
                }

                string gpa = SessionManager.IsInRole(MaNhom.GV)
                    ? "Không áp dụng"
                    : _diemService.TinhGPA(maSV, maHK)
                        .ToString("0.00");

                reportViewer1.Reset();
                reportViewer1.ProcessingMode =
                    ProcessingMode.Local;

                reportViewer1.LocalReport.ReportPath = duongDan;
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(
                    new ReportDataSource("BangDiemDataSet", ds));

                reportViewer1.LocalReport.SetParameters(
                    new ReportParameter[]
                    {
                new ReportParameter("MaSV", maSV),
                new ReportParameter("HoTen", ds[0].HoTen),
                new ReportParameter("TenHK", cboHocKy.Text),
                new ReportParameter("GPA", gpa)
                    });

                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi xem bảng điểm: " + ex.Message);
            }
        }


        private void btnDanhSachLop_Click(object sender, EventArgs e)
        {
            try
            {
                var lop = cboLopHocPhan.SelectedItem
                    as QLSV.DTOs.LopHocPhanDTO;

                if (lop == null)
                {
                    MessageBox.Show("Vui lòng chọn lớp học phần.");
                    return;
                }

                var ds = _lopService.GetDanhSachLopBaoCao(
                    lop.MaLHP);
                if (ds.Count == 0)
                {
                    MessageBox.Show("Lớp chưa có sinh viên hoặc không có quyền xem.");
                    return;
                }
                string duongDan = Path.Combine(
                    Application.StartupPath,
                    "Forms",
                    "Report",
                    "rptDanhSachLop.rdlc");

                if (!File.Exists(duongDan))
                {
                    MessageBox.Show("Không tìm thấy rptDanhSachLop.rdlc");
                    return;
                }

                reportViewer1.Reset();
                reportViewer1.ProcessingMode =ProcessingMode.Local;

                reportViewer1.LocalReport.ReportPath = duongDan;

                reportViewer1.LocalReport.DataSources.Clear();

                reportViewer1.LocalReport.DataSources.Add(
                    new ReportDataSource("DanhSachLopDataSet", ds));

                reportViewer1.LocalReport.SetParameters(
                    new ReportParameter[]
                    {
                new ReportParameter("MaLHP", lop.MaLHP),
                new ReportParameter("TenMon", lop.TenMon)
                    });

                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xem danh sách lớp: " + ex.Message);
            }
        }
    }
}
