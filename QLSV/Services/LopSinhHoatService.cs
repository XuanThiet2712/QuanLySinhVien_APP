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
    public class LopSinhHoatService
    {
        //Tất cả lớp
        public List<LopSinhHoat> GetAll()
        {
            using (var db = DbFactory.Create()) return new LopSinhHoatRepository(db).GetAll();
        }

        //Lớp thuộc một ngành
        public List<LopSinhHoat> GetByNganh(string maNganh)
        {
            using (var db = DbFactory.Create()) return new LopSinhHoatRepository(db).GetByNganh(maNganh);
        }

        private Result KiemTra(LopSinhHoat l)
        {
            if (l == null) return Result.Fail("Dữ liệu rỗng.");
            if (string.IsNullOrWhiteSpace(l.MaLop)) return Result.Fail("Mã lớp không được để trống.");
            if (string.IsNullOrWhiteSpace(l.TenLop)) return Result.Fail("Tên lớp không được để trống.");
            if (string.IsNullOrWhiteSpace(l.MaNganh)) return Result.Fail("Hãy chọn ngành.");
            return Result.Ok();
        }

        //Thêm lớp mới, chặn trùng mã
        public Result ThemMoi(LopSinhHoat l)
        {
            Result kt = KiemTra(l);
            if (!kt.Success) return kt;
            try
            {
                using (var db = DbFactory.Create())
                {
                    var repo = new LopSinhHoatRepository(db);
                    if (repo.ExistsId(l.MaLop.Trim())) return Result.Fail("Mã lớp đã tồn tại.");
                    repo.Add(new LopSinhHoat
                    {
                        MaLop = l.MaLop.Trim(),
                        TenLop = l.TenLop.Trim(),
                        NienKhoa = string.IsNullOrWhiteSpace(l.NienKhoa) ? null : l.NienKhoa.Trim(),
                        MaNganh = l.MaNganh
                    });
                    db.SubmitChanges();
                    return Result.Ok("Đã thêm lớp thành công.");
                }
            }
            catch (Exception ex) { return Result.Fail("Lỗi CSDL: " + ex.Message); }
        }

        //Lưu lớp: sửa
        public Result Luu(LopSinhHoat l)
        {
            Result kt = KiemTra(l);
            if (!kt.Success) return kt;
            try
            {
                using (var db = DbFactory.Create())
                {
                    var repo = new LopSinhHoatRepository(db);
                    //tìm bản ghi theo mã lớp
                    LopSinhHoat cu = repo.GetById(l.MaLop.Trim());
                    if (cu == null)
                        return Result.Fail("Không tìm thấy lớp cần cập nhật");
                    else { cu.TenLop = l.TenLop.Trim(); cu.MaNganh = l.MaNganh; cu.NienKhoa = string.IsNullOrWhiteSpace(l.NienKhoa) ? null : l.NienKhoa.Trim(); }
                    db.SubmitChanges();
                    return Result.Ok("Đã lưu lớp thành công.");
                }
            }
            catch (Exception ex) { return Result.Fail("Lỗi CSDL: " + ex.Message); }
        }

        //Xóa lớp; chặn nếu còn sinh viên
        public Result Xoa(string maLop)
        {
            try
            {
                using (var db = DbFactory.Create())
                {
                    var repo = new LopSinhHoatRepository(db);
                    if (repo.CountSinhVien(maLop) > 0) return Result.Fail("Không xóa được: lớp còn sinh viên.");
                    repo.Delete(maLop);
                    db.SubmitChanges();
                    return Result.Ok("Đã xóa lớp.");
                }
            }
            catch (Exception ex) { return Result.Fail("Lỗi CSDL: " + ex.Message); }
        }
    }

}
