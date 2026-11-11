using QLSV.Data;
using QLSV.DTOs;
using QLSV.Helpers;
using QLSV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.Services
{
    public class DangKyService
    {
        public List<HocKy> GetHocKy()
        {
            using (var db = DbFactory.Create())
            {
                return new DangKyRepository(db).GetHocKy();
            }
        }

        public List<LopDangKyDTO> GetLopMo(string maHK)
        {
            using (var db = DbFactory.Create())
            {
                return new DangKyRepository(db).GetLopTheoHocKy(maHK);
            }
        }

        public List<LopDangKyDTO> GetDaDangKy(string maSV, string maHK)
        {
            if (string.IsNullOrWhiteSpace(maSV)) 
                return new List<LopDangKyDTO>();
            using (var db = DbFactory.Create())
            {
                return new DangKyRepository(db).GetDaDangKy(maSV.Trim(), maHK);
            }
        }
        // Phải có quyền DANG_KY
        private static string KiemTraQuyen(string maSV)
        {
            if (!SessionManager.HasPermission(MaChucNang.DANG_KY))
                return "Bạn không có quyền đăng ký học phần.";
            string svCuaToi = SessionManager.CurrentUser.MaSV;
            if (!string.IsNullOrEmpty(svCuaToi) && svCuaToi != maSV)
                return "Bạn chỉ được đăng ký cho chính mình.";
            return null;
        }

        // Hai lớp trùng lịch: cùng thứ và khoảng tiết giao nhau.
        private static bool TrungLich(LopDangKyDTO a, LopDangKyDTO b)
        {
            return a.Thu == b.Thu
                && a.TietBatDau <= b.TietKetThuc
                && b.TietBatDau <= a.TietKetThuc;
        }

    }
}
