USE PTTK;

CREATE TABLE SanPham(
	ma int primary key IDENTITY(1,1),
	maSanPham nvarchar(1000) not null,
	tenSanPham nvarchar(1000) default '',
	anhDaiDien nvarchar(1000) default '',
	gia int default 0,
	xuatXu  nvarchar(1000),
	thoiGianBaoHanh int default 12,
	chieuDai nvarchar (1000),
	chieuRong nvarchar (1000),
	chieuCao nvarchar (1000),
	heDieuHanh nvarchar (1000),
	moTa nvarchar (1000),
	laDienThoai int default 1,
)

CREATE TABLE KhachHang (
	ma int primary key IDENTITY(1,1),
	loai nvarchar(1000),
	laKhachVip int default 0,
	ten nvarchar(1000),
	soDienThoai nvarchar(20),
	diaChi nvarchar(1000),
	nguoiDaiDien nvarchar(1000),
	soDienThoaiCongTy nvarchar (20),
	diem int default 0
)

CREATE TABLE HoaDon (
	ma int primary key IDENTITY(1,1),
	maKhachHang int,
	maKhuyenMai int,
	trangThai nvarchar(1000),
	tongTien int default 0,
	giamGiaTien int default 0,
	loai nvarchar(1000), -- SI | LE
)

CREATE TABLE SanPhamHoaDon(
	ma int primary key IDENTITY(1,1),
	maHoaDon int,
	maSanPham int,
	soLuong int default 0,
	tongTien int default 0,
)

CREATE TABLE KhuyenMai (
	ma int primary key IDENTITY(1,1),
	loai nvarchar (2000),
	ten nvarchar (2000),
	thoiGianBatDau datetime,
	thoiGianKetThuc datetime,
	giaTri int default 0,
	tongTienThapNhat int default 0
)

ALTER TABLE HoaDon
ADD FOREIGN KEY (maKhachHang) REFERENCES KhachHang(ma);

ALTER TABLE HoaDon
ADD FOREIGN KEY (maKhuyenMai) REFERENCES KhuyenMai(ma);

ALTER TABLE SanPhamHoaDon
ADD FOREIGN KEY (maHoaDon) REFERENCES HoaDon(ma)

ALTER TABLE SanPhamHoaDon
ADD FOREIGN KEY (maSanPham) REFERENCES SanPham(ma)