
using QLSV.DTOs;
using QLSV.Repositories;
using System.Collections.Generic;

namespace QLSV.Services
{
    public class ThongKeService
    {
        private readonly ThongKeRepository _repo =
            new ThongKeRepository();

        // 1. Sinh viên theo khoa
        public List<ThongKeDTO> SoSinhVienTheoKhoa()
        {
            return _repo.SoSinhVienTheoKhoa();
        }

        // 2. Doanh thu 12 tháng
        public List<DoanhThuDTO> DoanhThu12Thang(int nam)
        {
            return _repo.DoanhThu12Thang(nam);
        }

        // 3. Tỉ lệ xếp loại học lực
        public List<ThongKeDTO> TyLeXepLoaiHocLuc(string maHK)
        {
            return _repo.TyLeXepLoaiHocLuc(maHK);
        }

        // 4. Top 5 môn đông nhất
        public List<ThongKeDTO> Top5MonDongNhat(string maHK)
        {
            return _repo.Top5MonDongNhat(maHK);
        }
    }
}
