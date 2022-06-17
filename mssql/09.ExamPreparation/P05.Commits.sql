-- Connect to the 'Bitbucket' database for execution of this query
USE [Bitbucket]

GO

-- Select the id, message, repository id and contributor id from the 'Commits' table
  SELECT [Id]
       , [Message]
	   , [RepositoryId]
	   , [ContributorId]
    FROM [Commits]

-- Order by the id ascending
-- then by message ascending
-- then by repository id ascending
-- then by contributor id ascending
ORDER BY [Id] ASC
       , [Message] ASC
	   , [RepositoryId] ASC
	   , [ContributorId] ASC

GO
