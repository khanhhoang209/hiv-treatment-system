-- ================================================
-- SQL Script: Dữ liệu mẫu cho Dashboard HIV Treatment System
-- Tạo ngày: 28/07/2025
-- Mục đích: Tạo dữ liệu mẫu với UUID đúng định dạng chuẩn
-- ================================================

-- Tắt thông báo số lượng rows bị ảnh hưởng để script chạy nhanh hơn
SET NOCOUNT ON;

-- ================================================
-- 1. ROLES DATA
-- ================================================

PRINT 'Inserting Roles...';
INSERT INTO [Role] (Id, Name, NormalizedName) VALUES
    ('A1B2C3D4-E5F6-7890-1234-567890ABCDEF', 'Admin', 'ADMIN'),
    ('B2C3D4E5-F607-8901-2345-678901BCDEF0', 'Doctor', 'DOCTOR'),
    ('C3D4E5F6-0708-9012-3456-789012CDEF01', 'Staff', 'STAFF'),
    ('D4E5F6A7-0809-0123-4567-890123DEF012', 'User', 'USER');

-- ================================================
-- 2. USERS DATA (Admin, Doctors, Staff, Patients)
-- ================================================
PRINT 'Inserting Users...';

-- Admin User
DECLARE @AdminRoleId UNIQUEIDENTIFIER = 'A1B2C3D4-E5F6-7890-1234-567890ABCDEF';
DECLARE @AdminUserId UNIQUEIDENTIFIER = '12345678-90AB-CDEF-1234-567890ABCDEF';
INSERT INTO [User] (Id, Username, Password, Email, Phone, Address, DateOfBirth, Gender, Status, RoleId)
VALUES (@AdminUserId, 'admin', 'admin123', 'admin@hivtreatment.vn', '0901234567', '123 Đường ABC, Q1, TP.HCM', '1985-01-15', 'Male', 'Active', @AdminRoleId);

-- Doctor Users
DECLARE @DoctorRoleId UNIQUEIDENTIFIER = 'B2C3D4E5-F607-8901-2345-678901BCDEF0';
DECLARE @Doctor1Id UNIQUEIDENTIFIER = '23456789-01BC-DEF2-3456-7890ABCDEF12';
DECLARE @Doctor2Id UNIQUEIDENTIFIER = '34567890-12CD-EF34-5678-90ABCDEF1234';
DECLARE @Doctor3Id UNIQUEIDENTIFIER = '45678901-23DE-F456-7890-ABCDEF123456';

INSERT INTO [User] (Id, Username, Password, Email, Phone, Address, DateOfBirth, Gender, Status, RoleId) VALUES
    (@Doctor1Id, 'dr.nguyen', 'doctor123', 'dr.nguyen@hivtreatment.vn', '0912345678', '456 Đường DEF, Q2, TP.HCM', '1980-03-20', 'Male', 'Active', @DoctorRoleId),
    (@Doctor2Id, 'dr.le', 'doctor123', 'dr.le@hivtreatment.vn', '0923456789', '789 Đường DEF, Q3, TP.HCM', '1982-07-12', 'Female', 'Active', @DoctorRoleId),
    (@Doctor3Id, 'dr.tran', 'doctor123', 'dr.tran@hivtreatment.vn', '0934567890', '321 Đường JKL, Q4, TP.HCM', '1978-11-05', 'Male', 'Active', @DoctorRoleId);

-- Staff Users
DECLARE @StaffRoleId UNIQUEIDENTIFIER = 'C3D4E5F6-0708-9012-3456-789012CDEF01';
DECLARE @Staff1Id UNIQUEIDENTIFIER = '56789012-34EF-5678-90AB-CDEF12345678';
DECLARE @Staff2Id UNIQUEIDENTIFIER = '67890123-45F0-6789-01BC-DEF123456789';

INSERT INTO [User] (Id, Username, Password, Email, Phone, Address, DateOfBirth, Gender, Status, RoleId) VALUES
    (@Staff1Id, 'nurse.mai', 'staff123', 'nurse.mai@hivtreatment.vn', '0945678901', '654 Đường MNO, Q5, TP.HCM', '1990-05-18', 'Female', 'Active', @StaffRoleId),
    (@Staff2Id, 'tech.duc', 'staff123', 'tech.duc@hivtreatment.vn', '0956789012', '987 Đường PQR, Q6, TP.HCM', '1988-09-22', 'Male', 'Active', @StaffRoleId);

-- Patient Users (20 bệnh nhân)
DECLARE @UserRoleId UNIQUEIDENTIFIER = 'D4E5F6A7-0809-0123-4567-890123DEF012';
INSERT INTO [User] (Id, Username, Password, Email, Phone, Address, DateOfBirth, Gender, Status, RoleId) VALUES
    ('78901234-5601-789A-BCDE-F12345678901', 'patient01', 'patient123', 'patient01@email.com', '0967890123', '111 Đường ABC, Q7, TP.HCM', '1995-01-10', 'Male', 'Active', @UserRoleId),
    ('89012345-6712-89AB-CDEF-123456789012', 'patient02', 'patient123', 'patient02@email.com', '0978901234', '222 Đường DEF, Q8, TP.HCM', '1992-01-15', 'Female', 'Active', @UserRoleId),
    ('90123456-7823-90BC-DEF1-234567890123', 'patient03', 'patient123', 'patient03@email.com', '0989012345', '333 Đường ABC, Q9, TP.HCM', '1988-02-20', 'Male', 'Active', @UserRoleId),
    ('01234567-8934-01CD-EF12-345678901234', 'patient04', 'patient123', 'patient04@email.com', '0990123456', '444 Đường JKL, Q10, TP.HCM', '1991-02-25', 'Female', 'Active', @UserRoleId),
    ('12345678-9045-12DE-F123-456789012345', 'patient05', 'patient123', 'patient05@email.com', '0901234568', '555 Đường MNO, Q11, TP.HCM', '1987-03-12', 'Male', 'Active', @UserRoleId),
    ('23456789-0156-23EF-1234-567890123456', 'patient06', 'patient123', 'patient06@email.com', '0912345679', '666 Đường PQR, Q12, TP.HCM', '1993-03-28', 'Female', 'Active', @UserRoleId),
    ('34567890-1267-34F0-2345-678901234567', 'patient07', 'patient123', 'patient07@email.com', '0923456780', '777 Đường STU, Q1, TP.HCM', '1989-04-05', 'Male', 'Active', @UserRoleId),
    ('45678901-2378-4501-3456-789012345678', 'patient08', 'patient123', 'patient08@email.com', '0934567891', '888 Đường VWX, Q2, TP.HCM', '1994-04-18', 'Female', 'Active', @UserRoleId),
    ('56789012-3489-5612-4567-890123456789', 'patient09', 'patient123', 'patient09@email.com', '0945678902', '999 Đường YZ, Q3, TP.HCM', '1986-05-22', 'Male', 'Active', @UserRoleId),
    ('67890123-459A-6723-5678-901234567890', 'patient10', 'patient123', 'patient10@email.com', '0956789013', '101 Đường AB, Q4, TP.HCM', '1996-05-30', 'Female', 'Active', @UserRoleId),
    ('78901234-56AB-7834-6789-012345678901', 'patient11', 'patient123', 'patient11@email.com', '0967890124', '202 Đường CD, Q5, TP.HCM', '1985-06-08', 'Male', 'Active', @UserRoleId),
    ('89012345-67BC-8945-7890-123456789012', 'patient12', 'patient123', 'patient12@email.com', '0978901235', '303 Đường EF, Q6, TP.HCM', '1997-06-15', 'Female', 'Active', @UserRoleId),
    ('90123456-78CD-9056-8901-234567890123', 'patient13', 'patient123', 'patient13@email.com', '0989012346', '404 Đường AB, Q7, TP.HCM', '1984-07-03', 'Male', 'Active', @UserRoleId),
    ('01234567-89DE-0167-9012-345678901234', 'patient14', 'patient123', 'patient14@email.com', '0990123457', '505 Đường EF, Q8, TP.HCM', '1998-07-19', 'Female', 'Active', @UserRoleId),
    ('12345678-90EF-1278-0123-456789012345', 'patient15', 'patient123', 'patient15@email.com', '0901234569', '606 Đường KL, Q9, TP.HCM', '1983-08-11', 'Male', 'Active', @UserRoleId),
    ('23456789-01F0-2389-1234-567890123456', 'patient16', 'patient123', 'patient16@email.com', '0912345680', '707 Đường MN, Q10, TP.HCM', '1999-08-25', 'Female', 'Active', @UserRoleId),
    ('34567890-1201-349A-2345-678901234567', 'patient17', 'patient123', 'patient17@email.com', '0923456781', '808 Đường OP, Q11, TP.HCM', '1982-09-07', 'Male', 'Active', @UserRoleId),
    ('45678901-2312-45AB-3456-789012345678', 'patient18', 'patient123', 'patient18@email.com', '0934567892', '909 Đường QR, Q12, TP.HCM', '2000-09-14', 'Female', 'Active', @UserRoleId),
    ('56789012-3423-56BC-4567-890123456789', 'patient19', 'patient123', 'patient19@email.com', '0945678903', '111 Đường ST, Q1, TP.HCM', '1981-10-02', 'Male', 'Active', @UserRoleId),
    ('67890123-4534-67CD-5678-901234567890', 'patient20', 'patient123', 'patient20@email.com', '0956789014', '222 Đường UV, Q2, TP.HCM', '2001-10-28', 'Female', 'Active', @UserRoleId);

-- ================================================
-- 3. EMPLOYEES DATA
-- ================================================
PRINT 'Inserting Employees...';

DECLARE @AdminEmpId UNIQUEIDENTIFIER = 'ABCDEF12-3456-789A-BCDE-F12345678901';
DECLARE @DocEmp1Id UNIQUEIDENTIFIER = 'BCDEF123-4567-89AB-CDEF-123456789012';
DECLARE @DocEmp2Id UNIQUEIDENTIFIER = 'CDEF1234-5678-90BC-DEF1-234567890123';
DECLARE @DocEmp3Id UNIQUEIDENTIFIER = 'DEF12345-6789-01CD-EF12-345678901234';
DECLARE @StaffEmp1Id UNIQUEIDENTIFIER = 'EF123456-789A-12DE-F123-456789012345';
DECLARE @StaffEmp2Id UNIQUEIDENTIFIER = 'F1234567-89AB-23EF-1234-567890123456';

INSERT INTO [Employee] (Id, FirstName, LastName, Email, Phone, Address, DateOfBirth, Gender, Status, UserId) VALUES
    (@AdminEmpId, 'Admin', 'System', 'admin@hivtreatment.vn', '0901234567', '123 Đường ABC, Q1, TP.HCM', '1985-01-15', 'Male', 'Active', @AdminUserId),
    (@DocEmp1Id, 'Nguyễn Văn', 'A', 'dr.nguyen@hivtreatment.vn', '0912345678', '456 Đường DEF, Q2, TP.HCM', '1980-03-20', 'Male', 'Active', @Doctor1Id),
    (@DocEmp2Id, 'Lê Thị', 'B', 'dr.le@hivtreatment.vn', '0923456789', '789 Đường ABC, Q3, TP.HCM', '1982-07-12', 'Female', 'Active', @Doctor2Id),
    (@DocEmp3Id, 'Trần Minh', 'C', 'dr.tran@hivtreatment.vn', '0934567890', '321 Đường JKL, Q4, TP.HCM', '1978-11-05', 'Male', 'Active', @Doctor3Id),
    (@StaffEmp1Id, 'Mai Thị', 'D', 'nurse.mai@hivtreatment.vn', '0945678901', '654 Đường MNO, Q5, TP.HCM', '1990-05-18', 'Female', 'Active', @Staff1Id),
    (@StaffEmp2Id, 'Đức Văn', 'E', 'tech.duc@hivtreatment.vn', '0956789012', '987 Đường PQR, Q6, TP.HCM', '1988-09-22', 'Male', 'Active', @Staff2Id);

-- ================================================
-- 4. DOCTORS DATA
-- ================================================
PRINT 'Inserting Doctors...';

DECLARE @DoctorId1 UNIQUEIDENTIFIER = '12345678-9ABC-DEF1-2345-6789ABCDEF12';
DECLARE @DoctorId2 UNIQUEIDENTIFIER = '23456789-ABCD-EF12-3456-789ABCDEF123';
DECLARE @DoctorId3 UNIQUEIDENTIFIER = '3456789A-BCDE-F123-4567-89ABCDEF1234';

INSERT INTO [Doctor] (Id, Specialization, LicenseNumber, EmployeeId) VALUES
    (@DoctorId1, 'Bệnh nhiễm trùng', 'BS001234', @DocEmp1Id),
    (@DoctorId2, 'Nội khoa tổng quát', 'BS001235', @DocEmp2Id),
    (@DoctorId3, 'HIV/AIDS chuyên khoa', 'BS001236', @DocEmp3Id);

-- ================================================
-- 5. STAFF DATA
-- ================================================
PRINT 'Inserting Staff...';

INSERT INTO [Staff] (Id, Position, EmployeeId, Department) VALUES
    ('456789AB-CDEF-1234-5678-9ABCDEF12345', 'Y tá trưởng', @StaffEmp1Id, 'Biet chet lien'),
    ('56789ABC-DEF1-2345-6789-ABCDEF123456', 'Kỹ thuật viên xét nghiệm', @StaffEmp2Id, 'Biet chet lien');

-- ================================================
-- 6. TYPE DATA (cho Test Results)
-- ================================================
PRINT 'Inserting Types...';

DECLARE @TypeId1 UNIQUEIDENTIFIER = '6789ABCD-EF12-3456-789A-BCDEF123456A';
DECLARE @TypeId2 UNIQUEIDENTIFIER = '789ABCDE-F123-4567-89AB-CDEF123456AB';
DECLARE @TypeId3 UNIQUEIDENTIFIER = '89ABCDEF-1234-5678-90BC-DEF123456ABC';

INSERT INTO [Type] (Id, Name, Description, Price) VALUES
    (@TypeId1, 'HIV Viral Load', 'Xét nghiệm tải lượng virus HIV', 100000),
    (@TypeId2, 'CD4 Count', 'Đếm tế bào CD4', 200000),
    (@TypeId3, 'HIV Rapid Test', 'Test nhanh HIV', 300000);

-- ================================================
-- 7. ARV REGIMEN DATA
-- ================================================
PRINT 'Inserting ARV Regimens...';

DECLARE @ArvId1 UNIQUEIDENTIFIER = '9ABCDEF1-2345-6789-01CD-EF123456ABCD';
DECLARE @ArvId2 UNIQUEIDENTIFIER = 'ABCDEF12-3456-789A-12DE-F123456ABCDE';

INSERT INTO [ArvRegimen] (Id, Name, Description, Level) VALUES
    (@ArvId1, 'TDF + 3TC + EFV', 'Phác đồ điều trị hàng đầu', 1),
    (@ArvId2, 'ABC + 3TC + DTG', 'Phác đồ thay thế', 2);

-- ================================================
-- 8. APPOINTMENTS DATA
-- ================================================
PRINT 'Inserting Appointments...';

-- Appointments hôm nay (5 confirmed)
INSERT INTO [Appointment] (Id, AppointmentDate, Status, Notes, DoctorId, UserId) VALUES
    ('BCDEF123-4567-89AB-23EF-123456789ABC', DATEADD(HOUR, 8, CONVERT(DATETIME, CONVERT(DATE, GETDATE()))), 'Confirmed', 'Khám định kỳ', @DoctorId1, '78901234-5601-789A-BCDE-F12345678901'),
    ('CDEF1234-5678-9ABC-34F0-23456789ABCD', DATEADD(HOUR, 9, CONVERT(DATETIME, CONVERT(DATE, GETDATE()))), 'Confirmed', 'Khám định kỳ', @DoctorId1, '89012345-6712-89AB-CDEF-123456789012'),
    ('DEF12345-6789-ABCD-4501-3456789ABCDE', DATEADD(HOUR, 10, CONVERT(DATETIME, CONVERT(DATE, GETDATE()))), 'Confirmed', 'Khám định kỳ', @DoctorId2, '90123456-7823-90BC-DEF1-234567890123'),
    ('EF123456-789A-BCDE-5612-456789ABCDEF', DATEADD(HOUR, 11, CONVERT(DATETIME, CONVERT(DATE, GETDATE()))), 'Confirmed', 'Khám định kỳ', @DoctorId2, '01234567-8934-01CD-EF12-345678901234'),
    ('F1234567-89AB-CDEF-6723-56789ABCDEF1', DATEADD(HOUR, 14, CONVERT(DATETIME, CONVERT(DATE, GETDATE()))), 'Confirmed', 'Khám định kỳ', @DoctorId3, '12345678-9045-12DE-F123-456789012345');

-- Appointments hôm nay (3 pending)
INSERT INTO [Appointment] (Id, AppointmentDate, Status, Notes, DoctorId, UserId) VALUES
    ('12345678-9ABC-DEF7-834A-6789ABCDEF12', DATEADD(HOUR, 15, CONVERT(DATETIME, CONVERT(DATE, GETDATE()))), 'Pending', 'Tái khám', @DoctorId1, '23456789-0156-23EF-1234-567890123456'),
    ('23456789-ABCD-EF18-945B-789ABCDEF123', DATEADD(HOUR, 16, CONVERT(DATETIME, CONVERT(DATE, GETDATE()))), 'Pending', 'Tái khám', @DoctorId2, '34567890-1267-34F0-2345-678901234567'),
    ('3456789A-BCDE-F129-056C-89ABCDEF1234', DATEADD(HOUR, 17, CONVERT(DATETIME, CONVERT(DATE, GETDATE()))), 'Pending', 'Tái khám', @DoctorId3, '45678901-2378-4501-3456-789012345678');

-- Appointments tuần này (completed)
INSERT INTO [Appointment] (Id, AppointmentDate, Status, Notes, DoctorId, UserId) VALUES
    ('456789AB-CDEF-123A-167D-9012345678AB', DATEADD(DAY, -1, GETDATE()), 'Completed', 'Đã hoàn thành khám', @DoctorId1, '56789012-3489-5612-4567-890123456789'),
    ('56789ABC-DEF1-234B-278E-0123456789BC', DATEADD(DAY, -2, GETDATE()), 'Completed', 'Đã hoàn thành khám', @DoctorId2, '67890123-459A-6723-5678-901234567890'),
    ('6789ABCD-EF12-345C-389F-123456789BCD', DATEADD(DAY, -3, GETDATE()), 'Completed', 'Đã hoàn thành khám', @DoctorId3, '78901234-56AB-7834-6789-012345678901'),
    ('789ABCDE-F123-456D-49A0-23456789BCDE', DATEADD(DAY, -4, GETDATE()), 'Completed', 'Đã hoàn thành khám', @DoctorId1, '89012345-67BC-8945-7890-123456789012'),
    ('89ABCDEF-1234-567E-5AB1-3456789BCDEF', DATEADD(DAY, -5, GETDATE()), 'Completed', 'Đã hoàn thành khám', @DoctorId2, '90123456-78CD-9056-8901-234567890123');

-- Appointments bị hủy
INSERT INTO [Appointment] (Id, AppointmentDate, Status, Notes, DoctorId, UserId) VALUES
    ('9ABCDEF1-2345-678F-6BC2-456789ABCDEF', DATEADD(DAY, -7, GETDATE()), 'Cancelled', 'Bệnh nhân hủy lịch', @DoctorId1, '01234567-89DE-0167-9012-345678901234'),
    ('ABCDEF12-3456-7890-7CD3-56789ABCDEF1', DATEADD(DAY, -10, GETDATE()), 'Cancelled', 'Bệnh nhân hủy lịch', @DoctorId2, '12345678-90EF-1278-0123-456789012345');

-- ================================================
-- 9. MEDICAL RECORDS DATA
-- ================================================
PRINT 'Inserting Medical Records...';

INSERT INTO [MedicalRecord] (Id, RecordDate, Diagnosis, Treatment, Notes, DoctorId, UserId) VALUES
    ('BCDEF123-4567-8901-8DE4-6789ABCDEF12', DATEADD(DAY, -5, CAST(GETDATE() AS DATE)), 'HIV giai đoạn mãn tính', 'Điều trị ARV theo phác đồ', 'Bệnh nhân tuân thủ điều trị tốt', @DoctorId1, '78901234-5601-789A-BCDE-F12345678901'),
    ('CDEF1234-5678-9012-9EF5-789ABCDEF123', DATEADD(DAY, -10, CAST(GETDATE() AS DATE)), 'HIV với tổn thương da', 'Điều trị ARV theo phác đồ', 'Bệnh nhân tuân thủ điều trị tốt', @DoctorId2, '89012345-6712-89AB-CDEF-123456789012'),
    ('DEF12345-6789-0123-AF06-89ABCDEF1234', DATEADD(DAY, -15, CAST(GETDATE() AS DATE)), 'HIV kèm nhiễm trùng cơ hội', 'Điều trị ARV theo phác đồ', 'Bệnh nhân tuân thủ điều trị tốt', @DoctorId3, '90123456-7823-90BC-DEF1-234567890123'),
    ('EF123456-789A-1234-B017-9ABCDEF12345', DATEADD(DAY, -8, CAST(GETDATE() AS DATE)), 'HIV điều trị ổn định', 'Điều trị ARV theo phác đồ', 'Bệnh nhân tuân thủ điều trị tốt', @DoctorId1, '01234567-8934-01CD-EF12-345678901234'),
    ('F1234567-89AB-2345-C128-ABCDEF123456', DATEADD(DAY, -12, CAST(GETDATE() AS DATE)), 'HIV giai đoạn mãn tính', 'Điều trị ARV theo phác đồ', 'Bệnh nhân tuân thủ điều trị tốt', @DoctorId2, '12345678-9045-12DE-F123-456789012345'),
    ('12345678-9ABC-3456-D239-BCDEF1234567', DATEADD(DAY, -3, CAST(GETDATE() AS DATE)), 'HIV với tổn thương da', 'Điều trị ARV theo phác đồ', 'Bệnh nhân tuân thủ điều trị tốt', @DoctorId3, '23456789-0156-23EF-1234-567890123456'),
    ('23456789-ABCD-4567-E34A-CDEF12345678', DATEADD(DAY, -7, CAST(GETDATE() AS DATE)), 'HIV điều trị ổn định', 'Điều trị ARV theo phác đồ', 'Bệnh nhân tuân thủ điều trị tốt', @DoctorId1, '34567890-1267-34F0-2345-678901234567'),
    ('3456789A-BCDE-5678-F45B-DEF123456789', DATEADD(DAY, -20, CAST(GETDATE() AS DATE)), 'HIV kèm nhiễm trùng cơ hội', 'Điều trị ARV theo phác đồ', 'Bệnh nhân tuân thủ điều trị tốt', @DoctorId2, '45678901-2378-4501-3456-789012345678'),
    ('456789AB-CDEF-6789-056C-EF123456789A', DATEADD(DAY, -25, CAST(GETDATE() AS DATE)), 'HIV giai đoạn mãn tính', 'Điều trị ARV theo phác đồ', 'Bệnh nhân tuân thủ điều trị tốt', @DoctorId3, '56789012-3489-5612-4567-890123456789'),
    ('56789ABC-DEF1-789A-167D-F123456789AB', DATEADD(DAY, -2, CAST(GETDATE() AS DATE)), 'HIV điều trị ổn định', 'Điều trị ARV theo phác đồ', 'Bệnh nhân tuân thủ điều trị tốt', @DoctorId1, '67890123-459A-6723-5678-901234567890'),
    ('6789ABCD-EF12-89AB-278E-123456789ABC', DATEADD(DAY, -18, CAST(GETDATE() AS DATE)), 'HIV với tổn thương da', 'Điều trị ARV theo phác đồ', 'Bệnh nhân tuân thủ điều trị tốt', @DoctorId2, '78901234-56AB-7834-6789-012345678901'),
    ('789ABCDE-F123-9ABC-389F-23456789ABCD', DATEADD(DAY, -14, CAST(GETDATE() AS DATE)), 'HIV kèm nhiễm trùng cơ hội', 'Điều trị ARV theo phác đồ', 'Bệnh nhân tuân thủ điều trị tốt', @DoctorId3, '89012345-67BC-8945-7890-123456789012'),
    ('89ABCDEF-1234-ABCD-49A0-3456789ABCDE', DATEADD(DAY, -6, CAST(GETDATE() AS DATE)), 'HIV giai đoạn mãn tính', 'Điều trị ARV theo phác đồ', 'Bệnh nhân tuân thủ điều trị tốt', @DoctorId1, '90123456-78CD-9056-8901-234567890123'),
    ('9ABCDEF1-2345-BCDE-5AB1-456789ABCDEF', DATEADD(DAY, -22, CAST(GETDATE() AS DATE)), 'HIV điều trị ổn định', 'Điều trị ARV theo phác đồ', 'Bệnh nhân tuân thủ điều trị tốt', @DoctorId2, '01234567-89DE-0167-9012-345678901234'),
    ('ABCDEF12-3456-CDEF-6BC2-56789ABCDEF1', DATEADD(DAY, -9, CAST(GETDATE() AS DATE)), 'HIV với tổn thương da', 'Điều trị ARV theo phác đồ', 'Bệnh nhân tuân thủ điều trị tốt', @DoctorId3, '12345678-90EF-1278-0123-456789012345'),
    ('BCDEF123-4567-DEF1-7CD3-6789ABCDEF12', DATEADD(DAY, -16, CAST(GETDATE() AS DATE)), 'HIV kèm nhiễm trùng cơ hội', 'Điều trị ARV theo phác đồ', 'Bệnh nhân tuân thủ điều trị tốt', @DoctorId1, '23456789-01F0-2389-1234-567890123456'),
    ('CDEF1234-5678-EF12-8DE4-789ABCDEF123', DATEADD(DAY, -11, CAST(GETDATE() AS DATE)), 'HIV giai đoạn mãn tính', 'Điều trị ARV theo phác đồ', 'Bệnh nhân tuân thủ điều trị tốt', @DoctorId2, '34567890-1201-349A-2345-678901234567'),
    ('DEF12345-6789-F123-9EF5-89ABCDEF1234', DATEADD(DAY, -4, CAST(GETDATE() AS DATE)), 'HIV điều trị ổn định', 'Điều trị ARV theo phác đồ', 'Bệnh nhân tuân thủ điều trị tốt', @DoctorId3, '45678901-2312-45AB-3456-789012345678'),
    ('EF123456-789A-1234-AF06-9ABCDEF12345', DATEADD(DAY, -19, CAST(GETDATE() AS DATE)), 'HIV với tổn thương da', 'Điều trị ARV theo phác đồ', 'Bệnh nhân tuân thủ điều trị tốt', @DoctorId1, '56789012-3423-56BC-4567-890123456789'),
    ('F1234567-89AB-2345-B017-ABCDEF123456', DATEADD(DAY, -13, CAST(GETDATE() AS DATE)), 'HIV kèm nhiễm trùng cơ hội', 'Điều trị ARV theo phác đồ', 'Bệnh nhân tuân thủ điều trị tốt', @DoctorId2, '67890123-4534-67CD-5678-901234567890');

-- ================================================
-- 10. TEST RESULTS DATA
-- ================================================
PRINT 'Inserting Test Results...';

INSERT INTO [TestResult] (Id, TestDate, Result, Notes, MedicalRecordId, TypeId, ArvRegimentId) VALUES
    ('12345678-9ABC-BCDE-5678-90123456789A', DATEADD(DAY, -3, CAST(GETDATE() AS DATE)), 'Negative', 'Kết quả tốt', 'BCDEF123-4567-8901-8DE4-6789ABCDEF12', @TypeId1, @ArvId1),
    ('23456789-ABCD-CDEF-6789-01234567890B', DATEADD(DAY, -8, CAST(GETDATE() AS DATE)), 'Positive', 'Cần theo dõi', 'CDEF1234-5678-9012-9EF5-789ABCDEF123', @TypeId2, @ArvId2),
    ('3456789A-BCDE-DEF1-789A-12345678901C', DATEADD(DAY, -1, CAST(GETDATE() AS DATE)), 'Pending', 'Đang chờ kết quả', 'DEF12345-6789-0123-AF06-89ABCDEF1234', @TypeId3, @ArvId1),
    ('456789AB-CDEF-EF12-89AB-23456789012D', DATEADD(DAY, -5, CAST(GETDATE() AS DATE)), '', 'Chưa có kết quả', 'EF123456-789A-1234-B017-9ABCDEF12345', @TypeId1, @ArvId2),
    ('6fa0d9be-bee1-4b47-8821-ddbeb7753c99', DATEADD(DAY, -10, CAST(GETDATE() AS DATE)), 'Negative', 'Kết quả tốt', 'F1234567-89AB-2345-C128-ABCDEF123456', @TypeId2, @ArvId1),
    ('ff778df5-e039-4e9a-ab96-6fa44136eadb', DATEADD(DAY, -2, CAST(GETDATE() AS DATE)), 'Pending', 'Đang chờ kết quả', '12345678-9ABC-3456-D239-BCDEF1234567', @TypeId3, @ArvId2),
    ('52417d54-a421-4c8d-a103-20f04ffd7c6e', DATEADD(DAY, -6, CAST(GETDATE() AS DATE)), 'Positive', 'Cần theo dõi', '23456789-ABCD-4567-E34A-CDEF12345678', @TypeId1, @ArvId1),
    ('0efd78ea-aeb7-480a-99e8-0fa97fc233d9', DATEADD(DAY, -15, CAST(GETDATE() AS DATE)), 'Negative', 'Kết quả tốt', '3456789A-BCDE-5678-F45B-DEF123456789', @TypeId2, @ArvId2),
    ('858a2727-ced9-455e-b0d9-cd7495c3e34b', DATEADD(DAY, -12, CAST(GETDATE() AS DATE)), '', 'Chưa có kết quả', '456789AB-CDEF-6789-056C-EF123456789A', @TypeId3, @ArvId1),
    ('0420f1e1-c4aa-45e4-abcc-41010effc3bc', DATEADD(DAY, -4, CAST(GETDATE() AS DATE)), 'Pending', 'Đang chờ kết quả', '56789ABC-DEF1-789A-167D-F123456789AB', @TypeId1, @ArvId2);

-- ================================================
-- 11. ORDERS DATA (Đơn hàng với giá trị khác nhau)
-- ================================================
PRINT 'Inserting Orders...';

-- Orders tháng này
INSERT INTO [Order] (Id, UserId, DoctorId, MedicalRecordId, TotalPrice, CreateAt) VALUES
    ('BCDEF123-4567-6BC6-7890-987654321CBA', '78901234-5601-789A-BCDE-F12345678901', '12345678-9ABC-DEF1-2345-6789ABCDEF12', 'BCDEF123-4567-8901-8DE4-6789ABCDEF12', 500000, DATEADD(DAY, -5, GETDATE())),                                                                                      
    ('BCDEF123-4567-6BC6-7890-123456789ABC', '78901234-5601-789A-BCDE-F12345678901', '12345678-9ABC-DEF1-2345-6789ABCDEF12', 'BCDEF123-4567-8901-8DE4-6789ABCDEF12', 500000, DATEADD(DAY, -5, GETDATE())),
    ('CDEF1234-5678-7CD7-89AB-23456789ABCD', '89012345-6712-89AB-CDEF-123456789012', '23456789-ABCD-EF12-3456-789ABCDEF123', 'CDEF1234-5678-9012-9EF5-789ABCDEF123', 750000, DATEADD(DAY, -10, GETDATE())),
    ('DEF12345-6789-8DE8-9ABC-3456789ABCDE', '90123456-7823-90BC-DEF1-234567890123', '3456789A-BCDE-F123-4567-89ABCDEF1234', 'DEF12345-6789-0123-AF06-89ABCDEF1234', 1000000, DATEADD(DAY, -15, GETDATE())),
    ('EF123456-789A-9EF9-ABCD-456789ABCDEF', '01234567-8934-01CD-EF12-345678901234', '12345678-9ABC-DEF1-2345-6789ABCDEF12', 'EF123456-789A-1234-B017-9ABCDEF12345', 1250000, DATEADD(DAY, -8, GETDATE())),
    ('F1234567-89AB-AF0A-BCDE-56789ABCDEF1', '12345678-9045-12DE-F123-456789012345', '23456789-ABCD-EF12-3456-789ABCDEF123', 'F1234567-89AB-2345-C128-ABCDEF123456', 1500000, DATEADD(DAY, -12, GETDATE())),
    ('12345678-9ABC-B01B-CDEF-6789ABCDEF12', '23456789-0156-23EF-1234-567890123456', '3456789A-BCDE-F123-4567-89ABCDEF1234', '12345678-9ABC-3456-D239-BCDEF1234567', 800000, DATEADD(DAY, -3, GETDATE())),
    ('23456789-ABCD-C12C-DEF1-789ABCDEF123', '34567890-1267-34F0-2345-678901234567', '12345678-9ABC-DEF1-2345-6789ABCDEF12', '23456789-ABCD-4567-E34A-CDEF12345678', 600000, DATEADD(DAY, -7, GETDATE())),
    ('3456789A-BCDE-D23D-EF12-89ABCDEF1234', '45678901-2378-4501-3456-789012345678', '23456789-ABCD-EF12-3456-789ABCDEF123', '3456789A-BCDE-5678-F45B-DEF123456789', 900000, DATEADD(DAY, -20, GETDATE())),
    ('456789AB-CDEF-E34E-F123-9ABCDEF12345', '56789012-3489-5612-4567-890123456789', '3456789A-BCDE-F123-4567-89ABCDEF1234', '456789AB-CDEF-6789-056C-EF123456789A', 1100000, DATEADD(DAY, -25, GETDATE())),
    ('56789ABC-DEF1-F45F-1234-ABCDEF123456', '67890123-459A-6723-5678-901234567890', '12345678-9ABC-DEF1-2345-6789ABCDEF12', '56789ABC-DEF1-789A-167D-F123456789AB', 700000, DATEADD(DAY, -2, GETDATE())),
    ('6789ABCD-EF12-0560-2345-BCDEF1234567', '78901234-56AB-7834-6789-012345678901', '23456789-ABCD-EF12-3456-789ABCDEF123', '6789ABCD-EF12-89AB-278E-123456789ABC', 850000, DATEADD(DAY, -18, GETDATE())),
    ('789ABCDE-F123-1671-3456-CDEF12345678', '89012345-67BC-8945-7890-123456789012', '3456789A-BCDE-F123-4567-89ABCDEF1234', '789ABCDE-F123-9ABC-389F-23456789ABCD', 950000, DATEADD(DAY, -14, GETDATE())),
    ('89ABCDEF-1234-2782-4567-DEF123456789', '90123456-78CD-9056-8901-234567890123', '12345678-9ABC-DEF1-2345-6789ABCDEF12', '89ABCDEF-1234-ABCD-49A0-3456789ABCDE', 650000, DATEADD(DAY, -6, GETDATE())),
    ('9ABCDEF1-2345-3893-5678-EF123456789A', '01234567-89DE-0167-9012-345678901234', '23456789-ABCD-EF12-3456-789ABCDEF123', '9ABCDEF1-2345-BCDE-5AB1-456789ABCDEF', 1300000, DATEADD(DAY, -22, GETDATE())),
    ('ABCDEF12-3456-49A4-6789-F123456789AB', '12345678-90EF-1278-0123-456789012345', '3456789A-BCDE-F123-4567-89ABCDEF1234', 'ABCDEF12-3456-CDEF-6BC2-56789ABCDEF1', 750000, DATEADD(DAY, -9, GETDATE()));

-- Orders hôm nay
INSERT INTO [Order] (Id, UserId, DoctorId, MedicalRecordId, TotalPrice, CreateAt) VALUES
    ('BCDEF123-4567-5AB5-789A-123456789ABC', '23456789-01F0-2389-1234-567890123456', '12345678-9ABC-DEF1-2345-6789ABCDEF12', 'BCDEF123-4567-DEF1-7CD3-6789ABCDEF12', 800000, GETDATE()),
    ('CDEF1234-5678-6BC6-89AB-23456789ABCD', '34567890-1201-349A-2345-678901234567', '23456789-ABCD-EF12-3456-789ABCDEF123', 'CDEF1234-5678-EF12-8DE4-789ABCDEF123', 800000, GETDATE()),
    ('DEF12345-6789-7CD7-9ABC-3456789ABCDE', '45678901-2312-45AB-3456-789012345678', '3456789A-BCDE-F123-4567-89ABCDEF1234', 'DEF12345-6789-F123-9EF5-89ABCDEF1234', 800000, GETDATE()),
    ('EF123456-789A-8DE8-ABCD-456789ABCDEF', '56789012-3423-56BC-4567-890123456789', '12345678-9ABC-DEF1-2345-6789ABCDEF12', 'EF123456-789A-1234-AF06-9ABCDEF12345', 800000, GETDATE()),
    ('F1234567-89AB-9EF9-BCDE-56789ABCDEF1', '67890123-4534-67CD-5678-901234567890', '23456789-ABCD-EF12-3456-789ABCDEF123', 'F1234567-89AB-2345-B017-ABCDEF123456', 800000, GETDATE());

-- ================================================
-- 12. NOTIFICATIONS DATA
-- ================================================
PRINT 'Inserting Notifications...';

INSERT INTO [Notification] (Id, Title, Message, Payload, CreatedAt, ExpiresAt, TypeId) VALUES
    ('12345678-9ABC-BCDE-5678-90123456ABCD', 'Thông báo hệ thống', 'Hệ thống đã được cập nhật', 'System update payload', CAST(GETDATE() AS DATE), DATEADD(DAY, 30, GETDATE()), 0),
    ('23456789-ABCD-CDEF-6789-01234567BCDE', 'Lịch hẹn mới', 'Có lịch hẹn mới cần xác nhận', 'Appointment payload', CAST(GETDATE() AS DATE), DATEADD(DAY, 7, GETDATE()), 1),
    ('3456789A-BCDE-DEF1-789A-123456789CDF', 'Kết quả xét nghiệm', 'Có kết quả xét nghiệm mới', 'Test result payload', CAST(GETDATE() AS DATE), DATEADD(DAY, 15, GETDATE()), 2);

-- ================================================
-- 13. USER NOTIFICATIONS DATA
-- ================================================
PRINT 'Inserting User Notifications...';

INSERT INTO [UserNotification] (UserId, NotificationId, IsRead, ReadAt) VALUES
    (@AdminUserId, '12345678-9ABC-BCDE-5678-90123456ABCD', 1, CAST(GETDATE() AS DATE)),
    ( @AdminUserId, '23456789-ABCD-CDEF-6789-01234567BCDE', 0, NULL),
    ( @AdminUserId, '3456789A-BCDE-DEF1-789A-123456789CDF', 0, NULL),
    (@Doctor1Id, '12345678-9ABC-BCDE-5678-90123456ABCD', 1, CAST(GETDATE() AS DATE)),
    ( @Doctor1Id, '23456789-ABCD-CDEF-6789-01234567BCDE', 0, NULL),
    ( @Doctor2Id, '12345678-9ABC-BCDE-5678-90123456ABCD', 1, CAST(GETDATE() AS DATE)),
    (@Doctor2Id, '3456789A-BCDE-DEF1-789A-123456789CDF', 0, NULL),
    (@Doctor3Id, '23456789-ABCD-CDEF-6789-01234567BCDE', 1, CAST(GETDATE() AS DATE)),
    (@Staff1Id, '12345678-9ABC-BCDE-5678-90123456ABCD', 0, NULL),
    (@Staff2Id, '3456789A-BCDE-DEF1-789A-123456789CDF', 1, CAST(GETDATE() AS DATE));
