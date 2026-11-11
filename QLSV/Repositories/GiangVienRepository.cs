using QLSV.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.Repositories
{
    public class GiangVienRepository
    {
        private readonly QLSVDataContext _db;
        public GiangVienRepository(QLSVDataContext db) { _db = db; }

        //Tìm theo mã/tên và lọc theo khoa (rỗng = bỏ qua điều kiện đó)
        public List<GiangVien> Search(string keyword, string maKhoa)
        {
            IQueryable<GiangVien> q = _db.GiangViens;
            if (!string.IsNullOrWhiteSpace(maKhoa)) q = q.Where(g => g.MaKhoa == maKhoa);
            if (!string.IsNullOrWhiteSpace(keyword))
                q = q.Where(g => g.MaGV.Contains(keyword) || g.HoTen.Contains(keyword));
            return q.OrderBy(g => g.HoTen).ToList();
        }

        public GiangVien GetById(string maGV) { return _db.GiangViens.FirstOrDefault(g => g.MaGV == maGV); }
        public void Add(GiangVien g) { _db.GiangViens.InsertOnSubmit(g); }

        public void Delete(string maGV)
        {
            GiangVien g = GetById(maGV);
            if (g != null) _db.GiangViens.DeleteOnSubmit(g);
        }

        public bool ExistsId(string maGV) { return _db.GiangViens.Any(g => g.MaGV == maGV); }

        //Số lớp học phần giảng viên đang phụ trách
        public int CountLopHocPhan(string maGV) { return _db.LopHocPhans.Count(l => l.MaGV == maGV); }
    }
}
