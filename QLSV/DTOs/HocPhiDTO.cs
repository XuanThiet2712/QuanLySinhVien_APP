using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.DTOs
{
    internal class HocPhiDTO
    {
        public string MaSV { get; set; }
        public string HoTen { get; set; }
        public string MaHK { get; set; }
        public short TongTinChi { get; set; }
        public decimal DonGia { get; set; }
        public decimal TongTien { get; set; }
        public decimal GiamGia { get; set; }
        public decimal PhaiThu { get; set; }
        public decimal DaThu { get; set; }

        // Công nợ = Phải thu - Đã thu
        public decimal ConNo => PhaiThu - DaThu;
    }
}
