-- Create a new database called 'University'
-- Connect to the 'master' database to run this snippet
USE [master]

GO

-- Create the new database if it does not exist already
IF NOT EXISTS (
    SELECT [name]
        FROM sys.databases
        WHERE [name] = N'University'
)

CREATE DATABASE [University]

GO

-- Connect to the 'Store' database
USE [University]

GO

-- Create a new table called '[Subjects]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[Subjects]', 'U') IS NOT NULL
DROP TABLE [dbo].[Subjects]

GO

-- Create the table in the specified schema
CREATE TABLE [dbo].[Subjects]
(
    [SubjectID] INT PRIMARY KEY IDENTITY -- Primary Key column
    , [SubjectName] VARCHAR(50) NOT NULL
)

GO

-- Create a new table called '[Majors]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[Majors]', 'U') IS NOT NULL
DROP TABLE [dbo].[Majors]

GO

-- Create the table in the specified schema
CREATE TABLE [dbo].[Majors]
(
    [MajorID] INT PRIMARY KEY IDENTITY -- Primary Key column
    , [Name] NVARCHAR(50) NOT NULL
)

GO

-- Create a new table called '[Students]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[Students]', 'U') IS NOT NULL
DROP TABLE [dbo].[Students]

GO

-- Create the table in the specified schema
CREATE TABLE [dbo].[Students]
(
    [StudentID] INT PRIMARY KEY IDENTITY -- Primary Key column
    , [StudentNumber] VARCHAR(15) NOT NULL
    , [StudentName] NVARCHAR(50) NOT NULL
    , [MajorID] INT FOREIGN KEY REFERENCES [Majors]([MajorID])
)

GO

-- Create a new table called '[Payments]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[Payments]', 'U') IS NOT NULL
DROP TABLE [dbo].[Payments]

GO

-- Create the table in the specified schema
CREATE TABLE [dbo].[Payments]
(
    [PaymentID] INT PRIMARY KEY IDENTITY -- Primary Key column
    , [PaymentDate] DATE NOT NULL
    , [PaymentAmount] DECIMAL(6, 2) NOT NULL
    , [StudentID] INT FOREIGN KEY REFERENCES [Students]([StudentID])
)

GO

-- Create a new table called '[Agenda]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[Agenda]', 'U') IS NOT NULL
DROP TABLE [dbo].[Agenda]

GO

-- Create the table in the specified schema
CREATE TABLE [dbo].[Agenda]
(
    [StudentID] INT FOREIGN KEY REFERENCES [Students]([StudentID])
    , [SubjectID] INT FOREIGN KEY REFERENCES [Subjects]([SubjectID])
    , PRIMARY KEY ([StudentID], [SubjectID]) -- Primary Composite Key column
)

GO
