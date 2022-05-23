GO

USE [SoftUni]

GO

UPDATE [Employees]
SET [Salary] *= 1.12
WHERE [DepartmentID] = 1
	OR [DepartmentID] = 2
	OR [DepartmentID] = 4
	OR [DepartmentID] = 11

GO

SELECT [Salary]
FROM [Employees]
