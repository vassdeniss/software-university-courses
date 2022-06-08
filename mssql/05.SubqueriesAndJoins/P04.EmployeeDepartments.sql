-- Connect to the 'SoftUni' database for execution of this query
USE [SoftUni]

GO

-- Select the first 5 records that include the employee id, the first name and the salary from the 'Employees' table
-- Select the department name from the 'Departments' table as 'DepartmentName'
  SELECT TOP 5
	     [e].[EmployeeID]
	   , [e].[FirstName]
	   , [e].[Salary]
	   , [d].[Name] AS [DepartmentName]
    FROM [Employees] AS [e]

-- Inner join the 'Employees' table with the 'Department' table
    JOIN [Departments] AS [d] 
      ON [e].[DepartmentID] = [d].[DepartmentID]

-- Filter where the employee salary is higher than 15000
   WHERE [e].[Salary] > 15000

-- Order the results by the department id from the 'Departments' table ascending
ORDER BY [d].[DepartmentID] ASC

GO
