using QLSV.Data;
using QLSV.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.Repositories
{
    //Truy vấn bảng SinhVien (Where, Join, OrderBy, Skip/Take, Count, GroupBy)
    public class SinhVienRepository
    {
        private readonly QLSVDataContext _db;
        public SinhVienRepository(QLSVDataContext db) { _db = db; }

        // Lọc theo lớp và từ khóa (rỗng = bỏ qua)
        private IQueryable<SinhVien> Loc(string keyword, string maLop)
        {
            IQueryable<SinhVien> q = _db.SinhViens;
            if (!string.IsNullOrWhiteSpace(maLop)) q = q.Where(s => s.MaLop == maLop);
            if (!string.IsNullOrWhiteSpace(keyword))
                q = q.Where(s => s.MaSV.Contains(keyword) || s.HoTen.Contains(keyword));
            return q;
        }

        //Tìm sinh viên có phân trang, nối lớp-ngành-khoa
        public List<SinhVienDTO> Search(string keyword, string maLop, int page, int size)
        {
            var q = from s in Loc(keyword, maLop)
                    join l in _db.LopSinhHoats on s.MaLop equals l.MaLop
                    join n in _db.Nganhs on l.MaNganh equals n.MaNganh
                    join k in _db.Khoas on n.MaKhoa equals k.MaKhoa
                    orderby s.MaSV
                    select new SinhVienDTO
                    {
                        MaSV = s.MaSV,
                        HoTen = s.HoTen,
                        NgaySinh = s.NgaySinh,
                        TenLop = l.TenLop,
                        TenNganh = n.TenNganh,
                        TenKhoa = k.TenKhoa
                    };
            return q.Skip((page - 1) * size).Take(size).ToList();   // OrderBy phải đứng trước Skip
        }

        //Tổng số dòng theo bộ lọc (để tính số trang)
        public int Count(string keyword, string maLop) { return Loc(keyword, maLop).Count(); }

        public SinhVien GetById(string maSV) { return _db.SinhViens.FirstOrDefault(s => s.MaSV == maSV); }

        public List<SinhVien> GetByLop(string maLop)
        {
            return _db.SinhViens.Where(s => s.MaLop == maLop).OrderBy(s => s.MaSV).ToList();
        }

        public void Add(SinhVien s) { _db.SinhViens.InsertOnSubmit(s); }

        public void Delete(string maSV)
        {
            SinhVien s = GetById(maSV);
            if (s != null) _db.SinhViens.DeleteOnSubmit(s);
        }

        public bool ExistsId(string maSV) { return _db.SinhViens.Any(s => s.MaSV == maSV); }

        //Số đăng ký học phần của sinh viên (để chặn xóa)
        public int CountDangKy(string maSV) { return _db.DangKyHocPhans.Count(d => d.MaSV == maSV); }

        //Mã SV lớn nhất của lớp, phục vụ sinh mã tự động
        public string GetMaxMaSVTheoLop(string maLop)
        {
            return _db.SinhViens.Where(s => s.MaLop == maLop)
                               .OrderByDescending(s => s.MaSV)
                               .Select(s => s.MaSV).FirstOrDefault();
        }

        //Số sinh viên theo lớp (GroupBy)
        public List<KeyValuePair<string, int>> DemSinhVienTheoLop()
        {
            return _db.SinhViens.GroupBy(s => s.MaLop)
                .Select(g => new { Lop = g.Key, SoLuong = g.Count() })
                .ToList()
                .Select(x => new KeyValuePair<string, int>(x.Lop, x.SoLuong)).ToList();
        }
    }
}
