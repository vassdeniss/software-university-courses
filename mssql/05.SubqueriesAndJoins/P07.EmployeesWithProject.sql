-- Connect to the 'SoftUni' database for execution of this query
USE [SoftUni]

GO

-- Select the top 5 results with the employee id and the first name from the 'Employees' table
-- Select the project name from the 'Projects' table
  SELECT TOP 5
	     [e].[EmployeeID]
	   , [e].[FirstName]
	   , [p].[Name]
    FROM [Employees] AS [e]

-- Inner join the 'Employees' table with the 'EmployeesProjects' table
    JOIN [EmployeesProjects] AS [ep] 
      ON [e].[EmployeeID] = [ep].[EmployeeID]

-- Inner join the newly created table with the 'Projects' table
	JOIN [Projects] AS [p]
	  ON [ep].[ProjectID] = [p].[ProjectID]

-- Filter where the project start date is after the 13th of August 2002 
-- and where the project has not ended yet
   WHERE [p].[StartDate] > '2002-08-13'
	 AND [p].[EndDate] IS NULL

-- Order the results by the employee id ascending
ORDER BY [e].[EmployeeID] ASC

GO
