using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLSV.Data;

namespace QLSV.Repositories
{
    public class NhatKyDiemRepository
    {
        private readonly QLSVDataContext _db;
        public NhatKyDiemRepository(QLSVDataContext db)
        {
            _db = db;
        }
        // them lich su sua diem
        public void Add(NhatKyDiem nk)
        {
            _db.NhatKyDiems.InsertOnSubmit(nk);
        }

        /// lich su theo mdk
        public List<NhatKyDiem> GetByDangKy(int maDK)
        {
            return _db.NhatKyDiems
                .Where(x => x.MaDK == maDK)
                .OrderByDescending(x => x.NgaySua)
                .ThenByDescending(x => x.MaNK)
                .ToList();
        }
    }
}
