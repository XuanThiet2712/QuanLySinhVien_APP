using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.DTOs
{
    //Dòng hiển thị sinh viên trên lưới (đã nối lớp, ngành, khoa)
    public class SinhVienDTO
    {
        public string MaSV { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }   
        public string TenLop { get; set; }
        public string TenNganh { get; set; }
        public string TenKhoa { get; set; }
    }
}
