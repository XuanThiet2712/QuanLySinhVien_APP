using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.DTOs
{
    public class NguoiDungDTO
    {
        public int MaND { get; set; }
        public string TenDangNhap { get; set; }
        public string TenNhom { get; set; }
        public string DoiTuong { get; set; }    // mã SV hoặc mã GV, nếu có
        public string TrangThai { get; set; }   // "Hoạt động" hoặc "Đã khóa"
    }
}
