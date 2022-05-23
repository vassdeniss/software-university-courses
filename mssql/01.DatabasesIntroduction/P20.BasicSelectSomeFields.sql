GO

USE [SoftUni]

GO

SELECT [Name] 
FROM [Towns]
ORDER BY [Name] ASC

GO

SELECT [Name] 
FROM [Departments]
ORDER BY [Name] ASC

GO

SELECT [FirstName]
	, [LastName]
	, [JobTitle]
	, [Salary] 
FROM [Employees]
ORDER BY [Salary] DESC
