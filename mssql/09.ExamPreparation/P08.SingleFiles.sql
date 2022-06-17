-- Connect to the 'Bitbucket' database for execution of this query
USE [Bitbucket]

GO

-- Select the id and name from the 'Files' table
-- concat the file size with 'KB'
   SELECT [f].[Id]
        , [f].[Name]
        , CONCAT([f].[Size], 'KB') AS [Size]
     FROM [Files] AS [f]

-- Left join the 'Files' table with itself
LEFT JOIN [Files] AS [fi]
       ON [f].[Id] = [fi].[ParentId]

-- Filter where the parent id is null
    WHERE [fi].[ParentId] IS NULL

-- Oder by the id ascending
-- then by name ascending
-- then by size descending
ORDER BY [f].[Id] ASC
       , [f].[Name] ASC
	   , [f].[Size] DESC

GO
