using QLSV.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.Repositories
{
    internal class LopHocPhanRepository
    {
        private readonly QLSVDataContext _db;
        public LopHocPhanRepository (QLSVDataContext db)
        {
            _db = db;
        }
        //hp theo ma
        public LopHocPhan GetById(string maLHP)
        {
            return _db.LopHocPhans.FirstOrDefault ( x => x.MaLHP == maLHP);
        }
        //ds hp trg hk
        public List<LopHocPhan> GetByHocky(string maHK)
        {
            return _db.LopHocPhans.Where(x => x.MaHK == maHK).OrderBy(x => x.MaLHP).ToList();
        }
        //dem so sv
        public int GetSiSoHienTai(string maLHP)
        {
            return _db.DangKyHocPhans.Count(x =>  x.MaLHP == maLHP);
        }
        //them lhp
        public void Add(LopHocPhan lhp)
        {
            _db.LopHocPhans.InsertOnSubmit(lhp);
        }



    }
}
