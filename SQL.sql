Use Master
GO
    IF exists(Select name From sys.databases Where name='WebSimbMobifone')
    DROP Database WebSimbMobifone;
GO
    Create Database WebSimbMobifone;
GO

USE WebSimbMobifone;

CREATE TABLE CUAHANG(
	MaCH int primary key identity(1,1),
	Ten nvarchar(100) not null,
	DienThoai varchar(20),
	DiaChi nvarchar(100)
) 
GO

CREATE TABLE DANHMUC( -- loai TB: sim phong thuỷ , sim số đẹp
	MaDM int primary key identity(1,1),
	TenDM nvarchar(100) not null
) 
GO
CREATE TABLE LOAITB( -- Sim thường, sim lặp đầu,cuối,...
	MaLTB int primary key identity(1,1),
	TenL nvarchar(100) not null
) 
GO
CREATE TABLE THUEBAO(
	MaTB int primary key identity(1,1),
	SoThueBao varchar(10) not null,
	PhiHoaMang int default 0,
	MaDM int not null foreign key(MaDM) references DANHMUC(MaDM),
	MaLTB int not null foreign key(MaLTB) references LOAITB(MaLTB),
	LoaiSo nvarchar(50),
	DiaDiemHM nvarchar(100),
	TrangThai int -- 0:trống, 1:được mua, 2: đã kích hoạt
) 
GO

CREATE TABLE CHUCVU(
	MaCV int primary key identity(1,1),
	Ten nvarchar(100) not null,
	HeSo float default 1.0
) 
GO

CREATE TABLE NHANVIEN(
	MaNV int primary key identity(1,1),
	Ten nvarchar(100) not null,
	MaCV int not null foreign key(MaCV) references CHUCVU(MaCV),
	DienThoai varchar(20),
	Email varchar(50),
	MatKhau varchar(255)	
) 
GO

CREATE TABLE KHACHHANG(
	MaKH int primary key identity(1,1),
	Ten nvarchar(100) not null,
	DienThoai varchar(10),
	Email varchar(100),
	MatKhau varchar(255),
	CCCD varchar(12),
	HinhT varchar(255),
	HinhS varchar(255),
	SLThueB int default 0  -- tăng theo SL Thuê Bao
) 
GO

CREATE TABLE DIACHI(	
	MaDC int primary key identity(1,1),
	MaKH int not null foreign key(MaKH) references KHACHHANG(MaKH),
	DiaChi nvarchar(100) not null,
	PhuongXa varchar(20),
	QuanHuyen varchar(50) ,
	TinhThanh varchar(50),
	MacDinh int default 1	
) 
GO

CREATE TABLE HOADON(
	MaHD int primary key identity(1,1),
	MaTB int not null foreign key(MaTB) references THUEBAO(MaTB),
	Ngay datetime default getdate(),
	TongTien int default 0,
	MaKH int not null foreign key(MaKH) references KHACHHANG(MaKH),
	TrangThai int default 0 -- duyệt -> gửi sp 
) 
GO

CREATE TABLE TINTUC(
	MaTin int primary key identity(1,1),
	TieuDe nvarchar(max),
	TomTat nvarchar(max),
	NoiDung nvarchar(max),
	HinhAnh varchar(255),
	NgayDang  datetime default getdate(),
) 
GO
CREATE TABLE HUONGDAN(
	MaHDan int primary key identity(1,1),
	CauHoi nvarchar(255),
	TraLoi nvarchar(Max),
	NgayDang  datetime default getdate(),
) 
GO



-- dữ liệu danh mục
INSERT INTO DANHMUC(TenDM) VALUES(N'Sim Thường');
INSERT INTO DANHMUC(TenDM) VALUES(N'Sim Phong Thuỷ');
INSERT INTO DANHMUC(TenDM) VALUES(N'Sim Số Đẹp');
GO
-- dữ liệu loại thuê bao
INSERT INTO LOAITB(TenL) VALUES(N'Số Thường');
INSERT INTO LOAITB(TenL) VALUES(N'Số lặp(ABAB)(A>B)');
INSERT INTO LOAITB(TenL) VALUES(N'Số lặp cuối (ABC.DBC)');
INSERT INTO LOAITB(TenL) VALUES(N'Số Năm Sinh 197X');
INSERT INTO LOAITB(TenL) VALUES(N'Số Năm Sinh 198X');
INSERT INTO LOAITB(TenL) VALUES(N'Số Năm Sinh 199X');
INSERT INTO LOAITB(TenL) VALUES(N'Số Năm Sinh 200X');
GO
-- dữ liệu Thuê Bao
INSERT INTO THUEBAO(SoThueBao,PhiHoaMang,MaDM,MaLTB,LoaiSo,DiaDiemHM,TrangThai) VALUES(N'0788234213',60000,1,1,N'Trả Trước',N'Toàn Quốc',0);
INSERT INTO THUEBAO(SoThueBao,PhiHoaMang,MaDM,MaLTB,LoaiSo,DiaDiemHM,TrangThai) VALUES(N'0788234214',60000,1,1,N'Trả Trước',N'Toàn Quốc',0);
INSERT INTO THUEBAO(SoThueBao,PhiHoaMang,MaDM,MaLTB,LoaiSo,DiaDiemHM,TrangThai) VALUES(N'0788234215',60000,1,1,N'Trả Trước',N'Toàn Quốc',0);
INSERT INTO THUEBAO(SoThueBao,PhiHoaMang,MaDM,MaLTB,LoaiSo,DiaDiemHM,TrangThai) VALUES(N'0788234216',60000,1,1,N'Trả Trước',N'Toàn Quốc',0);
INSERT INTO THUEBAO(SoThueBao,PhiHoaMang,MaDM,MaLTB,LoaiSo,DiaDiemHM,TrangThai) VALUES(N'0788234217',60000,1,1,N'Trả Trước',N'Toàn Quốc',0);
INSERT INTO THUEBAO(SoThueBao,PhiHoaMang,MaDM,MaLTB,LoaiSo,DiaDiemHM,TrangThai) VALUES(N'0788234218',60000,1,1,N'Trả Trước',N'Toàn Quốc',0);
INSERT INTO THUEBAO(SoThueBao,PhiHoaMang,MaDM,MaLTB,LoaiSo,DiaDiemHM,TrangThai) VALUES(N'0788234219',60000,1,1,N'Trả Trước',N'Toàn Quốc',0);
INSERT INTO THUEBAO(SoThueBao,PhiHoaMang,MaDM,MaLTB,LoaiSo,DiaDiemHM,TrangThai) VALUES(N'0788234220',60000,2,1,N'Trả Trước',N'Toàn Quốc',0);
INSERT INTO THUEBAO(SoThueBao,PhiHoaMang,MaDM,MaLTB,LoaiSo,DiaDiemHM,TrangThai) VALUES(N'0788234221',60000,2,1,N'Trả Trước',N'Toàn Quốc',0);
INSERT INTO THUEBAO(SoThueBao,PhiHoaMang,MaDM,MaLTB,LoaiSo,DiaDiemHM,TrangThai) VALUES(N'0788234222',60000,2,1,N'Trả Trước',N'Toàn Quốc',0);
INSERT INTO THUEBAO(SoThueBao,PhiHoaMang,MaDM,MaLTB,LoaiSo,DiaDiemHM,TrangThai) VALUES(N'0788234223',60000,2,1,N'Trả Trước',N'Toàn Quốc',0);
INSERT INTO THUEBAO(SoThueBao,PhiHoaMang,MaDM,MaLTB,LoaiSo,DiaDiemHM,TrangThai) VALUES(N'0788234224',60000,3,1,N'Trả Trước',N'Toàn Quốc',0);
INSERT INTO THUEBAO(SoThueBao,PhiHoaMang,MaDM,MaLTB,LoaiSo,DiaDiemHM,TrangThai) VALUES(N'0788234225',60000,3,1,N'Trả Trước',N'Toàn Quốc',0);
INSERT INTO THUEBAO(SoThueBao,PhiHoaMang,MaDM,MaLTB,LoaiSo,DiaDiemHM,TrangThai) VALUES(N'0788234226',60000,3,1,N'Trả Trước',N'Toàn Quốc',0);
INSERT INTO THUEBAO(SoThueBao,PhiHoaMang,MaDM,MaLTB,LoaiSo,DiaDiemHM,TrangThai) VALUES(N'0788234227',60000,3,1,N'Trả Trước',N'Toàn Quốc',0);
INSERT INTO THUEBAO(SoThueBao,PhiHoaMang,MaDM,MaLTB,LoaiSo,DiaDiemHM,TrangThai) VALUES(N'0788234228',60000,1,1,N'Trả Trước',N'Toàn Quốc',0);
INSERT INTO THUEBAO(SoThueBao,PhiHoaMang,MaDM,MaLTB,LoaiSo,DiaDiemHM,TrangThai) VALUES(N'0788234229',60000,1,1,N'Trả Trước',N'Toàn Quốc',0);
INSERT INTO THUEBAO(SoThueBao,PhiHoaMang,MaDM,MaLTB,LoaiSo,DiaDiemHM,TrangThai) VALUES(N'0788234230',60000,1,1,N'Trả Trước',N'Toàn Quốc',0);
INSERT INTO THUEBAO(SoThueBao,PhiHoaMang,MaDM,MaLTB,LoaiSo,DiaDiemHM,TrangThai) VALUES(N'0788234231',60000,1,1,N'Trả Trước',N'Toàn Quốc',0);
INSERT INTO THUEBAO(SoThueBao,PhiHoaMang,MaDM,MaLTB,LoaiSo,DiaDiemHM,TrangThai) VALUES(N'0788234232',60000,1,1,N'Trả Trước',N'Toàn Quốc',0);
INSERT INTO THUEBAO(SoThueBao,PhiHoaMang,MaDM,MaLTB,LoaiSo,DiaDiemHM,TrangThai) VALUES(N'0788234233',60000,1,1,N'Trả Trước',N'Toàn Quốc',0);
INSERT INTO THUEBAO(SoThueBao,PhiHoaMang,MaDM,MaLTB,LoaiSo,DiaDiemHM,TrangThai) VALUES(N'0788234234',60000,1,1,N'Trả Trước',N'Toàn Quốc',0);
INSERT INTO THUEBAO(SoThueBao,PhiHoaMang,MaDM,MaLTB,LoaiSo,DiaDiemHM,TrangThai) VALUES(N'0788234235',60000,2,1,N'Trả Trước',N'Toàn Quốc',0);
INSERT INTO THUEBAO(SoThueBao,PhiHoaMang,MaDM,MaLTB,LoaiSo,DiaDiemHM,TrangThai) VALUES(N'0788234236',60000,2,1,N'Trả Trước',N'Toàn Quốc',0);
INSERT INTO THUEBAO(SoThueBao,PhiHoaMang,MaDM,MaLTB,LoaiSo,DiaDiemHM,TrangThai) VALUES(N'0788234237',60000,2,1,N'Trả Trước',N'Toàn Quốc',0);
INSERT INTO THUEBAO(SoThueBao,PhiHoaMang,MaDM,MaLTB,LoaiSo,DiaDiemHM,TrangThai) VALUES(N'0788234238',60000,2,1,N'Trả Trước',N'Toàn Quốc',0);
INSERT INTO THUEBAO(SoThueBao,PhiHoaMang,MaDM,MaLTB,LoaiSo,DiaDiemHM,TrangThai) VALUES(N'0788234239',60000,3,1,N'Trả Trước',N'Toàn Quốc',0);
INSERT INTO THUEBAO(SoThueBao,PhiHoaMang,MaDM,MaLTB,LoaiSo,DiaDiemHM,TrangThai) VALUES(N'0788234240',60000,3,1,N'Trả Trước',N'Toàn Quốc',0);
INSERT INTO THUEBAO(SoThueBao,PhiHoaMang,MaDM,MaLTB,LoaiSo,DiaDiemHM,TrangThai) VALUES(N'0788234241',60000,3,1,N'Trả Trước',N'Toàn Quốc',0);
GO
-- dữ liệu tin tức
INSERT INTO TINTUC(TieuDe,TomTat,NoiDung,HinhAnh,NgayDang) VALUES(N'Mình cùng đón Giáp Thìn – 2024!',N'Từ ngày 12/12/2023 đến ngày 31/01/2024, MobiFone Tỉnh An Giang triển khai chương trình khuyến mại “Mình cùng đón Giáp Thìn – 2024!”',N'Chào đón Năm Mới Giáp Thìn 2024, MobiFone An Giang triển khai chương trình khuyến mại “Mình Cùng Đón Giáp Thìn 2024! ” từ ngày 12/12/2023 đến 31/01/2024 Khách hàng hòa mạng mới hoặc đăng ký mới/gia hạn bất kỳ gói cước Data nào của MobiFone trong thời gian diễn ra chương trình, như một lời chúc, một lời tri ân sâu sắc dành cho các khách hàng đã luôn tin yêu và đồng hành cùng MobiFone Tỉnh An Giang.

Theo đó, từ ngày từ ngày 12/12/2023 đến 31/01/2024, Khách hàng hòa mạng mới hoặc đăng ký mới/gia hạn bất kỳ gói cước data nào của MobiFone trong thời gian diễn ra chương trình có nhắn tin sms tới số thuê bao 0779249999 kèm số dự đoán gần đúng nhất của 03 số cuối kết quả Giải đặc biệt Xổ số Kiến thiết tỉnh An Giang xổ ngày 01/02/2024.

Ví dụ: Thuê bao phát triển mới ngày 15/12/2023 soạn tin nhắn: 678 gởi đến 0779249999.

Sau khi nhắn tin tham gia chương trình thành công, khách hàng sẽ nhận lại được tin nhắn xác nhận đã đăng ký thành công – chậm nhất ngày n+1
Mỗi khách hàng chỉ được tham dự 01 mã dự thưởng cho 1 số thuê bao (gồm thuê bao trả trước hoặc thuê bao trả sau)
Kết quả trúng thưởng được căn cứ vào dự đoán của khách hàng có số gần đúng với 03 số cuối (trường hợp giống kết quả sẽ xét thời gian sớm hơn) của Giải đặc biết Xổ số Kiến thiết tỉnh An Giang ngày 01/02/2024',N'mobifone1.png',3/19/2024);
go
-- dữ liệu chức vụ
INSERT INTO CHUCVU(Ten) VALUES(N'Admin');
INSERT INTO CHUCVU(Ten) VALUES(N'Nhân Viên');
GO
-- dữ liệu Nhân Viên
INSERT INTO NHANVIEN(Ten,MaCV,DienThoai,Email,MatKhau) VALUES(N'Admin',1,'0789845633',N'Admin@gmail.com','123Admin');
INSERT INTO NHANVIEN(Ten,MaCV,DienThoai,Email,MatKhau) VALUES(N'Trương Văn Tân',2,'0789845632',N'Tan@gmail.com','123Tan');
GO
-- dữ liệu Khách hàng
INSERT INTO KHACHHANG(Ten,DienThoai,Email,MatKhau,CCCD,SLThueB) VALUES(N'NGuyễn Thị Như Huỳnh','0382180991',N'Huynh@gmail.com','9d63dd2cae6e90dfbcf017e962e5a032','085643245600',2);
GO
-- dữ liệu Hoá Đơn
INSERT INTO HOADON(MaTB,Ngay,TongTien,MaKH,TrangThai) VALUES(1,N'3/12/2024',60000,1,0);
GO


-- xuất dữ liệu bảng
SELECT * FROM DANHMUC;
SELECT * FROM LOAITB;
SELECT * FROM THUEBAO;
SELECT * FROM CHUCVU;
SELECT * FROM NHANVIEN;
SELECT * FROM HOADON;
SELECT * FROM TINTUC;
SELECT * FROM DIACHI;
SELECT * FROM KHACHHANG;
SELECT * FROM HUONGDAN;

delete from KHACHHANG
where MaKH=2;