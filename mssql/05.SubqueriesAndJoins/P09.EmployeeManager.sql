-- Connect to the 'SoftUni' database for execution of this query
USE [SoftUni]

GO

-- Select the employee id and the first name from the 'Employees' table
-- and the employee id and the first name again from the joined 'Employees' table
SELECT [e].[EmployeeID]
	 , [e].[FirstName]
	 , [em].[EmployeeID] AS [ManagerID]
	 , [em].[FirstName] AS [ManagerName]
  FROM [Employees] AS [e]

-- Inner join the 'Employees' table with itself
  JOIN [Employees] AS [em] 
    ON [e].[ManagerID] = [em].[EmployeeID]

-- Filter where the manager id is 3 or 7
 WHERE [e].[ManagerID] IN (3, 7)

GO
