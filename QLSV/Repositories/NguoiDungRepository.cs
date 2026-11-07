using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLSV.Data;

namespace QLSV.Repositories
{
    //doc ghi bang nguoi dung , 
    public class NguoiDungRepository
    {
        private readonly QLSVDataContext _db;

        public NguoiDungRepository(QLSVDataContext db)
        {
            _db = db;
        }

        //Tìm người dùng theo tên đăng nhập , null là ko có
        public NguoiDung GetByUsername(string tenDangNhap)
        {
            return _db.NguoiDungs.FirstOrDefault(u => u.TenDangNhap == tenDangNhap);
        }

        //Tìm người dùng theo mã , null ko có
        public NguoiDung GetById(int maND)
        {
            return _db.NguoiDungs.FirstOrDefault(u => u.MaND == maND);
        }

        //Toàn bộ người dùng sắp theo tên đăng nhập
        public List<NguoiDung> GetAll()
        {
            return _db.NguoiDungs.OrderBy(u => u.TenDangNhap).ToList();
        }

        //Xếp hàng thêm người dùng, Service gọi SubmitChanges để ghi thật
        public void Add(NguoiDung u)
        {
            _db.NguoiDungs.InsertOnSubmit(u);
        }

        //Xếp hàng xóa người dùng, Service gọi SubmitChanges để ghi thật
        public void Delete(int maND)
        {
            NguoiDung u = GetById(maND);
            if (u != null) _db.NguoiDungs.DeleteOnSubmit(u);
        }

        //Tên đăng nhập đã có người dùng chưa?
        public bool ExistsUsername(string tenDangNhap)
        {
            return _db.NguoiDungs.Any(u => u.TenDangNhap == tenDangNhap);
        }

        //Sinh viên này đã có tài khoản chưa?
        public bool ExistsMaSV(string maSV)
        {
            return _db.NguoiDungs.Any(u => u.MaSV == maSV);
        }

        //Lấy sinh viên theo mã , null nếu ko có . Dùng khi tự đăng ký tài khoản
        public SinhVien GetSinhVien(string maSV)
        {
            return _db.SinhViens.FirstOrDefault(s => s.MaSV == maSV);
        }
    }
}