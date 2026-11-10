using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.Repositories
{
    public class DiemRepository
    {
        private readonly QLSVDataContext _db;
        public DiemRepository(QlSVDataContext db)
            _db = db;
            public List<string> GetMonDaDat(string maSV)
        {
            var ds = from dk in _db.DangKyHocPhans
                     join d in _db.Diems on dk.MaDK equals d.MaDK
                     join lhp in _db.LopHocPhans on dk.MaLHP equals lhp.MaLHP
                     where dk.MaSV == maSV && d.DiemTongKet >= 4m
                     select lhp.MaMon;
            return ds.Distinct().ToList();
        }
    }
}
