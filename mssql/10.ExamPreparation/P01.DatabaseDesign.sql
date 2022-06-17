-- Create database 'CigarShop'
CREATE DATABASE [CigarShop]

GO

-- Connect to the 'CigarShop' database for execution of this query
USE [CigarShop]

GO

-- Create table 'Sizes'
CREATE TABLE [Sizes] (
      [Id] INT PRIMARY KEY IDENTITY
    , [Length] INT NOT NULL
	, CHECK([Length] BETWEEN 10 AND 25)
    , [RingRange] DECIMAL(3, 2) NOT NULL
	, CHECK([RingRange] BETWEEN 1.5 AND 7.5)
)

GO

-- Create table 'Tastes'
CREATE TABLE [Tastes] (
      [Id] INT PRIMARY KEY IDENTITY
    , [TasteType] VARCHAR(20) NOT NULL
	, [TasteStrength] VARCHAR(15) NOT NULL
	, [ImageURL] NVARCHAR(100) NOT NULL
)

GO

-- Create table 'Brands'
CREATE TABLE [Brands] (
      [Id] INT PRIMARY KEY IDENTITY
    , [BrandName] VARCHAR(30) UNIQUE NOT NULL
    , [BrandDescription] VARCHAR(MAX)
)

GO

-- Create table 'Cigars'
CREATE TABLE [Cigars] (
	  [Id] INT PRIMARY KEY IDENTITY
	, [CigarName] VARCHAR(80) NOT NULL
	, [BrandId] INT FOREIGN KEY REFERENCES [Brands]([Id]) NOT NULL
	, [TastId] INT FOREIGN KEY REFERENCES [Tastes]([Id]) NOT NULL
	, [SizeId] INT FOREIGN KEY REFERENCES [Sizes]([Id]) NOT NULL
	, [PriceForSingleCigar] MONEY NOT NULL
	, [ImageURL] NVARCHAR(100) NOT NULL
)

GO

-- Create table 'Addresses'
CREATE TABLE [Addresses] (
	  [Id] INT PRIMARY KEY IDENTITY
	, [Town] VARCHAR(30) NOT NULL
	, [Country] NVARCHAR(30) NOT NULL
	, [Street] NVARCHAR(100) NOT NULL
	, [ZIP] VARCHAR(20) NOT NULL
)

GO

-- Create table 'Clients'
CREATE TABLE [Clients] (
	  [Id] INT PRIMARY KEY IDENTITY
	, [FirstName] NVARCHAR(30) NOT NULL
	, [LastName] NVARCHAR(30) NOT NULL
	, [Email] NVARCHAR(50) NOT NULL
	, [AddressId] INT FOREIGN KEY REFERENCES [Addresses]([Id]) NOT NULL
)

GO

-- Create table 'ClientsCigars'
CREATE TABLE [ClientsCigars] (
      [ClientId] INT FOREIGN KEY REFERENCES [Clients]([Id]) NOT NULL
    , [CigarId] INT FOREIGN KEY REFERENCES [Cigars]([Id]) NOT NULL
    , PRIMARY KEY ([ClientId], [CigarId])
)

GO
