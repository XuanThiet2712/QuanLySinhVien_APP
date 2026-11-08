using QLSV.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.Repositories
{
    public class KhoaRepository
    {
        private readonly QLSVDataContext _db;
        public KhoaRepository(QLSVDataContext db) { _db = db; }

        // Lấy tất cả khoa, sắp xếp theo tên.
        public List<Khoa> GetAll()
        {
            return _db.Khoas.OrderBy(k => k.TenKhoa).ToList();
        }

        //Lấy một khoa theo mã, không có trả về null
        public Khoa GetById(string maKhoa)
        {
            return _db.Khoas.FirstOrDefault(k => k.MaKhoa == maKhoa);
        }

        //Thêm khoa vào hàng đợi (chưa ghi DB)
        public void Add(Khoa k)
        {
            _db.Khoas.InsertOnSubmit(k);
        }

        //Xóa khoa theo mã (chưa ghi DB)
        public void Delete(string maKhoa)
        {
            Khoa k = GetById(maKhoa);
            if (k != null) _db.Khoas.DeleteOnSubmit(k);
        }

        //Kiểm tra mã khoa đã tồn tại chưa
        public bool ExistsId(string maKhoa)
        {
            return _db.Khoas.Any(k => k.MaKhoa == maKhoa);
        }

        //Đếm số ngành thuộc khoa
        public int CountNganh(string maKhoa)
        {
            return _db.Nganhs.Count(n => n.MaKhoa == maKhoa);
        }
    }
}
