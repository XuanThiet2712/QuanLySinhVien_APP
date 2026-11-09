using QLSV.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.Repositories
{
    public class NganhRepository
    {
        private readonly QLSVDataContext _db;
        public NganhRepository(QLSVDataContext db) { _db = db; }

        //Tất cả ngành, sắp theo tên
        public List<Nganh> GetAll() { return _db.Nganhs.OrderBy(n => n.TenNganh).ToList(); }

        //Ngành thuộc một khoa.
        public List<Nganh> GetByKhoa(string maKhoa)
        {
            return _db.Nganhs.Where(n => n.MaKhoa == maKhoa).OrderBy(n => n.TenNganh).ToList();
        }

        public Nganh GetById(string maNganh) { return _db.Nganhs.FirstOrDefault(n => n.MaNganh == maNganh); }
        public void Add(Nganh n) { _db.Nganhs.InsertOnSubmit(n); }

        public void Delete(string maNganh)
        {
            Nganh n = GetById(maNganh);
            if (n != null) _db.Nganhs.DeleteOnSubmit(n);
        }

        public bool ExistsId(string maNganh) { return _db.Nganhs.Any(n => n.MaNganh == maNganh); }

        //Số lớp thuộc ngành.
        public int CountLop(string maNganh) { return _db.LopSinhHoats.Count(l => l.MaNganh == maNganh); }
    }
}
