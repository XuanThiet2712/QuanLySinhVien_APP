/* =====================================================================
   QLSV - 02_Seed.sql
   Nạp dữ liệu mẫu. Chạy SAU 01_CreateTables.sql. Chạy lần 2 sẽ tự dừng
   (không nhân đôi dữ liệu); muốn nạp lại từ đầu thì chạy lại 01 trước.

   TÀI KHOẢN MẪU (mật khẩu tất cả: 123456)
   ---------------------------------------------------------------------
   admin       Quản trị hệ thống   QL_USER, QL_ROLE, CAU_HINH, THONG_KE
   pdt01       Phòng đào tạo       danh mục, lớp học phần, đăng ký, xem điểm
   gv001       Giảng viên GV001    nhập điểm, xem điểm (dạy L2526-01, L2627-01, L2627-03, L2627-10)
   kt01        Kế toán             thu học phí, thống kê
   sv2501001   SV Nguyễn Văn An    đã đạt COMP1010 (A), COMP1020, MATH1001, ENGL1001
   sv2501002   SV Trần Thị Bình    TRƯỢT COMP1010 (F)  -> test chặn môn tiên quyết
   sv2501004   SV Phạm Thu Dung    đã đăng ký 5 tín chỉ HK1_2627 -> test cộng dồn giới hạn tín chỉ

   CÁCH BĂM MẬT KHẨU (PasswordHasher phải làm ĐÚNG như vậy thì đăng nhập mới khớp):
     salt = Convert.ToBase64String(16 byte ngẫu nhiên)
     hash = Convert.ToBase64String( SHA256( Encoding.UTF8.GetBytes(matKhau + salt) ) )

   KỊCH BẢN TEST ĐĂNG KÝ HỌC PHẦN (học kỳ HK1_2627)
   ---------------------------------------------------------------------
   - Tiên quyết : sv2501002 đăng ký L2627-01 (COMP1011) -> bị chặn (COMP1010 = F)
                  mọi SV đăng ký L2627-03 (COMP1019)    -> bị chặn (chưa đạt COMP1011)
   - Trùng lịch : L2627-01 (Thứ 2, tiết 1-3) và L2627-02 (Thứ 2, tiết 2-4)
   - Lớp đầy    : L2627-10 sĩ số tối đa 2, đã có 2 SV (2501004, 2501005)
   - Tín chỉ    : sv2501001 chọn L2627-01, 04, 05, 08, 09 = 14 tín chỉ, không trùng lịch -> hợp lệ
                  chọn ít hơn 14 hoặc nhiều hơn 25 -> bị chặn
                  sv2501004 đã có 5 tín chỉ, chọn thêm 3 môn (9 tín chỉ) = 14 -> hợp lệ
   ===================================================================== */

USE QLSV;
GO

SET NOCOUNT ON;
SET XACT_ABORT ON;

IF EXISTS (SELECT 1 FROM dbo.NhomQuyen)
BEGIN
    PRINT N'CSDL đã có dữ liệu. Chạy lại 01_CreateTables.sql nếu muốn nạp lại từ đầu.';
    RETURN;
END

BEGIN TRANSACTION;

-- Nhóm quyền
INSERT INTO dbo.NhomQuyen (MaNhom, TenNhom) VALUES
    (N'ADMIN', N'Quản trị hệ thống'),
    (N'PDT', N'Phòng đào tạo'),
    (N'GV', N'Giảng viên'),
    (N'KT', N'Kế toán'),
    (N'SV', N'Sinh viên');

-- Chức năng (mã trùng với Helpers/Constants.cs)
INSERT INTO dbo.ChucNang (MaCN, TenCN) VALUES
    (N'QL_USER', N'Quản lý tài khoản'),
    (N'QL_ROLE', N'Quản lý phân quyền'),
    (N'CAU_HINH', N'Cấu hình kết nối CSDL'),
    (N'QL_KHOA', N'Quản lý khoa'),
    (N'QL_NGANH', N'Quản lý ngành'),
    (N'QL_LOP', N'Quản lý lớp sinh hoạt'),
    (N'QL_SINHVIEN', N'Quản lý sinh viên'),
    (N'QL_GIANGVIEN', N'Quản lý giảng viên'),
    (N'QL_MONHOC', N'Quản lý môn học'),
    (N'QL_LOPHOCPHAN', N'Quản lý lớp học phần'),
    (N'DANG_KY', N'Đăng ký học phần'),
    (N'NHAP_DIEM', N'Nhập điểm'),
    (N'XEM_DIEM', N'Xem điểm / in bảng điểm'),
    (N'THU_HOC_PHI', N'Thu học phí'),
    (N'THONG_KE', N'Thống kê và biểu đồ');

-- Phân quyền theo nhóm
INSERT INTO dbo.PhanQuyen (MaNhom, MaCN) VALUES
    (N'ADMIN', N'QL_USER'),
    (N'ADMIN', N'QL_ROLE'),
    (N'ADMIN', N'CAU_HINH'),
    (N'ADMIN', N'THONG_KE'),
    (N'PDT', N'QL_KHOA'),
    (N'PDT', N'QL_NGANH'),
    (N'PDT', N'QL_LOP'),
    (N'PDT', N'QL_SINHVIEN'),
    (N'PDT', N'QL_GIANGVIEN'),
    (N'PDT', N'QL_MONHOC'),
    (N'PDT', N'QL_LOPHOCPHAN'),
    (N'PDT', N'DANG_KY'),
    (N'PDT', N'XEM_DIEM'),
    (N'PDT', N'THONG_KE'),
    (N'GV', N'NHAP_DIEM'),
    (N'GV', N'XEM_DIEM'),
    (N'KT', N'THU_HOC_PHI'),
    (N'KT', N'THONG_KE'),
    (N'SV', N'DANG_KY'),
    (N'SV', N'XEM_DIEM');

-- Khoa
INSERT INTO dbo.Khoa (MaKhoa, TenKhoa) VALUES
    (N'CNTT', N'Công nghệ thông tin'),
    (N'TOAN', N'Toán - Tin'),
    (N'NN', N'Ngoại ngữ');

-- Ngành
INSERT INTO dbo.Nganh (MaNganh, TenNganh, MaKhoa) VALUES
    (N'CNTT', N'Công nghệ thông tin', N'CNTT'),
    (N'SPTIN', N'Sư phạm Tin học', N'CNTT'),
    (N'SPTOAN', N'Sư phạm Toán học', N'TOAN'),
    (N'NNANH', N'Ngôn ngữ Anh', N'NN');

-- Lớp sinh hoạt
INSERT INTO dbo.LopSinhHoat (MaLop, TenLop, MaNganh, NienKhoa) VALUES
    (N'CNTT25A', N'Công nghệ thông tin 25A', N'CNTT', N'2025-2029'),
    (N'CNTT25B', N'Công nghệ thông tin 25B', N'CNTT', N'2025-2029'),
    (N'SPTIN25A', N'Sư phạm Tin học 25A', N'SPTIN', N'2025-2029'),
    (N'SPTOAN25A', N'Sư phạm Toán học 25A', N'SPTOAN', N'2025-2029');

-- Giảng viên
INSERT INTO dbo.GiangVien (MaGV, HoTen, Email, SDT, MaKhoa) VALUES
    (N'GV001', N'Nguyễn Thanh Tùng', N'gv001@qlsv.local', N'0911000001', N'CNTT'),
    (N'GV002', N'Trần Minh Quân', N'gv002@qlsv.local', N'0911000002', N'CNTT'),
    (N'GV003', N'Lê Thị Hạnh', N'gv003@qlsv.local', N'0911000003', N'CNTT'),
    (N'GV004', N'Phạm Quốc Bảo', N'gv004@qlsv.local', N'0911000004', N'CNTT'),
    (N'GV005', N'Võ Thị Lan', N'gv005@qlsv.local', N'0911000005', N'TOAN'),
    (N'GV006', N'Đỗ Anh Thư', N'gv006@qlsv.local', N'0911000006', N'NN');

-- Sinh viên
INSERT INTO dbo.SinhVien (MaSV, HoTen, NgaySinh, GioiTinh, Email, SDT, DiaChi, MaLop, TrangThai) VALUES
    (N'2501001', N'Nguyễn Văn An', N'2005-03-12', N'Nam', N'2501001@qlsv.local', N'0901001001', N'TP. Hồ Chí Minh', N'CNTT25A', 1),
    (N'2501002', N'Trần Thị Bình', N'2005-07-25', N'Nữ', N'2501002@qlsv.local', N'0901001002', N'TP. Hồ Chí Minh', N'CNTT25A', 1),
    (N'2501003', N'Lê Hoàng Cường', N'2005-01-08', N'Nam', N'2501003@qlsv.local', N'0901001003', N'TP. Hồ Chí Minh', N'CNTT25A', 1),
    (N'2501004', N'Phạm Thu Dung', N'2005-11-30', N'Nữ', N'2501004@qlsv.local', N'0901001004', N'TP. Hồ Chí Minh', N'CNTT25B', 1),
    (N'2501005', N'Võ Quốc Huy', N'2005-05-19', N'Nam', N'2501005@qlsv.local', N'0901001005', N'TP. Hồ Chí Minh', N'CNTT25B', 1),
    (N'2501006', N'Đặng Mai Lan', N'2005-09-02', N'Nữ', N'2501006@qlsv.local', N'0901001006', N'TP. Hồ Chí Minh', N'SPTIN25A', 1),
    (N'2501007', N'Hoàng Gia Khang', N'2005-02-14', N'Nam', N'2501007@qlsv.local', N'0901001007', N'TP. Hồ Chí Minh', N'SPTIN25A', 1),
    (N'2501008', N'Bùi Ngọc Hân', N'2005-12-21', N'Nữ', N'2501008@qlsv.local', N'0901001008', N'TP. Hồ Chí Minh', N'SPTOAN25A', 1);

-- Môn học
INSERT INTO dbo.MonHoc (MaMon, TenMon, SoTinChi, MaKhoa) VALUES
    (N'COMP1010', N'Nhập môn lập trình', 3, N'CNTT'),
    (N'COMP1011', N'Lập trình hướng đối tượng', 3, N'CNTT'),
    (N'COMP1019', N'Lập trình trên Windows', 3, N'CNTT'),
    (N'COMP1020', N'Cơ sở dữ liệu', 3, N'CNTT'),
    (N'COMP1021', N'Cấu trúc dữ liệu và giải thuật', 3, N'CNTT'),
    (N'COMP1022', N'Mạng máy tính', 3, N'CNTT'),
    (N'COMP1023', N'Công nghệ phần mềm', 3, N'CNTT'),
    (N'COMP1024', N'Lập trình Web', 3, N'CNTT'),
    (N'COMP1025', N'Trí tuệ nhân tạo', 3, N'CNTT'),
    (N'MATH1001', N'Giải tích 1', 3, N'TOAN'),
    (N'MATH1002', N'Đại số tuyến tính', 2, N'TOAN'),
    (N'ENGL1001', N'Tiếng Anh 1', 3, N'NN'),
    (N'ENGL1002', N'Tiếng Anh 2', 3, N'NN');

-- Môn tiên quyết (phải đạt DiemTongKet >= 4.0)
INSERT INTO dbo.MonTienQuyet (MaMon, MaMonTienQuyet) VALUES
    (N'COMP1011', N'COMP1010'),
    (N'COMP1019', N'COMP1011'),
    (N'COMP1021', N'COMP1010'),
    (N'COMP1023', N'COMP1011'),
    (N'COMP1024', N'COMP1020'),
    (N'COMP1025', N'COMP1021'),
    (N'ENGL1002', N'ENGL1001');

-- Học kỳ (HK1_2627 là học kỳ hiện tại: 07/09/2026 - 10/01/2027)
INSERT INTO dbo.HocKy (MaHK, TenHK, NamHoc, TuNgay, DenNgay, DonGiaTinChi) VALUES
    (N'HK1_2526', N'Học kỳ 1', N'2025-2026', N'2025-09-01', N'2026-01-11', 450000),
    (N'HK2_2526', N'Học kỳ 2', N'2025-2026', N'2026-01-19', N'2026-06-14', 450000),
    (N'HK1_2627', N'Học kỳ 1', N'2026-2027', N'2026-09-07', N'2027-01-10', 480000);

-- Lớp học phần
INSERT INTO dbo.LopHocPhan (MaLHP, MaMon, MaGV, MaHK, SiSoToiDa, Thu, TietBatDau, SoTiet, Phong) VALUES
    (N'L2526-01', N'COMP1010', N'GV001', N'HK2_2526', 50, 2, 1, 3, N'A101'),
    (N'L2526-02', N'COMP1020', N'GV002', N'HK2_2526', 50, 3, 1, 3, N'B101'),
    (N'L2526-03', N'MATH1001', N'GV005', N'HK2_2526', 50, 4, 1, 3, N'C101'),
    (N'L2526-04', N'ENGL1001', N'GV006', N'HK2_2526', 50, 5, 1, 3, N'D101'),
    (N'L2627-01', N'COMP1011', N'GV001', N'HK1_2627', 40, 2, 1, 3, N'A101'),
    (N'L2627-02', N'COMP1021', N'GV002', N'HK1_2627', 40, 2, 2, 3, N'A102'),
    (N'L2627-03', N'COMP1019', N'GV001', N'HK1_2627', 35, 3, 1, 3, N'B201'),
    (N'L2627-04', N'COMP1022', N'GV003', N'HK1_2627', 40, 3, 4, 3, N'B202'),
    (N'L2627-05', N'COMP1023', N'GV003', N'HK1_2627', 40, 4, 1, 3, N'A103'),
    (N'L2627-06', N'COMP1024', N'GV004', N'HK1_2627', 40, 4, 4, 3, N'A104'),
    (N'L2627-07', N'COMP1025', N'GV004', N'HK1_2627', 40, 5, 1, 3, N'B203'),
    (N'L2627-08', N'MATH1002', N'GV005', N'HK1_2627', 40, 5, 4, 2, N'C102'),
    (N'L2627-09', N'ENGL1002', N'GV006', N'HK1_2627', 40, 6, 1, 3, N'D102'),
    (N'L2627-10', N'COMP1010', N'GV001', N'HK1_2627', 2, 6, 4, 3, N'A101'),
    (N'L2627-11', N'COMP1020', N'GV002', N'HK1_2627', 40, 2, 7, 3, N'B102'),
    (N'L2627-12', N'MATH1001', N'GV005', N'HK1_2627', 40, 3, 7, 3, N'C103');

-- Tài khoản mẫu (mật khẩu 123456, băm SHA-256 + salt riêng từng người)
SET IDENTITY_INSERT dbo.NguoiDung ON;
INSERT INTO dbo.NguoiDung (MaND, TenDangNhap, MatKhauHash, Salt, MaNhom, MaSV, MaGV, TrangThai) VALUES
    (1, N'admin', N'hK7S3aqGVUeq/gZw4HLVkDWJbvpBHtN8p+lRcVtKR/0=', N'MI5CQjEtVhueV7ZNMfuIbg==', N'ADMIN', NULL, NULL, 1),
    (2, N'pdt01', N'ALlbcgrVcG5QRSaTbcyTvwX1V5ZFVC2u4VI2aHM9Q3U=', N'g7iUfCdMQ19cL9HgxNZFjA==', N'PDT', NULL, NULL, 1),
    (3, N'gv001', N'RbP2/IylI1W6T7zyZR9q7dbYh504lvDWQHDvm5P9vjI=', N'n6hOjbYTGYNLSP0nHS0jXg==', N'GV', NULL, N'GV001', 1),
    (4, N'kt01', N'NXYp8c8SzZvUrlWjl2PSH4Zu/G7+pFY64BBPkJULKSA=', N'D44nuwzbg/OEVpJaFL8p4w==', N'KT', NULL, NULL, 1),
    (5, N'sv2501001', N'd7HbPG/4eEAWJJrighh5dyW/nQrxSXmbOEcNN01BdBw=', N'UaUBfPYiUWO+trq7X/7B4w==', N'SV', N'2501001', NULL, 1),
    (6, N'sv2501002', N'7BXhhrjepIE48Py4vGoi4lZzk89Q8IpfSOAmFKLU28g=', N'0q+7pJwha2ADY+9jZsqFcQ==', N'SV', N'2501002', NULL, 1),
    (7, N'sv2501004', N'zZP71ThpBwlf8A/ZrCx79omDNFn3KFo0FI69vxRlr4c=', N'q4qAQshqLyb31AxljzXFkw==', N'SV', N'2501004', NULL, 1);

SET IDENTITY_INSERT dbo.NguoiDung OFF;

-- Đăng ký học phần (MaDK cố định: 1-12 = HK2_2526 có điểm, 13-15 = HK1_2627)
SET IDENTITY_INSERT dbo.DangKyHocPhan ON;
INSERT INTO dbo.DangKyHocPhan (MaDK, MaSV, MaLHP, NgayDK) VALUES
    (1, N'2501001', N'L2526-01', N'2026-01-20T08:30:00'),
    (2, N'2501001', N'L2526-02', N'2026-01-20T08:30:00'),
    (3, N'2501001', N'L2526-03', N'2026-01-20T08:30:00'),
    (4, N'2501001', N'L2526-04', N'2026-01-20T08:30:00'),
    (5, N'2501002', N'L2526-01', N'2026-01-20T08:30:00'),
    (6, N'2501002', N'L2526-02', N'2026-01-20T08:30:00'),
    (7, N'2501002', N'L2526-03', N'2026-01-20T08:30:00'),
    (8, N'2501002', N'L2526-04', N'2026-01-20T08:30:00'),
    (9, N'2501003', N'L2526-01', N'2026-01-20T08:30:00'),
    (10, N'2501003', N'L2526-02', N'2026-01-20T08:30:00'),
    (11, N'2501003', N'L2526-03', N'2026-01-20T08:30:00'),
    (12, N'2501003', N'L2526-04', N'2026-01-20T08:30:00'),
    (13, N'2501004', N'L2627-10', N'2026-09-02T09:00:00'),
    (14, N'2501004', N'L2627-08', N'2026-09-03T09:00:00'),
    (15, N'2501005', N'L2627-10', N'2026-09-04T09:00:00');

SET IDENTITY_INSERT dbo.DangKyHocPhan OFF;

-- Điểm HK2_2526 = CC*0.1 + GK*0.3 + CK*0.6 (làm tròn 1 số lẻ)
INSERT INTO dbo.Diem (MaDK, DiemCC, DiemGK, DiemCK, DiemTongKet, DiemChu, Diem4) VALUES
    (1, 10, 8, 9, 8.8, N'A', 4.0),
    (2, 9, 9, 9, 9.0, N'A', 4.0),
    (3, 8, 8, 8, 8.0, N'B+', 3.5),
    (4, 9, 8, 8, 8.1, N'B+', 3.5),
    (5, 8, 4, 3, 3.8, N'F', 0.0),
    (6, 7, 6, 7, 6.7, N'C+', 2.5),
    (7, 6, 5, 5, 5.1, N'D+', 1.5),
    (8, 7, 6, 6, 6.1, N'C', 2.0),
    (9, 7, 6, 7, 6.7, N'C+', 2.5),
    (10, 8, 7, 7, 7.1, N'B', 3.0),
    (11, 7, 7, 6, 6.4, N'C', 2.0),
    (12, 8, 8, 8, 8.0, N'B+', 3.5);

-- Nhật ký sửa điểm: gv001 sửa điểm CK của 2501002 từ 4 xuống 3
INSERT INTO dbo.NhatKyDiem (MaDK, DiemCu, DiemMoi, NguoiSua, NgaySua) VALUES
    (5, N'CC=8;GK=4;CK=4', N'CC=8;GK=4;CK=3', 3, N'2026-06-20T16:05:00');

-- Phiếu thu học phí (mỗi lần đóng tiền là một phiếu; có đủ các tháng 1-6 và 10/2026 cho biểu đồ doanh thu)
INSERT INTO dbo.PhieuThu (MaSV, MaHK, TongTinChi, TongTien, GiamGia, PhaiThu, DaThu, NgayLap, NguoiLap, GhiChu) VALUES
    (N'2501001', N'HK2_2526', 12, 5400000, 540000, 4860000, 4860000, N'2026-02-10T09:15:00', 4, N'Học bổng 10%, đóng đủ'),
    (N'2501002', N'HK2_2526', 12, 5400000, 0, 5400000, 3000000, N'2026-02-12T10:00:00', 4, N'Đóng đợt 1'),
    (N'2501002', N'HK2_2526', 12, 5400000, 0, 5400000, 1000000, N'2026-06-01T14:20:00', 4, N'Đóng đợt 2 (còn nợ 1.400.000)'),
    (N'2501003', N'HK2_2526', 12, 5400000, 0, 5400000, 1500000, N'2026-01-20T08:45:00', 4, N'Đóng đợt 1'),
    (N'2501003', N'HK2_2526', 12, 5400000, 0, 5400000, 1500000, N'2026-03-05T09:30:00', 4, N'Đóng đợt 2'),
    (N'2501003', N'HK2_2526', 12, 5400000, 0, 5400000, 1200000, N'2026-04-12T15:10:00', 4, N'Đóng đợt 3'),
    (N'2501003', N'HK2_2526', 12, 5400000, 0, 5400000, 1200000, N'2026-05-18T10:40:00', 4, N'Đóng đợt 4 (đủ)'),
    (N'2501004', N'HK1_2627', 5, 2400000, 0, 2400000, 2400000, N'2026-10-05T11:00:00', 4, N'Đóng đủ');

COMMIT TRANSACTION;

-- Kiểm tra nhanh số dòng từng bảng
SELECT N'NhomQuyen' AS Bang, COUNT(*) AS SoDong FROM dbo.NhomQuyen
UNION ALL
SELECT N'ChucNang' AS Bang, COUNT(*) AS SoDong FROM dbo.ChucNang
UNION ALL
SELECT N'PhanQuyen' AS Bang, COUNT(*) AS SoDong FROM dbo.PhanQuyen
UNION ALL
SELECT N'Khoa' AS Bang, COUNT(*) AS SoDong FROM dbo.Khoa
UNION ALL
SELECT N'Nganh' AS Bang, COUNT(*) AS SoDong FROM dbo.Nganh
UNION ALL
SELECT N'LopSinhHoat' AS Bang, COUNT(*) AS SoDong FROM dbo.LopSinhHoat
UNION ALL
SELECT N'SinhVien' AS Bang, COUNT(*) AS SoDong FROM dbo.SinhVien
UNION ALL
SELECT N'GiangVien' AS Bang, COUNT(*) AS SoDong FROM dbo.GiangVien
UNION ALL
SELECT N'MonHoc' AS Bang, COUNT(*) AS SoDong FROM dbo.MonHoc
UNION ALL
SELECT N'MonTienQuyet' AS Bang, COUNT(*) AS SoDong FROM dbo.MonTienQuyet
UNION ALL
SELECT N'HocKy' AS Bang, COUNT(*) AS SoDong FROM dbo.HocKy
UNION ALL
SELECT N'LopHocPhan' AS Bang, COUNT(*) AS SoDong FROM dbo.LopHocPhan
UNION ALL
SELECT N'NguoiDung' AS Bang, COUNT(*) AS SoDong FROM dbo.NguoiDung
UNION ALL
SELECT N'DangKyHocPhan' AS Bang, COUNT(*) AS SoDong FROM dbo.DangKyHocPhan
UNION ALL
SELECT N'Diem' AS Bang, COUNT(*) AS SoDong FROM dbo.Diem
UNION ALL
SELECT N'NhatKyDiem' AS Bang, COUNT(*) AS SoDong FROM dbo.NhatKyDiem
UNION ALL
SELECT N'PhieuThu' AS Bang, COUNT(*) AS SoDong FROM dbo.PhieuThu;

PRINT N'Đã nạp xong dữ liệu mẫu. Đăng nhập thử: admin / 123456';
