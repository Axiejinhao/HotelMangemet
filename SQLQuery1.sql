CREATE DATABASE HotelManagementLibrary
USE HotelManagementLibrary
go
CREATE TABLE Customer (
	CustomerID nvarchar(10) PRIMARY KEY,
	CustomerName nvarchar(10) NOT NULL,
	CustomerSex nvarchar(2) DEFAULT '��' CHECK (CustomerSex = '��'
	OR CustomerSex = 'Ů'),
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
	WorkerSex nvarchar(2) DEFAULT '��' CHECK (WorkerSex = '��'
	OR WorkerSex = 'Ů'),
	WorkerIDNumber nvarchar(18) ,
	WorkerPosition nvarchar(10),
	WorkerPassword nvarchar(20) 
);
CREATE TABLE Room (
	RoomID nvarchar(10) PRIMARY KEY,
	RoomType nvarchar(10) NOT NULL,
	RoomPrice float NOT NULL,
	RoomState nvarchar(10) DEFAULT 'δ��ס' CHECK (RoomState = '����ס'
	OR RoomState = 'δ��ס')
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
	�ͻ����, 
	�ͻ�����, 
	�ͻ��Ա�, 
	�ͻ�����, 
	�ͻ���ϵ��ʽ, 
	�쿨ʱ��
)
AS
SELECT CustomerID, CustomerName, CustomerSex, CustomerType, CustomerPhone
	, CustomerCreateDate
FROM Customer
go
CREATE VIEW RoomView (
	�����, 
	��������, 
	����۸�
)
AS
SELECT RoomID, RoomType, RoomPrice
FROM Room
go
CREATE VIEW InHistoryView (
	��ס���, 
	�ͻ����, 
	�ͻ�����, 
	�ͻ���סʱ��, 
	�ͻ�Ӧ�˷�ʱ��, 
	�����
)
AS
SELECT InID, CustomerID, CustomerType, CustomerInDate, CustomerOutDate
	, RoomID
FROM InHistory
go
CREATE VIEW OutHistoryView (
	�˷����, 
	�ͻ����, 
	�ͻ�����, 
	�ͻ���סʱ��, 
	�ͻ��˷�ʱ��, 
	�����, 
	��ʱ����
)
AS
SELECT OutID, CustomerID, CustomerType, CustomerInDate, CustomerOutDate
	, RoomID, Fine
FROM OutHistory,CustomerType
go

use HotelManagementLibrary
go


--�������Ա��Ϣ
insert 
into Manager
values('0001','����','zhangsan')

insert 
into Manager
values('0002','����','lisi')

insert 
into Manager
values('0003','����','wangwu')


--����Ա����Ϣ
insert 
into Worker
values ('000001','С��','��','110000000','����','xiaoming')

insert 
into Worker
values ('000002','С��','Ů','210000000','ǰ̨','xiaozhang')

insert 
into Worker
values ('000003','С��','��','220000000','ǰ̨','xiaozhang')

insert 
into Worker
values ('000005','С��','Ů','310000000','����','xiaohong')

insert 
into Worker
values ('000006','С��','Ů','320000000','����','xiaohuang')

insert 
into Worker
values ('000007','С��','��','330000000','����','xiaolan')

go

--���뷿����Ϣ
insert
into Room
values('101','���˼�','80','δ��ס')

insert
into Room
values('102','���˼�','80','δ��ס')

insert
into Room
values('103','���˼�','80','δ��ס')

insert
into Room
values('104','���˼�','80','δ��ס')

insert
into Room
values('105','���˼�','80','δ��ס')

insert
into Room
values('106','���˼�','80','δ��ס')

insert
into Room
values('107','���˼�','80','δ��ס')

insert
into Room
values('108','���˼�','80','δ��ס')

insert
into Room
values('201','˫�˼�','150','δ��ס')

insert
into Room
values('202','˫�˼�','150','δ��ס')

insert
into Room
values('203','˫�˼�','150','δ��ס')

insert
into Room
values('204','˫�˼�','150','δ��ס')

insert
into Room
values('205','�󴲷�','120','δ��ס')

insert
into Room
values('206','�󴲷�','120','δ��ס')

insert
into Room
values('301','���˼�','210','δ��ס')

insert
into Room
values('302','���˼�','210','δ��ס')

insert
into Room
values('303','���˼�','210','δ��ס')

insert
into Room
values('304','���˼�','210','δ��ס')

go

--����ͻ������Ϣ
insert 
into CustomerType
values('��ͨ�ͻ�','1','0')

insert 
into CustomerType
values('��ͨ��Ա','0.95','0')

insert 
into CustomerType
values('�׽��Ա','0.88','0')

insert 
into CustomerType
values('������Ա','0.8','0')

GO

--����ͻ���Ϣ
insert
into Customer
values('00000001','�ܲ�','��','00000001','��ͨ�ͻ�','19811111111','2021-4-1')

insert
into Customer
values('00000002','���','��','00000002','��ͨ�ͻ�','19822222222','2021-4-15')

insert
into Customer
values('00000003','����','��','00000003','��ͨ�ͻ�','19833333333','2021-5-1')

insert
into Customer
values('00000004','����','��','00000004','��ͨ�ͻ�','15811111111','2021-5-15')

insert
into Customer
values('00000005','�ŷ�','��','00000005','��ͨ�ͻ�','16622222222','2021-6-1')

insert
into Customer
values('00000006','����','��','00000006','��ͨ�ͻ�','16611111111','2021-6-1')

insert
into Customer
values('00000007','С��','��','00000007','��ͨ�ͻ�','16622222222','2021-6-1')

GO

--����ס����¼
insert
into InHistory
values('0001','00000001','��ͨ�ͻ�','2021-4-1','2021-4-3','101','000001')

insert
into InHistory
values('0002','00000002','��ͨ�ͻ�','2021-4-15','2021-4-20','102','000002')

insert
into InHistory
values('0003','00000003','��ͨ�ͻ�','2021-5-1','2021-5-3','103','000003')

insert
into InHistory
values('0004','00000004','��ͨ�ͻ�','2021-5-15','2021-5-18','201','000001')

insert
into InHistory
values('0005','00000005','��ͨ�ͻ�','2021-5-15','2021-5-18','201','000001')

insert
into InHistory
values('0006','00000006','��ͨ�ͻ�','2021-6-1','2021-6-8','202','000002')

insert
into InHistory
values('0007','00000007','��ͨ�ͻ�','2021-6-1','2021-6-8','202','000002')

GO


--�����˷���¼
insert
into OutHistory
values('1001','00000001','��ͨ�ͻ�','2021-4-1','2021-4-3','101','000001')

insert
into OutHistory
values('1002','00000002','��ͨ�ͻ�','2021-4-15','2021-4-20','102','000002')

insert
into OutHistory
values('1003','00000003','��ͨ�ͻ�','2021-5-1','2021-5-3','103','000003')

insert
into OutHistory
values('1004','00000004','��ͨ�ͻ�','2021-5-15','2021-5-18','201','000001')

insert
into OutHistory
values('1005','00000005','��ͨ�ͻ�','2021-5-15','2021-5-18','201','000001')

insert
into OutHistory
values('1006','00000006','��ͨ�ͻ�','2021-6-1','2021-6-8','202','000002')

insert
into OutHistory
values('1007','00000007','��ͨ�ͻ�','2021-6-1','2021-6-8','202','000002')

GO

--������
create trigger tri1
on sc
after insert
as
begin
 if((select count(*) from CustomerType,inserted where CustomerTyp.TypeName=inserted.TypeName)>4)
 begin
 rollback
 print('�˿������Դﵽ����')
 end
 else
 begin
 print('�ɹ�')
 end
end
go

--�洢����
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

