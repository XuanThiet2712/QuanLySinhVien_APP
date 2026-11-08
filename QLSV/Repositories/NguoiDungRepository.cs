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

        // constructor 
        public NguoiDungRepository(QLSVDataContext db)
        {
            _db = db;
        }

        //Tìm người dùng theo tên đăng nhập , null là ko có
        public NguoiDung GetByUsername(string tenDangNhap)
        {
            foreach (NguoiDung u in _db.NguoiDungs)
            {
                if (u.TenDangNhap == tenDangNhap)
                {
                    return u;
                }
            }

            return null;
        }

        //Tìm người dùng theo mã , null ko có
        public NguoiDung GetById(int maND)
        {
            foreach (NguoiDung u in _db.NguoiDungs)
            {
                if (u.MaND == maND)
                {
                    return u;
                }
            }

            return null;
        }

        //Toàn bộ người dùng sắp theo tên đăng nhập
        public List<NguoiDung> GetAll()
        {
            List<NguoiDung> danhSach = new List<NguoiDung>();

            foreach (NguoiDung u in _db.NguoiDungs)
            {
                danhSach.Add(u);
            }



            return danhSach;
        }

        //them nguoi dung moi vao NguoiDUng trong CSDL 
        public void Add(NguoiDung u)
        {
            _db.NguoiDungs.InsertOnSubmit(u);
        }

        // xoa nguoi dung khoi CSDL
        public void Delete(int maND)
        {
            NguoiDung u = GetById(maND);
            if (u != null) 
                _db.NguoiDungs.DeleteOnSubmit(u);
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
            foreach (SinhVien s in _db.SinhViens)
            {
                if (s.MaSV == maSV)
                {
                    return s;
                }
            }

            return null;
        }
    }
}