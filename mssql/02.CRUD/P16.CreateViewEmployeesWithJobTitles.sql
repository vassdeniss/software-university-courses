GO

USE [SoftUni]

GO

CREATE VIEW [V_EmployeeNameJobTitle]
AS SELECT CONCAT (
	[FirstName]
	, ' ' 
	, [MiddleName]
	, ' '
	, [LastName]
) AS [Full Name]
	, [JobTitle]
FROM [Employees]
