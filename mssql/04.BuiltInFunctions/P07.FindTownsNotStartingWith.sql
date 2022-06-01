-- Connect to the 'SoftUni' database to run this snippet
USE [SoftUni]

GO

-- Select the name of all towns from the towns table
SELECT *
FROM [Towns]
-- where the first letter of the name is not r, b or d
-- order the results alphabetically
WHERE LEFT([Name], 1) NOT IN ('R', 'B', 'D')
ORDER BY [Name] ASC

GO
