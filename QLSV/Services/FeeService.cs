using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using QLSV.Data;
using QLSV.DTOs;
using QLSV.Helpers;
using QLSV.Repositories;

namespace QLSV.Services
{
    public class FeeService
    {
        // tính học phí và công nợ của sinh viên trong một học kỳ
        public Result<HocPhiDTO> TinhHocPhi(string maSV, string maHK)
        {
            if (string.IsNullOrWhiteSpace(maSV) || string.IsNullOrWhiteSpace(maHK))
                return Result<HocPhiDTO>.Fail("Chưa nhập Mã sinh viên hoặc Mã học kỳ.");

            using (var db = DbFactory.Create())
            {
                return TinhHocPhiInternal(db, maSV, maHK);
            }
        }

        internal Result<HocPhiDTO> TinhHocPhiInternal(QLSVDataContext db, string maSV, string maHK)
        {
            maSV = maSV.Trim();
            maHK = maHK.Trim();
            var sv = db.SinhViens.FirstOrDefault(s => s.MaSV.Trim() == maSV);
            if (sv == null) return Result<HocPhiDTO>.Fail("Không tìm thấy sinh viên.");

            var hk = db.HocKies.FirstOrDefault(h => h.MaHK.Trim() == maHK);
            if (hk == null) return Result<HocPhiDTO>.Fail("Không tìm thấy học kỳ.");

            var dsMon = (from dk in db.DangKyHocPhans
                         join lhp in db.LopHocPhans on dk.MaLHP equals lhp.MaLHP
                         join mh in db.MonHocs on lhp.MaMon equals mh.MaMon
                         where dk.MaSV.Trim() == maSV && lhp.MaHK.Trim() == maHK
                         select mh).ToList();

            short tongTC = (short)dsMon.Sum(m => m.SoTinChi);
            decimal tongTien = tongTC * hk.DonGiaTinChi;

            decimal giamGia = 0m;
            decimal phaiThu = tongTien - giamGia;

            var repoPT = new PhieuThuRepository(db);
            decimal daThu = repoPT.GetTongDaThu(maSV, maHK);

            var dto = new HocPhiDTO
            {
                MaSV = maSV,
                HoTen = sv.HoTen,
                MaHK = maHK,
                TongTinChi = tongTC,
                DonGia = hk.DonGiaTinChi,
                TongTien = tongTien,
                GiamGia = giamGia,
                PhaiThu = phaiThu,
                DaThu = daThu
            };

            return Result<HocPhiDTO>.Ok(dto);
        }

        //Lập phiếu thu tiền học phí
        public Result<int> LapPhieuThu(string maSV, string maHK, decimal soTien, string ghiChu, int maNguoiLap)
        {
            if (soTien <= 0)
                return Result<int>.Fail("Số tiền thu phải lớn hơn 0.");

            try
            {
                using (var scope = new TransactionScope())
                using (var db = DbFactory.Create())
                {
                    var resHocPhi = TinhHocPhiInternal(db, maSV, maHK);
                    if (!resHocPhi.Success)
                        return Result<int>.Fail(resHocPhi.Message);

                    var hocPhi = resHocPhi.Data;
                    if (soTien > hocPhi.ConNo)
                        return Result<int>.Fail($"Số tiền thu vượt quá dư nợ ({hocPhi.ConNo:N0} đ).");

                    var pt = new PhieuThu
                    {
                        MaSV = maSV.Trim(),
                        MaHK = maHK.Trim(),
                        TongTinChi = hocPhi.TongTinChi,
                        TongTien = hocPhi.TongTien,
                        GiamGia = hocPhi.GiamGia,
                        PhaiThu = hocPhi.PhaiThu,
                        DaThu = soTien,
                        NgayLap = DateTime.Now,
                        NguoiLap = maNguoiLap,
                        GhiChu = ghiChu,
                        DaHuy = false
                    };

                    var repoPT = new PhieuThuRepository(db);
                    repoPT.Add(pt);
                    db.SubmitChanges();

                    scope.Complete();
                    return Result<int>.Ok(pt.MaPhieu, "Lập phiếu thu thành công.");
                }
            }
            catch (Exception ex)
            {
                return Result<int>.Fail("Lỗi lập phiếu thu: " + ex.Message);
            }
        }

        //Hủy phiếu thu trong cùng ngày
        public Result HuyPhieu(int maPhieu)
        {
            try
            {
                using (var db = DbFactory.Create())
                {
                    var repo = new PhieuThuRepository(db);
                    var pt = repo.GetById(maPhieu);

                    if (pt == null) return Result.Fail("Không tìm thấy phiếu thu.");
                    if (pt.DaHuy) return Result.Fail("Phiếu này đã được hủy trước đó.");
                    if (pt.NgayLap.Date != DateTime.Today)
                        return Result.Fail("Chỉ được hủy phiếu thu được lập trong ngày hôm nay.");

                    pt.DaHuy = true;
                    db.SubmitChanges();
                    return Result.Ok("Đã hủy phiếu thu thành công.");
                }
            }
            catch (Exception ex)
            {
                return Result.Fail("Lỗi hủy phiếu thu: " + ex.Message);
            }
        }
    }
}