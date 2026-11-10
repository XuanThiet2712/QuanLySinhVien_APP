using QLSV.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using QLSV.DTOs;

namespace QLSV.Repositories
{
    public class LopHocPhanRepository
    {
        private readonly QLSVDataContext _db;
        public LopHocPhanRepository(QLSVDataContext db)
        {
            _db = db;
        }
        //hp theo ma
        public LopHocPhan GetById(string maLHP)
        {
            return _db.LopHocPhans.FirstOrDefault(x => x.MaLHP == maLHP);
        }
        //ds hp trg hk
        public List<LopHocPhan> GetByHocky(string maHK)
        {
            return _db.LopHocPhans.Where(x => x.MaHK == maHK).OrderBy(x => x.MaLHP).ToList();
        }
        //dem so sv
        public int GetSiSoHienTai(string maLHP)
        {
            return _db.DangKyHocPhans.Count(x => x.MaLHP == maLHP);
        }
        //them lhp
        public void Add(LopHocPhan lhp)
        {
            _db.LopHocPhans.InsertOnSubmit(lhp);
        }
        public List<LopHocPhanDTO> Search(string maHK, string maMon, string maGV)
        {
            IQueryable<LopHocPhan> q = _db.LopHocPhans;
            if (!string.IsNullOrWhiteSpace(maHK))
                q = q.Where(x => x.MaHK == maHK);

            if (!string.IsNullOrWhiteSpace(maMon))
                q = q.Where(x => x.MaMon == maMon);

            if (!string.IsNullOrWhiteSpace(maGV))
                q = q.Where(x => x.MaGV == maGV);

            var ds = from lhp in q
                     join m in _db.MonHocs
                         on lhp.MaMon equals m.MaMon
                     join gv in _db.GiangViens
                         on lhp.MaGV equals gv.MaGV
                     orderby lhp.MaLHP
                     select new LopHocPhanDTO
                     {
                         MaLHP = lhp.MaLHP,
                         MaMon = lhp.MaMon,
                         TenMon = m.TenMon,
                         MaGV = lhp.MaGV,
                         TenGV = gv.HoTen,
                         MaHK = lhp.MaHK,
                         SiSo = _db.DangKyHocPhans.Count(
                             dk => dk.MaLHP == lhp.MaLHP),
                         SiSoToiDa = lhp.SiSoToiDa,
                         Thu = lhp.Thu,
                         TietBatDau = lhp.TietBatDau,
                         SoTiet = lhp.SoTiet,
                         Phong = lhp.Phong
                     };

            return ds.ToList();
        }
        //laylop
        public List<LopHocPhan> GetByGiangVien(string maGV, string maHK)
        {
            return _db.LopHocPhans
                .Where(x => x.MaGV == maGV && x.MaHK == maHK)
                .ToList();
        }
        //ktra trungtiet
        public List<LopHocPhan> GetLichGV(string maGV, string maHK)
        {
            return GetByGiangVien(maGV, maHK);
        }
        //capnhat hp tontai
        public void Update(LopHocPhan cu, LopHocPhan moi)
        {
            cu.MaMon = moi.MaMon;
            cu.MaGV = moi.MaGV;
            cu.MaHK = moi.MaHK;
            cu.SiSoToiDa = moi.SiSoToiDa;
            cu.Thu = moi.Thu;
            cu.TietBatDau = moi.TietBatDau;
            cu.SoTiet = moi.SoTiet;
            cu.Phong = moi.Phong;
        }
        //danhdau xoa hp
        public void Delete(LopHocPhan lhp)
        {
            _db.LopHocPhans.DeleteOnSubmit(lhp);
        }

        //dgv cbohocky
        public List<HocKy> GetHocKys()
        {
            return _db.HocKies
                .OrderByDescending(x => x.TuNgay)
                .ToList();
        }

        //dgv cbomonhoc
        public List<MonHoc> GetMonHocs()
        {
            return _db.MonHocs
                .OrderBy(x => x.TenMon)
                .ToList();
        }
        //dgv cbogv
        public List<GiangVien> GetGiangViens()
        {
            return _db.GiangViens
                .OrderBy(x => x.HoTen)
                .ToList();
        }

    }
}
