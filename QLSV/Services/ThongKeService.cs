using QLSV.Data;
using QLSV.DTOs;
using QLSV.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.Services
{
    internal class ThongKeService
    {
        // Thống kê tổng doanh thu học phí theo từng ngày trong một khoảng thời gian
        public Result<List<ThongKeDoanhThuDTO>> ThongKeTheoNgay(DateTime tuNgay, DateTime denNgay)
        {
            try
            {
                using (var db = DbFactory.Create())
                {
                    DateTime denNgayEnd = denNgay.Date.AddDays(1).AddTicks(-1);
                    var query = db.PhieuThus
                        .Where(p => !p.DaHuy && p.NgayLap >= tuNgay.Date && p.NgayLap <= denNgayEnd)
                        .GroupBy(p => p.NgayLap.Date)
                        .Select(g => new
                        {
                            NgayGoc = g.Key,
                            SoGiaoDich = g.Count(),
                            TongDoanhThu = (decimal)g.Sum(x => x.DaThu)
                        })
                        .OrderBy(x => x.NgayGoc)
                        .ToList();

                    var resultList = query.Select(x => new ThongKeDoanhThuDTO
                    {
                        TieuDe = x.NgayGoc.ToString("dd/MM/yyyy"),
                        SoGiaoDich = x.SoGiaoDich,
                        TongDoanhThu = x.TongDoanhThu
                    })
                        .ToList();

                    return Result<List<ThongKeDoanhThuDTO>>.Ok(resultList);
                }
            }
            catch (Exception ex)
            {
                return Result<List<ThongKeDoanhThuDTO>>.Fail("Lỗi thống kê doanh thu: " + ex.Message);
            }
        }
    }
}
