using QLSV.Data;
using QLSV.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QLSV.Repositories
{
    public class DiemRepository
    {
        private readonly QLSVDataContext _db;
        public DiemRepository(QLSVDataContext db)
        {
            _db = db;
        }
        public List<string> GetMonDaDat(string maSV)
        {
            var ds = from dk in _db.DangKyHocPhans
                     join d in _db.Diems on dk.MaDK equals d.MaDK
                     join lhp in _db.LopHocPhans on dk.MaLHP equals lhp.MaLHP
                     where dk.MaSV == maSV && d.DiemTongKet >= 4m
                     select lhp.MaMon;
            return ds.Distinct().ToList();
        }
        public List<DiemDTO> GetByLHP(string MaLHP)
        {
            var ds = from dk in _db.DangKyHocPhans
                     join sv in _db.SinhViens on dk.MaSV equals sv.MaSV
                     join d in _db.Diems on dk.MaDK equals d.MaDK into nhomDiem
                     from d in nhomDiem.DefaultIfEmpty()
                     where dk.MaLHP == MaLHP
                     orderby sv.MaSV
                     select new DiemDTO
                     {
                         MaDK = dk.MaDK,
                         MaSV = dk.MaSV,
                         HoTen = sv.HoTen,

                         DiemCC = d == null ? null : d.DiemCC,
                         DiemGK = d == null ? null : d.DiemGK,
                         DiemCK = d == null ? null : d.DiemCK,

                         DiemTongKet = d == null ? null : d.DiemTongKet,
                         DiemChu = d == null ? null : d.DiemChu,
                         Diem4 = d == null ? null : d.Diem4
                     };
            return ds.ToList();
        }
        
    }
}
