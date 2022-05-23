GO

USE [SoftUni]

GO

CREATE VIEW [V_EmployeesSalaries]
AS SELECT [FirstName]
	, [LastName]
	, [Salary]
FROM [Employees]
