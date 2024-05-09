Use Master
GO
    IF exists(Select name From sys.databases Where name='WebSIMbMobifone')
    DROP Database WebSIMbMobifone;
GO
    Create Database WebSIMbMobifone;
GO

USE WebSIMbMobifone;

CREATE TABLE CUAHANG(
	MaCH int primary key identity(1,1),
	Ten nvarchar(100) not null,
	DienThoai varchar(20),
	DiaChi nvarchar(100),
	Email varchar(50)
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
	TrangThai int default 0, -- 0:trống, 1:được mua, 2: đã kích hoạt
	Daxoa int default 0 -- 0: bth , 1: đã xoá ----
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
	MatKhau varchar(255),	
	Daxoa int default 0 ------------
) 
GO

CREATE TABLE KHACHHANG(
	MaKH int primary key identity(1,1),
	Ten nvarchar(100) not null,
	DienThoai varchar(10),
	Email varchar(100)  ,
	MatKhau varchar(255),
	CCCD varchar(12),
	HinhT varchar(255),
	HinhS varchar(255),
	SLThueB int default 0, -- tăng theo SL Thuê Bao
	Daxoa int default 0 -- 0: bth , 1: khoá , 2: xoá --------------
) 
GO

CREATE TABLE DIACHI(	
	MaDC int primary key identity(1,1),
	MaKH int not null foreign key(MaKH) references KHACHHANG(MaKH),
	DiaChi nvarchar(255),
	PhuongXa nvarchar(255),
	QuanHuyen nvarchar(255) ,
	TinhThanh nvarchar(255),
	MacDinh int default 1,
	Daxoa int default 0 ------------
) 
GO
CREATE TABLE QLTHUEBAO(
	MaQL int primary key identity(1,1),
	MaTB int not null foreign key(MaTB) references THUEBAO(MaTB),
	MaKH int not null foreign key(MaKH) references KHACHHANG(MaKH),
	NgayKichHoat datetime default getdate(),
	TrangThai int default 0, -- 0:trống, 1:được mua, 2: đã kích hoạt -----------
	Daxoa int default 0 ----------------
) 
GO
CREATE TABLE HOADON(
	MaHD int primary key identity(1,1),
	MaTB int not null foreign key(MaTB) references THUEBAO(MaTB),
	Ngay datetime default getdate(),
	TongTien int default 0,
	MaKH int not null foreign key(MaKH) references KHACHHANG(MaKH),
	MaDC int not null foreign key(MaDC) references DIACHI(MaDC),
	TrangThai int default 0, -- duyệt -> gửi sp 
	Daxoa int default 0 ---------------------------------
) 
GO

CREATE TABLE TINTUC(
	MaTin int primary key identity(1,1),
	TieuDe nvarchar(max),
	TomTat nvarchar(max),
	NoiDung nvarchar(max),
	HinhAnh varchar(255),
	NgayDang  datetime default getdate(),
	Hot int  default 0

) 
GO
CREATE TABLE HUONGDAN(
	MaHDan int primary key identity(1,1),
	CauHoi nvarchar(255),
	TraLoi nvarchar(Max),
	NgayDang  datetime default getdate(),
) 
GO

INSERT INTO CUAHANG(Ten,DienThoai,DiaChi,Email) VALUES(N'Mobifone An Giang',N'077 924 9999',N'93, Trần Hưng Đạo, Mỹ Quý Long Xuyên, An Giang',N'mobifoneaglx@gmail.com');
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
INSERT INTO TINTUC(TieuDe,TomTat,NoiDung,HinhAnh,NgayDang) VALUES(N'<h3><strong>Mình cùng đón Giáp Thìn – 2024!</strong></h3>',N'<p><i><strong>Từ ngày&nbsp;
12/12/2023&nbsp;đến ngày&nbsp;31/01/2024, MobiFone Tỉnh An Giang triển khai chương trình khuyến mại “</strong></i><strong>Mình cùng đón Giáp Thìn – 2024!
”&nbsp;</strong></p>',N'<p>Chào đón Năm Mới Giáp Thìn 2024, MobiFone An Giang triển khai chương trình khuyến mại “Mình Cùng Đón Giáp Thìn 2024! ” từ ngày 
12/12/2023 đến 31/01/2024 Khách hàng hòa mạng mới hoặc đăng ký mới/gia hạn bất kỳ gói cước&nbsp;Data&nbsp;nào của MobiFone trong thời gian diễn ra chương
trình, như một lời chúc, một lời tri ân sâu sắc dành cho các khách hàng đã luôn tin yêu và đồng hành cùng MobiFone Tỉnh An Giang.</p><p>Theo đó, từ ngày từ 
ngày 12/12/2023 đến 31/01/2024, Khách hàng hòa mạng mới hoặc đăng ký mới/gia hạn bất kỳ gói cước&nbsp;data&nbsp;nào của MobiFone trong thời gian diễn ra 
chương trình có nhắn tin&nbsp;sms&nbsp;tới số thuê bao 0779249999 kèm số dự đoán gần đúng nhất của 03 số cuối kết quả Giải đặc biệt Xổ số Kiến thiết tỉnh An 
Giang xổ ngày 01/02/2024.</p><p>Ví dụ: Thuê bao phát triển mới ngày 15/12/2023 soạn tin nhắn: 678 gởi đến 0779249999.</p><ul><li>Sau khi nhắn tin tham gia 
chương trình thành công, khách hàng sẽ nhận lại được tin nhắn xác nhận đã đăng ký thành công – chậm nhất ngày n+1</li><li>Mỗi khách hàng chỉ được tham dự 01 
mã dự thưởng cho 1 số thuê bao (gồm thuê bao trả trước hoặc thuê bao trả sau)</li><li>Kết quả trúng thưởng được căn cứ vào dự đoán của khách hàng có số gần
đúng với 03 số cuối (trường hợp giống kết quả sẽ xét thời gian sớm hơn) của Giải đặc biết Xổ số Kiến thiết tỉnh An Giang ngày 01/02/2024</li><li>Giải thưởng
:</li></ul><figure class="table"><table><tbody><tr><td><strong>Giải thưởng</strong></td><td><strong>Số lượng</strong></td><td><strong>Quà tặng</strong></td>
</tr><tr><td>Giải Nhất</td><td>01</td><td>01 chỉ vàng&nbsp;9999</td></tr><tr><td>Giải Nhì</td><td>20</td><td>Thẻ cào mệnh giá 100.000 đồng</td></tr><tr><td>Giải 
Ba</td><td>24</td><td>Thẻ cào mệnh giá 50.000 đồng</td></tr><tr><td>Giải Khuyến khích</td><td>100</td><td>01 hộp khẩu trang y tế</td></tr></tbody></table>
</figure><ul><li>Danh sách trúng giải sẽ được công bố trên trang fanpage của MobiFone Tỉnh An Giang, đường link:&nbsp;
<a href="https://www.facebook.com/mobifonetinhangiang">https://www.facebook.com/mobifonetinhangiang</a></li><li>Thời gian trao giải chậm nhất đến ngày 8/2/2024</li>
</ul><p>Gọi 0779 24 9999 hoặc 9090 để biết thêm thông tin chi tiết.</p>',N'mobifone1.png',3/19/2024);
go
INSERT INTO TINTUC(TieuDe,TomTat,NoiDung,HinhAnh,NgayDang) VALUES(N'<h4><strong>DATA NHÓM THẢ GA – NHẬN 200GB QUÁ ĐÃ</strong></h4>'
,N'<p>Nếu như bạn thường xuyên đi chơi cùng hội bạn bè, đi du lịch xa cùng với các thành viên trong gia đình thì để có thể giúp bạn tiết kiệm trong việc sử dụng 4G,
thay vì từng thành viên đăng ký thì giờ đây nhờ những gói data nhóm, người dùng hoàn toàn có thể chia sẻ dung lượng truy cập 4G cho các thuê bao khác</p>'
,N'<p>Hiện tại, MobiFone đem đến cho khách hàng nhiều gói cước nhóm với chi phí hợp lý tùy theo nhu cầu sử dụng. Các gói cước mFamily của MobiFone đem lại nhiều ưu 
điểm nổi trội như:</p><ul><li>Chi phí tiết kiệm cho gói nhóm, có thể phân bổ hạn mức theo nhu cầu sử dụng của từng thuê bao.</li><li>Thanh toán chỉ 1 lần duy nhất,
tiện lợi và dễ dàng quản lý theo nhóm.</li><li>Ngoài ra còn miễn phí gọi không giới hạn nội nhóm.</li></ul><p>Đặc biệt, các gói cước MFY200, MFY với ưu đãi data khủng
lên đến 400GB/tháng, miễn phí truy cập Facebook, YouTube là lựa chọn phù hợp cho những khách hàng có nhu cầu sử dụng lưu lượng lớn data hàng ngày.</p><p>Gói cước áp 
dụng với thuê bao trả trước, trả sau phát triển mới từ 01/6/2023. Hoặc thuê bao trả trước, trả sau hiện hữu theo danh sách quy định.</p><p>Gói cước cho phép chia sẻ 
tới 05 thuê bao (bao gồm 01 thuê bao trưởng nhóm và 04 thuê bao thành viên khác)</p><p>Chi tiết các gói cước như sau:<br>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Để đăng
ký gói cước, soạn tin:&nbsp;<strong>DK Tên gói cước</strong>&nbsp; <strong>0799980067</strong> gửi <strong>909</strong></p><p>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Để
chia sẻ gói cước cho thành viên, soạn tin&nbsp;<strong>ADM</strong>&nbsp;<strong>MFY Số thuê bao thành viên&nbsp;</strong>gửi<strong>&nbsp;999</strong></p><p>&nbsp; 
&nbsp; &nbsp; &nbsp; &nbsp;(Phí thành viên:&nbsp;<strong>15.000 đ/thuê bao/30 ngày</strong>, trừ vào Tài khoản chính của thuê bao trưởng nhóm).</p><p>&nbsp; &nbsp; 
&nbsp; &nbsp; &nbsp;Mọi thông tin chi tiết vui lòng liên hệ hotline 0779 24 9999.</p>',N'tin2.png',5/6/2024);
go
-- dữ liệu chức vụ
INSERT INTO CHUCVU(Ten) VALUES(N'Admin');
INSERT INTO CHUCVU(Ten) VALUES(N'Nhân Viên');
GO
-- dữ liệu Nhân Viên
INSERT INTO NHANVIEN(Ten,MaCV,DienThoai,Email,MatKhau) VALUES(N'Admin',1,'0789845633',N'Admin@gmail.com','AQAAAAEAACcQAAAAEBO/yZP9lqYHO4BYQbIUxbclNnXTB0C4ljyB2VCqxBwT0krD4w3IBjfgx5QBcRQrQQ=='); -- 123Admin
INSERT INTO NHANVIEN(Ten,MaCV,DienThoai,Email,MatKhau) VALUES(N'Trương Văn Tân',2,'0789845632',N'Tan@gmail.com','AQAAAAEAACcQAAAAEDBPezsoNDRV7Jw82ZAjonXUNV+xenpO7pPkQpuICGk/MQwsDchGrPNjMq5eh+6R2w==');-- 123Tan
GO
-- dữ liệu Khách hàng
INSERT INTO KHACHHANG(Ten,DienThoai,Email,MatKhau,CCCD,SLThueB) VALUES(N'NGuyễn Thị Như Huỳnh','0382180991',N'Huynh@gmail.com','AQAAAAEAACcQAAAAEHMY7fkbGxZx8LESboxUQ2C24Bu9Yi5SLDC6ZOsxie6Xyq/y+pHFJoBGOktwQTfqsw==','085643245600',0); -- mk: 123Huynh
GO
INSERT INTO DIACHI(MaKH,DiaChi,PhuongXa,QuanHuyen,TinhThanh,MacDinh) VALUES(1,N'Ấp Long Thuận 2',N'Long Điền A',N'Chợ Mới',N'An Giang',1)
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
SELECT * FROM QLTHUEBAO;
 
