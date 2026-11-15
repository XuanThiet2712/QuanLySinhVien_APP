using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLSV.Data;
using QLSV.DTOs;

namespace QLSV.Repositories
{
    public class ThongKeRepository
    {
        // 1. SỐ LƯỢNG SINH VIÊN THEO KHOA
        public List<ThongKeDTO> SoSinhVienTheoKhoa()
        {
            using (var db = DbFactory.Create())
            {
                var query = (from sv in db.SinhViens
                             join lsh in db.LopSinhHoats
                                 on sv.MaLop equals lsh.MaLop
                             join ng in db.Nganhs
                                 on lsh.MaNganh equals ng.MaNganh
                             join k in db.Khoas
                                 on ng.MaKhoa equals k.MaKhoa
                             group sv by k.TenKhoa into g
                             select new ThongKeDTO
                             {
                                 Nhan = g.Key,
                                 GiaTri = g.Count()
                             })
                             .OrderByDescending(x => x.GiaTri)
                             .ToList();

                return query;
            }
        }

    
        // 2 DOANH THU HỌC PHÍ 12 THÁNG
        public List<DoanhThuDTO> DoanhThu12Thang(int nam)
        {
            using (var db = DbFactory.Create())
            {
                DateTime dau = new DateTime(nam, 1, 1);
                DateTime cuoi = dau.AddYears(1);

                var rows = db.PhieuThus
                    .Where(p => !p.DaHuy
                             && p.NgayLap >= dau
                             && p.NgayLap < cuoi)
                    .Select(p => new
                    {
                        p.NgayLap,
                        p.DaThu
                    })
                    .ToList();

                var query = rows
                    .GroupBy(x => x.NgayLap.Month)
                    .Select(g => new
                    {
                        Thang = g.Key,
                        TongThu = g.Sum(x => Convert.ToDecimal(x.DaThu)),
                        SoGiaoDich = g.Count()
                    })
                    .ToList();

                var result = new List<DoanhThuDTO>();

                for (int i = 1; i <= 12; i++)
                {
                    var item = query.FirstOrDefault(x => x.Thang == i);

                    result.Add(new DoanhThuDTO
                    {
                        TieuDe = "Tháng " + i,
                        TongDoanhThu = item != null
                            ? item.TongThu
                            : 0,

                        SoGiaoDich = item != null
                            ? item.SoGiaoDich
                            : 0
                    });
                }

                return result;
            }
        }

        // 3 TỈ LỆ XẾP LOẠI HỌC LỰC THEO HỌC KỲ
  
        public List<ThongKeDTO> TyLeXepLoaiHocLuc(string maHK)
        {
            using (var db = DbFactory.Create())
            {
                string hk = (maHK ?? "").Trim();

                // Bước 1: Lấy điểm của sinh viên trong học kỳ
                var rows = (from sv in db.SinhViens
                            join dk in db.DangKyHocPhans
                                on sv.MaSV equals dk.MaSV
                            join lhp in db.LopHocPhans
                                on dk.MaLHP equals lhp.MaLHP
                            join d in db.Diems
                                on dk.MaDK equals d.MaDK
                            where lhp.MaHK == hk
                                  && d.DiemTongKet != null
                            select new
                            {
                                MaSV = sv.MaSV,
                                Diem = d.DiemTongKet.Value
                            })
                            .ToList();

                // Bước 2: Tính điểm trung bình từng sinh viên
                var diemTB = rows
                    .GroupBy(x => x.MaSV)
                    .Select(g => new
                    {
                        MaSV = g.Key,
                        DiemTB = g.Average(x => x.Diem)
                    })
                    .ToList();

                // Bước 3: Xếp loại học lực
                var xepLoai = diemTB
                    .Select(x => new
                    {
                        Loai = x.DiemTB >= 8.5m ? "Giỏi" :
                               x.DiemTB >= 7.0m ? "Khá" :
                               x.DiemTB >= 5.0m ? "Trung bình" :
                               "Yếu"
                    })
                    .ToList();

                // Bước 4: Đếm số sinh viên từng loại
                var dem = xepLoai
                    .GroupBy(x => x.Loai)
                    .ToDictionary(
                        g => g.Key,
                        g => g.Count()
                    );

                // Bước 5: Trả về đủ 4 loại
                return new List<ThongKeDTO>
                {
                    new ThongKeDTO
                    {
                        Nhan = "Giỏi",
                        GiaTri = dem.ContainsKey("Giỏi")
                            ? dem["Giỏi"] : 0
                    },

                    new ThongKeDTO
                    {
                        Nhan = "Khá",
                        GiaTri = dem.ContainsKey("Khá")
                            ? dem["Khá"] : 0
                    },

                    new ThongKeDTO
                    {
                        Nhan = "Trung bình",
                        GiaTri = dem.ContainsKey("Trung bình")
                            ? dem["Trung bình"] : 0
                    },

                    new ThongKeDTO
                    {
                        Nhan = "Yếu",
                        GiaTri = dem.ContainsKey("Yếu")
                            ? dem["Yếu"] : 0
                    }
                };
            }
        }

        // 4. TOP 5 MÔN HỌC ĐÔNG SINH VIÊN NHẤT
        public List<ThongKeDTO> Top5MonDongNhat(string maHK)
        {
            string hk = (maHK ?? "").Trim();

            using (var db = DbFactory.Create())
            {
                var query = (from dk in db.DangKyHocPhans
                             join lhp in db.LopHocPhans
                                 on dk.MaLHP equals lhp.MaLHP
                             join mh in db.MonHocs
                                 on lhp.MaMon equals mh.MaMon
                             where lhp.MaHK == hk
                             group dk by new
                             {
                                 mh.MaMon,
                                 mh.TenMon
                             } into g
                             select new ThongKeDTO
                             {
                                 Nhan = g.Key.TenMon,
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
