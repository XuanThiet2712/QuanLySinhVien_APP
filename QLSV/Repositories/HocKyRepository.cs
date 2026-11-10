using QLSV.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.Repositories
{
    public class HocKyRepository
    {
        private readonly QLSVDataContext _db;
        public HocKyRepository(QLSVDataContext db) { _db = db; }

        //Tất cả học kỳ, mới nhất trước
        public List<HocKy> GetAll() { return _db.HocKies.OrderByDescending(h => h.TuNgay).ToList(); }

        //Học kỳ chứa ngày hôm nay; không có thì null
        public HocKy GetHienTai()
        {
            DateTime today = DateTime.Today;
            return _db.HocKies.FirstOrDefault(h => h.TuNgay <= today && today <= h.DenNgay);
        }

        public HocKy GetById(string maHK) { return _db.HocKies.FirstOrDefault(h => h.MaHK == maHK); }
        public void Add(HocKy h) { _db.HocKies.InsertOnSubmit(h); }

        public void Delete(string maHK)
        {
            HocKy h = GetById(maHK);
            if (h != null) _db.HocKies.DeleteOnSubmit(h);
        }

        public bool ExistsId(string maHK) { return _db.HocKies.Any(h => h.MaHK == maHK); }

        //Số lớp học phần của học kỳ (để chặn xóa)
        public int CountLopHocPhan(string maHK) { return _db.LopHocPhans.Count(l => l.MaHK == maHK); }
    }
}

