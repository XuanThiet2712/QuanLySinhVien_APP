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
    internal class DoanhThuService
    {
        // Thống kê tổng doanh thu học phí theo từng ngày trong một khoảng thời gian
        public Result<List<DoanhThuDTO>> ThongKeTheoNgay(DateTime tuNgay, DateTime denNgay)
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

                    var resultList = query.Select(x => new DoanhThuDTO
                    {
                        TieuDe = x.NgayGoc.ToString("dd/MM/yyyy"),
                        SoGiaoDich = x.SoGiaoDich,
                        TongDoanhThu = x.TongDoanhThu
                    })
                        .ToList();

                    return Result<List<DoanhThuDTO>>.Ok(resultList);
                }
            }
            catch (Exception ex)
            {
                return Result<List<DoanhThuDTO>>.Fail("Lỗi thống kê doanh thu: " + ex.Message);
            }
        }
        // 2. Dùng cho Biểu đồ Đường
        public List<DoanhThuDTO> DoanhThu12Thang(int nam)
        {
            using (var db = DbFactory.Create())
            {
                var queryDb = db.PhieuThus
                    .Where(p => !p.DaHuy && p.NgayLap.Year == nam)
                    .GroupBy(p => p.NgayLap.Month)
                    .Select(g => new { Thang = g.Key, TongThu = g.Sum(x => (decimal?)x.DaThu) ?? 0 })
                    .ToList();

                var result = new List<DoanhThuDTO>();
                for (int i = 1; i <= 12; i++)
                {
                    var dataThang = queryDb.FirstOrDefault(x => x.Thang == i);
                    result.Add(new DoanhThuDTO
                    {
                        TieuDe = "Tháng " + i,
                        TongDoanhThu = dataThang != null ? dataThang.TongThu : 0,
                        SoGiaoDich = 0
                    });
                }
                return result;
            }
        }

        // 3. Biểu đồ cột số sinh viên
        public List<ThongKeDTO> SoSinhVienTheoKhoa()
        {
            using (var db = DbFactory.Create())
            {
                var query = (from sv in db.SinhViens
                             join lsh in db.LopSinhHoats on sv.MaLop equals lsh.MaLop
                             join ng in db.Nganhs on lsh.MaNganh equals ng.MaNganh
                             select ng.MaKhoa)
                       .GroupBy(maKhoa => maKhoa)
                       .Select(g => new
                       {
                           MaKhoa = g.Key,
                           SoLuong = g.Count()
                       })
                       .ToList();

                return query.Select(x => new ThongKeDTO
                {
                    Nhan = x.MaKhoa != null ? x.MaKhoa.Trim() : "Chưa xếp khoa",
                    GiaTri = x.SoLuong
                }).ToList();
            }
        }
    }
}
