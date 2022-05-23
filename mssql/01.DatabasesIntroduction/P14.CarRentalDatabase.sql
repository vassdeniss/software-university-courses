GO

CREATE DATABASE [CarRental]

GO

USE [CarRental]

GO

CREATE TABLE [Categories] (
	[Id] INT PRIMARY KEY IDENTITY
	, [CategoryName] NVARCHAR(200) NOT NULL UNIQUE
	, [DailyRate] DECIMAL(5, 2) NOT NULL
	, [WeeklyRate] DECIMAL(6, 2) NOT NULL
	, [MonthlyRate] DECIMAL(7, 2) NOT NULL
	, [WeekendRate] DECIMAL(5, 2) NOT NULL
)

GO

CREATE TABLE [Cars] (
	[Id] INT PRIMARY KEY IDENTITY
	, [PlateNumber] VARCHAR(10) NOT NULL UNIQUE
	, [Manufacturer] NVARCHAR(60) NOT NULL
	, [Model] VARCHAR(50) NOT NULL
	, [CarYear] VARCHAR(4) NOT NULL
	, [CategoryId] INT FOREIGN KEY REFERENCES [Categories]([Id])
	, [Doors] TINYINT NOT NULL
	, [Picture] VARBINARY(MAX)
	, CHECK (DATALENGTH([Picture]) <= 100000000)
	, [Condition] VARCHAR(30)
	, [Available] BIT NOT NULL
)

GO

CREATE TABLE [Employees] (
	[Id] INT PRIMARY KEY IDENTITY
	, [FirstName] VARCHAR(50) NOT NULL
	, [LastName] VARCHAR(50) NOT NULL
	, [Title] VARCHAR(50) NOT NULL
	, [Notes] VARCHAR(500)
)

GO

CREATE TABLE [Customers] (
	[Id] INT PRIMARY KEY IDENTITY
	, [DriverLicenceNumber] VARCHAR(20) NOT NULL
	, [FullName] VARCHAR(150) NOT NULL
	, [Address] VARCHAR(200) NOT NULL
	, [City] VARCHAR(50) NOT NULL
	, [ZIPCode] VARCHAR(4) NOT NULL
	, [Notes] VARCHAR(500)
)

GO

CREATE TABLE [RentalOrders] (
	[Id] INT PRIMARY KEY IDENTITY
	, [EmployeeId] INT FOREIGN KEY REFERENCES [Employees]([Id])
	, [CustomerId] INT FOREIGN KEY REFERENCES [Customers]([Id])
	, [CarId] INT FOREIGN KEY REFERENCES [Cars]([Id])
	, [TankLevel] INT NOT NULL
	, [KilometrageStart] INT NOT NULL
	, [KilometrageEnd] INT NOT NULL
	, [TotalKilometrage] INT NOT NULL
	, [StartDate] DATE NOT NULL
	, [EndDate] DATE NOT NULL
	, [TotalDays] INT NOT NULL
	, [RateApplied] DECIMAL(7, 2) NOT NULL
	, [TaxRate] DECIMAL(9, 2) NOT NULL
	, [OrderStatus] VARCHAR(50) NOT NULL
	, [Notes] VARCHAR(500)
)

GO

INSERT INTO [Categories] (
	[CategoryName]
	, [DailyRate]
	, [WeeklyRate]
	, [MonthlyRate]
	, [WeekendRate]
)
VALUES (
	'A', 10.00, 68.80, 277.55, 35.00
) , (
	'B', 20.00, 108.80, 477.55, 65.00
) , (
	'C', 25.00, 138.80, 577.55, 95.00
)

GO

INSERT INTO [Cars] (
	[PlateNumber]
	, [Manufacturer]
	, [Model]
	, [CarYear]
	, [CategoryId]
	, [Doors]
	, [Condition]
	, [Available]
)
VALUES (
	'A 2323 AB', 'MAN', '350', 2010, 1, 3, 'Broken', 0
) , (
	'B 1818 CB', 'VW', 'Caddy', 2020, 3, 5, 'Amazing', 1
) , (
	'C 1313 KX', 'KIA', 'Optima', 2018, 2, 4, 'Good', 1
)

GO

INSERT INTO [Employees] (
	[FirstName]
	, [LastName]
	, [Title]
)
VALUES (
	'Denis', 'Vasilev', 'Manager'
) , (
	'Andrej', 'hostovecky', 'Supervisor'
) , (
	'Yu', 'Narukami', 'driver'
)

GO

INSERT INTO [Customers] (
	[DriverLicenceNumber]
	, [FullName]
	, [Address]
	, [City]
	, [ZIPCode]
)
VALUES (
	28252, 'Jane1 Doe1', 'Sofia', 'Sofia', 1303
) , (
	28253, 'Jane2 Doe2', 'Sofia', 'Sofia', 1303
) , (
	28254, 'Jane3 Doe3', 'Sofia', 'Sofia', 1303
)

GO

INSERT INTO [RentalOrders] (
	[EmployeeId]
	, [CustomerId]
	, [CarId]
	, [TankLevel]
	, [KilometrageStart]
	, [KilometrageEnd]
	, [TotalKilometrage]
	, [StartDate]
	, [EndDate]
	, [TotalDays]
	, [RateApplied]
	, [TaxRate]
	, [OrderStatus]
)
VALUES (
	1, 1, 1, 20, 100, 200, 100, '1998-01-01', '1998-01-03', 3, 2.33, 253.42, 'Received'
) , (
	2, 2, 2, 40, 100, 200, 100, '1998-01-01', '1998-01-03', 3, 2.33, 453.42, 'In Progress'
) , (
	3, 3, 3, 80, 100, 200, 100, '1998-01-01', '1998-01-03', 3, 2.33, 553.42, 'Not Started'
)
