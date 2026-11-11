using QLSV.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.Repositories
{
    public class NhomQuyenRepository
    {
        private readonly QLSVDataContext _db;

        public NhomQuyenRepository(QLSVDataContext db)
        {
            _db = db;
        }

        public List<NhomQuyen> GetAllNhom()
        {
            return _db.NhomQuyens.OrderBy(n => n.MaNhom).ToList();
        }

        public bool ExistsNhom(string maNhom)
        {
            return _db.NhomQuyens.Any(n => n.MaNhom == maNhom);
        }

        public List<ChucNang> GetAllChucNang()
        {
            return _db.ChucNangs.OrderBy(c => c.MaCN).ToList();
        }

        // Trong danh sách mã đưa vào, những mã nào có thật trong bảng ChucNang
        public List<string> LocMaChucNangHopLe(List<string> dsMaCN)
        {
            return _db.ChucNangs.Where(c => dsMaCN.Contains(c.MaCN)).Select(c => c.MaCN).ToList();
        }


    }
}
