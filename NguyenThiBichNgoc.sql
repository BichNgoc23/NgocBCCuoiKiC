CREATE DATABASE NguyenThiBichNgocDB

USE NguyenThiBichNgocDB
CREATE TABLE AdminAccount
(
	ID int IDENTITY(1,1) primary key,
	UserName  char(50) NOT NULL,
	PassWord char(100) NOT NULL,
	Status varchar(100)
)
drop table UserAccount

CREATE TABLE UserAccount
(
	ID int IDENTITY(1,1) primary key,
	UserName  char(50) NOT NULL,
	PassWord char(100) NOT NULL,
	Status varchar(100)
)

insert into UserAccount(UserName,PassWord,Status)
values('bichngoc','ngoc123','Active')

CREATE TABLE Category
(
	ID int IDENTITY(1,1) PRIMARY KEY,
	Name nvarchar(200) NOT NULL,
	Description nvarchar(200)
)
insert into Category(Name,Description)
values(N'Life Skills', N'Kỹ năng sống'),
	(N'Children', N'Thiếu nhi'),
	(N'Education', N'Sách giáo dục')

CREATE TABLE Product
(
	ID int IDENTITY(1,1) PRIMARY KEY,
	Name nvarchar(200) NOT NULL,
	UnitCost decimal(10,2),
	Quantity INT not null,
	Image varchar(200),
	Description nvarchar(200),
	Status int,
	IDCategory int foreign key references Category(ID)
)

insert into Product(Name,UnitCost,Quantity,Image,Description,Status,IDCategory)
values('Thay Đổi Cuộc Sống Với Nhân Số Học',150000,1,'1.png','Sách Mới Về',1,1),
		('Doraemon Truyện Ngắn',75000,1,'2.png','Sách Có Sẵn',1,2),
		('Combo trọn bộ POMath Toán tư duy cho trẻ em',100000,1,'3.png','Sách Mới Về',1,3)

