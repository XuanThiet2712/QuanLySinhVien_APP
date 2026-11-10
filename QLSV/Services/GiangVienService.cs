using QLSV.Data;
using QLSV.Helpers;
using QLSV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.Services
{
    public class GiangVienService
    {
        //Tìm giảng viên theo từ khóa và khoa
        public List<GiangVien> Search(string kw, string maKhoa)
        {
            using (var db = DbFactory.Create()) return new GiangVienRepository(db).Search(kw, maKhoa);
        }

        private Result KiemTra(GiangVien g)
        {
            if (g == null) return Result.Fail("Dữ liệu rỗng.");
            if (string.IsNullOrWhiteSpace(g.MaGV)) return Result.Fail("Mã giảng viên không được để trống.");
            if (string.IsNullOrWhiteSpace(g.HoTen)) return Result.Fail("Họ tên không được để trống.");
            if (string.IsNullOrWhiteSpace(g.MaKhoa)) return Result.Fail("Hãy chọn khoa.");
            
            if (!ValidationHelpers.EmailHopLe(g.Email)) return Result.Fail("Email không hợp lệ.");
            if (!ValidationHelpers.SdtHopLe(g.SDT)) return Result.Fail("Số điện thoại không hợp lệ.");
            return Result.Ok();
        }

        //Thêm giảng viên mới, chặn trùng mã
        public Result ThemMoi(GiangVien g)
        {
            Result kt = KiemTra(g);
            if (!kt.Success) return kt;
            try
            {
                using (var db = DbFactory.Create())
                {
                    var repo = new GiangVienRepository(db);
                    if (repo.ExistsId(g.MaGV.Trim())) return Result.Fail("Mã giảng viên đã tồn tại.");
                    repo.Add(new GiangVien { MaGV = g.MaGV.Trim(), HoTen = g.HoTen.Trim(), Email = g.Email.Trim(), SDT = g.SDT.Trim(), MaKhoa = g.MaKhoa});
                    db.SubmitChanges();
                    return Result.Ok("Đã thêm giảng viên.");
                }
            }
            catch (Exception ex) { return Result.Fail("Lỗi CSDL: " + ex.Message); }
        }

        //Lưu giảng viên:sửa
        public Result Luu(GiangVien g)
        {
            Result kt = KiemTra(g);
            if (!kt.Success) return kt;
            try
            {
                using (var db = DbFactory.Create())
                {
                    var repo = new GiangVienRepository(db);
                    GiangVien cu = repo.GetById(g.MaGV);
                    if (cu == null) return Result.Fail("Không tìm thấy giảng viên cần cập nhật");
                    else
                    {
                        cu.HoTen = g.HoTen.Trim();
                        cu.Email = g.Email;
                        cu.SDT = g.SDT;
                        cu.MaKhoa = g.MaKhoa;
                    }
                    db.SubmitChanges();
                    return Result.Ok("Đã lưu giảng viên.");
                }
            }
            catch (Exception ex) { return Result.Fail("Lỗi CSDL: " + ex.Message); }
        }

        //Xóa giảng viên; chặn nếu đang phụ trách lớp học phần
        public Result Xoa(string maGV)
        {
            try
            {
                using (var db = DbFactory.Create())
                {
                    var repo = new GiangVienRepository(db);
                    if (repo.CountLopHocPhan(maGV) > 0)
                        return Result.Fail("Không xóa được: giảng viên đang phụ trách lớp học phần.");
                    repo.Delete(maGV);
                    db.SubmitChanges();
                    return Result.Ok("Đã xóa giảng viên.");
                }
            }
            catch (Exception ex) { return Result.Fail("Lỗi CSDL: " + ex.Message); }
        }
    }
}

