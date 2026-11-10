using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QLSV.Helpers
{
    //Các hàm kiểm tra dữ liệu dùng chung cho nhiều Service 
    public class ValidationHelpers
    {
        //Email hợp lệ. Nếu batBuoc = false thì để trống vẫn hợp lệ
        public static bool EmailHopLe(string email, bool batBuoc = false)
        {
            if (string.IsNullOrWhiteSpace(email)) return !batBuoc;
            return Regex.IsMatch(email.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        //Số điện thoại: 9-11 chữ số, cho phép để trống
        public static bool SdtHopLe(string sdt)
        {
            if (string.IsNullOrWhiteSpace(sdt)) return true;
            return Regex.IsMatch(sdt.Trim(), @"^\d{9,11}$");
        }

        //Tính tuổi tính đến hôm nay
        public static int TinhTuoi(DateTime ngaySinh)
        {
            int tuoi = DateTime.Today.Year - ngaySinh.Year;
            if (ngaySinh.Date > DateTime.Today.AddYears(-tuoi)) tuoi--;   // chưa tới sinh nhật năm nay
            return tuoi;
        }
    }
}

