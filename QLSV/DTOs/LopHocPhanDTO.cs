using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.DTOs
{
    public class LopHocPhanDTO
    {
        public string MaLHP { get; set; }
        public string MaMon { get; set; }
        public string TenMon { get; set; }
        public string MaGV { get; set; }
        public string TenGV { get; set; }
        public string MaHK { get; set; }
        public int SiSo { get; set; }
        public int SiSoToiDa { get; set; }
        public int Thu { get; set; }
        public int TietBatDau { get; set; }
        public int SoTiet { get; set; }
        public string Phong { get; set; }
    }
}
