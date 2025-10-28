CREATE DATABASE hen_ho
GO
USE hen_ho
GO

-- Bảng người dùng
CREATE TABLE nguoi_dung (
    nguoi_dung_id CHAR(10) PRIMARY KEY,
    ten_dang_nhap NVARCHAR(50) NOT NULL UNIQUE,
    mat_khau NVARCHAR(100) NOT NULL,
    email NVARCHAR(100) UNIQUE,
    so_dien_thoai NVARCHAR(20) UNIQUE,
    gioi_tinh NVARCHAR(10),
    ngay_sinh DATE,
    ngay_tao DATETIME DEFAULT GETDATE(),
    trang_thai NVARCHAR(20) DEFAULT 'active' -- active/banned
)
GO

-- Hồ sơ người dùng
CREATE TABLE ho_so (
    ho_so_id CHAR(10) PRIMARY KEY,
    nguoi_dung_id CHAR(10) NOT NULL,
    anh_dai_dien NVARCHAR(200),
    album_anh NVARCHAR(MAX),
    so_thich NVARCHAR(200),
    mo_ta_ban_than NVARCHAR(500),
    dia_chi NVARCHAR(200),
    FOREIGN KEY (nguoi_dung_id) REFERENCES nguoi_dung(nguoi_dung_id)
)
GO

-- Lượt thích
CREATE TABLE thich (
    nguoi_gui_id CHAR(10) NOT NULL,
    nguoi_nhan_id CHAR(10) NOT NULL,
    thoi_gian DATETIME DEFAULT GETDATE(),
    PRIMARY KEY (nguoi_gui_id, nguoi_nhan_id),
    FOREIGN KEY (nguoi_gui_id) REFERENCES nguoi_dung(nguoi_dung_id),
    FOREIGN KEY (nguoi_nhan_id) REFERENCES nguoi_dung(nguoi_dung_id)
)
GO

-- Match (khi cả 2 cùng thích nhau)
CREATE TABLE match_user (
    match_id CHAR(10) PRIMARY KEY,
    nguoi_a_id CHAR(10) NOT NULL,
    nguoi_b_id CHAR(10) NOT NULL,
    thoi_gian DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (nguoi_a_id) REFERENCES nguoi_dung(nguoi_dung_id),
    FOREIGN KEY (nguoi_b_id) REFERENCES nguoi_dung(nguoi_dung_id)
)
GO

-- Tin nhắn
CREATE TABLE tin_nhan (
    tin_nhan_id CHAR(10) PRIMARY KEY,
    match_id CHAR(10) NOT NULL,
    nguoi_gui_id CHAR(10) NOT NULL,
    noi_dung NVARCHAR(1000),
    thoi_gian DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (match_id) REFERENCES match_user(match_id),
    FOREIGN KEY (nguoi_gui_id) REFERENCES nguoi_dung(nguoi_dung_id),
    FOREIGN KEY (nguoi_nhan_id) REFERENCES nguoi_dung(nguoi_dung_id)

)
GO

-- Báo cáo người dùng
CREATE TABLE bao_cao (
    bao_cao_id CHAR(10) PRIMARY KEY,
    nguoi_bao_cao_id CHAR(10) NOT NULL,
    nguoi_bi_bao_cao_id CHAR(10) NOT NULL,
    ly_do NVARCHAR(500),
    thoi_gian DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (nguoi_bao_cao_id) REFERENCES nguoi_dung(nguoi_dung_id),
    FOREIGN KEY (nguoi_bi_bao_cao_id) REFERENCES nguoi_dung(nguoi_dung_id)
)
GO

-- Tài khoản VIP
CREATE TABLE tai_khoan_vip (
    vip_id CHAR(10) PRIMARY KEY,
    nguoi_dung_id CHAR(10) NOT NULL UNIQUE,
    goi_vip NVARCHAR(50),
    ngay_bat_dau DATE,
    ngay_ket_thuc DATE,
    FOREIGN KEY (nguoi_dung_id) REFERENCES nguoi_dung(nguoi_dung_id)
)
GO

GO