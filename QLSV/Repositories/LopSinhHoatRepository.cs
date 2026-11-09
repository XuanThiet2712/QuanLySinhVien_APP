using QLSV.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.Repositories
{
    //Truy vấn bảng lớp sinh hoạt
    public class LopSinhHoatRepository
    {
        private readonly QLSVDataContext _db;
        public LopSinhHoatRepository(QLSVDataContext db) { _db = db; }

        public List<LopSinhHoat> GetAll() { return _db.LopSinhHoats.OrderBy(l => l.TenLop).ToList(); }

        //Lớp thuộc một ngành
        public List<LopSinhHoat> GetByNganh(string maNganh)
        {
            return _db.LopSinhHoats.Where(l => l.MaNganh == maNganh).OrderBy(l => l.TenLop).ToList();
        }

        public LopSinhHoat GetById(string maLop) { return _db.LopSinhHoats.FirstOrDefault(l => l.MaLop == maLop); }
        public void Add(LopSinhHoat l) { _db.LopSinhHoats.InsertOnSubmit(l); }

        public void Delete(string maLop)
        {
            LopSinhHoat l = GetById(maLop);
            if (l != null) _db.LopSinhHoats.DeleteOnSubmit(l);
        }

        public bool ExistsId(string maLop) { return _db.LopSinhHoats.Any(l => l.MaLop == maLop); }

        //Số sinh viên thuộc lớp
        public int CountSinhVien(string maLop) { return _db.SinhViens.Count(s => s.MaLop == maLop); }
    }

}
