-- Create a new database called 'TableRelations'
-- Connect to the 'master' database to run this snippet
USE [master]

GO

-- Create the new database if it does not exist already
IF NOT EXISTS (
    SELECT [name]
    FROM [sys].[databases]
    WHERE [name] = N'TableRelations'
)

CREATE DATABASE TableRelations

GO

-- Connect to 'TableRelations' database
USE [TableRelations]

GO

-- Create a new table called '[Passports]' in schema '[dbo]'
-- Drop the table `[Persons]` if it already exists
IF OBJECT_ID('[dbo].[Persons]', 'U') IS NOT NULL
DROP TABLE [dbo].[Persons]

GO

-- Drop the table `[Passports]` if it already exists
IF OBJECT_ID('[dbo].[Passports]', 'U') IS NOT NULL
DROP TABLE [dbo].[Passports]

GO

-- Create the table in the specified schema
CREATE TABLE [dbo].[Passports] 
(
    [Id] INT PRIMARY KEY IDENTITY(101, 1) -- Primary Key column
    , [PassportNumber] VARCHAR(10) NOT NULL
)

GO

-- Create a new table called '[Persons]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[Persons]', 'U') IS NOT NULL
DROP TABLE [dbo].[Persons]

GO

-- Create the table in the specified schema
CREATE TABLE [dbo].[Persons] 
(
    [Id] INT PRIMARY KEY IDENTITY -- Primary Key column
    , [FirstName] NVARCHAR(50) NOT NULL
    , [Salary] DECIMAL(7, 2) NOT NULL
    , [PassportID] INT FOREIGN KEY REFERENCES [dbo].[Passports]([Id]) UNIQUE
)

GO

-- Insert rows into table 'Passports' in schema '[dbo]'
INSERT INTO [dbo].[Passports]
( -- Columns to insert data into
    [PassportNumber]
)
VALUES
( -- First row: values for the columns in the list below
    'N34FG21B'
),
( -- Second row: values for the columns in the list below
    'K65LO4R7'
),
( -- Third row: values for the colums in the list below
    'ZE657QP2'
)

GO

-- Insert rows into table 'Persons' in schema '[dbo]'
INSERT INTO [dbo].[Persons]
( -- Columns to insert data into
    [FirstName]
    , [Salary]
    , [PassportID]
)
VALUES
( -- First row: values for the columns in the list below
    'Roberto'
    , 43300.00
    , 102
),
( -- Second row: values for the columns in the list below
    'Tom'
    , 56100.00
    , 103
),
( -- Third row: values for the colums in the list below
    'Yana'
    , 60200.00
    , 101
)

GO
