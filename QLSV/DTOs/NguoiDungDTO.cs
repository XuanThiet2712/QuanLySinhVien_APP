using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.DTOs
{
    public class NguoiDungDTO
    {
        [Browsable(false)]
        public int MaND { get; set; }
        [DisplayName("Ten dang nhap")]
        public string TenDangNhap { get; set; }
        [DisplayName("Ten nhom")]
        public string TenNhom { get; set; }
        [DisplayName("Doi tuong")]
        public string DoiTuong { get; set; }    // mã SV hoặc mã GV, nếu có
        public string TrangThai { get; set; }   // "Hoạt động" hoặc "Đã khóa"
    }
}
