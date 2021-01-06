CREATE DATABASE DO_AN
USE DO_AN
DROP DATABASE DO_AN

-- CÂU LỆNH TABLE 
CREATE TABLE KHACHHANG
(
	MAKH char(4) PRIMARY KEY,
	HOTEN nvarchar(50) NOT NULL,
	DCHI nvarchar(50) NULL,
	SODT varchar(20) NULL,
	NGSINH varchar(50),
	DOANHSO float NULL,
	NGDK varchar(50) NOT NULL
)
CREATE TABLE NHANVIEN
(
	MANV char(4) primary key,
	HOTEN nvarchar(50) NOT NULL,
	SDT varchar(20) NULL,
	NGVL varchar(50) NOT NULL
)
CREATE TABLE SANPHAM
(
	MASP char(4),
	TENSP nvarchar(50) NOT NULL,
	DVT nvarchar(20) NOT NULL,
	NUOCSX nvarchar(40) NOT NULL,
	GIA float NOT NULL,
	LINK_ANH varchar(100),
	TRANGTHAI nvarchar(40),
	PRIMARY KEY(MASP)
)
CREATE TABLE HOADON
(
	SOHD varchar(10) primary key,
	NGHD varchar(50) NOT NULL,
	MAKH char(4),
	MANV char(4),
	TRIGIA float NOT NULL,
	GHICHU nvarchar(100)
)

CREATE TABLE CTHD 
(
	SOHD varchar(10),
	MASP char(4),
	SL int NULL,
	PRIMARY KEY(SOHD, MASP)
)

ALTER TABLE HOADON ADD 
	CONSTRAINT HD_MAKH_FK FOREIGN KEY(MAKH) REFERENCES KHACHHANG(MAKH);
ALTER TABLE HOADON ADD 
	CONSTRAINT HD_MANV_FK FOREIGN KEY(MANV) REFERENCES NHANVIEN(MANV);

set dateformat dmy

insert into KHACHHANG values('KH01',N'Nguyễn Văn Hưng',N'731 Trần Hưng Đạo, Q5, TpHCM','19240000','22/10/1960',13060000,'22/07/2006')
insert into KHACHHANG values('KH02',N'Trần Ngọc Hân',N'23/5 Nguyễn Trãi, Q5, TpHCM','0908256478','3/4/1974',1310000,'30/07/2006')
insert into KHACHHANG values('KH03',N'Trần Ngọc Linh',N'45 Nguyễn Cảnh Chân, Q1, TpHCM','0938776266','12/6/1980',13900000,'05/08/2006')
insert into KHACHHANG values('KH04',N'Trần Minh Long',N'50/34 Lê Đại Hành, Q10, TpHCM','0917325476','9/3/1965',250000,'02/10/2006')
insert into KHACHHANG values('KH05',N'Lê Nhất Minh',N'34 Trương Định, Q3, TpHCM','08246108','10/3/1950',21000,'28/10/2006')
insert into KHACHHANG values('KH06',N'Lê Hoài Thương',N'227 Nguyễn Văn Cừ, Q5, TpHCM','08631738','31/12/1981',660000,'24/11/2006')
insert into KHACHHANG values('KH07',N'Nguyễn Mạnh Tâm',N'32/3 Trần Bình Trọng, Q5, TpHCM','0916783565','6/4/1971',12500,'01/12/2006')
insert into KHACHHANG values('KH08',N'Phan Thị Thanh Tâm',N'45/2 An Dương Vương, Q5, TpHCM','0938435756','10/1/1971',136000,'13/12/2006')
insert into KHACHHANG values('KH09',N'Lê Hà Vinh',N'873 Cách Mạng Tháng Tám, QTB, TpHCM','08654763','3/9/1979',330000,'14/01/2007')
insert into KHACHHANG values('KH10',N'Hà Duy Lập',N'34/34B Nguyễn Trãi, Q1, TpHCM','08768904','2/5/1983',70500,'16/01/2007')

insert into NHANVIEN values('NV01',N'Nguyễn Như Nhật','0927345678','13/4/2006')
insert into NHANVIEN values('NV02',N'Lê Thị Phi Yến','0987567390','21/4/2006')
insert into NHANVIEN values('NV03',N'Nguyễn Văn Tạ','0997047382','27/4/2006')
insert into NHANVIEN values('NV04',N'Ngô Thanh Tuấn','0913758498','24/6/2006')
insert into NHANVIEN values('NV05',N'Nguyễn Thị Trúc Thanh','0918590387','20/7/2006')

insert into SANPHAM values('BC02',N'Bút chì',N'cây',N'Singapore',5000,'D:\Git_Lab\Do_An_Cuoi_Ki\Do_An_Cuoi_Ki\Image\CayButChi.jpg', N'Được bán')
insert into SANPHAM values('BC03',N'Bánh snack',N'bịch',N'Việt Nam',6000,'D:\Git_Lab\Do_An_Cuoi_Ki\Do_An_Cuoi_Ki\Image\BanhSnack.jpg', N'Được bán')
insert into SANPHAM values('BC04',N'Kẹo bạc hà',N'bịch',N'Việt Nam',30000,'D:\Git_Lab\Do_An_Cuoi_Ki\Do_An_Cuoi_Ki\Image\KeoBacHa.jpg', N'Được bán')
insert into SANPHAM values('BB01',N'Dầu đậu nành Simply',N'chai',N'Việt Nam',205000,'D:\Git_Lab\Do_An_Cuoi_Ki\Do_An_Cuoi_Ki\Image\DauAn.jpg', N'Được bán')
insert into SANPHAM values('BB02',N'Bút bi',N'cây',N'Trung Quốc',7000,'D:\Git_Lab\Do_An_Cuoi_Ki\Do_An_Cuoi_Ki\Image\ButBi.jpg', N'Được bán')
insert into SANPHAM values('BB03',N'Khẩu trang y tế',N'hộp',N'Thái Lan',50000,'D:\Git_Lab\Do_An_Cuoi_Ki\Do_An_Cuoi_Ki\Image\KhauTrangYTe.jpg', N'Được bán')
insert into SANPHAM values('TV01',N'Tập 100 trang giấy mỏng',N'quyển',N'Trung Quốc',2500,'D:\Git_Lab\Do_An_Cuoi_Ki\Do_An_Cuoi_Ki\Image\Tap100Trang.jpg', N'Được bán')
insert into SANPHAM values('TV02',N'Sách học làm giàu',N'quyển',N'Trung Quốc',45000,'D:\Git_Lab\Do_An_Cuoi_Ki\Do_An_Cuoi_Ki\Image\SachHocLamGiau.jpg', N'Được bán')
insert into SANPHAM values('TV03',N'Nước xả vải comfort',N'bịch',N'Việt Nam',16000,'D:\Git_Lab\Do_An_Cuoi_Ki\Do_An_Cuoi_Ki\Image\NuocxaVai.jpg', N'Được bán')
insert into SANPHAM values('TV04',N'Tập 200 trang giấy tốt',N'quyển',N'Việt Nam',15000,'D:\Git_Lab\Do_An_Cuoi_Ki\Do_An_Cuoi_Ki\Image\Tap200Trang.jpg', N'Được bán')
insert into SANPHAM values('TV05',N'Gậy tự sướng',N'cây',N'Việt Nam',23000,'D:\Git_Lab\Do_An_Cuoi_Ki\Do_An_Cuoi_Ki\Image\GayTuSuong.jpg', N'Được bán')
insert into SANPHAM values('TV06',N'Ống hút giấy',N'bịch',N'Việt Nam',20000,'D:\Git_Lab\Do_An_Cuoi_Ki\Do_An_Cuoi_Ki\Image\OngHutGiay.jpg', N'Được bán')
insert into SANPHAM values('TV07',N'Rượu nếp',N'chai',N'Trung Quốc',34000,'D:\Git_Lab\Do_An_Cuoi_Ki\Do_An_Cuoi_Ki\Image\Ruounep.jpg', N'Được bán')
insert into SANPHAM values('ST01',N'Sổ tay 500 trang',N'quyển',N'Trung Quốc',40000,'D:\Git_Lab\Do_An_Cuoi_Ki\Do_An_Cuoi_Ki\Image\SoTay500Trang.jfif', N'Được bán')
insert into SANPHAM values('ST02',N'Hộp quà',N'hộp',N'Việt Nam',55000,'D:\Git_Lab\Do_An_Cuoi_Ki\Do_An_Cuoi_Ki\Image\HopQua.jfif', N'Được bán')
insert into SANPHAM values('ST03',N'Stick note',N'quyển',N'Việt Nam',5000,'D:\Git_Lab\Do_An_Cuoi_Ki\Do_An_Cuoi_Ki\Image\StickyNote.jpg', N'Được bán')
insert into SANPHAM values('ST04',N'Ly sứ 3D',N'hộp',N'Thái Lan',55000,'D:\Git_Lab\Do_An_Cuoi_Ki\Do_An_Cuoi_Ki\Image\LySu3D.jpg', N'Được bán')
insert into SANPHAM values('ST05',N'Đắc Nhân Tâm',N'quyển',N'Thái Lan',70000,'D:\Git_Lab\Do_An_Cuoi_Ki\Do_An_Cuoi_Ki\Image\DacNhanTam.jpg', N'Được bán')
insert into SANPHAM values('ST06',N'Phấn viết bảng',N'hộp',N'Việt Nam',5000,'D:\Git_Lab\Do_An_Cuoi_Ki\Do_An_Cuoi_Ki\Image\PhanVietBang.jpg', N'Được bán')
insert into SANPHAM values('ST07',N'Phấn viết bảng không bụi',N'hộp',N'Việt Nam',7000,'D:\Git_Lab\Do_An_Cuoi_Ki\Do_An_Cuoi_Ki\Image\PhanVietBangKhongBui.jfif', N'Được bán')
insert into SANPHAM values('ST08',N'Cục tẩy',N'hộp',N'Việt Nam',20000,'D:\Git_Lab\Do_An_Cuoi_Ki\Do_An_Cuoi_Ki\Image\CucTay.jpg', N'Được bán')
insert into SANPHAM values('ST09',N'Bút lông',N'cây',N'Việt Nam',5000,'D:\Git_Lab\Do_An_Cuoi_Ki\Do_An_Cuoi_Ki\Image\ButLong.jfif', N'Được bán')
insert into SANPHAM values('ST10',N'Bút màu',N'hộp',N'Trung Quốc',70000,'D:\Git_Lab\Do_An_Cuoi_Ki\Do_An_Cuoi_Ki\Image\ButMau.jpg', N'Được bán')

insert into HOADON values('1001','23/07/2006','KH01','NV01',950000, N'Không có dữ liệu')
insert into HOADON values('1002','12/8/2006','KH01','NV02',4900000, N'Không có dữ liệu')
insert into HOADON values('1003','23/08/2006','KH02','NV01',520000, N'Không có dữ liệu')
insert into HOADON values('1004','1/9/2006','KH02','NV01',830000, N'Không có dữ liệu')
insert into HOADON values('1005','20/10/2006','KH01','NV02',2500000, N'Không có dữ liệu')
insert into HOADON values('1006','16/10/2006','KH01','NV03',2600000, N'Không có dữ liệu')
insert into HOADON values('1007','28/10/2006','KH03','NV03',55000, N'Không có dữ liệu')
insert into HOADON values('1008','28/10/2006','KH01','NV03',460000, N'Không có dữ liệu')
insert into HOADON values('1009','28/10/2006','KH03','NV04',790000, N'Không có dữ liệu')
insert into HOADON values('1010','1/11/2006','KH01','NV01',8800000, N'Không có dữ liệu')
insert into HOADON values('1011','4/11/2006','KH04','NV03',293000, N'Không có dữ liệu')
insert into HOADON values('1012','30/11/2006','KH05','NV03',27000, N'Không có dữ liệu')
insert into HOADON values('1013','12/12/2006','KH06','NV01',130000, N'Không có dữ liệu')
insert into HOADON values('1014','31/12/2006','KH03','NV02',14000000, N'Không có dữ liệu')
insert into HOADON values('1015','1/1/2007','KH06','NV01',570000, N'Không có dữ liệu')
insert into HOADON values('1016','1/1/2007','KH07','NV02',15600, N'Không có dữ liệu')
insert into HOADON values('1017','2/1/2007','KH08','NV03',193000, N'Không có dữ liệu')
insert into HOADON values('1018','13/01/2007','KH08','NV03',380000, N'Không có dữ liệu')
insert into HOADON values('1019','13/01/2007','KH01','NV03',86000, N'Không có dữ liệu')
insert into HOADON values('1020','14/01/2007','KH09','NV04',80000, N'Không có dữ liệu')
insert into HOADON values('1021','16/01/2007','KH10','NV03',595500, N'Không có dữ liệu')
insert into HOADON values('1022','16/01/2007',Null,'NV03',7000, N'Không có dữ liệu')
insert into HOADON values('1023','17/01/2005',Null,'NV01',360000, N'Không có dữ liệu')

insert into CTHD values('1001','TV02',10)
insert into CTHD values('1001','ST01',5)
insert into CTHD values('1001','BC01',5)
insert into CTHD values('1001','BC02',10)
insert into CTHD values('1001','ST08',10)
insert into CTHD values('1002','BC04',20)
insert into CTHD values('1002','BB01',20)
insert into CTHD values('1002','BB02',20)
insert into CTHD values('1003','BB03',10)
insert into CTHD values('1004','TV01',20)
insert into CTHD values('1004','TV02',10)
insert into CTHD values('1004','TV03',10)
insert into CTHD values('1004','TV04',10)
insert into CTHD values('1005','TV05',50)
insert into CTHD values('1005','TV06',50)
insert into CTHD values('1006','TV07',20)
insert into CTHD values('1006','ST01',30)
insert into CTHD values('1006','ST02',10)
insert into CTHD values('1007','ST03',10)
insert into CTHD values('1008','ST04',8)
insert into CTHD values('1009','ST05',10)
insert into CTHD values('1010','TV07',50)
insert into CTHD values('1010','ST07',50)
insert into CTHD values('1010','ST08',100)
insert into CTHD values('1010','ST04',50)
insert into CTHD values('1010','TV03',100)
insert into CTHD values('1011','ST06',50)
insert into CTHD values('1012','ST07',3)
insert into CTHD values('1013','ST08',5)
insert into CTHD values('1014','BC02',80)
insert into CTHD values('1014','BB02',100)
insert into CTHD values('1014','BC04',60)
insert into CTHD values('1014','BB01',50)
insert into CTHD values('1015','BB02',30)
insert into CTHD values('1015','BB03',7)
insert into CTHD values('1016','TV01',5)
insert into CTHD values('1017','TV02',1)
insert into CTHD values('1017','TV03',1)
insert into CTHD values('1017','TV04',5)
insert into CTHD values('1018','ST04',6)
insert into CTHD values('1019','ST05',1)
insert into CTHD values('1019','ST06',2)
insert into CTHD values('1020','ST07',10)
insert into CTHD values('1021','ST08',5)
insert into CTHD values('1021','TV01',7)
insert into CTHD values('1021','TV02',10)
insert into CTHD values('1022','ST07',1)
insert into CTHD values('1023','ST04',6)

select * from SANPHAM

select * from SANPHAM order by DVT asc

SELECT* FROM SANPHAM 
WHERE TRANGTHAI = N'Được bán'

SELECT SUM(KHACHHANG.DOANHSO) FROM KHACHHANG

SELECT SUM(TRIGIA) FROM HOADON


SELECT MAKH, TRIGIA/1000
FROM HOADON
ORDER BY MAKH 

select SANPHAM.TENSP, sum(SL) SLBANRA
from SANPHAM, CTHD
where SANPHAM.MASP = CTHD.MASP
group by TENSP
order by sum(SL) desc

select top 3 with ties SUM(TRIGIA) TONG, HOTEN, NHANVIEN.MANV
from NHANVIEN, HOADON
where NHANVIEN.MANV = HOADON.MANV
group by NHANVIEN.MANV, HOTEN
order by SUM(TRIGIA) desc

select TOP 3 SUM(SL * GIA) TONG , TENSP, SANPHAM.MASP	
from SANPHAM, CTHD
where SANPHAM.MASP = CTHD.MASP
group by TENSP, SANPHAM.MASP
order by SUM(SL * GIA) desc

select top 3 sum(SL) SLBANRA, SANPHAM.TENSP 
                                                                 from SANPHAM, CTHD 
																where SANPHAM.MASP = CTHD.MASP
                                                                 group by TENSP
                                                                 order by sum(SL) desc

select * from CTHD where SOHD = 1024