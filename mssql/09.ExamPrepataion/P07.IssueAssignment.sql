-- Connect to the 'Bitbucket' database for execution of this query
USE [Bitbucket]

GO

-- Select the id from the 'Files' table
-- concat the username and title of an issue
  SELECT [i].[Id]
       , CONCAT([u].[Username], ' : ', [i].[Title]) AS [IssueAssignee] 
    FROM [Issues] AS [i]

-- Inner join the 'Issues' table with the 'Users' table
    JOIN [Users] AS [u] ON [i].[AssigneeId] = [u].[Id]

-- Oder by the id descending
-- then by assignee id ascending
ORDER BY [i].[Id] DESC
       , [i].[AssigneeId] ASC

GO
