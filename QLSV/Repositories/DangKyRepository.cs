using QLSV.Data;
using QLSV.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.Repositories
{
    public class DangKyRepository
    {
        private readonly QLSVDataContext _db;

        public DangKyRepository(QLSVDataContext db)
        {
            _db = db;
        }

        // Câu truy vấn gốc: ghép lớp + môn + giảng viên + đếm sĩ số hiện tại.
        private IQueryable<LopDangKyDTO> Query()
        {
            return from l in _db.LopHocPhans
                   join m in _db.MonHocs on l.MaMon equals m.MaMon
                   join g in _db.GiangViens on l.MaGV equals g.MaGV
                   select new LopDangKyDTO
                   {
                       MaLHP = l.MaLHP,
                       MaMon = l.MaMon,
                       MaHK = l.MaHK,
                       TenMon = m.TenMon,
                       SoTinChi = m.SoTinChi,
                       TenGV = g.HoTen,
                       Thu = l.Thu,
                       TietBatDau = l.TietBatDau,
                       SoTiet = l.SoTiet,
                       Phong = l.Phong,
                       SiSoToiDa = l.SiSoToiDa,
                       DaDangKy = _db.DangKyHocPhans.Count(d => d.MaLHP == l.MaLHP)
                   };
        }
        //lay danh sach hoc ky moi nhat
        public List<HocKy> GetHocKy()
        {
            return _db.HocKies.OrderByDescending(h => h.TuNgay).ToList();
        }
        // Lấy danh sách lớp học phần theo học kỳ.
        public List<LopDangKyDTO> GetLopTheoHocKy(string maHK)
        {
            return Query().Where(x => x.MaHK == maHK).OrderBy(x => x.MaLHP).ToList();
        }

        // Lấy danh sách lớp học phần theo học kỳ và môn học.
        public List<LopDangKyDTO> GetLop(List<string> dsMaLHP)
        {
            return Query().Where(x => dsMaLHP.Contains(x.MaLHP)).ToList();
        }
        // Lấy danh sách lớp học phần mà sinh viên đã đăng ký trong học kỳ.
        public List<LopDangKyDTO> GetDaDangKy(string maSV, string maHK)
        {
            List<string> dsLop = _db.DangKyHocPhans
                                    .Where(d => d.MaSV == maSV)
                                    .Select(d => d.MaLHP)
                                    .ToList();
            return Query().Where(x => x.MaHK == maHK && dsLop.Contains(x.MaLHP))
                          .OrderBy(x => x.MaLHP).ToList();
        }

        // Các môn sinh viên đã ĐẠT (điểm tổng kết từ 4.0 trở lên).
        public List<string> GetMonDaDat(string maSV)
        {
            return (from d in _db.DangKyHocPhans
                    join l in _db.LopHocPhans on d.MaLHP equals l.MaLHP
                    join k in _db.Diems on d.MaDK equals k.MaDK
                    where d.MaSV == maSV && k.DiemTongKet >= 4.0m
                    select l.MaMon).Distinct().ToList();
        }

        // Lấy danh sách lớp học phần mà sinh viên chưa đăng ký trong học kỳ.
        public List<LopDangKyDTO> GetChuaDangKy(string maSV, string maHK)
        {
            List<string> dsLop = _db.DangKyHocPhans
                                    .Where(d => d.MaSV == maSV)
                                    .Select(d => d.MaLHP)
                                    .ToList();
            return Query().Where(x => x.MaHK == maHK && !dsLop.Contains(x.MaLHP))
                          .OrderBy(x => x.MaLHP).ToList();
        }

        public List<MonTienQuyet> GetTienQuyet(List<string> dsMaMon)
        {
            return _db.MonTienQuyets.Where(t => dsMaMon.Contains(t.MaMon)).ToList();
        }
        // Lay ten mon hoc
        public string GetTenMon(string maMon)
        {
            MonHoc m = _db.MonHocs.FirstOrDefault(x => x.MaMon == maMon);
            return m == null ? maMon : m.TenMon;
        }
        // Kiem tra sinh vien co ton tai ko 
        public bool ExistsSinhVien(string maSV)
        {
            return _db.SinhViens.Any(s => s.MaSV == maSV);
        }

        //Xếp hàng thêm một lượt đăng ký
        public void Add(string maSV, string maLHP)
        {
            _db.DangKyHocPhans.InsertOnSubmit(new DangKyHocPhan
            {
                MaSV = maSV,
                MaLHP = maLHP,
                NgayDK = DateTime.Now
            });
        }
        // Phục vụ hủy đăng ký
        public DangKyHocPhan Get(string maSV, string maLHP)
        {
            return _db.DangKyHocPhans.FirstOrDefault(d => d.MaSV == maSV && d.MaLHP == maLHP);
        }


        public bool CoDiem(int maDK)
        {
            return _db.Diems.Any(k => k.MaDK == maDK);
        }

        public void Delete(DangKyHocPhan dk)
        {
            _db.DangKyHocPhans.DeleteOnSubmit(dk);
        }
    }
    }
