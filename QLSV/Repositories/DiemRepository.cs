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
        //lay diem theo mhp
        public Diem GetByDangKy(int maDK)
        {
            return _db.Diems.FirstOrDefault(x => x.MaDK == maDK);
        }
        //chx co diem -> them moi
        //co = cap nhat
        public void Upsert(Diem diem)
        {
            Diem cu = GetByDangKy(diem.MaDK);
            if (cu == null)
            {
                _db.Diems.InsertOnSubmit(diem);
            }
            else
            {
                cu.DiemCC = diem.DiemCC;
                cu.DiemGK = diem.DiemGK;
                cu.DiemCK = diem.DiemCK;
                cu.DiemTongKet = diem.DiemTongKet;
                cu.DiemChu = diem.DiemChu;
                cu.Diem4 = diem.Diem4;
            }
        }
        // doc diem
        public List<Diem> GetByStudent(string maSV)
        {
            return (from d in _db.Diems
                    join dk in _db.DangKyHocPhans
                        on d.MaDK equals dk.MaDK
                    where dk.MaSV == maSV
                    orderby dk.MaDK
                    select d).ToList();
        }

    }
}
