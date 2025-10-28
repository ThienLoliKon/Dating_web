-- Sử dụng cơ sở dữ liệu hen_ho
USE hen_ho
GO

--------------------------------------------------------------------------------
-- 1. Chèn dữ liệu vào bảng NGUOI_DUNG
--------------------------------------------------------------------------------
INSERT INTO nguoi_dung (nguoi_dung_id, ten_dang_nhap, mat_khau, email, so_dien_thoai, gioi_tinh, ngay_sinh) VALUES
('USER000001', N'minh_anh', N'hashed_pw_1', 'minhanh@example.com', '0901111111', N'Nữ', '1998-05-15'),
('USER000002', N'tuan_hung', N'hashed_pw_2', 'tuanhung@example.com', '0902222222', N'Nam', '1995-10-20'),
('USER000003', N'ngoc_lan', N'hashed_pw_3', 'ngoclan@example.com', '0903333333', N'Nữ', '2000-01-01'),
('USER000004', N'phuong_nam', N'hashed_pw_4', 'phuongnam@example.com', '0904444444', N'Nam', '1993-07-25'),
('USER000005', N'quoc_bao', N'hashed_pw_5', 'quocbao@example.com', '0905555555', N'Nam', '1997-12-10')
GO

--------------------------------------------------------------------------------
-- 2. Chèn dữ liệu vào bảng HO_SO
--------------------------------------------------------------------------------
INSERT INTO ho_so (ho_so_id, nguoi_dung_id, anh_dai_dien, album_anh, so_thich, mo_ta_ban_than, dia_chi) VALUES
('HS00000001', 'USER000001', N'/avatars/ma_1.jpg', NULL, N'Đọc sách, Du lịch, Yoga', N'Tìm kiếm một người bạn đời chân thành và thú vị.', N'Hà Nội'),
('HS00000002', 'USER000002', N'/avatars/th_2.jpg', NULL, N'Bóng đá, Gym, Âm nhạc Rock', N'Thích các cuộc trò chuyện sâu sắc, nghiêm túc trong mối quan hệ.', N'TP Hồ Chí Minh'),
('HS00000003', 'USER000003', N'/avatars/nl_3.jpg', NULL, N'Nấu ăn, Xem phim, Chăm sóc mèo', N'Sống tích cực, yêu thiên nhiên.', N'Đà Nẵng'),
('HS00000004', 'USER000004', N'/avatars/pn_4.jpg', NULL, N'Đi phượt, Chụp ảnh, Lập trình', N'Tự do, thích khám phá những điều mới mẻ.', N'Hà Nội'),
('HS00000005', 'USER000005', N'/avatars/qb_5.jpg', NULL, N'Vẽ tranh, Thiền, Đạp xe', N'Người hướng nội, cần một sự kết nối từ từ.', N'TP Hồ Chí Minh')
GO

--------------------------------------------------------------------------------
-- 3. Chèn dữ liệu vào bảng THICH (Lượt thích)
--------------------------------------------------------------------------------
-- Minh Anh (1) thích Tuấn Hùng (2) và Phương Nam (4)
INSERT INTO thich (nguoi_gui_id, nguoi_nhan_id, thoi_gian) VALUES
('USER000001', 'USER000002', DATEADD(MINUTE, -120, GETDATE())),
('USER000001', 'USER000004', DATEADD(MINUTE, -90, GETDATE()))

-- Tuấn Hùng (2) thích Minh Anh (1)
INSERT INTO thich (nguoi_gui_id, nguoi_nhan_id, thoi_gian) VALUES
('USER000002', 'USER000001', DATEADD(MINUTE, -100, GETDATE())) -- MATCH xảy ra

-- Ngọc Lan (3) thích Quốc Bảo (5)
INSERT INTO thich (nguoi_gui_id, nguoi_nhan_id, thoi_gian) VALUES
('USER000003', 'USER000005', DATEADD(MINUTE, -60, GETDATE()))

-- Phương Nam (4) thích Ngọc Lan (3)
INSERT INTO thich (nguoi_gui_id, nguoi_nhan_id, thoi_gian) VALUES
('USER000004', 'USER000003', DATEADD(MINUTE, -30, GETDATE()))
GO

--------------------------------------------------------------------------------
-- 4. Chèn dữ liệu vào bảng MATCH_USER
--------------------------------------------------------------------------------
-- Chỉ có Minh Anh (1) và Tuấn Hùng (2) là Match (thích nhau)
INSERT INTO match_user (match_id, nguoi_a_id, nguoi_b_id, thoi_gian) VALUES
('MATCH00001', 'USER000001', 'USER000002', DATEADD(MINUTE, -99, GETDATE())) -- Match Minh Anh & Tuấn Hùng

-- Match phụ (Ngọc Lan và Phương Nam)
INSERT INTO match_user (match_id, nguoi_a_id, nguoi_b_id, thoi_gian) VALUES
('MATCH00002', 'USER000003', 'USER000004', DATEADD(MINUTE, -20, GETDATE()))
GO

--------------------------------------------------------------------------------
-- 5. Chèn dữ liệu vào bảng TIN_NHAN
--------------------------------------------------------------------------------
-- Cuộc trò chuyện Match 1 (Minh Anh và Tuấn Hùng)
INSERT INTO tin_nhan (tin_nhan_id, match_id, nguoi_gui_id, nguoi_nhan_id, noi_dung, thoi_gian) VALUES
('MSG0000001', 'MATCH00001', 'USER000001', 'USER000002', N'Chào bạn, chúng ta đã match! Rất vui được làm quen 😊', DATEADD(MINUTE, -95, GETDATE())),
('MSG0000002', 'MATCH00001', 'USER000002', 'USER000001', N'Chào Minh Anh, mình cũng vậy! Bạn làm nghề gì?', DATEADD(MINUTE, -90, GETDATE())),
('MSG0000003', 'MATCH00001', 'USER000001', 'USER000002', N'Mình là biên tập viên, còn bạn?', DATEADD(MINUTE, -85, GETDATE()))

-- Cuộc trò chuyện Match 2 (Ngọc Lan và Phương Nam)
INSERT INTO tin_nhan (tin_nhan_id, match_id, nguoi_gui_id, nguoi_nhan_id, noi_dung, thoi_gian) VALUES
('MSG0000004', 'MATCH00002', 'USER000003', 'USER000004', N'Ảnh phượt của bạn trông thú vị quá!', DATEADD(MINUTE, -15, GETDATE())),
('MSG0000005', 'MATCH00002', 'USER000004', 'USER000003', N'Cảm ơn bạn! Bạn thích phượt không?', DATEADD(MINUTE, -10, GETDATE()))
GO

--------------------------------------------------------------------------------
-- 6. Chèn dữ liệu vào bảng TAI_KHOAN_VIP
--------------------------------------------------------------------------------
-- Tuấn Hùng (2) đăng ký gói VIP
INSERT INTO tai_khoan_vip (vip_id, nguoi_dung_id, goi_vip, ngay_bat_dau, ngay_ket_thuc) VALUES
('VIP0000001', 'USER000002', N'Gold', '2025-10-01', '2025-11-01')
GO

--------------------------------------------------------------------------------
-- 7. Chèn dữ liệu vào bảng BAO_CAO
--------------------------------------------------------------------------------
-- Minh Anh báo cáo Quốc Bảo (ví dụ)
INSERT INTO bao_cao (bao_cao_id, nguoi_bao_cao_id, nguoi_bi_bao_cao_id, ly_do, thoi_gian) VALUES
('BC00000001', 'USER000001', 'USER000005', N'Gửi tin nhắn quấy rối sau khi bị unmatch', DATEADD(DAY, -1, GETDATE()))
GO