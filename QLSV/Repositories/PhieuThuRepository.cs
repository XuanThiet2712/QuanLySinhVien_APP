using QLSV.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.Repositories
{
    internal class PhieuThuRepository
    {
        private readonly QLSVDataContext _db;

        public PhieuThuRepository(QLSVDataContext db)
        {
            _db = db;
        }

        public List<PhieuThu> GetBySinhVien(string maSV, string maHK)
        {
            var q = _db.PhieuThus.Where(p => p.MaSV == maSV);
            if (!string.IsNullOrEmpty(maHK))
                q = q.Where(p => p.MaHK == maHK);
            return q.OrderByDescending(p => p.NgayLap).ToList();
        }

        public PhieuThu GetById(int maPhieu)
        {
            return _db.PhieuThus.FirstOrDefault(p => p.MaPhieu == maPhieu);
        }

        public decimal GetTongDaThu(string maSV, string maHK)
        {
            return _db.PhieuThus
                       .Where(p => p.MaSV.Trim() == maSV.Trim() && p.MaHK.Trim() == maHK.Trim() && !p.DaHuy)
                       .Sum(p => (decimal?)p.DaThu) ?? 0m;
        }

        public void Add(PhieuThu pt)
        {
            _db.PhieuThus.InsertOnSubmit(pt);
        }

        public List<PhieuThu> GetByDateRange(DateTime tu, DateTime den)
        {
            DateTime denEnd = den.Date.AddDays(1).AddTicks(-1);
            return _db.PhieuThus
                       .Where(p => !p.DaHuy && p.NgayLap >= tu.Date && p.NgayLap <= denEnd)
                       .OrderBy(p => p.NgayLap)
                       .ToList();
        }
    }
}
