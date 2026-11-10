using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
namespace QLSV.Helpers
{
    public class ExcelHelper
    {
        //Xuất DataTable ra file .xlsx; sheetName tối đa 31 ký tự
        public static void ExportDataTable(DataTable dt, string path, string sheetName)
        {
            using (var wb = new XLWorkbook())
            {
                var ws = wb.Worksheets.Add(dt, sheetName);
                ws.Columns().AdjustToContents();   // tự giãn độ rộng cột
                wb.SaveAs(path);
            }
        }

        //Đọc sheet đầu tiên; dòng 1 là tên cột, các dòng sau là dữ liệu (đều ở dạng chuỗi)
        public static DataTable ReadSheet(string path)
        {
            var dt = new DataTable();
            using (var wb = new XLWorkbook(path))
            {
                var ws = wb.Worksheet(1);
                var range = ws.RangeUsed();
                if (range == null) return dt;   // sheet trống

                bool dongDau = true;
                foreach (var row in range.RowsUsed())
                {
                    if (dongDau)
                    {
                        foreach (var c in row.Cells()) dt.Columns.Add(c.GetString().Trim());
                        dongDau = false;
                    }
                    else
                    {
                        var dr = dt.NewRow();
                        int i = 0;
                        // chỉ đọc đúng số cột của dòng tiêu đề
                        foreach (var c in row.Cells(1, dt.Columns.Count)) dr[i++] = c.GetString().Trim();
                        dt.Rows.Add(dr);
                    }
                }
            }
            return dt;
        }
    }
}   


