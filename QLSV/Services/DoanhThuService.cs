using QLSV.Data;
using QLSV.DTOs;
using QLSV.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

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
                    DateTime tu = tuNgay.Date;
                    DateTime den = denNgay.Date.AddDays(1).AddTicks(-1);

                    // Chỉ lấy 2 cột cần thiết từ DB
                    var rows = db.PhieuThus
                        .Where(p => !p.DaHuy && p.NgayLap >= tu && p.NgayLap <= den)
                        .Select(p => new { p.NgayLap, p.DaThu })
                        .ToList();

                    // Gom nhóm theo ngày trong bộ nhớ
                    var resultList = rows
                        .GroupBy(x => x.NgayLap.Date)
                        .OrderBy(g => g.Key)
                        .Select(g => new DoanhThuDTO
                        {
                            TieuDe = g.Key.ToString("dd/MM/yyyy"),
                            SoGiaoDich = g.Count(),
                            TongDoanhThu = g.Sum(x => Convert.ToDecimal(x.DaThu))
                        })
                        .ToList();

                    return Result<List<DoanhThuDTO>>.Ok(resultList);
                }
            }
            catch (Exception ex)
            {
                Exception root = ex;
                while (root.InnerException != null) root = root.InnerException;
                return Result<List<DoanhThuDTO>>.Fail("Lỗi thống kê doanh thu: " + root.Message);
            }
        }

        // Biểu đồ Đường
        public List<DoanhThuDTO> DoanhThu12Thang(int nam)
        {
            using (var db = DbFactory.Create())
            {
                DateTime dau = new DateTime(nam, 1, 1);
                DateTime cuoi = dau.AddYears(1);

                var rows = db.PhieuThus
                    .Where(p => !p.DaHuy && p.NgayLap >= dau && p.NgayLap < cuoi)
                    .Select(p => new { p.NgayLap, p.DaThu })
                    .ToList();

                var queryDb = rows
                    .GroupBy(x => x.NgayLap.Month)
                    .Select(g => new { Thang = g.Key, TongThu = g.Sum(x => Convert.ToDecimal(x.DaThu)) })
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

        // Biểu đồ cột số sinh viên
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

        // Biểu đồ tròn
        public List<ThongKeDTO> TyLeXepLoaiHocLuc(string maHK)
        {
            return new List<ThongKeDTO>
            {
                new ThongKeDTO { Nhan = "Giỏi", GiaTri = 120 },
                new ThongKeDTO { Nhan = "Khá", GiaTri = 350 },
                new ThongKeDTO { Nhan = "Trung bình", GiaTri = 150 },
                new ThongKeDTO { Nhan = "Yếu", GiaTri = 20 }
            };
        }

        // Top 5 môn đông nhất
        public List<ThongKeDTO> Top5MonDongNhat(string maHK)
        {
            string hk = (maHK ?? "").Trim();

            using (var db = DbFactory.Create())
            {
                var query = (from dk in db.DangKyHocPhans
                             join lhp in db.LopHocPhans on dk.MaLHP equals lhp.MaLHP
                             join mh in db.MonHocs on lhp.MaMon equals mh.MaMon
                             where lhp.MaHK.Trim() == hk
                             group dk by mh.TenMon into g
                             select new ThongKeDTO
                             {
                                 Nhan = g.Key,
                                 GiaTri = g.Count()
                             })
                             .OrderByDescending(x => x.GiaTri)
                             .Take(5)
                             .ToList();

                return query;
            }
        }
    }
}