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
        [DisplayName("Mã lớp HP")]
        public string MaLHP { get; set; }

        [DisplayName("Mã môn")]
        public string MaMon { get; set; }

        [Browsable(false)] public string MaHK { get; set; }

        [DisplayName("Tên môn học")]
        public string TenMon { get; set; }

        [DisplayName("Tín chỉ")]
        public int SoTinChi { get; set; }

        [Browsable(false)] public string TenGV { get; set; }
        [Browsable(false)] public string Phong { get; set; }

        [Browsable(false)] public int Thu { get; set; }
        [Browsable(false)] public int TietBatDau { get; set; }
        [Browsable(false)] public int SoTiet { get; set; }
        [Browsable(false)] public int SiSoToiDa { get; set; }
        [Browsable(false)] public int DaDangKy { get; set; }

        [Browsable(false)]
        public int TietKetThuc { get { return TietBatDau + SoTiet - 1; } }

        [DisplayName("Lịch học")]
        public string LichHoc
        {
            get { return "Thứ " + Thu + ", tiết " + TietBatDau + "-" + TietKetThuc; }
        }

        [DisplayName("Thứ")]
        public string ThuHoc
        {
            get { return Thu.ToString(); }
        }

        [DisplayName("Tiết học")]
        public string TietHoc
        {
            get { return TietBatDau + "-" + TietKetThuc; }
        }

        [DisplayName("Sĩ số")]
        public string SiSo
        {
            get { return DaDangKy + "/" + SiSoToiDa; }
        }

        // Form gán sau khi tải: "Còn chỗ" / "Đã đầy" / "Đã đăng ký"
        [DisplayName("Trạng thái")]
        public string TrangThai { get; set; }
    }

    // Thông tin hiển thị ở khung "Thông tin sinh viên" của form đăng ký
    public class ThongTinSvDangKyDTO
    {
        public string MaSV { get; set; }
        public string HoTen { get; set; }
        public string TenKhoa { get; set; }
        public string TenLop { get; set; }
        public byte[] Anh { get; set; }
    }
}