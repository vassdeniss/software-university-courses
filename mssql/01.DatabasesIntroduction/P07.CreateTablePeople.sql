GO

USE [Minions]

GO

CREATE TABLE [People] (
    [Id] INT PRIMARY KEY IDENTITY
    , [Name] NVARCHAR(200) NOT NULL
    , [Picture] VARBINARY(MAX)
    , CHECK (DATALENGTH([Picture]) <= 2000000)
    , [Height] DECIMAL(3, 2)
    , [Weight] DECIMAL(5, 2)
    , [Gender] CHAR(1) NOT NULL
    , CHECK ([Gender] = 'm' OR [Gender] = 'f')
    , [Birthdate] DATE NOT NULL
    , [Biography] NVARCHAR(MAX)
)

GO

INSERT INTO [People] (
    [Name]
	, [Height]
	, [Weight]
	, [Gender]
	, [Birthdate]
)
VALUES (
    'Kevin', 1.77, 75.2, 'm', '1998-05-25'
) , (
    'Ben', 1.50, 90.0, 'm', '2001-02-01'
) , (
    'Denis', 1.83, 64.8, 'm', '2003-10-06'
) , (
    'Andrej', 1.75, 65.1, 'm', '2003-02-03'
) , (
    'Narumaki', 1.80, 63.0, 'm', '2001-01-30'
)
