-- Connect to the 'SoftUni' database to run this snippet
USE [SoftUni]

GO

-- Select the name of all towns from the towns table
SELECT [Name]
FROM [Towns]
-- where the length of the name is 5 or 6
-- order the results alphabetically
WHERE LEN([Name]) = 5
    OR LEN([Name]) = 6
ORDER BY [Name] ASC

GO
