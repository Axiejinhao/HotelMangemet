CREATE DATABASE HotelManagementLibrary
USE HotelManagementLibrary
go
CREATE TABLE Customer (
	CustomerID nvarchar(10) PRIMARY KEY,
	CustomerName nvarchar(10) NOT NULL,
	CustomerSex nvarchar(2) DEFAULT '男' CHECK (CustomerSex = '男'
	OR CustomerSex = '女'),
	CustomerIDNumber nvarchar(18) NOT NULL,
	CustomerType nvarchar(10) NOT NULL,
	CustomerPhone nvarchar(11) NOT NULL,
	CustomerCreateDate date NOT NULL,
	FOREIGN KEY (CustomerType)
		REFERENCES CustomerType (TypeName)
);
CREATE TABLE CustomerType (
	TypeName nvarchar(10) PRIMARY KEY,
	Discount float NOT NULL,
	Fine float NOT NULL
);
CREATE TABLE Worker (
	WorkerID nvarchar(10) PRIMARY KEY,
	WorkerName nvarchar(10) ,
	WorkerSex nvarchar(2) DEFAULT '男' CHECK (WorkerSex = '男'
	OR WorkerSex = '女'),
	WorkerIDNumber nvarchar(18) ,
	WorkerPosition nvarchar(10),
	WorkerPassword nvarchar(20) 
);
CREATE TABLE Room (
	RoomID nvarchar(10) PRIMARY KEY,
	RoomType nvarchar(10) NOT NULL,
	RoomPrice float NOT NULL,
	RoomState nvarchar(10) DEFAULT '未入住' CHECK (RoomState = '已入住'
	OR RoomState = '未入住')
);
CREATE TABLE Manager (
	ManagerID nvarchar(10) PRIMARY KEY,
	ManagerName nvarchar(10) ,
	ManagerPassword nvarchar(20)
);
CREATE TABLE InHistory (
	InID nvarchar(10) PRIMARY KEY,
	CustomerID nvarchar(10) NOT NULL,
	CustomerType nvarchar(10) NOT NULL,
	CustomerInDate date NOT NULL,
	CustomerOutDate date NOT NULL,
	RoomID nvarchar(10) NOT NULL,
	Worker nvarchar(10) NOT NULL,
	FOREIGN KEY (CustomerID)
		REFERENCES Customer (CustomerID),
	FOREIGN KEY (CustomerType)
		REFERENCES CustomerType (TypeName),
	FOREIGN KEY (RoomID)
		REFERENCES Room (RoomID),
	FOREIGN KEY (Worker)
		REFERENCES Worker (WorkerID)
);
CREATE TABLE OutHistory (
	OutID nvarchar(10) PRIMARY KEY,
	CustomerID nvarchar(10) NOT NULL,
	CustomerType nvarchar(10) NOT NULL,
	CustomerInDate nvarchar(10) NOT NULL,
	CustomerOutDate nvarchar(10) NOT NULL,
	RoomID nvarchar(10) NOT NULL,
	Worker nvarchar(10) NOT NULL,
	FOREIGN KEY (CustomerID)
		REFERENCES Customer (CustomerID),
	FOREIGN KEY (CustomerType)
		REFERENCES CustomerType (TypeName),
	FOREIGN KEY (RoomID)
		REFERENCES Room (RoomID),
	FOREIGN KEY (Worker)
		REFERENCES Worker (WorkerID)
);
go


CREATE VIEW CustomerView (
	客户编号, 
	客户姓名, 
	客户性别, 
	客户类型, 
	客户联系方式, 
	办卡时间
)
AS
SELECT CustomerID, CustomerName, CustomerSex, CustomerType, CustomerPhone
	, CustomerCreateDate
FROM Customer
go
CREATE VIEW RoomView (
	房间号, 
	房间类型, 
	房间价格
)
AS
SELECT RoomID, RoomType, RoomPrice
FROM Room
go
CREATE VIEW InHistoryView (
	入住编号, 
	客户编号, 
	客户类型, 
	客户入住时间, 
	客户应退房时间, 
	房间号
)
AS
SELECT InID, CustomerID, CustomerType, CustomerInDate, CustomerOutDate
	, RoomID
FROM InHistory
go
CREATE VIEW OutHistoryView (
	退房编号, 
	客户编号, 
	客户类型, 
	客户入住时间, 
	客户退房时间, 
	房间号, 
	超时罚款
)
AS
SELECT OutID, CustomerID, CustomerType, CustomerInDate, CustomerOutDate
	, RoomID, Fine
FROM OutHistory,CustomerType
go

use HotelManagementLibrary
go


--插入管理员信息
insert 
into Manager
values('0001','张三','zhangsan')

insert 
into Manager
values('0002','李四','lisi')

insert 
into Manager
values('0003','王五','wangwu')


--插入员工信息
insert 
into Worker
values ('000001','小明','男','110000000','经理','xiaoming')

insert 
into Worker
values ('000002','小张','女','210000000','前台','xiaozhang')

insert 
into Worker
values ('000003','小王','男','220000000','前台','xiaozhang')

insert 
into Worker
values ('000005','小红','女','310000000','保洁','xiaohong')

insert 
into Worker
values ('000006','小黄','女','320000000','保洁','xiaohuang')

insert 
into Worker
values ('000007','小蓝','男','330000000','保洁','xiaolan')

go

--插入房间信息
insert
into Room
values('101','单人间','80','未入住')

insert
into Room
values('102','单人间','80','未入住')

insert
into Room
values('103','单人间','80','未入住')

insert
into Room
values('104','单人间','80','未入住')

insert
into Room
values('105','单人间','80','未入住')

insert
into Room
values('106','单人间','80','未入住')

insert
into Room
values('107','单人间','80','未入住')

insert
into Room
values('108','单人间','80','未入住')

insert
into Room
values('201','双人间','150','未入住')

insert
into Room
values('202','双人间','150','未入住')

insert
into Room
values('203','双人间','150','未入住')

insert
into Room
values('204','双人间','150','未入住')

insert
into Room
values('205','大床房','120','未入住')

insert
into Room
values('206','大床房','120','未入住')

insert
into Room
values('301','三人间','210','未入住')

insert
into Room
values('302','三人间','210','未入住')

insert
into Room
values('303','三人间','210','未入住')

insert
into Room
values('304','三人间','210','未入住')

go

--插入客户类别信息
insert 
into CustomerType
values('普通客户','1','0')

insert 
into CustomerType
values('普通会员','0.95','0')

insert 
into CustomerType
values('白金会员','0.88','0')

insert 
into CustomerType
values('超级会员','0.8','0')

GO

--插入客户信息
insert
into Customer
values('00000001','曹操','男','00000001','普通客户','19811111111','2021-4-1')

insert
into Customer
values('00000002','孙策','男','00000002','普通客户','19822222222','2021-4-15')

insert
into Customer
values('00000003','刘备','男','00000003','普通客户','19833333333','2021-5-1')

insert
into Customer
values('00000004','关羽','男','00000004','普通客户','15811111111','2021-5-15')

insert
into Customer
values('00000005','张飞','男','00000005','普通客户','16622222222','2021-6-1')

insert
into Customer
values('00000006','大乔','男','00000006','普通客户','16611111111','2021-6-1')

insert
into Customer
values('00000007','小乔','男','00000007','普通客户','16622222222','2021-6-1')

GO

--插入住房记录
insert
into InHistory
values('0001','00000001','普通客户','2021-4-1','2021-4-3','101','000001')

insert
into InHistory
values('0002','00000002','普通客户','2021-4-15','2021-4-20','102','000002')

insert
into InHistory
values('0003','00000003','普通客户','2021-5-1','2021-5-3','103','000003')

insert
into InHistory
values('0004','00000004','普通客户','2021-5-15','2021-5-18','201','000001')

insert
into InHistory
values('0005','00000005','普通客户','2021-5-15','2021-5-18','201','000001')

insert
into InHistory
values('0006','00000006','普通客户','2021-6-1','2021-6-8','202','000002')

insert
into InHistory
values('0007','00000007','普通客户','2021-6-1','2021-6-8','202','000002')

GO


--插入退房记录
insert
into OutHistory
values('1001','00000001','普通客户','2021-4-1','2021-4-3','101','000001')

insert
into OutHistory
values('1002','00000002','普通客户','2021-4-15','2021-4-20','102','000002')

insert
into OutHistory
values('1003','00000003','普通客户','2021-5-1','2021-5-3','103','000003')

insert
into OutHistory
values('1004','00000004','普通客户','2021-5-15','2021-5-18','201','000001')

insert
into OutHistory
values('1005','00000005','普通客户','2021-5-15','2021-5-18','201','000001')

insert
into OutHistory
values('1006','00000006','普通客户','2021-6-1','2021-6-8','202','000002')

insert
into OutHistory
values('1007','00000007','普通客户','2021-6-1','2021-6-8','202','000002')

GO

--触发器
create trigger tri1
on sc
after insert
as
begin
 if((select count(*) from CustomerType,inserted where CustomerTyp.TypeName=inserted.TypeName)>4)
 begin
 rollback
 print('顾客类型以达到四类')
 end
 else
 begin
 print('成功')
 end
end
go

--存储过程
create procedure pro1
(@aa nvarchar(10),@bb float,@cc float)
as
begin
 insert into CustomerType values(@aa,@bb,@cc)
end
select *
from CustomerType
go

exec pro1 @aa='123',@bb=123,@cc=123

go

