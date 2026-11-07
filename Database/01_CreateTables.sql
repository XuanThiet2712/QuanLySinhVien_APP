/* =====================================================================
   QLSV - 01_CreateTables.sql
   Tạo cơ sở dữ liệu QLSV và 17 bảng. Chạy bằng SSMS.

   CẢNH BÁO: script này XÓA các bảng cũ rồi tạo lại => mất toàn bộ dữ liệu.
   Dùng khi dựng mới hoặc khi schema thay đổi. Sau đó chạy 02_Seed.sql.
   Chỉ trưởng nhóm (A) được sửa file này; ai cần thêm cột thì nhắn A.

   Quy ước:
   - Mã (PK) dùng VARCHAR không dấu; văn bản tiếng Việt dùng NVARCHAR.
   - TrangThai (BIT): 1 = đang hoạt động / đang học, 0 = khóa / nghỉ.
   - Thu: 2..7 = Thứ hai..Thứ bảy, 8 = Chủ nhật.
   ===================================================================== */

IF DB_ID(N'QLSV') IS NULL
    CREATE DATABASE QLSV;
GO

USE QLSV;
GO

/* ---------------------------------------------------------------------
   1. XÓA BẢNG CŨ (đúng thứ tự phụ thuộc: bảng con trước, bảng cha sau)
   --------------------------------------------------------------------- */
IF OBJECT_ID(N'dbo.NhatKyDiem',    N'U') IS NOT NULL DROP TABLE dbo.NhatKyDiem;
IF OBJECT_ID(N'dbo.Diem',          N'U') IS NOT NULL DROP TABLE dbo.Diem;
IF OBJECT_ID(N'dbo.PhieuThu',      N'U') IS NOT NULL DROP TABLE dbo.PhieuThu;
IF OBJECT_ID(N'dbo.DangKyHocPhan', N'U') IS NOT NULL DROP TABLE dbo.DangKyHocPhan;
IF OBJECT_ID(N'dbo.LopHocPhan',    N'U') IS NOT NULL DROP TABLE dbo.LopHocPhan;
IF OBJECT_ID(N'dbo.NguoiDung',     N'U') IS NOT NULL DROP TABLE dbo.NguoiDung;
IF OBJECT_ID(N'dbo.PhanQuyen',     N'U') IS NOT NULL DROP TABLE dbo.PhanQuyen;
IF OBJECT_ID(N'dbo.MonTienQuyet',  N'U') IS NOT NULL DROP TABLE dbo.MonTienQuyet;
IF OBJECT_ID(N'dbo.SinhVien',      N'U') IS NOT NULL DROP TABLE dbo.SinhVien;
IF OBJECT_ID(N'dbo.GiangVien',     N'U') IS NOT NULL DROP TABLE dbo.GiangVien;
IF OBJECT_ID(N'dbo.MonHoc',        N'U') IS NOT NULL DROP TABLE dbo.MonHoc;
IF OBJECT_ID(N'dbo.HocKy',         N'U') IS NOT NULL DROP TABLE dbo.HocKy;
IF OBJECT_ID(N'dbo.LopSinhHoat',   N'U') IS NOT NULL DROP TABLE dbo.LopSinhHoat;
IF OBJECT_ID(N'dbo.Nganh',         N'U') IS NOT NULL DROP TABLE dbo.Nganh;
IF OBJECT_ID(N'dbo.Khoa',          N'U') IS NOT NULL DROP TABLE dbo.Khoa;
IF OBJECT_ID(N'dbo.ChucNang',      N'U') IS NOT NULL DROP TABLE dbo.ChucNang;
IF OBJECT_ID(N'dbo.NhomQuyen',     N'U') IS NOT NULL DROP TABLE dbo.NhomQuyen;
GO

/* ---------------------------------------------------------------------
   2. NHÓM HỆ THỐNG: NhomQuyen, ChucNang, PhanQuyen
   --------------------------------------------------------------------- */
CREATE TABLE dbo.NhomQuyen (
    MaNhom   VARCHAR(20)   NOT NULL,
    TenNhom  NVARCHAR(100) NOT NULL,
    CONSTRAINT PK_NhomQuyen PRIMARY KEY (MaNhom)
);

CREATE TABLE dbo.ChucNang (
    MaCN   VARCHAR(30)   NOT NULL,   -- trùng với class MaChucNang trong Helpers/Constants.cs
    TenCN  NVARCHAR(100) NOT NULL,
    CONSTRAINT PK_ChucNang PRIMARY KEY (MaCN)
);

CREATE TABLE dbo.PhanQuyen (
    MaNhom  VARCHAR(20) NOT NULL,
    MaCN    VARCHAR(30) NOT NULL,
    CONSTRAINT PK_PhanQuyen PRIMARY KEY (MaNhom, MaCN),
    CONSTRAINT FK_PhanQuyen_NhomQuyen FOREIGN KEY (MaNhom) REFERENCES dbo.NhomQuyen (MaNhom),
    CONSTRAINT FK_PhanQuyen_ChucNang  FOREIGN KEY (MaCN)   REFERENCES dbo.ChucNang (MaCN)
);
GO

/* ---------------------------------------------------------------------
   3. NHÓM DANH MỤC: Khoa, Nganh, LopSinhHoat, SinhVien, GiangVien,
                     MonHoc, MonTienQuyet, HocKy
   --------------------------------------------------------------------- */
CREATE TABLE dbo.Khoa (
    MaKhoa   VARCHAR(10)   NOT NULL,
    TenKhoa  NVARCHAR(100) NOT NULL,
    CONSTRAINT PK_Khoa PRIMARY KEY (MaKhoa)
);

CREATE TABLE dbo.Nganh (
    MaNganh   VARCHAR(10)   NOT NULL,
    TenNganh  NVARCHAR(100) NOT NULL,
    MaKhoa    VARCHAR(10)   NOT NULL,
    CONSTRAINT PK_Nganh PRIMARY KEY (MaNganh),
    CONSTRAINT FK_Nganh_Khoa FOREIGN KEY (MaKhoa) REFERENCES dbo.Khoa (MaKhoa)
);

CREATE TABLE dbo.LopSinhHoat (
    MaLop     VARCHAR(15)   NOT NULL,
    TenLop    NVARCHAR(100) NOT NULL,
    MaNganh   VARCHAR(10)   NOT NULL,
    NienKhoa  NVARCHAR(20)  NULL,
    CONSTRAINT PK_LopSinhHoat PRIMARY KEY (MaLop),
    CONSTRAINT FK_LopSinhHoat_Nganh FOREIGN KEY (MaNganh) REFERENCES dbo.Nganh (MaNganh)
);

CREATE TABLE dbo.SinhVien (
    MaSV        VARCHAR(15)    NOT NULL,
    HoTen       NVARCHAR(100)  NOT NULL,
    NgaySinh    DATE           NOT NULL,
    GioiTinh    NVARCHAR(3)    NOT NULL,
    Email       VARCHAR(100)   NULL,
    SDT         VARCHAR(15)    NULL,
    DiaChi      NVARCHAR(200)  NULL,
    MaLop       VARCHAR(15)    NOT NULL,
    AnhDaiDien  VARBINARY(MAX) NULL,           -- lưu byte ảnh, copy repo sang máy khác vẫn thấy ảnh
    TrangThai   BIT            NOT NULL CONSTRAINT DF_SinhVien_TrangThai DEFAULT (1),
    CONSTRAINT PK_SinhVien PRIMARY KEY (MaSV),
    CONSTRAINT CK_SinhVien_GioiTinh CHECK (GioiTinh IN (N'Nam', N'Nữ')),
    CONSTRAINT FK_SinhVien_LopSinhHoat FOREIGN KEY (MaLop) REFERENCES dbo.LopSinhHoat (MaLop)
);

CREATE TABLE dbo.GiangVien (
    MaGV    VARCHAR(15)   NOT NULL,
    HoTen   NVARCHAR(100) NOT NULL,
    Email   VARCHAR(100)  NULL,
    SDT     VARCHAR(15)   NULL,
    MaKhoa  VARCHAR(10)   NOT NULL,
    CONSTRAINT PK_GiangVien PRIMARY KEY (MaGV),
    CONSTRAINT FK_GiangVien_Khoa FOREIGN KEY (MaKhoa) REFERENCES dbo.Khoa (MaKhoa)
);

CREATE TABLE dbo.MonHoc (
    MaMon     VARCHAR(15)   NOT NULL,
    TenMon    NVARCHAR(150) NOT NULL,
    SoTinChi  TINYINT       NOT NULL,
    MaKhoa    VARCHAR(10)   NOT NULL,
    CONSTRAINT PK_MonHoc PRIMARY KEY (MaMon),
    CONSTRAINT CK_MonHoc_SoTinChi CHECK (SoTinChi BETWEEN 1 AND 6),
    CONSTRAINT FK_MonHoc_Khoa FOREIGN KEY (MaKhoa) REFERENCES dbo.Khoa (MaKhoa)
);

CREATE TABLE dbo.MonTienQuyet (
    MaMon           VARCHAR(15) NOT NULL,   -- môn muốn đăng ký
    MaMonTienQuyet  VARCHAR(15) NOT NULL,   -- môn phải đạt trước (DiemTongKet >= 4.0)
    CONSTRAINT PK_MonTienQuyet PRIMARY KEY (MaMon, MaMonTienQuyet),
    CONSTRAINT CK_MonTienQuyet_KhacNhau CHECK (MaMon <> MaMonTienQuyet),
    CONSTRAINT FK_MonTienQuyet_Mon      FOREIGN KEY (MaMon)          REFERENCES dbo.MonHoc (MaMon),
    CONSTRAINT FK_MonTienQuyet_TienQuyet FOREIGN KEY (MaMonTienQuyet) REFERENCES dbo.MonHoc (MaMon)
);

CREATE TABLE dbo.HocKy (
    MaHK           VARCHAR(15)   NOT NULL,
    TenHK          NVARCHAR(50)  NOT NULL,
    NamHoc         VARCHAR(15)   NOT NULL,
    TuNgay         DATE          NOT NULL,
    DenNgay        DATE          NOT NULL,
    DonGiaTinChi   DECIMAL(18,0) NOT NULL,   -- VND / tín chỉ
    CONSTRAINT PK_HocKy PRIMARY KEY (MaHK),
    CONSTRAINT CK_HocKy_Ngay  CHECK (TuNgay < DenNgay),
    CONSTRAINT CK_HocKy_DonGia CHECK (DonGiaTinChi >= 0)
);
GO

/* ---------------------------------------------------------------------
   4. NHÓM HỌC VỤ: LopHocPhan, DangKyHocPhan, Diem, NhatKyDiem
   --------------------------------------------------------------------- */
CREATE TABLE dbo.LopHocPhan (
    MaLHP        VARCHAR(20)  NOT NULL,
    MaMon        VARCHAR(15)  NOT NULL,
    MaGV         VARCHAR(15)  NOT NULL,
    MaHK         VARCHAR(15)  NOT NULL,
    SiSoToiDa    SMALLINT     NOT NULL,
    Thu          TINYINT      NOT NULL,       -- 2..7 = Thứ 2..Thứ 7, 8 = Chủ nhật
    TietBatDau   TINYINT      NOT NULL,       -- 1..12
    SoTiet       TINYINT      NOT NULL,       -- tiết kết thúc = TietBatDau + SoTiet - 1
    Phong        NVARCHAR(20) NULL,
    CONSTRAINT PK_LopHocPhan PRIMARY KEY (MaLHP),
    CONSTRAINT CK_LopHocPhan_SiSo  CHECK (SiSoToiDa > 0),
    CONSTRAINT CK_LopHocPhan_Thu   CHECK (Thu BETWEEN 2 AND 8),
    CONSTRAINT CK_LopHocPhan_Tiet  CHECK (TietBatDau BETWEEN 1 AND 12
                                          AND SoTiet BETWEEN 1 AND 6
                                          AND TietBatDau + SoTiet - 1 <= 12),
    CONSTRAINT FK_LopHocPhan_MonHoc   FOREIGN KEY (MaMon) REFERENCES dbo.MonHoc (MaMon),
    CONSTRAINT FK_LopHocPhan_GiangVien FOREIGN KEY (MaGV)  REFERENCES dbo.GiangVien (MaGV),
    CONSTRAINT FK_LopHocPhan_HocKy    FOREIGN KEY (MaHK)  REFERENCES dbo.HocKy (MaHK)
);

CREATE TABLE dbo.DangKyHocPhan (
    MaDK    INT IDENTITY(1,1) NOT NULL,
    MaSV    VARCHAR(15)       NOT NULL,
    MaLHP   VARCHAR(20)       NOT NULL,
    NgayDK  DATETIME          NOT NULL CONSTRAINT DF_DangKyHocPhan_NgayDK DEFAULT (GETDATE()),
    CONSTRAINT PK_DangKyHocPhan PRIMARY KEY (MaDK),
    CONSTRAINT UQ_DangKyHocPhan_SV_LHP UNIQUE (MaSV, MaLHP),   -- một sinh viên chỉ đăng ký một lớp học phần một lần
    CONSTRAINT FK_DangKyHocPhan_SinhVien  FOREIGN KEY (MaSV)  REFERENCES dbo.SinhVien (MaSV),
    CONSTRAINT FK_DangKyHocPhan_LopHocPhan FOREIGN KEY (MaLHP) REFERENCES dbo.LopHocPhan (MaLHP)
);

CREATE TABLE dbo.Diem (
    MaDK         INT          NOT NULL,        -- vừa là PK vừa là FK: mỗi đăng ký có tối đa một dòng điểm
    DiemCC       DECIMAL(3,1) NULL,            -- NULL = chưa nhập (không coi là 0)
    DiemGK       DECIMAL(3,1) NULL,
    DiemCK       DECIMAL(3,1) NULL,
    DiemTongKet  DECIMAL(3,1) NULL,            -- CC*10% + GK*30% + CK*60%, làm tròn 1 số lẻ
    DiemChu      NVARCHAR(2)  NULL,            -- A, B+, B, C+, C, D+, D, F
    Diem4        DECIMAL(2,1) NULL,            -- thang 4
    CONSTRAINT PK_Diem PRIMARY KEY (MaDK),
    CONSTRAINT CK_Diem_CC CHECK (DiemCC BETWEEN 0 AND 10),
    CONSTRAINT CK_Diem_GK CHECK (DiemGK BETWEEN 0 AND 10),
    CONSTRAINT CK_Diem_CK CHECK (DiemCK BETWEEN 0 AND 10),
    CONSTRAINT CK_Diem_TK CHECK (DiemTongKet BETWEEN 0 AND 10),
    CONSTRAINT CK_Diem_He4 CHECK (Diem4 BETWEEN 0 AND 4),
    CONSTRAINT FK_Diem_DangKyHocPhan FOREIGN KEY (MaDK) REFERENCES dbo.DangKyHocPhan (MaDK)
);
GO

/* ---------------------------------------------------------------------
   5. NHÓM TÀI KHOẢN: NguoiDung (cần SinhVien, GiangVien, NhomQuyen có trước)
   --------------------------------------------------------------------- */
CREATE TABLE dbo.NguoiDung (
    MaND         INT IDENTITY(1,1) NOT NULL,
    TenDangNhap  VARCHAR(50)       NOT NULL,
    MatKhauHash  VARCHAR(100)      NOT NULL,   -- Base64( SHA256( UTF8(matKhau + salt) ) ) = 44 ký tự
    Salt         VARCHAR(50)       NOT NULL,   -- Base64 của 16 byte ngẫu nhiên = 24 ký tự
    MaNhom       VARCHAR(20)       NOT NULL,
    MaSV         VARCHAR(15)       NULL,       -- tài khoản của sinh viên nào (nếu là nhóm Sinh viên)
    MaGV         VARCHAR(15)       NULL,       -- tài khoản của giảng viên nào (nếu là nhóm Giảng viên)
    TrangThai    BIT               NOT NULL CONSTRAINT DF_NguoiDung_TrangThai DEFAULT (1),
    CONSTRAINT PK_NguoiDung PRIMARY KEY (MaND),
    CONSTRAINT UQ_NguoiDung_TenDangNhap UNIQUE (TenDangNhap),
    CONSTRAINT CK_NguoiDung_MotLoai CHECK (NOT (MaSV IS NOT NULL AND MaGV IS NOT NULL)),
    CONSTRAINT FK_NguoiDung_NhomQuyen FOREIGN KEY (MaNhom) REFERENCES dbo.NhomQuyen (MaNhom),
    CONSTRAINT FK_NguoiDung_SinhVien  FOREIGN KEY (MaSV)   REFERENCES dbo.SinhVien (MaSV),
    CONSTRAINT FK_NguoiDung_GiangVien FOREIGN KEY (MaGV)   REFERENCES dbo.GiangVien (MaGV)
);

CREATE TABLE dbo.NhatKyDiem (
    MaNK       INT IDENTITY(1,1) NOT NULL,
    MaDK       INT               NOT NULL,
    DiemCu     NVARCHAR(100)     NULL,        -- ví dụ: CC=8;GK=4;CK=4
    DiemMoi    NVARCHAR(100)     NULL,        -- ví dụ: CC=8;GK=4;CK=3
    NguoiSua   INT               NOT NULL,
    NgaySua    DATETIME          NOT NULL CONSTRAINT DF_NhatKyDiem_NgaySua DEFAULT (GETDATE()),
    CONSTRAINT PK_NhatKyDiem PRIMARY KEY (MaNK),
    CONSTRAINT FK_NhatKyDiem_DangKyHocPhan FOREIGN KEY (MaDK)     REFERENCES dbo.DangKyHocPhan (MaDK),
    CONSTRAINT FK_NhatKyDiem_NguoiDung     FOREIGN KEY (NguoiSua) REFERENCES dbo.NguoiDung (MaND)
);
GO

/* ---------------------------------------------------------------------
   6. NHÓM TÀI CHÍNH: PhieuThu
      - TongTinChi, TongTien, GiamGia, PhaiThu: số liệu học phí của học kỳ,
        chụp lại (snapshot) tại thời điểm lập phiếu.
      - DaThu: số tiền thu trong CHÍNH phiếu này (mỗi lần đóng là một phiếu).
      - Công nợ = PhaiThu - SUM(DaThu của các phiếu chưa hủy) theo (MaSV, MaHK).
      - DaHuy: HuyPhieu() chỉ đặt cờ này = 1, không xóa dòng (giữ lịch sử).
   --------------------------------------------------------------------- */
CREATE TABLE dbo.PhieuThu (
    MaPhieu      INT IDENTITY(1,1) NOT NULL,
    MaSV         VARCHAR(15)       NOT NULL,
    MaHK         VARCHAR(15)       NOT NULL,
    TongTinChi   SMALLINT          NOT NULL,
    TongTien     DECIMAL(18,0)     NOT NULL,
    GiamGia      DECIMAL(18,0)     NOT NULL CONSTRAINT DF_PhieuThu_GiamGia DEFAULT (0),
    PhaiThu      DECIMAL(18,0)     NOT NULL,
    DaThu        DECIMAL(18,0)     NOT NULL,
    NgayLap      DATETIME          NOT NULL CONSTRAINT DF_PhieuThu_NgayLap DEFAULT (GETDATE()),
    NguoiLap     INT               NOT NULL,
    GhiChu       NVARCHAR(200)     NULL,
    DaHuy        BIT               NOT NULL CONSTRAINT DF_PhieuThu_DaHuy DEFAULT (0),
    CONSTRAINT PK_PhieuThu PRIMARY KEY (MaPhieu),
    CONSTRAINT CK_PhieuThu_DaThu  CHECK (DaThu > 0),
    CONSTRAINT CK_PhieuThu_Tien   CHECK (TongTien >= 0 AND GiamGia >= 0 AND PhaiThu >= 0),
    CONSTRAINT FK_PhieuThu_SinhVien  FOREIGN KEY (MaSV)     REFERENCES dbo.SinhVien (MaSV),
    CONSTRAINT FK_PhieuThu_HocKy     FOREIGN KEY (MaHK)     REFERENCES dbo.HocKy (MaHK),
    CONSTRAINT FK_PhieuThu_NguoiDung FOREIGN KEY (NguoiLap) REFERENCES dbo.NguoiDung (MaND)
);
GO

/* ---------------------------------------------------------------------
   7. INDEX cho các cột hay tìm kiếm / nối bảng
   --------------------------------------------------------------------- */
CREATE INDEX IX_SinhVien_MaLop        ON dbo.SinhVien (MaLop);
CREATE INDEX IX_SinhVien_HoTen        ON dbo.SinhVien (HoTen);
CREATE INDEX IX_LopHocPhan_MaHK       ON dbo.LopHocPhan (MaHK, MaMon);
CREATE INDEX IX_LopHocPhan_MaGV       ON dbo.LopHocPhan (MaGV);
CREATE INDEX IX_DangKyHocPhan_MaLHP   ON dbo.DangKyHocPhan (MaLHP);
CREATE INDEX IX_PhieuThu_SV_HK        ON dbo.PhieuThu (MaSV, MaHK);
CREATE INDEX IX_PhieuThu_NgayLap      ON dbo.PhieuThu (NgayLap);
CREATE INDEX IX_NhatKyDiem_MaDK       ON dbo.NhatKyDiem (MaDK);
GO

PRINT N'Đã tạo xong CSDL QLSV (17 bảng). Chạy tiếp 02_Seed.sql để nạp dữ liệu mẫu.';
GO
