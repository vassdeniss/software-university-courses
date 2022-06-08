-- Connect to the 'SoftUni' database for execution of this query
USE [SoftUni]

GO

-- Select top 50 records that include the employee id from the 'Employees' table
-- Create a column as 'EmployeeName' that concats the first and last name from the left 'Employees' table
-- Create a column as 'ManagerName' that concats the first and last name from the right 'Employees' table
-- Select the department name from the 'Departments' table
  SELECT TOP 50
         [e].[EmployeeID]
	   , CONCAT([e].[FirstName], ' ', [e].[LastName]) AS [EmployeeName]
	   , CONCAT([em].[FirstName], ' ', [em].[LastName]) AS [ManagerName]
	   , [d].[Name] AS [DepartmentName]
    FROM [Employees] AS [e]

-- Inner join the 'Employees' table with itself
    JOIN [Employees] AS [em] 
      ON [e].[ManagerID] = [em].[EmployeeID]

-- Inner join the newly created table with the 'Departments' table
    JOIN [Departments] AS [d]
	  ON [e].[DepartmentID] = [d].[DepartmentID]

-- Order by the employee id ascending
ORDER BY [e].[EmployeeID] ASC

GO
