-- Connect to the 'SoftUni' database for execution of this query
USE [SoftUni]

GO

-- Select the first 3 records that include the employee id and the first name from the 'Employees' table
     SELECT TOP 3
	          [e].[EmployeeID]
	        , [e].[FirstName]
         FROM [Employees] AS [e]

-- Left join the 'Employees' table with the 'EmployeesProjects' table
    LEFT JOIN [EmployeesProjects] AS [ep] 
           ON [e].[EmployeeID] = [ep].[EmployeeID]

-- Filter where the project id is null
        WHERE [ep].[ProjectID] IS NULL

-- Order the results by the employee id id from the 'Employees' table ascending
     ORDER BY [e].[EmployeeID] ASC

GO
