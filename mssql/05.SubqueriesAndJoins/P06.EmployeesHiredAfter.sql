-- Connect to the 'SoftUni' database for execution of this query
USE [SoftUni]

GO

-- Select the first and last names and hire date from the 'Employees' table
-- Select the department name from the 'Departments' table
  SELECT [e].[FirstName]
	   , [e].[LastName]
	   , [e].[HireDate]
	   , [d].[Name]
    FROM [Employees] AS [e]

-- Inner join the 'Employees' table with the 'Departments' table
    JOIN [Departments] AS [d] 
      ON [e].[DepartmentID] = [d].[DepartmentID]

-- Filter where the employee hire date is after 1st January 1999 
-- and the department is either 'Sales' or 'Finance' is higher than 15000
   WHERE [e].[HireDate] > '1999-01-01'
    AND ([d].[Name] = 'Sales'
      OR [d].[Name] = 'Finance')

-- Order the results by the hire date ascending
ORDER BY [e].[HireDate] ASC

GO
