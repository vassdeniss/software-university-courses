GO

USE [SoftUni]

GO

SELECT [FirstName]
	, [LastName]
FROM [Employees]
WHERE [ManagerID] IS NULL
