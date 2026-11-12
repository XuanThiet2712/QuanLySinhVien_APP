using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLSV.Data;
using QLSV.DTOs;
using QLSV.Helpers;
using QLSV.Repositories;

namespace QLSV.Services
{
    public class DiemService
    {
        public double TinhDiemTongKet(double cc, double gk, double ck)
        {
            double tk = cc * 0.1 + gk * 0.3 + ck * 0.6;
            return Math.Round(tk, 1, MidpointRounding.AwayFromZero);
        }
        public string QuyDoiDiemChu(double tk)
        {
            if (tk >= 8.5) return "A";
            if (tk >= 8.0) return "B+";
            if (tk >= 7.0) return "B";
            if (tk >= 6.5) return "C+";
            if (tk >= 5.5) return "C";
            if (tk >= 5.0) return "D+";
            if (tk >= 4.0) return "D";
            return "F";
        }
        public double QuyDoiHe4(double tk) { 
            if (tk >= 8.5) return 4.0;
            if (tk >= 8.0) return 3.5;
            if (tk >= 7.0) return 3.0;
            if (tk >= 6.5) return 2.5;
            if (tk >= 5.5) return 2.0;
            if (tk >= 5.0) return 1.5;
            if (tk >= 4.0) return 1.0;
            return 0;
        }
        //ds lop co quyen nhap diem, gv chi thay lop minh
        public List<LopHocPhanDTO> GetLopDuocNhapDiem()
        {
            if (!SessionManager.HasPermission(MaChucNang.NHAP_DIEM))
                return new List<LopHocPhanDTO>();
            using (var db = DbFactory.Create())
            {
                var repo = new LopHocPhanRepository(db);
                if (SessionManager.IsInRole(MaNhom.GV))
                {
                    string MaGV = SessionManager.CurrentUser.MaGV;
                    if (string.IsNullOrWhiteSpace(MaGV))
                        return new List<LopHocPhanDTO>();
                    return repo.Search(null, null, MaGV);
                }
                return repo.Search(null, null, null);
            }
        } 

        public List<DiemDTO> GetDanhSachNhapDiem(string MaLHP)
        {
            if (!SessionManager.HasPermission(MaChucNang.NHAP_DIEM))
                return new List<DiemDTO>();

            using (var db = DbFactory.Create())
            {
                var lop = db.LopHocPhans
                    .FirstOrDefault(x => x.MaLHP == MaLHP);

                if (lop == null)
                    return new List<DiemDTO>();

                if (SessionManager.IsInRole(MaNhom.GV) &&
                    lop.MaGV != SessionManager.CurrentUser.MaGV)
                    return new List<DiemDTO>();

                var repo = new DiemRepository(db);

                return repo.GetByLHP(MaLHP);
            }
        }
        private bool DiemHopLe(decimal? diem)
        {
            return !diem.HasValue || (diem.Value >= 0 && diem.Value <= 10);
        }

        // chuyen sang chuoi
        private string ChuoiDiem(decimal? cc, decimal? gk, decimal? ck)
        {
            return "CC=" + (cc.HasValue ? cc.Value.ToString() : "-")
                + ";GK=" + (gk.HasValue ? gk.Value.ToString() : "-")
                + ";CK=" + (ck.HasValue ? ck.Value.ToString() : "-");
        }


    }
}
