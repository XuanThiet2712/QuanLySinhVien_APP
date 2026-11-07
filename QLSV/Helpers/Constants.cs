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
        public const string QL_USER = "QL_USER";
        public const string QL_ROLE = "QL_ROLE";
        public const string CAU_HINH = "CAU_HINH";
        public const string QL_KHOA = "QL_KHOA";
        public const string QL_NGANH = "QL_NGANH";
        public const string QL_LOP = "QL_LOP";
        public const string QL_SINHVIEN = "QL_SINHVIEN";
        public const string QL_GIANGVIEN = "QL_GIANGVIEN";
        public const string QL_MONHOC = "QL_MONHOC";
        public const string QL_LOPHOCPHAN = "QL_LOPHOCPHAN";
        public const string DANG_KY = "DANG_KY";
        public const string NHAP_DIEM = "NHAP_DIEM";
        public const string XEM_DIEM = "XEM_DIEM";
        public const string THU_HOC_PHI = "THU_HOC_PHI";
        public const string THONG_KE = "THONG_KE";
    }
    //Mã nhóm quyền, trùng với cột MaNhom trong bảng NhomQuyen
    public static class MaNhom
    {
        public const string ADMIN = "ADMIN";
        public const string PDT = "PDT";
        public const string GV = "GV";
        public const string KT = "KT";
        public const string SV = "SV";
    }
    //Giới hạn tổng tín chỉ một học kỳ khi đăng ký học phần
    public static class GioiHanTinChi
    {
        public const int ToiThieu = 14;
        public const int ToiDa = 25;
    }


}