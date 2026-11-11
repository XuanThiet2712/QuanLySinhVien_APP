using QLSV.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.Repositories
{
    public class MonHocRepository
    {
        private readonly QLSVDataContext _db;
        public MonHocRepository(QLSVDataContext db) { _db = db; }

        //Tìm theo mã/tên và lọc theo khoa
        public List<MonHoc> Search(string keyword, string maKhoa)
        {
            IQueryable<MonHoc> q = _db.MonHocs;
            if (!string.IsNullOrWhiteSpace(maKhoa)) q = q.Where(m => m.MaKhoa == maKhoa);
            if (!string.IsNullOrWhiteSpace(keyword))
                q = q.Where(m => m.MaMon.Contains(keyword) || m.TenMon.Contains(keyword));
            return q.OrderBy(m => m.TenMon).ToList();
        }

        public MonHoc GetById(string maMon) { return _db.MonHocs.FirstOrDefault(m => m.MaMon == maMon); }
        public void Add(MonHoc m) { _db.MonHocs.InsertOnSubmit(m); }

        public void Delete(string maMon)
        {
            MonHoc m = GetById(maMon);
            if (m != null) _db.MonHocs.DeleteOnSubmit(m);
        }

        public bool ExistsId(string maMon) { return _db.MonHocs.Any(m => m.MaMon == maMon); }

        //Danh sách mã môn tiên quyết của một môn
        public List<string> GetTienQuyet(string maMon)
        {
            return _db.MonTienQuyets.Where(t => t.MaMon == maMon)
                                   .Select(t => t.MaMonTienQuyet).ToList();
        }

        //Ghi đè tiên quyết: xếp hàng xóa cũ và thêm mới
        public void SetTienQuyet(string maMon, List<string> ds)
        {
            _db.MonTienQuyets.DeleteAllOnSubmit(_db.MonTienQuyets.Where(t => t.MaMon == maMon));
            foreach (string tq in ds.Distinct())
                _db.MonTienQuyets.InsertOnSubmit(new MonTienQuyet { MaMon = maMon, MaMonTienQuyet = tq });
        }

        //Số lớp học phần đã mở của môn
        public int CountLopHocPhan(string maMon) { return _db.LopHocPhans.Count(l => l.MaMon == maMon); }

        //Số môn khác đang lấy môn này làm tiên quyết
        public int CountLaTienQuyetCuaMonKhac(string maMon)
        {
            return _db.MonTienQuyets.Count(t => t.MaMonTienQuyet == maMon);
        }
    }
}

