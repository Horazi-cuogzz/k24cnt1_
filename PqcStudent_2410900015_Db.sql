-- =======================================================
-- FILE NỘP: PqcStudent_2410900015_Db.sql
-- SINH VIÊN: Phùng Quang Cường
-- MÃ SINH VIÊN: 2410900015
-- LỚP: K24CNT1
-- BÀI THI: ASP.NET Core MVC - Entity Framework Core Database First
-- NGÀY THI: 26/09/2026
-- =======================================================

-- 1. Tạo cơ sở dữ liệu
CREATE DATABASE PQCStudent_2410900015_Db;
GO

USE PQCStudent_2410900015_Db;
GO

-- 2. Tạo bảng PqcStudent
CREATE TABLE PqcStudent (
    Id INT IDENTITY(1,1) PRIMARY KEY,       -- Khóa chính tự tăng
    PqcName NVARCHAR(100) NOT NULL,         -- Họ tên sinh viên
    PqcGender BIT NULL,                     -- Giới tính (1: Nam, 0: Nữ)
    PqcBirthDay DATE NULL,                  -- Ngày sinh
    PqcEmail VARCHAR(100) NULL,             -- Email liên hệ
    PqcPhone VARCHAR(20) NULL,              -- Số điện thoại
    PqcActive BIT DEFAULT 1                 -- Trạng thái học tập (1: Đang học, 0: Tạm dừng)
);
GO

-- 3. Thêm dữ liệu mẫu kiểm thử
INSERT INTO PqcStudent (PqcName, PqcGender, PqcBirthDay, PqcEmail, PqcPhone, PqcActive)
VALUES 
(N'Phùng Quang Cường', 1, '2006-01-15', 'cuong.pq@gmail.com', '0987654321', 1),
(N'Nguyễn Văn An', 1, '2006-05-20', 'an.nv@gmail.com', '0912345678', 1),
(N'Trần Thị Bích', 0, '2006-08-10', 'bich.tt@gmail.com', '0901234567', 1),
(N'Lê Hoàng Cúc', 0, '2006-11-25', 'cuc.lh@gmail.com', '0934567890', 0);
GO

-- 4. Truy vấn kiểm tra dữ liệu
SELECT * FROM PqcStudent;
GO
