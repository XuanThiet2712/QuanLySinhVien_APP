using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.DTOs
{
    public class BangDiemItemDTO
    {
        public string MaSV { get; set; }
        public string HoTen { get; set; }
        public string MaHK { get; set; }
        public string MaLHP { get; set; }

        public string MaMon { get; set; }
        public string TenMon { get; set; }
        public int SoTinChi { get; set; }

        public decimal? DiemCC { get; set; }
        public decimal? DiemGK { get; set; }
        public decimal? DiemCK { get; set; }
        public decimal? DiemTongKet { get; set; }

        public string DiemChu { get; set; }
        public decimal? Diem4 { get; set; }
    }
}
