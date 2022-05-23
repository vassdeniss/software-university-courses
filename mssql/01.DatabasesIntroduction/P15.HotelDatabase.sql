GO

CREATE DATABASE [Hotel]

GO

USE [Hotel]

GO

CREATE TABLE [Employees] (
	[Id] INT PRIMARY KEY IDENTITY
	, [FirstName] NVARCHAR(50) NOT NULL
	, [LastName] NVARCHAR(50) NOT NULL
	, [Title] VARCHAR(50) NOT NULL
	, [Notes] NVARCHAR(500)
)

GO

INSERT INTO [Employees] 
VALUES (
    'fname1', 'lname1', 'title1', NULL
) , (
    'fname2', 'lname2', 'title1', NULL
) , (
    'fname3', 'lname3', 'title1', NULL
)

GO

CREATE TABLE [Customers] (
	[Id] INT PRIMARY KEY IDENTITY
	, [AccountNumber] VARCHAR(20) UNIQUE NOT NULL
	, [FirstName] NVARCHAR(50) NOT NULL
	, [LastName] NVARCHAR(50) NOT NULL
	, [PhoneNumber] VARCHAR(15) NOT NULL
	, [EmergencyName] VARCHAR(100)
	, [EmergencyNumber] VARCHAR(15)
	, [Notes] NVARCHAR(500)
)

GO

INSERT INTO [Customers] (
	[AccountNumber]
	, [FirstName] 
	, [LastName]
	, [PhoneNumber]
)
VALUES (
    432877, 'fname1', 'lname1', '+359 88 2321688'
) , (
    432878, 'fname2', 'lname2', '+359 88 2325688'
) , (
    432879, 'fname3', 'lname3', '+359 88 3327688'
)

GO

CREATE TABLE [RoomStatus] (
	[Id] INT PRIMARY KEY IDENTITY
	, [RoomStatus] VARCHAR(50) NOT NULL
	, [Notes] NVARCHAR(500)
)

GO

INSERT INTO [RoomStatus] 
VALUES (
	'Free', NULL
) , (
    'Not Free', NULL
) , (
    'Under Construction', NULL
)

GO

CREATE TABLE [RoomTypes] (
	[Id] INT PRIMARY KEY IDENTITY
	, [RoomType] VARCHAR(50) NOT NULL
	, [Notes] NVARCHAR(500)
)

GO

INSERT INTO [RoomTypes] 
VALUES (
	'Small', NULL
) , (
    'Medium', NULL
) , (
    'Large', NULL
)

GO

CREATE TABLE [BedTypes] (
	[Id] INT PRIMARY KEY IDENTITY
	, [BedType] VARCHAR(50) NOT NULL
	, [Notes] NVARCHAR(500)
)

GO

INSERT INTO [BedTypes] 
VALUES (
	'X', NULL
) , (
    'XL', NULL
) , (
    'XXL', NULL
)

GO

CREATE TABLE [Rooms] (
	[Id] INT PRIMARY KEY IDENTITY
	, [RoomNumber] VARCHAR(4) NOT NULL
	, [RoomType] INT FOREIGN KEY REFERENCES [RoomTypes]([Id])
	, [BedType] INT FOREIGN KEY REFERENCES [BedTypes]([Id])
	, [Rate] DECIMAL(6, 2) NOT NULL
	, [RoomStatus] INT FOREIGN KEY REFERENCES [RoomStatus]([Id])
	, [Notes] NVARCHAR(500)
)

GO

INSERT INTO [Rooms] 
VALUES (
	1234, 1, 1, 1000.25, 1, NULL
) , (
	1235, 2, 2, 1100.25, 2, NULL
) , (
	1236, 3, 3, 1200.25, 3, NULL
)

GO

CREATE TABLE [Payments] (
    [Id] INT PRIMARY KEY IDENTITY NOT NULL
    , [EmpoyeeId] INT FOREIGN KEY REFERENCES [Employees]([Id])
    , [PaymentDate] DATE NOT NULL
    , [AccountNumber] INT FOREIGN KEY REFERENCES [Customers]([Id])
    , [FirstDateOccupied] DATE NOT NULL
    , [LastDateOccupied] DATE NOT NULL
    , [TotayDays] INT NOT NULL
    , [AmountCharged] DECIMAL(6, 2) NOT NULL
    , [TaxRate] DECIMAL(6, 2) NOT NULL
    , [TaxAmount] DECIMAL(6, 2) NOT NULL
    , [PaymentTotal] DECIMAL(7, 2) NOT NULL
    , [Notes] NVARCHAR(500)
)

GO

INSERT INTO [Payments] 
VALUES (
	1, '2022-05-06', 1, '2022-04-06', '2022-05-06', DATEDIFF(DAY, '2022-04-06', '2022-05-06'), 1000.25, 1003.21, 1231.23, 3000.23, NULL
) , (
	2, '2022-05-06', 2, '2020-04-06', '2022-05-06', DATEDIFF(DAY, '2020-04-06', '2022-05-06'), 2000.25, 2003.21, 2231.23, 5000.23, NULL
) , (
	3, '2022-05-06', 3, '2018-04-06', '2022-05-06', DATEDIFF(DAY, '2018-04-06', '2022-05-06'), 3000.25, 3003.21, 3231.23, 6000.23, NULL
)

GO

CREATE TABLE [Occupancies] (
    [Id] INT PRIMARY KEY IDENTITY NOT NULL
    , [EmpoyeeId] INT FOREIGN KEY REFERENCES [Employees]([Id])
    , [DateOccupied] DATE NOT NULL
    , [AccountNumber] INT FOREIGN KEY REFERENCES [Customers]([Id])
    , [RoomNumber] INT NOT NULL
    , [RateApplied] DECIMAL(6, 2) NOT NULL
    , [PhoneCharge] DECIMAL(5, 2) NOT NULL
    , [Notes] NVARCHAR(500)
)

GO

INSERT INTO [Occupancies] 
VALUES (
	1, '2022-05-06', 1, 222, 1000.25, 100.21, NULL
) , (
	2, '2022-05-06', 2, 333, 2000.25, 200.21, NULL
) , (
	3, '2022-05-06', 3, 444, 3000.25, 300.21, NULL
)
