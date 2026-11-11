using QLSV.Data;
using QLSV.Helpers;
using QLSV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace QLSV.Services
{
    public class MonHocService
    {
        //Tìm môn học theo từ khóa và khoa
        public List<MonHoc> Search(string kw, string maKhoa)
        {
            using (var db = DbFactory.Create()) return new MonHocRepository(db).Search(kw, maKhoa);
        }

        //Danh sách mã môn tiên quyết của một môn
        public List<string> GetTienQuyet(string maMon)
        {
            using (var db = DbFactory.Create()) return new MonHocRepository(db).GetTienQuyet(maMon);
        }

        //Lưu môn và danh sách tiên quyết trong một giao dịch
        public Result Luu(MonHoc m, List<string> tienQuyet)
        {
            if (m == null || string.IsNullOrWhiteSpace(m.MaMon)) return Result.Fail("Mã môn không được để trống.");
            if (string.IsNullOrWhiteSpace(m.TenMon)) return Result.Fail("Tên môn không được để trống.");
            if (string.IsNullOrWhiteSpace(m.MaKhoa)) return Result.Fail("Hãy chọn khoa.");
            if (m.SoTinChi < 1 || m.SoTinChi > 6) return Result.Fail("Số tín chỉ phải từ 1 đến 6.");
            if (tienQuyet == null) tienQuyet = new List<string>();
            if (tienQuyet.Contains(m.MaMon)) return Result.Fail("Môn học không thể là tiên quyết của chính nó.");

            try
            {
                // Một TransactionScope + đúng MỘT DataContext để tránh lỗi MSDTC
                using (var scope = new TransactionScope())
                using (var db = DbFactory.Create())
                {
                    var repo = new MonHocRepository(db);
                    if (TaoVong(repo, m.MaMon, tienQuyet))
                        return Result.Fail("Môn tiên quyết tạo thành vòng lặp.");

                    MonHoc cu = repo.GetById(m.MaMon);
                    if (cu == null)
                        repo.Add(new MonHoc
                        {
                            MaMon = m.MaMon.Trim(),
                            TenMon = m.TenMon.Trim(),
                            SoTinChi = m.SoTinChi,
                            MaKhoa = m.MaKhoa
                        });
                    else { cu.TenMon = m.TenMon.Trim(); cu.SoTinChi = m.SoTinChi; cu.MaKhoa = m.MaKhoa; }
                    db.SubmitChanges();   // môn phải có trước khi thêm tiên quyết (khóa ngoại)

                    repo.SetTienQuyet(m.MaMon, tienQuyet);
                    db.SubmitChanges();

                    scope.Complete();     // chỉ gọi khi mọi thứ thành công
                    return Result.Ok("Đã lưu môn học.");
                }
            }
            catch (Exception ex) { return Result.Fail("Lỗi CSDL: " + ex.Message); }
        }

        //Thêm môn mới: chặn trùng mã rồi gọi Luu
        public Result ThemMoi(MonHoc m, List<string> tienQuyet)
        {
            if (m == null || string.IsNullOrWhiteSpace(m.MaMon)) return Result.Fail("Mã môn không được để trống.");
            try
            {
                using (var db = DbFactory.Create())
                    if (new MonHocRepository(db).ExistsId(m.MaMon.Trim()))
                        return Result.Fail("Mã môn đã tồn tại.");
            }
            catch (Exception ex) { return Result.Fail("Lỗi CSDL: " + ex.Message); }
            return Luu(m, tienQuyet);
        }

        //Xóa môn; chặn nếu đã có lớp học phần hoặc đang là tiên quyết của môn khác
        public Result Xoa(string maMon)
        {
            try
            {
                using (var scope = new TransactionScope())
                using (var db = DbFactory.Create())
                {
                    var repo = new MonHocRepository(db);
                    if (repo.CountLopHocPhan(maMon) > 0)
                        return Result.Fail("Không xóa được: môn đã có lớp học phần.");
                    if (repo.CountLaTienQuyetCuaMonKhac(maMon) > 0)
                        return Result.Fail("Không xóa được: môn đang là tiên quyết của môn khác.");

                    repo.SetTienQuyet(maMon, new List<string>());   // gỡ tiên quyết của chính môn này
                    db.SubmitChanges();
                    repo.Delete(maMon);
                    db.SubmitChanges();
                    scope.Complete();
                    return Result.Ok("Đã xóa môn học.");
                }
            }
            catch (Exception ex) { return Result.Fail("Lỗi CSDL: " + ex.Message); }
        }

        // Duyệt đồ thị tiên quyết: gặp lại chính maMon nghĩa là có vòng.
        private bool TaoVong(MonHocRepository repo, string maMon, List<string> ds)
        {
            var daXet = new HashSet<string>();
            var stack = new Stack<string>(ds);
            while (stack.Count > 0)
            {
                string m = stack.Pop();
                if (m == maMon) return true;
                if (!daXet.Add(m)) continue;
                foreach (string p in repo.GetTienQuyet(m)) stack.Push(p);
            }
            return false;
        }
    }
}
