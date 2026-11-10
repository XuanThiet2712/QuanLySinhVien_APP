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
    public class KhoaService
    {
            //Lấy danh sách khoa
            public List<Khoa> GetAll()
            {
                using (var db = DbFactory.Create())
                {
                    return new KhoaRepository(db).GetAll();
                }
            }

            //Thêm khoa mới; báo lỗi nếu trùng mã.
            public Result ThemMoi(Khoa k)
            {
                if (k == null || string.IsNullOrWhiteSpace(k.MaKhoa) || string.IsNullOrWhiteSpace(k.TenKhoa))
                    return Result.Fail("Mã khoa và tên khoa không được để trống.");
                try
                {
                    using (var db = DbFactory.Create())
                    {
                        var repo = new KhoaRepository(db);
                        string maKhoaUpper = k.MaKhoa.Trim().ToUpper();

                        Khoa cu = repo.GetById(maKhoaUpper);
                        if (repo.ExistsId(k.MaKhoa.Trim())) return Result.Fail("Mã Khoa đã tồn tại.");
                        repo.Add(new Khoa { MaKhoa = k.MaKhoa.Trim(), TenKhoa = k.TenKhoa.Trim() });
                      
                        db.SubmitChanges();
                        return Result.Ok("Đã thêm Khoa thành công.");
                    }
                }
                catch (Exception ex) { return Result.Fail("Lỗi CSDL: " + ex.Message); }
            }

            //Lưu khoa: sửa tên khoa
            public Result Luu(Khoa k)
            {
                if (k == null || string.IsNullOrWhiteSpace(k.MaKhoa) || string.IsNullOrWhiteSpace(k.TenKhoa))
                    return Result.Fail("Mã khoa và tên khoa không được để trống.");
                try
                {
                    using (var db = DbFactory.Create())
                    {
                        var repo = new KhoaRepository(db);
                        Khoa cu = repo.GetById(k.MaKhoa);
                        if (cu == null)
                            return Result.Fail("Không tìm thấy Khoa cần cập nhật");
                        else { cu.MaKhoa = k.MaKhoa.Trim(); cu.TenKhoa = k.TenKhoa; }
                    db.SubmitChanges();
                        return Result.Ok("Đã cập nhật khoa thành công.");
                    }
                }
                catch (Exception ex) { return Result.Fail("Lỗi CSDL: " + ex.Message); }
            }

            //Xóa khoa; chặn nếu còn ngành
            public Result Xoa(string maKhoa)
            {
                try
                {
                    using (var db = DbFactory.Create())
                    {
                        var repo = new KhoaRepository(db);
                        if (repo.CountNganh(maKhoa) > 0)
                            return Result.Fail("Không thể xóa: khoa đang chứa ngành học.");
                        repo.Delete(maKhoa);
                        db.SubmitChanges();
                        return Result.Ok("Đã xóa khoa thành công.");
                    }
                }
                catch (Exception ex) { return Result.Fail("Lỗi CSDL: " + ex.Message); }
            }
        
    }
}
