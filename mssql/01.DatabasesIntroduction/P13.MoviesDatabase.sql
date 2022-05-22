CREATE DATABASE [Movies]

USE [Movies]

CREATE TABLE [Directors] (
	[Id] INT PRIMARY KEY IDENTITY
	, [DirectorName] NVARCHAR(50) NOT NULL
	, [Notes] NVARCHAR(500)
)

CREATE TABLE [Genres] (
	[Id] INT PRIMARY KEY IDENTITY
	, [GenreName] NVARCHAR(30) NOT NULL
	, [Notes] NVARCHAR(500)
)

CREATE TABLE [Categories] (
	[Id] INT PRIMARY KEY IDENTITY
	, [CategoryName] NVARCHAR(30) NOT NULL
	, [Notes] NVARCHAR(500)
)

CREATE TABLE [Movies] (
	[Id] INT PRIMARY KEY IDENTITY
	, [Title] NVARCHAR(50) NOT NULL
	, [DirectorId] INT FOREIGN KEY REFERENCES [Directors](Id)
	, [CopyrightYear] CHAR(4) NOT NULL
	, [Length] INT NOT NULL
	, [GenreId] INT FOREIGN KEY REFERENCES [Genres](Id)
	, [CategoryId] INT FOREIGN KEY REFERENCES [Categories](Id)
	, [Rating] TINYINT
	, CHECK ([Rating] >= 0 AND [Rating] <= 100)
	, [Notes] NVARCHAR(500)
)

INSERT INTO [Directors] (
	[DirectorName]
)
VALUES (
	'Ren'
) , (
	'Makoto'
) , (
	'Denis'
) , (
	'Andrej'
) , (
	'Narumaki'
)

INSERT INTO [Genres] (
	[GenreName]
)
VALUES (
	'Horror'
) , (
	'Science Fiction'
) , (
	'Action'
) , (
	'Animated'
) , (
	'Fantasy'
)

INSERT INTO [Categories] (
	[CategoryName]
)
VALUES (
	'For Kids'
) , (
	'For Adults'
) , (
	'Trending'
) , (
	'Best Selling'
) , (
	'Recommendations'
)

INSERT INTO [Movies] (
	[Title]
	, [DirectorId]
	, [CopyrightYear]
	, [Length]
	, [GenreId]
	, [CategoryId]
	, [Rating]
)
VALUES (
	'Saw X', 1, 2023, 150, 1, 2, 65
) , (
	'Back to the Future IV', 2, 2022, 135, 2, 5, 75
) , (
	'Fast & Furious' ,3 ,2025 ,180 ,3 ,3 ,88
) , (
	'Persona 4 Golden The Movie', 4, 2021, 300, 4, 3, 97
) , (
	'Avatar II', 5, 2024, 120, 5, 1, 77
)
