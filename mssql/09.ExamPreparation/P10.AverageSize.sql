-- Connect to the 'Bitbucket' database for execution of this query
USE [Bitbucket]

GO

-- Select the username from the 'Users' table
-- Select the average size of each file from the 'Files' table
  SELECT [u].[Username]
        , AVG([f].[Size]) AS [Size] 
    FROM [Users] AS [u]

-- Inner join the 'Users' table with the 'Commits' table
    JOIN [Commits] AS [c]
      ON [u].[Id] = [c].[ContributorId]

-- Inner join the 'Commits' table with the 'Files' table
    JOIN [Files] AS [f]
      ON [c].[Id] = [f].[CommitId]

-- Group the results by the users username
GROUP BY [u].[Username]

-- Order the results by the average file size descending
-- then by the users username ascending
ORDER BY AVG([f].[Size]) DESC
       , [u].[Username] ASC

GO
