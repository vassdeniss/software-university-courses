-- Create database 'Bitbucket'
CREATE DATABASE [Bitbucket]

GO

-- Connect to the 'Bitbucket' database for execution of this query
USE [Bitbucket]

GO

-- Create table 'Users'
CREATE TABLE [Users] (
      [Id] INT PRIMARY KEY IDENTITY
    , [Username] VARCHAR(30) NOT NULL
    , [Password] VARCHAR(30) NOT NULL
    , [Email] VARCHAR(50) NOT NULL
)

GO

-- Create table 'Repositories'
CREATE TABLE [Repositories] (
      [Id] INT PRIMARY KEY IDENTITY
    , [Name] VARCHAR(50) NOT NULL
)

GO

-- Create table 'RepositoriesContributors'
CREATE TABLE [RepositoriesContributors] (
      [RepositoryId] INT FOREIGN KEY REFERENCES [Repositories]([Id]) NOT NULL
    , [ContributorId] INT FOREIGN KEY REFERENCES [Users]([Id]) NOT NULL
    , PRIMARY KEY ([RepositoryId], [ContributorId])
)

GO

-- Create table 'Issues'
CREATE TABLE [Issues] (
      [Id] INT PRIMARY KEY IDENTITY
    , [Title] VARCHAR(250) NOT NULL
    , [IssueStatus] VARCHAR(6) NOT NULL
    , [RepositoryId] INT FOREIGN KEY REFERENCES [Repositories] ([Id]) NOT NULL
    , [AssigneeId] INT FOREIGN KEY REFERENCES [Users]([Id]) NOT NULL
)

GO

-- Create table 'Commits'
CREATE TABLE [Commits] (
	  [Id] INT PRIMARY KEY IDENTITY
	, [Message] VARCHAR(255) NOT NULL
	, [IssueId] INT FOREIGN KEY REFERENCES [Issues]([Id])
	, [RepositoryId] INT FOREIGN KEY REFERENCES [Repositories]([Id]) NOT NULL
	, [ContributorId] INT FOREIGN KEY REFERENCES [Users]([Id]) NOT NULL
)

GO

-- Create table 'Files'
CREATE TABLE [Files] (
	  [Id] INT PRIMARY KEY IDENTITY
	, [Name] VARCHAR(100) NOT NULL
	, [Size] DECIMAL(10, 2) NOT NULL
	, [ParentId] INT FOREIGN KEY REFERENCES [Files]([Id])
	, [CommitId] INT FOREIGN KEY REFERENCES [Commits]([Id]) NOT NULL
)

GO
