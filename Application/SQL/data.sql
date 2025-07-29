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
-- 14. MEDICINES DATA (50 loại thuốc)
-- ================================================
PRINT 'Inserting Medicines...';

INSERT INTO [Medicine] (Id, Name, Description, Price, Stock) VALUES
    ('11111111-1111-1111-1111-111111111111', 'Efavirenz 600mg', 'Thuốc ARV nhóm NNRTI', 25000, 100),
    ('22222222-2222-2222-2222-222222222222', 'Tenofovir 300mg', 'Thuốc ARV nhóm NRTI', 30000, 100),
    ('33333333-3333-3333-3333-333333333333', 'Emtricitabine 200mg', 'Thuốc ARV nhóm NRTI', 28000, 100),
    ('44444444-4444-4444-4444-444444444444', 'Dolutegravir 50mg', 'Thuốc ARV nhóm INSTI', 45000, 100),
    ('55555555-5555-5555-5555-555555555555', 'Rilpivirine 25mg', 'Thuốc ARV nhóm NNRTI', 35000, 100),
    ('66666666-6666-6666-6666-666666666666', 'Abacavir 600mg', 'Thuốc ARV nhóm NRTI', 40000, 100),
    ('77777777-7777-7777-7777-777777777777', 'Lamivudine 150mg', 'Thuốc ARV nhóm NRTI', 20000, 100),
    ('88888888-8888-8888-8888-888888888888', 'Zidovudine 300mg', 'Thuốc ARV nhóm NRTI', 22000, 100),
    ('99999999-9999-9999-9999-999999999999', 'Atazanavir 300mg', 'Thuốc ARV nhóm PI', 50000, 100),
    ('AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA', 'Ritonavir 100mg', 'Thuốc ARV nhóm PI', 25000, 100),
    ('BBBBBBBB-BBBB-BBBB-BBBB-BBBBBBBBBBBB', 'Darunavir 800mg', 'Thuốc ARV nhóm PI', 55000, 100),
    ('CCCCCCCC-CCCC-CCCC-CCCC-CCCCCCCCCCCC', 'Raltegravir 400mg', 'Thuốc ARV nhóm INSTI', 48000, 100),
    ('DDDDDDDD-DDDD-DDDD-DDDD-DDDDDDDDDDDD', 'Maraviroc 150mg', 'Thuốc ARV nhóm CCR5', 60000, 100),
    ('EEEEEEEE-EEEE-EEEE-EEEE-EEEEEEEEEEEE', 'Enfuvirtide 90mg', 'Thuốc ARV nhóm FI', 120000, 100),
    ('FFFFFFFF-FFFF-FFFF-FFFF-FFFFFFFFFFFF', 'Bictegravir 50mg', 'Thuốc ARV nhóm INSTI', 65000, 100),
    ('10101010-1010-1010-1010-101010101010', 'Elvitegravir 150mg', 'Thuốc ARV nhôm INSTI', 58000, 100),
    ('20202020-2020-2020-2020-202020202020', 'Cobicistat 150mg', 'Thuốc tăng cường', 35000, 100),
    ('30303030-3030-3030-3030-303030303030', 'Didanosine 400mg', 'Thuốc ARV nhóm NRTI', 32000, 100),
    ('40404040-4040-4040-4040-404040404040', 'Stavudine 40mg', 'Thuốc ARV nhóm NRTI', 18000, 100),
    ('50505050-5050-5050-5050-505050505050', 'Nevirapine 200mg', 'Thuốc ARV nhóm NNRTI', 24000, 100),
    ('60606060-6060-6060-6060-606060606060', 'Lopinavir 200mg', 'Thuốc ARV nhóm PI', 42000, 100),
    ('70707070-7070-7070-7070-707070707070', 'Saquinavir 500mg', 'Thuốc ARV nhóm PI', 46000, 100),
    ('80808080-8080-8080-8080-808080808080', 'Indinavir 400mg', 'Thuốc ARV nhóm PI', 38000, 100),
    ('90909090-9090-9090-9090-909090909090', 'Nelfinavir 250mg', 'Thuốc ARV nhóm PI', 36000, 100),
    ('A1A1A1A1-A1A1-A1A1-A1A1-A1A1A1A1A1A1', 'Fosamprenavir 700mg', 'Thuốc ARV nhóm PI', 52000, 100),
    ('B2B2B2B2-B2B2-B2B2-B2B2-B2B2B2B2B2B2', 'Tipranavir 250mg', 'Thuốc ARV nhóm PI', 58000, 100),
    ('C3C3C3C3-C3C3-C3C3-C3C3-C3C3C3C3C3C3', 'Delavirdine 200mg', 'Thuốc ARV nhóm NNRTI', 30000, 100),
    ('D4D4D4D4-D4D4-D4D4-D4D4-D4D4D4D4D4D4', 'Etravirine 100mg', 'Thuốc ARV nhóm NNRTI', 34000, 100),
    ('E5E5E5E5-E5E5-E5E5-E5E5-E5E5E5E5E5E5', 'Zalcitabine 0.75mg', 'Thuốc ARV nhóm NRTI', 28000, 100),
    ('F6F6F6F6-F6F6-F6F6-F6F6-F6F6F6F6F6F6', 'Emtricitabine/Tenofovir', 'Thuốc ARV phối hợp', 55000, 100),
    ('12121212-1212-1212-1212-121212121212', 'Efavirenz/Emtricitabine/Tenofovir', 'Thuốc ARV phối hợp 3 trong 1', 85000, 100),
    ('23232323-2323-2323-2323-232323232323', 'Abacavir/Lamivudine', 'Thuốc ARV phối hợp', 58000, 100),
    ('34343434-3434-3434-3434-343434343434', 'Zidovudine/Lamivudine', 'Thuốc ARV phối hợp', 42000, 100),
    ('45454545-4545-4545-4545-454545454545', 'Lopinavir/Ritonavir', 'Thuốc ARV phối hợp', 65000, 100),
    ('56565656-5656-5656-5656-565656565656', 'Elvitegravir/Cobicistat/Emtricitabine/Tenofovir', 'Thuốc ARV phối hợp 4 trong 1', 125000, 100),
    ('67676767-6767-6767-6767-676767676767', 'Bictegravir/Emtricitabine/Tenofovir', 'Thuốc ARV phối hợp 3 trong 1', 115000, 100),
    ('78787878-7878-7878-7878-787878787878', 'Dolutegravir/Abacavir/Lamivudine', 'Thuốc ARV phối hợp 3 trong 1', 105000, 100),
    ('89898989-8989-8989-8989-898989898989', 'Rilpivirine/Emtricitabine/Tenofovir', 'Thuốc ARV phối hợp 3 trong 1', 95000, 100),
    ('9A9A9A9A-9A9A-9A9A-9A9A-9A9A9A9A9A9A', 'Darunavir/Cobicistat', 'Thuốc ARV phối hợp', 78000, 100),
    ('ABABABAB-ABAB-ABAB-ABAB-ABABABABABAB', 'Atazanavir/Cobicistat', 'Thuốc ARV phối hợp', 72000, 100),
    ('BCBCBCBC-BCBC-BCBC-BCBC-BCBCBCBCBCBC', 'Paracetamol 500mg', 'Thuốc giảm đau, hạ sốt', 2000, 100),
    ('CDCDCDCD-CDCD-CDCD-CDCD-CDCDCDCDCDCD', 'Ibuprofen 400mg', 'Thuốc chống viêm', 3500, 100),
    ('DEDEDEDE-DEDE-DEDE-DEDE-DEDEDEDEDEDE', 'Fluconazole 150mg', 'Thuốc chống nấm', 15000, 100),
    ('EFEFEFEF-EFEF-EFEF-EFEF-EFEFEFEFEFEF', 'Metronidazole 500mg', 'Thuốc kháng sinh', 8000, 100),
    ('F0F0F0F0-F0F0-F0F0-F0F0-F0F0F0F0F0F0', 'Ciprofloxacin 500mg', 'Thuốc kháng sinh', 12000, 100),
    ('01010101-0101-0101-0101-010101010101', 'Azithromycin 250mg', 'Thuốc kháng sinh', 18000, 100),
    ('02020202-0202-0202-0202-020202020202', 'Trimethoprim/Sulfamethoxazole', 'Thuốc kháng sinh phối hợp', 9500, 100),
    ('03030303-0303-0303-0303-030303030303', 'Vitamin B Complex', 'Vitamin tổng hợp nhóm B', 5000, 100),
    ('04040404-0404-0404-0404-040404040404', 'Vitamin C 1000mg', 'Vitamin tăng cường miễn dịch', 4000, 100),
    ('05050505-0505-0505-0505-050505050505', 'Omega-3 Fish Oil', 'Bổ sung axit béo omega-3', 25000, 100),
    ('06060606-0606-0606-0606-060606060606', 'Calcium + Vitamin D3', 'Bổ sung canxi và vitamin D', 15000, 100);

-- ================================================
-- 15. PRESCRIPTIONS DATA (Đơn thuốc cho 20 bệnh nhân)
-- ================================================
PRINT 'Inserting Prescriptions...';

INSERT INTO [Prescription] (Id, PrescriptionDate, Notes, MedicalRecordId) VALUES
    ('0A1B2C3D-4E5F-6789-ABCD-1234567890AB', DATEADD(DAY, -5, CAST(GETDATE() AS DATE)), 'Uống theo chỉ định, không được bỏ liều', 'BCDEF123-4567-8901-8DE4-6789ABCDEF12'),
    ('1B2C3D4E-5F60-789A-BCDE-2345678901BC', DATEADD(DAY, -10, CAST(GETDATE() AS DATE)), 'Uống đúng giờ, theo dõi tác dụng phụ', 'CDEF1234-5678-9012-9EF5-789ABCDEF123'),
    ('2C3D4E5F-6071-89AB-CDEF-3456789012CD', DATEADD(DAY, -15, CAST(GETDATE() AS DATE)), 'Uống sau ăn 30 phút, đủ nước',  'DEF12345-6789-0123-AF06-89ABCDEF1234'),
    ('3D4E5F60-7182-9ABC-DEFA-4567890123DE', DATEADD(DAY, -8, CAST(GETDATE() AS DATE)), 'Uống hàng ngày cùng giờ', 'EF123456-789A-1234-B017-9ABCDEF12345'),
    ('4E5F6071-8293-ABCD-EFAB-5678901234EF', DATEADD(DAY, -12, CAST(GETDATE() AS DATE)), 'Không uống cùng với thuốc khác', 'F1234567-89AB-2345-C128-ABCDEF123456'),
    ('5F607182-9304-BCDE-FABC-6789012345F0', DATEADD(DAY, -3, CAST(GETDATE() AS DATE)), 'Uống theo chỉ định bác sĩ',  '12345678-9ABC-3456-D239-BCDEF1234567'),
    ('60718293-0415-CDEF-ABCD-7890123456A1', DATEADD(DAY, -7, CAST(GETDATE() AS DATE)), 'Tăng liều dần theo hướng dẫn',  '23456789-ABCD-4567-E34A-CDEF12345678'),
    ('71829304-1526-DEFA-BCDE-8901234567B2', DATEADD(DAY, -20, CAST(GETDATE() AS DATE)), 'Uống trước ăn 1 tiếng',  '3456789A-BCDE-5678-F45B-DEF123456789'),
    ('82930415-2637-EFAB-CDEF-9012345678C3', DATEADD(DAY, -25, CAST(GETDATE() AS DATE)), 'Kiểm tra gan thận định kỳ',  '456789AB-CDEF-6789-056C-EF123456789A'),
    ('93041526-3748-FABC-DEFA-0123456789D4', DATEADD(DAY, -2, CAST(GETDATE() AS DATE)), 'Uống với thức ăn để giảm kích ứng dạ dày', '56789ABC-DEF1-789A-167D-F123456789AB'),
    ('04152637-4859-ABCD-EFAB-1234567890E5', DATEADD(DAY, -18, CAST(GETDATE() AS DATE)), 'Theo dõi các triệu chứng bất thường', '6789ABCD-EF12-89AB-278E-123456789ABC'),
    ('15263748-5960-BCDE-FABC-2345678901F6', DATEADD(DAY, -14, CAST(GETDATE() AS DATE)), 'Uống đều đặn để duy trì nồng độ thuốc', '789ABCDE-F123-9ABC-389F-23456789ABCD'),
    ('26374859-6071-CDEF-ABCD-345678901207', DATEADD(DAY, -6, CAST(GETDATE() AS DATE)), 'Tránh uống với rượu bia', '89ABCDEF-1234-ABCD-49A0-3456789ABCDE'),
    ('37485960-7182-DEFA-BCDE-456789012318', DATEADD(DAY, -22, CAST(GETDATE() AS DATE)), 'Bảo quản thuốc nơi khô ráo, thoáng mát',  '9ABCDEF1-2345-BCDE-5AB1-456789ABCDEF'),
    ('48596071-8293-EFAB-CDEF-567890123429', DATEADD(DAY, -9, CAST(GETDATE() AS DATE)), 'Uống đúng liều, không tự ý thay đổi',  'ABCDEF12-3456-CDEF-6BC2-56789ABCDEF1'),
    ('59607182-9304-FABC-DEFA-67890123453A', DATEADD(DAY, -16, CAST(GETDATE() AS DATE)), 'Thông báo ngay nếu có phản ứng dị ứng',  'BCDEF123-4567-DEF1-7CD3-6789ABCDEF12'),
    ('60718293-0415-ABCD-EFAB-78901234564B', DATEADD(DAY, -11, CAST(GETDATE() AS DATE)), 'Uống cùng giờ mỗi ngày',  'CDEF1234-5678-EF12-8DE4-789ABCDEF123'),
    ('71829304-1526-BCDE-FABC-89012345675C', DATEADD(DAY, -4, CAST(GETDATE() AS DATE)), 'Tránh tiếp xúc với ánh nắng mặt trời', 'DEF12345-6789-F123-9EF5-89ABCDEF1234'),
    ('82930415-2637-CDEF-ABCD-90123456786D', DATEADD(DAY, -19, CAST(GETDATE() AS DATE)), 'Kiểm tra sức khỏe định kỳ',  'EF123456-789A-1234-AF06-9ABCDEF12345'),
    ('93041526-3748-DEFA-BCDE-01234567897E', DATEADD(DAY, -13, CAST(GETDATE() AS DATE)), 'Uống nhiều nước trong ngày', 'F1234567-89AB-2345-B017-ABCDEF123456');


-- ================================================
-- 16. PRESCRIPTION MEDICINES DATA (Chi tiết thuốc trong đơn)
-- ================================================
PRINT 'Inserting Prescription Medicines...';

-- Đơn thuốc 1
INSERT INTO [PrescriptionMedicine] (PrescriptionId, MedicineId, Quantity, Dosage, BoughtPrice, SumOfMedicationTime, Instructions) VALUES
    ('0A1B2C3D-4E5F-6789-ABCD-1234567890AB', '11111111-1111-1111-1111-111111111111', 30, 1, 25000, 8, 'Uống vào buổi tối trước khi đi ngủ'),
    ('0A1B2C3D-4E5F-6789-ABCD-1234567890AB', '22222222-2222-2222-2222-222222222222', 30, 1, 30000, 8, 'Uống cùng lúc với Efavirenz'),
    ('0A1B2C3D-4E5F-6789-ABCD-1234567890AB', '33333333-3333-3333-3333-333333333333', 30, 1, 28000, 8, 'Uống cùng lúc với các thuốc khác');

-- Đơn thuốc 2
INSERT INTO [PrescriptionMedicine] (PrescriptionId, MedicineId, Quantity, Dosage, BoughtPrice, SumOfMedicationTime, Instructions) VALUES
    ('1B2C3D4E-5F60-789A-BCDE-2345678901BC', '44444444-4444-4444-4444-444444444444', 30, 1, 45000, 1, 'Uống vào buổi sáng sau ăn'),
    ('1B2C3D4E-5F60-789A-BCDE-2345678901BC', '66666666-6666-6666-6666-666666666666', 60, 1, 40000, 9, 'Sáng và tối sau ăn'),
    ('1B2C3D4E-5F60-789A-BCDE-2345678901BC', '77777777-7777-7777-7777-777777777777', 60, 1, 20000, 9, 'Uống cùng Abacavir');

-- Đơn thuốc 3
INSERT INTO [PrescriptionMedicine] (PrescriptionId, MedicineId, Quantity, Dosage, BoughtPrice, SumOfMedicationTime, Instructions) VALUES
    ('2C3D4E5F-6071-89AB-CDEF-3456789012CD', 'F6F6F6F6-F6F6-F6F6-F6F6-F6F6F6F6F6F6', 30, 1, 55000, 1, 'Thuốc phối hợp, uống buổi sáng'),
    ('2C3D4E5F-6071-89AB-CDEF-3456789012CD', '55555555-5555-5555-5555-555555555555', 30, 1, 35000, 8, 'Uống vào buổi tối');

-- Đơn thuốc 4
INSERT INTO [PrescriptionMedicine] (PrescriptionId, MedicineId, Quantity, Dosage, BoughtPrice, SumOfMedicationTime, Instructions) VALUES
    ('3D4E5F60-7182-9ABC-DEFA-4567890123DE', '12121212-1212-1212-1212-121212121212', 30, 1, 85000, 1, 'Thuốc 3 trong 1, uống buổi sáng'),
    ('3D4E5F60-7182-9ABC-DEFA-4567890123DE', 'BCBCBCBC-BCBC-BCBC-BCBC-BCBCBCBCBCBC', 10, 1, 2000, 15, 'Uống khi sốt hoặc đau đầu');

-- Đơn thuốc 5
INSERT INTO [PrescriptionMedicine] (PrescriptionId, MedicineId, Quantity, Dosage, BoughtPrice, SumOfMedicationTime, Instructions) VALUES
    ('4E5F6071-8293-ABCD-EFAB-5678901234EF', '99999999-9999-9999-9999-999999999999', 30, 1, 50000, 1, 'Uống với thức ăn buổi sáng'),
    ('4E5F6071-8293-ABCD-EFAB-5678901234EF', 'AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA', 30, 1, 25000, 1, 'Thuốc tăng cường cho Atazanavir'),
    ('4E5F6071-8293-ABCD-EFAB-5678901234EF', 'DEDEDEDE-DEDE-DEDE-DEDE-DEDEDEDEDEDE', 7, 1, 15000, 8, 'Điều trị nhiễm nấm buổi tối');

-- Đơn thuốc 6
INSERT INTO [PrescriptionMedicine] (PrescriptionId, MedicineId, Quantity, Dosage, BoughtPrice, SumOfMedicationTime, Instructions) VALUES
    ('5F607182-9304-BCDE-FABC-6789012345F0', '67676767-6767-6767-6767-676767676767', 30, 1, 115000, 1, 'Thuốc mới thế hệ mới, uống buổi sáng'),
    ('5F607182-9304-BCDE-FABC-6789012345F0', '03030303-0303-0303-0303-030303030303', 30, 1, 5000, 2, 'Bổ sung vitamin B buổi trưa');

-- Đơn thuốc 7
INSERT INTO [PrescriptionMedicine] (PrescriptionId, MedicineId, Quantity, Dosage, BoughtPrice, SumOfMedicationTime, Instructions) VALUES
    ('60718293-0415-CDEF-ABCD-7890123456A1', '78787878-7878-7878-7878-787878787878', 30, 1, 105000, 1, 'Thuốc phối hợp hiệu quả cao, buổi sáng'),
    ('60718293-0415-CDEF-ABCD-7890123456A1', 'F0F0F0F0-F0F0-F0F0-F0F0-F0F0F0F0F0F0', 14, 1, 12000, 10, 'Kháng sinh sáng và tối');

-- Đơn thuốc 8
INSERT INTO [PrescriptionMedicine] (PrescriptionId, MedicineId, Quantity, Dosage, BoughtPrice, SumOfMedicationTime, Instructions) VALUES
    ('71829304-1526-DEFA-BCDE-8901234567B2', '45454545-4545-4545-4545-454545454545', 60, 2, 65000, 9, 'Sáng và tối, uống sau ăn'),
    ('71829304-1526-DEFA-BCDE-8901234567B2', '88888888-8888-8888-8888-888888888888', 60, 1, 22000, 9, 'Phối hợp với Lopinavir/Ritonavir');

-- Đơn thuốc 9
INSERT INTO [PrescriptionMedicine] (PrescriptionId, MedicineId, Quantity, Dosage, BoughtPrice, SumOfMedicationTime, Instructions) VALUES
    ('82930415-2637-EFAB-CDEF-9012345678C3', '56565656-5656-5656-5656-565656565656', 30, 1, 125000, 1, 'Thuốc 4 trong 1 tiện lợi, buổi sáng'),
    ('82930415-2637-EFAB-CDEF-9012345678C3', '02020202-0202-0202-0202-020202020202', 14, 2, 9500, 10, 'Phòng ngừa nhiễm khuẩn cơ hội');

-- Đơn thuốc 10
INSERT INTO [PrescriptionMedicine] (PrescriptionId, MedicineId, Quantity, Dosage, BoughtPrice, SumOfMedicationTime, Instructions) VALUES
    ('93041526-3748-FABC-DEFA-0123456789D4', '89898989-8989-8989-8989-898989898989', 30, 1, 95000, 8, 'Uống vào buổi tối'),
    ('93041526-3748-FABC-DEFA-0123456789D4', 'CDCDCDCD-CDCD-CDCD-CDCD-CDCDCDCDCDCD', 6, 1, 3500, 7, 'Giảm đau chống viêm sáng trưa tối'),
    ('93041526-3748-FABC-DEFA-0123456789D4', '04040404-0404-0404-0404-040404040404', 30, 1, 4000, 1, 'Tăng cường miễn dịch buổi sáng');

-- Đơn thuốc 11
INSERT INTO [PrescriptionMedicine] (PrescriptionId, MedicineId, Quantity, Dosage, BoughtPrice, SumOfMedicationTime, Instructions) VALUES
    ('04152637-4859-ABCD-EFAB-1234567890E5', 'BBBBBBBB-BBBB-BBBB-BBBB-BBBBBBBBBBBB', 30, 1, 55000, 1, 'Uống với thức ăn buổi sáng'),
    ('04152637-4859-ABCD-EFAB-1234567890E5', '20202020-2020-2020-2020-202020202020', 30, 1, 35000, 1, 'Tăng cường cho Darunavir'),
    ('04152637-4859-ABCD-EFAB-1234567890E5', '77777777-7777-7777-7777-777777777777', 60, 1, 20000, 9, 'Backbone therapy sáng tối');

-- Đơn thuốc 12
INSERT INTO [PrescriptionMedicine] (PrescriptionId, MedicineId, Quantity, Dosage, BoughtPrice, SumOfMedicationTime, Instructions) VALUES
    ('15263748-5960-BCDE-FABC-2345678901F6', 'CCCCCCCC-CCCC-CCCC-CCCC-CCCCCCCCCCCC', 60, 1, 48000, 9, 'Sáng và tối'),
    ('15263748-5960-BCDE-FABC-2345678901F6', '34343434-3434-3434-3434-343434343434', 60, 1, 42000, 9, 'Phối hợp với Raltegravir');

-- Đơn thuốc 13
INSERT INTO [PrescriptionMedicine] (PrescriptionId, MedicineId, Quantity, Dosage, BoughtPrice, SumOfMedicationTime, Instructions) VALUES
    ('26374859-6071-CDEF-ABCD-345678901207', '9A9A9A9A-9A9A-9A9A-9A9A-9A9A9A9A9A9A', 30, 1, 78000, 1, 'Thuốc phối hợp mới buổi sáng'),
    ('26374859-6071-CDEF-ABCD-345678901207', '01010101-0101-0101-0101-010101010101', 3, 1, 18000, 1, 'Điều trị nhiễm khuẩn buổi sáng');

-- Đơn thuốc 14
INSERT INTO [PrescriptionMedicine] (PrescriptionId, MedicineId, Quantity, Dosage, BoughtPrice, SumOfMedicationTime, Instructions) VALUES
    ('37485960-7182-DEFA-BCDE-456789012318', 'DDDDDDDD-DDDD-DDDD-DDDD-DDDDDDDDDDDD', 60, 1, 60000, 9, 'Thuốc đặc biệt, theo dõi sát'),
    ('37485960-7182-DEFA-BCDE-456789012318', '05050505-0505-0505-0505-050505050505', 30, 1, 25000, 1, 'Bổ sung dinh dưỡng buổi sáng');

-- Đơn thuốc 15
INSERT INTO [PrescriptionMedicine] (PrescriptionId, MedicineId, Quantity, Dosage, BoughtPrice, SumOfMedicationTime, Instructions) VALUES
    ('48596071-8293-EFAB-CDEF-567890123429', 'ABABABAB-ABAB-ABAB-ABAB-ABABABABABAB', 30, 1, 72000, 1, 'Thuốc phối hợp tiện lợi buổi sáng'),
    ('48596071-8293-EFAB-CDEF-567890123429', '88888888-8888-8888-8888-888888888888', 60, 1, 22000, 9, 'Backbone therapy sáng tối');

-- Đơn thuốc 16
INSERT INTO [PrescriptionMedicine] (PrescriptionId, MedicineId, Quantity, Dosage, BoughtPrice, SumOfMedicationTime, Instructions) VALUES
    ('59607182-9304-FABC-DEFA-67890123453A', '50505050-5050-5050-5050-505050505050', 60, 1, 24000, 9, 'Thuốc cũ nhưng hiệu quả'),
    ('59607182-9304-FABC-DEFA-67890123453A', '22222222-2222-2222-2222-222222222222', 30, 1, 30000, 1, 'Backbone therapy buổi sáng'),
    ('59607182-9304-FABC-DEFA-67890123453A', '44444444-4444-4444-4444-444444444444', 30, 1, 45000, 1, 'INSTI cho hiệu quả cao');

-- Đơn thuốc 17
INSERT INTO [PrescriptionMedicine] (PrescriptionId, MedicineId, Quantity, Dosage, BoughtPrice, SumOfMedicationTime, Instructions) VALUES
    ('60718293-0415-ABCD-EFAB-78901234564B', '60606060-6060-6060-6060-606060606060', 60, 2, 42000, 9, 'PI cũ nhưng hiệu quả'),
    ('60718293-0415-ABCD-EFAB-78901234564B', 'AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA', 60, 1, 25000, 9, 'Ritonavir boost'),
    ('60718293-0415-ABCD-EFAB-78901234564B', '33333333-3333-3333-3333-333333333333', 60, 1, 28000, 9, 'NRTI backbone');

-- Đơn thuốc 18
INSERT INTO [PrescriptionMedicine] (PrescriptionId, MedicineId, Quantity, Dosage, BoughtPrice, SumOfMedicationTime, Instructions) VALUES
    ('71829304-1526-BCDE-FABC-89012345675C', '23232323-2323-2323-2323-232323232323', 60, 1, 58000, 9, 'Thuốc phối hợp ABC/3TC'),
    ('71829304-1526-BCDE-FABC-89012345675C', '11111111-1111-1111-1111-111111111111', 30, 1, 25000, 8, 'NNRTI Efavirenz buổi tối'),
    ('71829304-1526-BCDE-FABC-89012345675C', 'CDCDCDCD-CDCD-CDCD-CDCD-CDCDCDCDCDCD', 12, 2, 3500, 7, 'Chống viêm giảm đau');

-- Đơn thuốc 19
INSERT INTO [PrescriptionMedicine] (PrescriptionId, MedicineId, Quantity, Dosage, BoughtPrice, SumOfMedicationTime, Instructions) VALUES
    ('82930415-2637-CDEF-ABCD-90123456786D', 'FFFFFFFF-FFFF-FFFF-FFFF-FFFFFFFFFFFF', 30, 1, 65000, 1, 'INSTI thế hệ mới buổi sáng'),
    ('82930415-2637-CDEF-ABCD-90123456786D', 'F6F6F6F6-F6F6-F6F6-F6F6-F6F6F6F6F6F6', 30, 1, 55000, 8, 'FTC/TDF backbone buổi tối'),
    ('82930415-2637-CDEF-ABCD-90123456786D', 'EFEFEFEF-EFEF-EFEF-EFEF-EFEFEFEFEFEF', 10, 1, 8000, 9, 'Kháng sinh điều trị');

-- Đơn thuốc 20
INSERT INTO [PrescriptionMedicine] (PrescriptionId, MedicineId, Quantity, Dosage, BoughtPrice, SumOfMedicationTime, Instructions) VALUES
    ('93041526-3748-DEFA-BCDE-01234567897E', '70707070-7070-7070-7070-707070707070', 60, 2, 46000, 9, 'PI cũ Saquinavir'),
    ('93041526-3748-DEFA-BCDE-01234567897E', 'AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA', 30, 1, 25000, 1, 'Tăng cường cho Saquinavir'),
    ('93041526-3748-DEFA-BCDE-01234567897E', 'EFEFEFEF-EFEF-EFEF-EFEF-EFEFEFEFEFEF', 14, 1, 8000, 9, 'Điều trị nhiễm khuẩn đường ruột');


-- ================================================
-- 17. Regemen ARV DATA
-- ================================================

PRINT 'Inserting Additional Regimen ARV...';

INSERT INTO ArvRegimen (Id, Name, Description, Level) VALUES
-- Trẻ em
('E2EF28CB-13CD-4186-83C9-71B53B5C56DB', N'ARV trẻ em 1', N'trẻ em', 1),

-- Nhiễm HIV cấp tính
('E2EF28CB-13CD-4186-83C9-71B53B5C1234', N'ARV cấp tính 1', N'cấp tính', 2),

-- Nhiễm HIV mạn tính (mô tả là "thứ tính" trong code)
('E2EF28CB-13CD-4186-83C9-71B53B5C4321', N'ARV thứ tính 1', N'thứ tính', 3),

-- AIDS
('E2EF28CB-13CD-4186-83C9-71B53B5C5412', N'ARV AIDS 1', N'AIDS', 4),

-- Phụ nữ mang thai
('E2EF28CB-13CD-4186-83C9-71B53B5C1237', N'ARV thai kỳ 1', N'mang thai', 2),

-- Viêm gan B
('E2EF28CB-13CD-4186-83C9-71B53B5C57321', N'ARV viêm gan B 1', N'viêm gan B', 2),

-- Bệnh lao
('E2EF28CB-13CD-4186-83C9-71B53B5C8898', N'ARV lao 1', N'Lao', 3);

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