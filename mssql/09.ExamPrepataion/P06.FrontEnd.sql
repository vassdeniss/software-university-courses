-- Connect to the 'Bitbucket' database for execution of this query
USE [Bitbucket]

GO

-- Select the id, name and size from the 'Files' table
  SELECT [Id]
       , [Name]
	   , [Size]
    FROM [Files]

-- Filter where the size is higher than a 1000
-- and where the name contains html
   WHERE [Size] > 1000
	 AND [Name] LIKE '%html%'

-- Order by the size descending
-- then by id ascending
-- then by name ascending
ORDER BY [Size] DESC
	   , [Id] ASC
	   , [Name] ASC

GO
