-- Connect to the 'TableRelations' database
USE [TableRelations]

GO

-- Create a new table called '[Teachers]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[Teachers]', 'U') IS NOT NULL
DROP TABLE [dbo].[Teachers]

GO

-- Create the table in the specified schema
CREATE TABLE [dbo].[Teachers] 
(
    [Id] INT PRIMARY KEY IDENTITY(101, 1) -- Primary Key column
    , [Name] NVARCHAR(50) NOT NULL
    , [ManagerID] INT FOREIGN KEY REFERENCES [Teachers]([Id])
)

GO

-- Insert rows into table 'Teachers' in schema '[dbo]'
INSERT INTO [dbo].[Teachers]
( -- Columns to insert data into
    [Name]
    , [ManagerID]
)
VALUES
( -- First row: values for the columns in the list below
    'John'
    , NULL
),
( -- Second row: values for the columns in the list below
    'Maya'
    , 106
),
( -- Third row: values for the colums in the list below
    'Silvia'
    , 106
),
( -- Fourth row: values for the colums in the list below
    'Ted'
    , 105
),
( -- Fifth row: values for the colums in the list below
    'Mark'
    , 101
),
( -- Sixth row: values for the colums in the list below
    'Greta'
    , 101
)

GO
