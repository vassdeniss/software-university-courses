-- Create a new database called 'Store'
-- Connect to the 'master' database to run this snippet
USE [master]

GO

-- Create the new database if it does not exist already
IF NOT EXISTS (
    SELECT [name]
        FROM sys.databases
        WHERE [name] = N'Store'
)

CREATE DATABASE [Store]

GO

-- Connect to the 'Store' database
USE [Store]

GO

-- Create a new table called '[ItemTypes]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[ItemTypes]', 'U') IS NOT NULL
DROP TABLE [dbo].[ItemTypes]

GO

-- Create the table in the specified schema
CREATE TABLE [dbo].[ItemTypes]
(
    [ItemTypeID] INT PRIMARY KEY IDENTITY -- Primary Key column
    , [Name] VARCHAR(50) NOT NULL
)

GO

-- Create a new table called '[Cities]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[Cities]', 'U') IS NOT NULL
DROP TABLE [dbo].[Cities]

GO

-- Create the table in the specified schema
CREATE TABLE [dbo].[Cities]
(
    [CityID] INT PRIMARY KEY IDENTITY -- Primary Key column
    , [Name] VARCHAR(50) NOT NULL
)

GO

-- Create a new table called '[Items]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[Items]', 'U') IS NOT NULL
DROP TABLE [dbo].[Items]

GO

-- Create the table in the specified schema
CREATE TABLE [dbo].[Items]
(
    [ItemID] INT PRIMARY KEY IDENTITY -- Primary Key column
    , [Name] VARCHAR(50) NOT NULL
    , [ItemTypeID] INT FOREIGN KEY REFERENCES [ItemTypes]([ItemTypeID])
)

GO

-- Create a new table called '[Customers]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[Customers]', 'U') IS NOT NULL
DROP TABLE [dbo].[Customers]

GO

-- Create the table in the specified schema
CREATE TABLE [dbo].[Customers]
(
    [CustomerID] INT PRIMARY KEY IDENTITY -- Primary Key column
    , [Name] VARCHAR(50) NOT NULL
    , [Birthday] DATE NOT NULL
    , [CityID] INT FOREIGN KEY REFERENCES [Cities]([CityID])
)

GO

-- Create a new table called '[Orders]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[Orders]', 'U') IS NOT NULL
DROP TABLE [dbo].[Orders]

GO

-- Create the table in the specified schema
CREATE TABLE [dbo].[Orders]
(
    [OrderID] INT PRIMARY KEY IDENTITY -- Primary Key column
    , [CustomerID] INT FOREIGN KEY REFERENCES [Customers]([CustomerID])
)

GO

-- Create a new table called '[OrderItems]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[OrderItems]', 'U') IS NOT NULL
DROP TABLE [dbo].[OrderItems]

GO

-- Create the table in the specified schema
CREATE TABLE [dbo].[OrderItems]
(
    [OrderID] INT FOREIGN KEY REFERENCES [Orders]([OrderID])
    , [ItemID] INT FOREIGN KEY REFERENCES [Items]([ItemID])
    , PRIMARY KEY ([OrderID], [ItemID]) -- Primary Composite Key column
)

GO
