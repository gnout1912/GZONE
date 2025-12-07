-- 1. Create database
CREATE DATABASE QuanLyPhongGym;
GO

USE QuanLyPhongGym;
GO

-- 2. Branch table (Parent table - created first)
CREATE TABLE CHI_NHANH (
    CN_Ma CHAR(10) PRIMARY KEY,
    CN_Ten NVARCHAR(256),
    CN_DiaChi NVARCHAR(256),
    CN_Sdt NVARCHAR(20),
    CN_NgayThanhLap DATE
);
GO

-- 3. Membership Package table (Parent table - created first)
CREATE TABLE GOI_TAP (
    GT_Ma CHAR(10) PRIMARY KEY,
    GT_Ten NVARCHAR(256),
    GT_ThoiHan INT CHECK (GT_ThoiHan > 0),
    GT_Gia DECIMAL(12,2) CHECK (GT_Gia >= 0)
);
GO

-- 4. Work Shift table (Parent table - created first)
CREATE TABLE CA_LAM_VIEC (
    CA_Ma CHAR(10) NOT NULL PRIMARY KEY,
    CA_Ten NVARCHAR(100) NOT NULL,
    CA_ThoiGianBD TIME NOT NULL, -- Standard TIME type
    CA_ThoiGianKT TIME NOT NULL, -- Standard TIME type
    CONSTRAINT CHK_ThoiGianHopLe CHECK (CA_ThoiGianKT > CA_ThoiGianBD)
);
GO

-- 5. Employee table (Depends on BRANCH)
CREATE TABLE NHAN_VIEN (
    NV_Ma CHAR(10) PRIMARY KEY,
    NV_Ten NVARCHAR(256) NOT NULL,
    NV_Sdt NVARCHAR(20),
    NV_GioiTinh NVARCHAR(10),
    CN_Ma CHAR(10),
    FOREIGN KEY (CN_Ma) REFERENCES CHI_NHANH(CN_Ma)
);
GO

-- 6. Account table (Depends on BRANCH)
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

-- 7. Member table (Depends on BRANCH)
-- Merged ALTER TABLE logic here to include CN_Ma directly for cleaner code
CREATE TABLE THANH_VIEN (
    TV_Ma CHAR(10) PRIMARY KEY,
    TV_HoTen NVARCHAR(256) NOT NULL,
    TV_NgaySinh DATE,
    TV_GioiTinh NVARCHAR(10),
    TV_Sdt NVARCHAR(20),
    CN_Ma CHAR(10) NULL,
    FOREIGN KEY (CN_Ma) REFERENCES CHI_NHANH(CN_Ma)
);
GO

-- 8. Attendance table (Depends on EMPLOYEE)
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
GO

-- 9. Member Package Registration table (Depends on MEMBER, PACKAGE, BRANCH)
CREATE TABLE THANH_VIEN_GOI_TAP (
    TVGT_ID INT IDENTITY(1,1) PRIMARY KEY,
    TV_Ma CHAR(10) NOT NULL,
    GT_Ma CHAR(10) NOT NULL,
    CN_Ma CHAR(10) NULL,
    NgayDangKy DATE NOT NULL DEFAULT GETDATE(),
    NgayHetHan DATE NOT NULL,
    TrangThai NVARCHAR(50) 
        CHECK (TrangThai IN (N'Còn hiệu lực', N'Hết hạn')),
    FOREIGN KEY (TV_Ma) REFERENCES THANH_VIEN(TV_Ma),
    FOREIGN KEY (GT_Ma) REFERENCES GOI_TAP(GT_Ma),
    FOREIGN KEY (CN_Ma) REFERENCES CHI_NHANH(CN_Ma) 
);
GO

-- 10. Facilities/Equipment table (Depends on BRANCH)
CREATE TABLE CO_SO_VAT_CHAT (
    CSVC_Ma INT IDENTITY(1,1) PRIMARY KEY,
    CN_Ma CHAR(10) NOT NULL,
    TenMay NVARCHAR(100) NOT NULL,
    LoaiMay NVARCHAR(50),
    SoLuong INT DEFAULT 1,
    TinhTrang NVARCHAR(50) CHECK (TinhTrang IN (N'Hoạt động', N'Hỏng', N'Bảo trì')) DEFAULT N'Hoạt động',
    GhiChu NVARCHAR(255),
    FOREIGN KEY (CN_Ma) REFERENCES CHI_NHANH(CN_Ma)
);
GO

-- 11. Request table (Depends on BRANCH)
CREATE TABLE YEU_CAU (
    YC_Ma INT IDENTITY(1,1) PRIMARY KEY,
    CN_Ma CHAR(10) NOT NULL, 
    YC_TieuDe NVARCHAR(255) NOT NULL,
    YC_NoiDung NVARCHAR(MAX) NULL,
    YC_NgayGui DATETIME NOT NULL DEFAULT GETDATE(),
    YC_TrangThai NVARCHAR(50) NOT NULL 
        DEFAULT N'Chờ duyệt' 
        CHECK (YC_TrangThai IN (N'Chờ duyệt', N'Đã duyệt', N'Đã từ chối')),
    YC_PhanHoi NVARCHAR(1000) NULL,
    YC_NgayXuLy DATETIME NULL,
    FOREIGN KEY (CN_Ma) REFERENCES CHI_NHANH(CN_Ma)
);
GO

-- 12. Shift Registration table (Depends on EMPLOYEE, WORK_SHIFT)
CREATE TABLE DANG_KI_LICH_LAM (
    DK_Ma INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    NV_Ma CHAR(10) NOT NULL, -- Linked to EMPLOYEE
    CA_Ma CHAR(10) NOT NULL, -- Linked to WORK_SHIFT
    
    -- This column contains (Day, Month, Year)
    DK_NgayDangKy DATE NOT NULL, 
    
    -- "Attendance" column (0 is absent, 1 is present)
    DK_DaChamCong BIT NOT NULL DEFAULT 0, 
    
    -- Foreign keys
    CONSTRAINT FK_DANG_KI_NHAN_VIEN FOREIGN KEY (NV_Ma) REFERENCES NHAN_VIEN(NV_Ma),
    CONSTRAINT FK_DANG_KI_CA_LAM_VIEC FOREIGN KEY (CA_Ma) REFERENCES CA_LAM_VIEC(CA_Ma),
    
    -- Logic constraint: An employee cannot register for the same shift on the same day
    CONSTRAINT UK_NHAN_VIEN_CA_NGAY UNIQUE (NV_Ma, CA_Ma, DK_NgayDangKy)
);
GO

-- User: admin
-- Password: admin
INSERT INTO TAI_KHOAN (TK_Ma, TK_Ten, TK_MatKhau, TK_TrangThai, TK_Quyen, CN_Ma)
VALUES ('AD001', 'admin', 'admin', 1, 'Admin', NULL);
GO
