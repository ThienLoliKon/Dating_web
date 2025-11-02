-- Đảm bảo bạn đang dùng đúng database
USE hen_ho
GO

--------------------------------------------------------------------------------
-- 1. Chèn 10 NGƯỜI DÙNG (Đã sửa: Thêm 'trang_thai' và 'ngay_tao')
--------------------------------------------------------------------------------
INSERT INTO nguoi_dung (nguoi_dung_id, ten_dang_nhap, mat_khau, email, so_dien_thoai, gioi_tinh, ngay_sinh, trang_thai, ngay_tao) VALUES
('ND001', 'an_nguyen', 'pass123', 'an@example.com', '0901000001', N'Nam', '1995-10-20', 'active', GETDATE()),
('ND002', 'binh_tran', 'pass123', 'binh@example.com', '0901000002', N'Nam', '1997-05-15', 'active', GETDATE()),
('ND003', 'chi_le', 'pass123', 'chi@example.com', '0901000003', N'Nữ', '1998-01-30', 'active', GETDATE()),
('ND004', 'dung_pham', 'pass123', 'dung@example.com', '0901000004', N'Nữ', '1996-07-07', 'active', GETDATE()),
('ND005', 'em_ho', 'pass123', 'em@example.com', '0901000005', N'Nam', '2000-12-12', 'active', GETDATE()),
('ND006', 'gia_han', 'pass123', 'giahan@example.com', '0901000006', N'Nữ', '1999-02-14', 'active', GETDATE()),
('ND007', 'huy_vu', 'pass123', 'huy@example.com', '0901000007', N'Nam', '1994-08-25', 'active', GETDATE()),
('ND008', 'khanh_ly', 'pass123', 'khanhly@example.com', '0901000008', N'Nữ', '2001-03-10', 'active', GETDATE()),
('ND009', 'minh_long', 'pass123', 'long@example.com', '0901000009', N'Nam', '1998-11-05', 'active', GETDATE()),
('ND010', 'nhu_y', 'pass123', 'nhuy@example.com', '0901000010', N'Nữ', '2002-06-22', 'active', GETDATE());
GO

-- (Chạy tiếp các script INSERT cho HỒ SƠ, TÀI KHOẢN VIP, ... như cũ)
-- (Tôi đã sửa luôn lỗi 'thoi_gian' cho bảng 'bao_cao' và 'thich')

--------------------------------------------------------------------------------
-- 2. Chèn 10 HỒ SƠ 
--------------------------------------------------------------------------------
INSERT INTO ho_so (ho_so_id, nguoi_dung_id, ho_va_ten, anh_dai_dien, album_anh, so_thich, mo_ta_ban_than, dia_chi) VALUES
('HS001', 'ND001', N'Nguyễn Văn An', '/img/avatars/an.jpg', NULL, N'Leo núi, đọc sách', N'Tìm bạn tâm sự.', N'Hà Nội'),
('HS002', 'ND002', N'Trần Văn Bình', '/img/avatars/binh.jpg', '/img/album/binh_1.jpg', N'Gym, bơi lội', N'Nghiêm túc trong các mối quan hệ.', N'TP Hồ Chí Minh'),
('HS003', 'ND003', N'Lê Thị Chi', '/img/avatars/chi.jpg', NULL, N'Nấu ăn, xem phim', N'Vui vẻ, hòa đồng, thích mèo.', N'Đà Nẵng'),
('HS004', 'ND004', N'Phạm Thị Dung', '/img/avatars/dung.jpg', '/img/album/dung_1.jpg', N'Du lịch, chụp ảnh', N'Thích khám phá những vùng đất mới.', N'Hà Nội'),
('HS005', 'ND005', N'Hồ Văn Em', '/img/avatars/em.jpg', NULL, N'Đàn guitar, cafe', N'Tìm người tâm sự.', N'TP Hồ Chí Minh'),
('HS006', 'ND006', N'Trần Gia Hân', '/img/avatars/han.jpg', NULL, N'Yoga, thiền', N'Yêu động vật, sống chậm.', N'Cần Thơ'),
('HS007', 'ND007', N'Vũ Quang Huy', '/img/avatars/huy.jpg', NULL, N'Bóng đá, lập trình', N'Work hard, play hard.', N'Hà Nội'),
('HS008', 'ND008', N'Lý Khánh Ly', '/img/avatars/ly.jpg', '/img/album/ly_1.jpg', N'Vẽ tranh, piano', N'Một tâm hồn nghệ sĩ.', N'Huế'),
('HS009', 'ND009', N'Hoàng Minh Long', '/img/avatars/long.jpg', NULL, N'Chơi game, xem anime', N'Introvert, tìm người cùng sở thích.', N'TP Hồ Chí Minh'),
('HS010', 'ND010', N'Nguyễn Như Ý', '/img/avatars/y.jpg', '/img/album/y_1.jpg', N'Shopping, trà sữa', N'Gen Z chính hiệu.', N'Đà Lạt');
GO

--------------------------------------------------------------------------------
-- 3. Chèn TÀI KHOẢN VIP 
--------------------------------------------------------------------------------
INSERT INTO tai_khoan_vip (vip_id, nguoi_dung_id, goi_vip, ngay_bat_dau, ngay_ket_thuc) VALUES
('VIP001', 'ND001', 'Gold', GETDATE(), DATEADD(month, 1, GETDATE())),
('VIP002', 'ND004', 'Premium', DATEADD(day, -10, GETDATE()), DATEADD(month, 2, GETDATE())),
('VIP003', 'ND007', 'Gold', DATEADD(day, -5, GETDATE()), DATEADD(month, 1, GETDATE()));
GO

--------------------------------------------------------------------------------
-- 4. Chèn LƯỢT THÍCH (Đã sửa: Thêm 'thoi_gian')
--------------------------------------------------------------------------------
INSERT INTO thich (nguoi_gui_id, nguoi_nhan_id, thoi_gian) VALUES
('ND001', 'ND003', DATEADD(hour, -5, GETDATE())),
('ND003', 'ND001', DATEADD(hour, -4, GETDATE())),
('ND002', 'ND006', DATEADD(hour, -3, GETDATE())),
('ND006', 'ND002', DATEADD(hour, -2, GETDATE())),
('ND007', 'ND008', DATEADD(hour, -1, GETDATE())),
('ND008', 'ND007', DATEADD(minute, -30, GETDATE())),
('ND009', 'ND010', DATEADD(minute, -15, GETDATE())),
('ND010', 'ND009', DATEADD(minute, -10, GETDATE())),
('ND001', 'ND004', DATEADD(day, -1, GETDATE())), 
('ND005', 'ND003', DATEADD(day, -2, GETDATE())), 
('ND007', 'ND004', DATEADD(hour, -6, GETDATE())), 
('ND002', 'ND008', DATEADD(hour, -8, GETDATE()));
GO

--------------------------------------------------------------------------------
-- 5. Chèn MATCH (Đã sửa: Thêm 'thoi_gian')
--------------------------------------------------------------------------------
INSERT INTO match_user (match_id, nguoi_a_id, nguoi_b_id, thoi_gian) VALUES
('MAT001', 'ND001', 'ND003', DATEADD(hour, -4, GETDATE())), 
('MAT002', 'ND002', 'ND006', DATEADD(hour, -2, GETDATE())), 
('MAT003', 'ND007', 'ND008', DATEADD(minute, -30, GETDATE())), 
('MAT004', 'ND009', 'ND010', DATEADD(minute, -10, GETDATE()));
GO

--------------------------------------------------------------------------------
-- 6. Chèn TIN NHẮN (Đã sửa: Thêm 'thoi_gian')
--------------------------------------------------------------------------------
INSERT INTO tin_nhan (tin_nhan_id, match_id, nguoi_gui_id, noi_dung, thoi_gian) VALUES
('MSG001', 'MAT001', 'ND001', N'Chào Chi, mình match rồi!', DATEADD(minute, -239, GETDATE())),
('MSG002', 'MAT001', 'ND003', N'Chào An 😊 Rất vui được làm quen.', DATEADD(minute, -238, GETDATE())),
('MSG003', 'MAT001', 'ND001', N'Bạn cũng ở Hà Nội à? Mình ở Cầu Giấy.', DATEADD(minute, -235, GETDATE())),
('MSG004', 'MAT002', 'ND002', N'Chào em, anh là Bình.', DATEADD(minute, -119, GETDATE())),
('MSG005', 'MAT002', 'ND006', N'Dạ em chào anh', DATEADD(minute, -118, GETDATE())),
('MSG006', 'MAT002', 'ND002', N'Em cũng thích gym à?', DATEADD(minute, -115, GETDATE())),
('MSG007', 'MAT003', 'ND007', N'Ảnh vẽ của em đẹp quá', DATEADD(minute, -29, GETDATE())),
('MSG008', 'MAT003', 'ND008', N'Em cảm ơn anh ^^', DATEADD(minute, -28, GETDATE())),
('MSG009', 'MAT004', 'ND009', N'Hi, bạn thích xem anime gì?', DATEADD(minute, -9, GETDATE())),
('MSG010', 'MAT004', 'ND010', N'Chào bạn, mình thích One Piece', DATEADD(minute, -8, GETDATE()));
GO

--------------------------------------------------------------------------------
-- 7. Chèn BÁO CÁO (Đã sửa: Thêm 'thoi_gian')
--------------------------------------------------------------------------------
INSERT INTO bao_cao (bao_cao_id, nguoi_bao_cao_id, nguoi_bi_bao_cao_id, ly_do, thoi_gian) VALUES
('BC001', 'ND005', 'ND007', N'Người này có vẻ dùng ảnh giả mạo.', GETDATE()),
('BC002', 'ND002', 'ND009', N'Quấy rối, gửi tin nhắn không phù hợp.', GETDATE());
GO

PRINT N'Chèn 10 người dùng và dữ liệu liên quan thành công!'
GO
