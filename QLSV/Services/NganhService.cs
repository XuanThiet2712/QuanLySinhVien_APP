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
    public class NganhService
    {
        //Tất cả ngành
        public List<Nganh> GetAll()
        {
            using (var db = DbFactory.Create()) return new NganhRepository(db).GetAll();
        }

        //Ngành thuộc một khoa.
        public List<Nganh> GetByKhoa(string maKhoa)
        {
            using (var db = DbFactory.Create()) return new NganhRepository(db).GetByKhoa(maKhoa);
        }

        private Result KiemTra(Nganh n)
        {
            if (n == null) return Result.Fail("Dữ liệu rỗng.");
            if (string.IsNullOrWhiteSpace(n.MaNganh)) return Result.Fail("Mã ngành không được để trống.");
            if (string.IsNullOrWhiteSpace(n.TenNganh)) return Result.Fail("Tên ngành không được để trống.");
            if (string.IsNullOrWhiteSpace(n.MaKhoa)) return Result.Fail("Hãy chọn khoa.");
            return Result.Ok();
        }

        //Thêm ngành mới, chặn trùng mã.
        public Result ThemMoi(Nganh n)
        {
            Result kt = KiemTra(n);
            if (!kt.Success) return kt;
            try
            {
                using (var db = DbFactory.Create())
                {
                    var repo = new NganhRepository(db);
                    //kiểm tra trùng mã ngành
                    if (repo.ExistsId(n.MaNganh.Trim())) return Result.Fail("Mã ngành đã tồn tại.");
                    repo.Add(new Nganh { MaNganh = n.MaNganh.Trim(), TenNganh = n.TenNganh.Trim(), MaKhoa = n.MaKhoa });
                    db.SubmitChanges();
                    return Result.Ok("Đã thêm ngành.");
                }
            }
            catch (Exception ex) { return Result.Fail("Lỗi CSDL: " + ex.Message); }
        }

        //Lưu ngành: sửa
        public Result Luu(Nganh n)
        {
            Result kt = KiemTra(n);
            if (!kt.Success) return kt;
            try
            {
                using (var db = DbFactory.Create())
                {
                    var repo = new NganhRepository(db);
                    //tìm bản ghi cần sửa theo mã ngành
                    Nganh cu = repo.GetById(n.MaNganh);

                    if (cu == null)
                        return Result.Fail("Không tìm thấy ngành cần cập nhật");
                    else { cu.TenNganh = n.TenNganh.Trim(); cu.MaKhoa = n.MaKhoa; }
                    db.SubmitChanges();
                    return Result.Ok("Đã cập nhật ngành.");
                }
            }
            catch (Exception ex) { return Result.Fail("Lỗi CSDL: " + ex.Message); }
        }

        //Xóa ngành; chặn nếu còn lớp.
        public Result Xoa(string maNganh)
        {
            try
            {
                using (var db = DbFactory.Create())
                {
                    var repo = new NganhRepository(db);
                    if (repo.CountLop(maNganh) > 0) return Result.Fail("Không xóa được: ngành còn lớp.");
                    repo.Delete(maNganh);
                    db.SubmitChanges();
                    return Result.Ok("Đã xóa ngành.");
                }
            }
            catch (Exception ex) { return Result.Fail("Lỗi CSDL: " + ex.Message); }
        }
    }
}

