-- Tạo database
CREATE DATABASE QuanLyPhongGym;
GO

USE QuanLyPhongGym;
GO

-- Bảng chi nhánh
CREATE TABLE CHI_NHANH (
    CN_Ma CHAR(10) PRIMARY KEY,
    CN_Ten NVARCHAR(256),
    CN_DiaChi NVARCHAR(256),
    CN_Sdt NVARCHAR(20),
    CN_NgayThanhLap DATE
);
GO

-- Bảng tài khoản
CREATE TABLE TAI_KHOAN (
    TK_Ma CHAR(10) PRIMARY KEY,
    TK_Ten NVARCHAR(256) NOT NULL,
    TK_MatKhau NVARCHAR(256) NOT NULL,
    TK_TrangThai BIT DEFAULT 1,
    TK_Quyen NVARCHAR(50) CHECK (TK_Quyen IN ('Admin', 'Manager', 'Staff')),
    CN_Ma CHAR(10) NULL,
    FOREIGN KEY (CN_Ma) REFERENCES CHI_NHANH(CN_Ma)
);
GO

-- Bảng nhân viên
CREATE TABLE NHAN_VIEN (
    NV_Ma CHAR(10) PRIMARY KEY,
    NV_Ten NVARCHAR(256) NOT NULL,
    NV_Sdt NVARCHAR(20),
    NV_GioiTinh NVARCHAR(10),
    CN_Ma CHAR(10),
    FOREIGN KEY (CN_Ma) REFERENCES CHI_NHANH(CN_Ma)
);
GO

-- Bảng thành viên
CREATE TABLE THANH_VIEN (
    TV_Ma CHAR(10) PRIMARY KEY,
    TV_HoTen NVARCHAR(256) NOT NULL,
    TV_NgaySinh DATE,
    TV_GioiTinh NVARCHAR(10),
    TV_Sdt NVARCHAR(20)
);
GO

-- Bảng gói tập
CREATE TABLE GOI_TAP (
    GT_Ma CHAR(10) PRIMARY KEY,
    GT_Ten NVARCHAR(256),
    GT_ThoiHan INT CHECK (GT_ThoiHan > 0),
    GT_Gia DECIMAL(12,2) CHECK (GT_Gia >= 0)
);
GO

-- Thêm dữ liệu mẫu
INSERT INTO GOI_TAP (GT_Ma, GT_Ten, GT_ThoiHan, GT_Gia)
VALUES 
('GT001', N'Khởi Đầu Hoàn Hảo (1 Tháng)', 1, 550000.00),
('GT002', N'Chuyển Mình Mạnh Mẽ (3 Tháng)', 3, 1500000.00),
('GT004', N'Năm Vàng Nâng Tầm (12 Tháng)', 12, 5000000.00),
('GT005', N'Đỉnh Cao Phát Triển (24 Tháng)', 24, 9000000.00),
('GT006', N'Gói VIP Trọn Đời (36 Tháng)', 36, 12000000.00);
GO

SELECT * FROM GOI_TAP;
GO

-- Bảng chấm công (đã sửa lỗi kiểu dữ liệu)
CREATE TABLE CHAM_CONG (
    CC_ID INT IDENTITY(1,1) PRIMARY KEY,
    NV_Ma CHAR(10) NOT NULL,
    GioVao DATETIME NULL,
    GioRa DATETIME NULL,
    Ngay DATE NOT NULL DEFAULT CAST(GETDATE() AS DATE),
    CONSTRAINT FK_CHAMCONG_NHANVIEN FOREIGN KEY (NV_Ma)
        REFERENCES NHAN_VIEN(NV_Ma)
        ON DELETE CASCADE
);
CREATE TABLE THANH_VIEN_GOI_TAP (
    TVGT_ID INT IDENTITY(1,1) PRIMARY KEY,
    TV_Ma CHAR(10) NOT NULL,
    GT_Ma CHAR(10) NOT NULL,
    NgayDangKy DATE NOT NULL DEFAULT GETDATE(),
    NgayHetHan DATE NOT NULL,
    TrangThai NVARCHAR(50) 
        CHECK (TrangThai IN (N'Còn hiệu lực', N'Hết hạn')),
    FOREIGN KEY (TV_Ma) REFERENCES THANH_VIEN(TV_Ma),
    FOREIGN KEY (GT_Ma) REFERENCES GOI_TAP(GT_Ma)
);


UPDATE THANH_VIEN_GOI_TAP
SET TrangThai = 
    CASE WHEN NgayHetHan >= GETDATE() THEN N'Còn hiệu lực' ELSE N'Hết hạn' END;
GO
select * from THANH_VIEN_GOI_TAP;
select * from THANH_VIEN;
