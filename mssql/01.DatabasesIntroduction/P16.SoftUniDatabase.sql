CREATE DATABASE [SoftUni] 

USE [SoftUni]

CREATE TABLE [Towns] (
	[Id] INT PRIMARY KEY IDENTITY
	, [Name] NVARCHAR(150) NOT NULL
)

CREATE TABLE [Addresses] (
	[Id] INT PRIMARY KEY IDENTITY
	, [AddressText] NVARCHAR(200) NOT NULL
	, [TownId] INT FOREIGN KEY REFERENCES [Towns]([Id])
)

CREATE TABLE [Departments] (
	[Id] INT PRIMARY KEY IDENTITY
	, [Name] NVARCHAR(60) NOT NULL
)

CREATE TABLE [Employees] (
	[Id] INT PRIMARY KEY IDENTITY
	, [FirstName] NVARCHAR(50) NOT NULL
	, [MiddleName] NVARCHAR(50) NOT NULL
	, [LastName] NVARCHAR(50) NOT NULL
	, [JobTitle] NVARCHAR(30) NOT NULL
	, [DepartmentId] INT FOREIGN KEY REFERENCES [Departments]([Id])
	, [HireDate] DATE NOT NULL
	, [Salary] DECIMAL(6, 2) NOT NULL
	, [AddressId] INT
)
