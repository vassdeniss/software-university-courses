-- Connect to the 'SoftUni' database for execution of this query
USE [SoftUni]

GO

-- Select the employee id and the first and last names and the last name from the 'Employees' table
-- Select the department name from the 'Departments' table as 'DepartmentName'
  SELECT [e].[EmployeeID]
	   , [e].[FirstName]
	   , [e].[LastName]
	   , [d].[Name] AS [DepartmentName]
    FROM [Employees] AS [e]

-- Inner join the 'Employees' table with the 'Department' table
    JOIN [Departments] AS [d] 
      ON [e].[DepartmentID] = [d].[DepartmentID]

-- Filter where the department is 'Sales'
   WHERE [d].[Name] = 'Sales'

-- Order the results by the employee id from the 'Employees' table ascending
ORDER BY [e].[EmployeeID] ASC

GO
