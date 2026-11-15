using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        private const int GHI_CHU_TOI_DA = 200; // khớp NVARCHAR(200) của PhieuThu.GhiChu

        // tính học phí và công nợ của sinh viên trong một học kỳ
        public Result<HocPhiDTO> TinhHocPhi(string maSV, string maHK)
        {
            if (string.IsNullOrWhiteSpace(maSV) || string.IsNullOrWhiteSpace(maHK))
                return Result<HocPhiDTO>.Fail("Chưa nhập Mã sinh viên hoặc Mã học kỳ.");

            try
            {
                using (var db = DbFactory.Create())
                {
                    return TinhHocPhiInternal(db, maSV, maHK);
                }
            }
            catch (Exception ex)
            {
                return Result<HocPhiDTO>.Fail("Lỗi tra cứu học phí: " + ex.Message);
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
            if (string.IsNullOrWhiteSpace(maSV) || string.IsNullOrWhiteSpace(maHK))
                return Result<int>.Fail("Chưa nhập Mã sinh viên hoặc Mã học kỳ.");

            if (soTien <= 0)
                return Result<int>.Fail("Số tiền thu phải lớn hơn 0.");

            // Cột DaThu là DECIMAL(18,0): số lẻ sẽ bị SQL làm tròn âm thầm, nên chặn từ đầu
            if (soTien != decimal.Truncate(soTien))
                return Result<int>.Fail("Số tiền thu phải là số nguyên (đồng).");

            maSV = maSV.Trim();
            maHK = maHK.Trim();
            ghiChu = string.IsNullOrWhiteSpace(ghiChu) ? null : ghiChu.Trim();

            if (ghiChu != null && ghiChu.Length > GHI_CHU_TOI_DA)
                return Result<int>.Fail($"Ghi chú tối đa {GHI_CHU_TOI_DA} ký tự.");

            var options = new TransactionOptions
            {
                IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,
                Timeout = TimeSpan.FromSeconds(30)
            };

            try
            {
                using (var scope = new TransactionScope(TransactionScopeOption.Required, options))
                using (var db = DbFactory.Create())
                {
                    // Khóa dòng sinh viên cho tới khi transaction kết thúc: hai người cùng thu
                    // cho một sinh viên sẽ phải xếp hàng, người sau tính công nợ trên số liệu
                    // đã có phiếu của người trước => không thu vượt nợ, không deadlock.
                    db.ExecuteCommand("SELECT 1 FROM dbo.SinhVien WITH (UPDLOCK, HOLDLOCK) WHERE MaSV = {0}", maSV);

                    var resHocPhi = TinhHocPhiInternal(db, maSV, maHK);
                    if (!resHocPhi.Success)
                        return Result<int>.Fail(resHocPhi.Message);

                    var hocPhi = resHocPhi.Data;
                    if (hocPhi.ConNo <= 0)
                        return Result<int>.Fail("Sinh viên không còn dư nợ trong học kỳ này.");

                    if (soTien > hocPhi.ConNo)
                        return Result<int>.Fail($"Số tiền thu vượt quá dư nợ ({hocPhi.ConNo:N0} đ).");

                    var pt = new PhieuThu
                    {
                        MaSV = maSV,
                        MaHK = maHK,
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
            catch (SqlException ex) when (ex.Number == 547)
            {
                return Result<int>.Fail("Người lập phiếu không tồn tại trong hệ thống.");
            }
            catch (SqlException ex) when (ex.Number == 1205)
            {
                return Result<int>.Fail("Hệ thống đang bận, vui lòng thử lại.");
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