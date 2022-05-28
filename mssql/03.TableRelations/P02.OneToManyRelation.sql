-- Connect to the 'TableRelations' database
USE [TableRelations]

GO

-- Create a new table called '[Manufacturers]' in schema '[dbo]'
-- Drop the table `[Models]` if it already exists
IF OBJECT_ID('[dbo].[Models]', 'U') IS NOT NULL
DROP TABLE [dbo].[Models]

GO

-- Drop the table `[Manufacturers]` if it already exists
IF OBJECT_ID('[dbo].[Manufacturers]', 'U') IS NOT NULL
DROP TABLE [dbo].[Manufacturers]

GO

-- Create the table in the specified schema
CREATE TABLE [dbo].[Manufacturers] 
(
    [Id] INT PRIMARY KEY IDENTITY -- Primary Key column
    , [Name] NVARCHAR(30) NOT NULL
    , [EstablishedOn] DATE NOT NULL
)

GO

-- Create a new table called '[Models]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[Models]', 'U') IS NOT NULL
DROP TABLE [dbo].[Models]

GO

-- Create the table in the specified schema
CREATE TABLE [dbo].[Models] 
(
    [Id] INT PRIMARY KEY IDENTITY(101, 1) -- Primary Key column
    , [Name] NVARCHAR(30) NOT NULL
    , [ManufacturerID] INT FOREIGN KEY REFERENCES [dbo].[Manufacturers]([Id])
)

GO

-- Insert rows into table 'Manufacturers' in schema '[dbo]'
INSERT INTO [dbo].[Manufacturers]
( -- Columns to insert data into
    [Name]
    , [EstablishedOn]
)
VALUES
( -- First row: values for the columns in the list below
    'BMW'
    , '1916/03/07'
),
( -- Second row: values for the columns in the list below
    'Tesla'
    , '2003/01/01'
),
( -- Third row: values for the colums in the list below
    'Lada'
    , '1966/05/01'
)

GO

-- Insert rows into table 'Models' in schema '[dbo]'
INSERT INTO [dbo].[Models]
( -- Columns to insert data into
    [Name]
    , [ManufacturerID]
)
VALUES
( -- First row: values for the columns in the list below
    'X1'
    , 1
),
( -- Second row: values for the columns in the list below
    'i6'
    , 1
),
( -- Third row: values for the colums in the list below
    'Model S'
    , 2
),
( -- Fourth row: values for the colums in the list below
    'Model X'
    , 2
),
( -- Fifth row: values for the colums in the list below
    'Model 3'
    , 2
),
( -- Sixth row: values for the colums in the list below
    'Nova'
    , 3
)

GO
