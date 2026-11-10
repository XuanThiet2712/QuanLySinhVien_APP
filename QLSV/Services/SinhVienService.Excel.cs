using QLSV.Data;
using QLSV.DTOs;
using QLSV.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.Services
{
    public partial class SinhVienService
    {
        private static readonly string[] CotBatBuoc =
            { "MaSV", "HoTen", "NgaySinh", "GioiTinh", "Email", "SDT", "DiaChi", "MaLop" };

        private static readonly string[] DinhDangNgay =
            { "dd/MM/yyyy", "d/M/yyyy", "yyyy-MM-dd", "M/d/yyyy" };

        //Nhập sinh viên từ Excel. Dòng lỗi ghi vào báo cáo, không dừng cả file
        public Result<ImportReport> ImportExcel(string path)
        {
            var rp = new ImportReport();
            try
            {
                DataTable dt = ExcelHelper.ReadSheet(path);
                foreach (string c in CotBatBuoc)
                    if (!dt.Columns.Contains(c))
                        return Result<ImportReport>.Fail("File thiếu cột: " + c);

                rp.TongDong = dt.Rows.Count;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int dong = i + 2;   // dòng 1 của file là tiêu đề
                    DataRow r = dt.Rows[i];

                    DateTime ns;
                    string chuoiNgay = r["NgaySinh"].ToString();
                    if (!DateTime.TryParseExact(chuoiNgay, DinhDangNgay, CultureInfo.InvariantCulture,
                            DateTimeStyles.None, out ns)
                        && !DateTime.TryParse(chuoiNgay, out ns))
                    {
                        rp.DanhSachLoi.Add("Dòng " + dong + ": ngày sinh không hợp lệ.");
                        continue;
                    }

                    var s = new SinhVien
                    {
                        MaSV = r["MaSV"].ToString(),
                        HoTen = r["HoTen"].ToString(),
                        NgaySinh = ns,
                        GioiTinh = r["GioiTinh"].ToString(),
                        Email = r["Email"].ToString(),
                        SDT = r["SDT"].ToString(),
                        DiaChi = r["DiaChi"].ToString(),
                        MaLop = r["MaLop"].ToString()
                    };

                    Result kq = ThemMoi(s);   // tái sử dụng toàn bộ kiểm tra dữ liệu
                    if (kq.Success) rp.ThanhCong++;
                    else rp.DanhSachLoi.Add("Dòng " + dong + " (" + s.MaSV + "): " + kq.Message);
                }
                return Result<ImportReport>.Ok(rp, "Đã nhập " + rp.ThanhCong + "/" + rp.TongDong + " dòng.");
            }
            catch (Exception ex) { return Result<ImportReport>.Fail("Không đọc được file: " + ex.Message); }
        }

        //Xuất danh sách sinh viên của lớp (rỗng = tất cả) ra file Excel
        public Result ExportExcel(string path, string maLop)
        {
            try
            {
                int tong = Count("", maLop);
                var ds = Search("", maLop, 1, Math.Max(1, tong));

                var dt = new DataTable();
                dt.Columns.Add("MSSV");
                dt.Columns.Add("Họ tên");
                dt.Columns.Add("Ngày sinh");
                dt.Columns.Add("Lớp");
                dt.Columns.Add("Ngành");
                dt.Columns.Add("Khoa");
                foreach (var s in ds)
                    dt.Rows.Add(s.MaSV, s.HoTen, s.NgaySinh.ToString("dd/MM/yyyy"),
                                s.TenLop, s.TenNganh, s.TenKhoa);

                ExcelHelper.ExportDataTable(dt, path, "SinhVien");
                return Result.Ok("Đã xuất " + ds.Count + " sinh viên.");
            }
            catch (Exception ex) { return Result.Fail("Lỗi xuất file: " + ex.Message); }
        }
    }
}

