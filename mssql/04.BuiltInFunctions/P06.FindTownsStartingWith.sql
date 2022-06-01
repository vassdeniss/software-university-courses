-- Connect to the 'SoftUni' database to run this snippet
USE [SoftUni]

GO

-- Select the name of all towns from the towns table
SELECT *
FROM [Towns]
-- where the first letter of the name is m, k, b or e
-- order the results alphabetically
WHERE LEFT([Name], 1) IN ('M', 'K', 'B', 'E')
ORDER BY [Name] ASC

GO
