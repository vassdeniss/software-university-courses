GO

USE [SoftUni]

GO

SELECT CONCAT (
	[FirstName]
	, '.'
	, [LastName]
	, '@softuni.bg'
) AS [Full Email Address]
FROM [Employees]
