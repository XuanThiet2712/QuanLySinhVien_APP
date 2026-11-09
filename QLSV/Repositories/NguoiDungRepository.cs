using QLSV.Data;
using QLSV.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        // tim nguoi dung theo ten dang nhap 
        public List<NguoiDungDTO> Search(string keyword)
        {
            List<NguoiDungDTO> danhSach = new List<NguoiDungDTO>();

            // Nếu keyword null thì đổi thành chuỗi rỗng
            if (keyword == null)
            {
                keyword = "";
            }

            keyword = keyword.Trim();

            // Duyệt từng người dùng
            foreach (NguoiDung u in _db.NguoiDungs)
            {
                // Kiểm tra tên đăng nhập
                if (keyword == "" || u.TenDangNhap.Contains(keyword))
                {
                    NguoiDungDTO dto = new NguoiDungDTO();

                    dto.MaND = u.MaND;
                    dto.TenDangNhap = u.TenDangNhap;

                    // Tìm tên nhóm quyền
                    foreach (NhomQuyen n in _db.NhomQuyens)
                    {
                        if (n.MaNhom == u.MaNhom)
                        {
                            dto.TenNhom = n.TenNhom;
                            break;
                        }
                    }

                    // Lấy mã sinh viên hoặc mã giảng viên
                    if (u.MaSV != null)
                    {
                        dto.DoiTuong = u.MaSV;
                    }
                    else if (u.MaGV != null)
                    {
                        dto.DoiTuong = u.MaGV;
                    }
                    else
                    {
                        dto.DoiTuong = "";
                    }

                    // Kiểm tra trạng thái
                    if (u.TrangThai == true)
                    {
                        dto.TrangThai = "Hoạt động";
                    }
                    else
                    {
                        dto.TrangThai = "Đã khóa";
                    }

                    danhSach.Add(dto);
                }
            }

            return danhSach;
        }
    }
}