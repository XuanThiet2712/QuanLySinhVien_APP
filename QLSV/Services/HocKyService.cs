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
    public class HocKyService
    {
        // Tất cả học kỳ, mới nhất trước
        public List<HocKy> GetAll()
        {
            using (var db = DbFactory.Create()) return new HocKyRepository(db).GetAll();
        }

        //Học kỳ hiện tại theo ngày hôm nay (có thể null)
        public HocKy GetHienTai()
        {
            using (var db = DbFactory.Create()) return new HocKyRepository(db).GetHienTai();
        }

        private Result KiemTra(HocKy h)
        {
            if (h == null) return Result.Fail("Dữ liệu rỗng.");
            if (string.IsNullOrWhiteSpace(h.MaHK)) return Result.Fail("Mã học kỳ không được để trống.");
            if (string.IsNullOrWhiteSpace(h.TenHK)) return Result.Fail("Tên học kỳ không được để trống.");
            if (string.IsNullOrWhiteSpace(h.NamHoc)) return Result.Fail("Năm học không được để trống.");
            if (h.TuNgay >= h.DenNgay) return Result.Fail("Từ ngày phải nhỏ hơn đến ngày.");
            if (h.DonGiaTinChi <= 0) return Result.Fail("Đơn giá tín chỉ phải lớn hơn 0.");
            return Result.Ok();
        }

        //Lưu học kỳ: sửa
        public Result Luu(HocKy h)
        {
            Result kt = KiemTra(h);
            if (!kt.Success) return kt;
            try
            {
                using (var db = DbFactory.Create())
                {
                    var repo = new HocKyRepository(db);
                    HocKy cu = repo.GetById(h.MaHK);
                    if (cu == null) return Result.Fail("Không tìm thấy học kỳ cần cập nhật");

                    cu.TenHK = h.TenHK.Trim(); cu.NamHoc = h.NamHoc.Trim(); cu.TuNgay = h.TuNgay; cu.DenNgay = h.DenNgay; cu.DonGiaTinChi = h.DonGiaTinChi;

                    db.SubmitChanges();


                    return Result.Ok("Đã lưu học kỳ.");
                }
            }

            catch (Exception ex) { return Result.Fail("Lỗi CSDL: " + ex.Message); }
        }

        //Thêm học kỳ mới, chặn trùng mã
        public Result ThemMoi(HocKy h)
        {
            Result kt = KiemTra(h); 
            if (!kt.Success) return kt;
            try
            {
                using (var db = DbFactory.Create())
                {
                    var repo = new HocKyRepository(db);
                    if (repo.ExistsId(h.MaHK.Trim())) return Result.Fail("Mã học kỳ đã tồn tại.");
                    repo.Add(new HocKy { MaHK = h.MaHK.Trim(), TenHK = h.TenHK.Trim(), NamHoc = h.NamHoc.Trim(), TuNgay = h.TuNgay, DenNgay = h.DenNgay, DonGiaTinChi = h.DonGiaTinChi });
                    db.SubmitChanges();
                    return Result.Ok("Đã lưu học kỳ");
                }
            }
            catch (Exception ex) { return Result.Fail("Lỗi CSDL: " + ex.Message); }
            
        }

        //Xóa học kỳ; chặn nếu đã có lớp học phần
        public Result Xoa(string maHK)
        {
            try
            {
                using (var db = DbFactory.Create())
                {
                    var repo = new HocKyRepository(db);
                    if (repo.CountLopHocPhan(maHK) > 0)
                        return Result.Fail("Không xóa được: học kỳ đã có lớp học phần.");
                    repo.Delete(maHK);
                    db.SubmitChanges();
                    return Result.Ok("Đã xóa học kỳ.");
                }
            }
            catch (Exception ex) { return Result.Fail("Lỗi CSDL: " + ex.Message); }
        }
    }
}
