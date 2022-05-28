-- Connect to the 'TableRelations' database
USE [TableRelations]

GO

-- Create a new table called '[Students]' in schema '[dbo]'
-- Drop the table `[StudentsExams]` if it already exists
IF OBJECT_ID('[dbo].[StudentsExams]', 'U') IS NOT NULL
DROP TABLE [dbo].[StudentsExams]

GO

-- Drop the table `[Students]` if it already exists
IF OBJECT_ID('[dbo].[Students]', 'U') IS NOT NULL
DROP TABLE [dbo].[Students]

GO

-- Create the table in the specified schema
CREATE TABLE [dbo].[Students] 
(
    [Id] INT PRIMARY KEY IDENTITY -- Primary Key column
    , [Name] NVARCHAR(50) NOT NULL
)

GO

-- Create a new table called '[Models]' in schema '[dbo]'
-- Drop the table `[StudentsExams]` if it already exists
IF OBJECT_ID('[dbo].[StudentsExams]', 'U') IS NOT NULL
DROP TABLE [dbo].[StudentsExams]

GO

-- Drop the table `[Exams]` if it already exists
IF OBJECT_ID('[dbo].[Exams]', 'U') IS NOT NULL
DROP TABLE [dbo].[Exams]

GO

-- Create the table in the specified schema
CREATE TABLE [dbo].[Exams] 
(
    [Id] INT PRIMARY KEY IDENTITY(101, 1) -- Primary Key column
    , [Name] NVARCHAR(30) NOT NULL
)

GO

-- Create a new table called '[StudentsExams]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[StudentsExams]', 'U') IS NOT NULL
DROP TABLE [dbo].[StudentsExams]

GO

-- Create the table in the specified schema
CREATE TABLE [dbo].[StudentsExams] 
(
    [StudentID] INT FOREIGN KEY REFERENCES [dbo].[Students]([Id])
    , [ExamID] INT FOREIGN KEY REFERENCES [dbo].[Exams]([Id])
    , PRIMARY KEY ([StudentID], [ExamID]) -- Primary Composite Key column
)

GO

-- Insert rows into table 'Students' in schema '[dbo]'
INSERT INTO [dbo].[Students]
( -- Columns to insert data into
    [Name]
)
VALUES
( -- First row: values for the columns in the list below
    'Mila'
),
( -- Second row: values for the columns in the list below
    'Toni'
),
( -- Third row: values for the colums in the list below
    'Ron'
)

GO

-- Insert rows into table 'Exams' in schema '[dbo]'
INSERT INTO [dbo].[Exams]
( -- Columns to insert data into
    [Name]
)
VALUES
( -- First row: values for the columns in the list below
    'SpringMVC'
),
( -- Second row: values for the columns in the list below
    'Neo4j'
),
( -- Third row: values for the colums in the list below
    'Oracle 11g'
)

GO

-- Insert rows into table 'StudentsExams' in schema '[dbo]'
INSERT INTO [dbo].[StudentsExams]
( -- Columns to insert data into
    [StudentID]
    , [ExamID]
)
VALUES
( -- First row: values for the columns in the list below
    1
    , 101
),
( -- Second row: values for the columns in the list below
    1
    , 102
),
( -- Third row: values for the colums in the list below
    2
    , 101
),
( -- Fourth row: values for the colums in the list below
    3
    , 103
),
( -- Fifth row: values for the colums in the list below
    2
    , 102
),
( -- Sixth row: values for the colums in the list below
    2
    , 103
)

GO
