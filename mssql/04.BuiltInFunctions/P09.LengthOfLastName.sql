-- Connect to the 'SoftUni' database to run this snippet
USE [SoftUni]

GO

-- Select the first and last names from the 'Employees' table
SELECT [FirstName]
	, [LastName]
FROM [Employees]
-- Where the last name is exactly 5 letters long
WHERE LEN([LastName]) = 5

GO
