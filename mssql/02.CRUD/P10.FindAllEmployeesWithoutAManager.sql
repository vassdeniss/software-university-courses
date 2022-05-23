USE [SoftUni]

SELECT [FirstName]
	, [LastName]
FROM [Employees]
WHERE [ManagerID] IS NULL
