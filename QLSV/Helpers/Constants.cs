using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.Helpers
{

    // Ma chuc nang cho Phân Quyền . Trùng MaCN trong table ChucNang 
    // Cách dùng: SessionManager.HasPermission(MaChucNang.QL_KHOA)

    public static class MaChucNang
    {
        public const string QL_USER = "QL_USER"; // Quản lý tài khoản
        public const string QL_ROLE = "QL_ROLE"; // Quản lý nhóm quyền
        public const string CAU_HINH = "CAU_HINH"; 
        //Cấu hình kết nối CSDL, cấu hình hệ thống
        public const string QL_KHOA = "QL_KHOA";

        public const string QL_NGANH = "QL_NGANH";
        public const string QL_LOP = "QL_LOP";
        public const string QL_SINHVIEN = "QL_SINHVIEN";
        public const string QL_GIANGVIEN = "QL_GIANGVIEN";
        public const string QL_MONHOC = "QL_MONHOC";
        public const string QL_LOPHOCPHAN = "QL_LOPHOCPHAN";
        public const string DANG_KY = "DANG_KY"; // Đăng ký học phần
        public const string NHAP_DIEM = "NHAP_DIEM";
        public const string XEM_DIEM = "XEM_DIEM";
        public const string THU_HOC_PHI = "THU_HOC_PHI";
        public const string THONG_KE = "THONG_KE"; // thống kê và biểu đồ
    }

    //Mã nhóm quyền, trùng với cột MaNhom trong bảng NhomQuyen
    public static class MaNhom // nhom nguoi dùng
    {
        public const string ADMIN = "ADMIN";
        public const string PDT = "PDT"; // Phòng đào tạo
        public const string GV = "GV";
        public const string KT = "KT"; // kế toán
        public const string SV = "SV";
    }
    //Giới hạn tổng tín chỉ một học kỳ khi đăng ký học phần
    public static class GioiHanTinChi
    {
        public const int ToiThieu = 14;
        public const int ToiDa = 25;
    }

    //Tỉ lệ tính điểm tổng kết và các ngưỡng liên quan đến điểm
    public static class ThangDiem
    {
        public const double TyLeChuyenCan = 0.1;
        public const double TyLeGiuaKy = 0.3;
        public const double TyLeCuoiKy = 0.6;

      //Điểm tổng kết tối thiểu để tính là ĐẠT 
        public const double DiemDat = 4.0;

    //Cảnh báo học vụ: GPA học kỳ thấp hơn mức này
        public const double NguongGpaCanhBao = 1.0;

       //Cảnh báo học vụ: số tín chỉ nợ vượt mức này
        public const int NguongTinChiNo = 8;
    }
    //Các hằng số liên quan đến tài khoản người dùng

    public static class TaiKhoan // mat khau mac dinh khi reset
    {
        public const string MatKhauMacDinh = "123456";
        public const int DoDaiMatKhauToiThieu = 6;
    }
}