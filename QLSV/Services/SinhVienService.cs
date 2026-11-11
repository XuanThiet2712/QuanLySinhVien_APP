using QLSV.Data;
using QLSV.DTOs;
using QLSV.Helpers;
using QLSV.Repositories;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QLSV.Services
{
    //Nghiệp vụ sinh viên. Phần Excel nằm ở SinhVienService.Excel.cs
    public partial class SinhVienService
    {
        //Tìm kiếm có phân trang
        public List<SinhVienDTO> Search(string kw, string maLop, int page, int size)
        {
            using (var db = DbFactory.Create())
                return new SinhVienRepository(db).Search(kw, maLop, page, size);
        }

        //Tổng số bản ghi theo bộ lọc
        public int Count(string kw, string maLop)
        {
            using (var db = DbFactory.Create())
                return new SinhVienRepository(db).Count(kw, maLop);
        }

        //Lấy một sinh viên đầy đủ theo mã
        public SinhVien GetById(string maSV)
        {
            using (var db = DbFactory.Create())
                return new SinhVienRepository(db).GetById(maSV);
        }

        private Result KiemTra(SinhVien s)
        {
            if (s == null) return Result.Fail("Dữ liệu rỗng.");
            if (string.IsNullOrWhiteSpace(s.MaSV)) return Result.Fail("Mã sinh viên không được để trống.");
            if (string.IsNullOrWhiteSpace(s.HoTen)) return Result.Fail("Họ tên không được để trống.");
            if (s.GioiTinh != "Nam" && s.GioiTinh != "Nữ") return Result.Fail("Giới tính chỉ nhận Nam hoặc Nữ.");
            if (string.IsNullOrWhiteSpace(s.MaLop)) return Result.Fail("Hãy chọn lớp.");
            if (!ValidationHelpers.EmailHopLe(s.Email)) return Result.Fail("Email không hợp lệ.");
            if (!ValidationHelpers.SdtHopLe(s.SDT)) return Result.Fail("Số điện thoại không hợp lệ.");
            if (ValidationHelpers.TinhTuoi(s.NgaySinh) < 16) return Result.Fail("Sinh viên phải từ 16 tuổi trở lên.");
            return Result.Ok();
        }

        //Thêm sinh viên mới, chặn trùng mã
        public Result ThemMoi(SinhVien s)
        {
            Result kt = KiemTra(s);
            if (!kt.Success) return kt;
            try
            {
                using (var db = DbFactory.Create())
                {
                    var repo = new SinhVienRepository(db);
                    if (repo.ExistsId(s.MaSV)) return Result.Fail("Mã sinh viên đã tồn tại.");
                    repo.Add(s);
                    db.SubmitChanges();
                    return Result.Ok("Đã thêm sinh viên.");
                }
            }
            catch (Exception ex) { return Result.Fail("Lỗi CSDL: " + ex.Message); }
        }

        //Lưu sinh viên: sửa (không có ảnh mới thì giữ ảnh cũ)
        public Result Luu(SinhVien s)
        {
            Result kt = KiemTra(s);
            if (!kt.Success) return kt;
            try
            {
                using (var db = DbFactory.Create())
                {
                    var repo = new SinhVienRepository(db);
                    SinhVien cu = repo.GetById(s.MaSV);
                    if (cu == null) repo.Add(s);
                    else
                    {
                        cu.HoTen = s.HoTen;
                        cu.NgaySinh = s.NgaySinh;
                        cu.GioiTinh = s.GioiTinh;
                        cu.Email = s.Email;
                        cu.SDT = s.SDT;
                        cu.DiaChi = s.DiaChi;
                        cu.MaLop = s.MaLop;
                        if (s.AnhDaiDien != null) cu.AnhDaiDien = s.AnhDaiDien;
                    }
                    db.SubmitChanges();
                    return Result.Ok("Đã lưu sinh viên.");
                }
            }
            catch (Exception ex) { return Result.Fail("Lỗi CSDL: " + ex.Message); }
        }

        //Xóa sinh viên; chặn nếu đã có đăng ký học phần
        public Result Xoa(string maSV)
        {
            try
            {
                using (var db = DbFactory.Create())
                {
                    var repo = new SinhVienRepository(db);
                    if (repo.CountDangKy(maSV) > 0)
                        return Result.Fail("Không xóa được: sinh viên đã có đăng ký học phần.");
                    repo.Delete(maSV);
                    db.SubmitChanges();
                    return Result.Ok("Đã xóa sinh viên.");
                }
            }
            catch (Exception ex) { return Result.Fail("Lỗi CSDL: " + ex.Message); }
        }

        /// <summary>Gợi ý mã sinh viên mới của lớp (mã lớn nhất + 1); rỗng nếu lớp chưa có sinh viên.</summary>
        public string TaoMaSV(string maLop)
        {
            using (var db = DbFactory.Create())
            {
                string max = new SinhVienRepository(db).GetMaxMaSVTheoLop(maLop);
                if (string.IsNullOrEmpty(max)) return "";
                var m = Regex.Match(max, @"^(.*?)(\d+)$");   // tách phần chữ và phần số cuối
                if (!m.Success) return "";
                int so = int.Parse(m.Groups[2].Value) + 1;
                return m.Groups[1].Value + so.ToString().PadLeft(m.Groups[2].Length, '0');
            }
        }
    }
}
