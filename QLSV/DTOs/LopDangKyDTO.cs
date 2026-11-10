using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.DTOs
{
    public class LopDangKyDTO
    {
        [DisplayName("Mã lớp")]
        public string MaLHP { get; set; }

        [Browsable(false)] public string MaMon { get; set; }
        [Browsable(false)] public string MaHK { get; set; }

        [DisplayName("Môn học")]
        public string TenMon { get; set; }

        [DisplayName("Tín chỉ")]
        public int SoTinChi { get; set; }

        [DisplayName("Giảng viên")]
        public string TenGV { get; set; }

        [Browsable(false)] public int Thu { get; set; }
        [Browsable(false)] public int TietBatDau { get; set; }
        [Browsable(false)] public int SoTiet { get; set; }
        [Browsable(false)] public int SiSoToiDa { get; set; }
        [Browsable(false)] public int DaDangKy { get; set; }

        [DisplayName("Phòng")]
        public string Phong { get; set; }

        [Browsable(false)]
        public int TietKetThuc { get { return TietBatDau + SoTiet - 1; } }

        [DisplayName("Lịch học")]
        public string LichHoc 
        { 
            get { return "Thứ " + Thu + ", tiết " + TietBatDau + "-" + TietKetThuc; } 
        }

        [DisplayName("Sĩ số")]
        public string SiSo 
        { 
            get { return DaDangKy + "/" + SiSoToiDa; } 
        }
    }
}
