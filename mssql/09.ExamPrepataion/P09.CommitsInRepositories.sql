-- Connect to the 'Bitbucket' database for execution of this query
USE [Bitbucket]

GO

-- Select the id and name from the 'Repositories' table
-- Select the count of the records from the 'Commits' table
SELECT TOP 5
         [r].[Id]
       , [r].[Name]
       , COUNT([c].[Id]) AS [Commits]
    FROM [Commits] AS [c]

-- Inner join the 'Commits' table with the 'Repositories' table
    JOIN [Repositories] AS [r] 
      ON [c].[RepositoryId] = [r].[Id]

-- Inner join the 'Repositories' table with the 'RepositoriesContributors' table
    JOIN [RepositoriesContributors] AS [rc] 
      ON [r].[Id] = [rc].[RepositoryId]

-- Group the results by the id
-- and by the name
GROUP BY [r].[Id]
       , [r].[Name]

-- Oder by commits descending
-- then by the id ascending
-- then by name ascending
ORDER BY [Commits] DESC
       , [r].[Id] ASC
	   , [r].[Name] DESC

GO
