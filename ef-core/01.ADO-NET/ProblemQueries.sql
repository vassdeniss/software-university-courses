-- Create database 'MinionsDB'
CREATE DATABASE [MinionsDB]

GO

-- Connect to 'MinionsDB' for execution of this query
USE [MinionsDB]

GO

-- Create table 'Countries'
CREATE TABLE [Countries] (
	  [Id] INT PRIMARY KEY IDENTITY
	, [Name] VARCHAR(50)
)

GO

-- Create table 'Towns'
CREATE TABLE [Towns] (
	  [Id] INT PRIMARY KEY IDENTITY
	, [Name] VARCHAR(50)
	, [CountryCode] INT FOREIGN KEY REFERENCES [Countries](Id)
)

GO

-- Create table 'Minions'
CREATE TABLE [Minions] (
	  [Id] INT PRIMARY KEY IDENTITY
	, [Name] VARCHAR(30)
	, [Age] INT
	, [TownId] INT FOREIGN KEY REFERENCES [Towns](Id)
)

GO

-- Create table 'EvilnessFactors'
CREATE TABLE [EvilnessFactors] (
	  [Id] INT PRIMARY KEY IDENTITY
	, [Name] VARCHAR(50)
)

GO

-- Create table 'Villains'
CREATE TABLE [Villains] (
	  [Id] INT PRIMARY KEY IDENTITY
	, [Name] VARCHAR(50)
	, [EvilnessFactorId] INT FOREIGN KEY REFERENCES [EvilnessFactors](Id)
)

GO

-- Create table 'MinionsVillains'
CREATE TABLE [MinionsVillains] (
	  [MinionId] INT FOREIGN KEY REFERENCES [Minions](Id)
	, [VillainId] INT FOREIGN KEY REFERENCES [Villains](Id)
	, CONSTRAINT PK_MinionsVillains PRIMARY KEY ([MinionId], [VillainId])
)

GO

-- Insert dummy data
INSERT INTO [Countries] ([Name]) 
     VALUES ('Bulgaria')
	      , ('England')
		  , ('Cyprus')
		  , ('Germany')
		  , ('Norway')

GO

INSERT INTO [Towns] ([Name], [CountryCode]) 
     VALUES ('Plovdiv', 1)
	      , ('Varna', 1)
		  , ('Burgas', 1)
		  , ('Sofia', 1)
		  , ('London', 2)
		  , ('Southampton', 2)
		  , ('Bath', 2)
		  , ('Liverpool', 2)
		  , ('Berlin', 3)
		  , ('Frankfurt', 3)
		  , ('Oslo', 4)

GO

INSERT INTO [Minions] ([Name], [Age], [TownId])
     VALUES ('Bob', 42, 3)
	      , ('Kevin', 1, 1)
		  , ('Bob ', 32, 6)
		  , ('Simon', 45, 3)
		  , ('Cathleen', 11, 2)
		  , ('Carry ', 50, 10)
		  , ('Becky', 125, 5)
		  , ('Mars', 21, 1)
		  , ('Misho', 5, 10)
		  , ('Zoe', 125, 5)
		  , ('Json', 21, 1)

GO

INSERT INTO [EvilnessFactors] ([Name]) 
     VALUES ('Super good')
		  , ('Good')
		  , ('Bad')
		  , ('Evil')
		  , ('Super evil')

GO

INSERT INTO [Villains] ([Name], [EvilnessFactorId]) 
     VALUES ('Gru', 2)
	      , ('Victor', 1)
		  , ('Jilly', 3)
		  , ('Miro', 4)
		  , ('Rosen', 5)
		  , ('Dimityr', 1)
		  , ('Dobromir', 2)

GO

INSERT INTO [MinionsVillains] ([MinionId], [VillainId]) 
     VALUES (4, 2)
	      , (1, 1)
		  , (5, 7)
		  , (3, 5)
		  , (2, 6)
		  , (11, 5)
		  , (8, 4)
		  , (9, 7)
		  , (7, 1)
		  , (1, 3) 
		  , (7, 3)
		  , (5, 3)
		  , (4, 3)
		  , (1, 2)
		  , (2, 1)
		  , (2, 7)

GO

-- Problem 02 - Villains Names
  SELECT [v].[Name]
       , COUNT([mv].[VillainId]) AS MinionsCount  
    FROM [Villains] AS [v] 
    JOIN [MinionsVillains] AS [mv] 
	  ON [v].[Id] = [mv].[VillainId] 
GROUP BY [v].[Name] 
  HAVING COUNT([mv].[VillainId]) > 3 
ORDER BY [MinionsCount] DESC

GO

-- Problem 03 - Minion Names

-- Villain Name Query
SELECT [Name] 
  FROM [Villains] 
 WHERE [Id] = @villainId

GO

-- Minions Query
   SELECT [m].[Name]
        , [m].[Age]
     FROM [Villains] AS [v]
LEFT JOIN [MinionsVillains] AS [mv]
       ON [v].[Id] = [mv].[VillainId]
LEFT JOIN [Minions] AS [m]
       ON [m].[Id] = [mv].[MinionId]
    WHERE [mv].[VillainId] = @villainId
 ORDER BY [m].[Name]

GO

-- Problem 04 - Add Minion

-- Helper Method 01 Town Id Query
SELECT [Id] 
  FROM [Towns] 
 WHERE [Name] = @townName

GO

-- Helper Method 01 Add Town Query
INSERT INTO [Towns] ([Name]) 
     VALUES (@townName)

GO

-- Helper Method 02 Villain Id Query
SELECT [Id] 
  FROM [Villains] 
 WHERE [Name] = @name

GO

-- Helper Method 02 Evilness Factor Query
SELECT [Id] 
  FROM [EvilnessFactors] 
 WHERE [Name] = 'Evil'

GO

-- Helper Method 02 Insert Villain Query
INSERT INTO [Villains] ([Name], [EvilnessFactorId])
     VALUES (@villainName, @evilnessFactorId)

GO

-- Helper Method 03 Add Minion Query
INSERT INTO [Minions] ([Name], [Age], [TownId]) 
     VALUES (@name, @age, @townId)

GO

-- Helper Method 03 Added Minion Id Query
SELECT [Id]
  FROM [Minions]
 WHERE [Name] = @name 
   AND [Age] = @age 
   AND [TownId] = @townId

GO

-- Problem 04 Add Minion To Villain Query
INSERT INTO [MinionsVillains] ([MinionId], [VillainId]) 
     VALUES (@minionId, @villainId)

GO

-- Problem 05 - Change Town Names Casing

-- Update Towns Query
UPDATE [Towns]
   SET [Name] = UPPER([Name])
 WHERE [CountryCode] = (
                        SELECT [c].[Id] 
						  FROM [Countries] AS [c] 
						 WHERE [c].[Name] = @countryName
					   )

GO

-- Get Changed Towns Query
 SELECT [t].[Name] 
   FROM [Towns] as [t]
   JOIN [Countries] AS [c] 
     ON [c].[Id] = [t].[CountryCode]
  WHERE [c].[Name] = @countryName

GO

-- Problem 06 - Remove Villains

-- Villains Name Query
SELECT [Name] 
  FROM [Villains] 
 WHERE [Id] = @villainId

GO

-- Release Minions Query
DELETE FROM [MinionsVillains] 
      WHERE [VillainId] = @villainId

GO

-- Delete Villain Query
DELETE FROM [Villains]
      WHERE [Id] = @villainId

GO

-- Problem 07 - Print All Minions

-- Select Minions Query
SELECT [Name] 
  FROM [Minions]

GO

-- Problem 8 - Increase Minion Age

-- Update Minions By Id Query
 UPDATE [Minions]
    SET [Name] = UPPER(LEFT([Name], 1)) + SUBSTRING([Name], 2, LEN([Name]))
	  , [Age] += 1
  WHERE [Id] = @id

GO

-- Get Minions Names And Age Query
SELECT [Name]
     , [Age] 
  FROM [Minions]

GO

-- Problem 9
CREATE PROC [usp_GetOlder] 
            @id INT
AS
	UPDATE [Minions]
	   SET [Age] += 1
	 WHERE [Id] = @id

GO

-- Increase Age Query
EXEC [dbo].[usp_GetOlder] @minionId

GO

-- Minion Info Query
SELECT [Name]
     , [Age] 
  FROM [Minions] 
 WHERE [Id] = @minionId

GO
