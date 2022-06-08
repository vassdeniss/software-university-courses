-- Connect to the 'SoftUni' database for execution of this query
USE [SoftUni]

GO

-- Select the employee id and the first name from the 'Employees' table
-- Create a new column 'ProjectName' where if the projects start year is 2005 or later label null
-- else leave the project name
SELECT [e].[EmployeeID]
	 , [e].[FirstName]
	 , CASE WHEN DATEPART(YEAR, [p].[StartDate]) >= 2005 
			THEN NULL
			ELSE [p].[Name]
	   END AS [ProjectName]
  FROM [Employees] AS [e]

-- Inner join the 'Employees' table with the 'EmployeesProjects' table
  JOIN [EmployeesProjects] AS [ep] 
    ON [e].[EmployeeID] = [ep].[EmployeeID]

-- Inner join the newly created table with the 'Projects' table
  JOIN [Projects] AS [p]
	ON [ep].[ProjectID] = [p].[ProjectID]

-- Filter where the employee id is 24
 WHERE [e].[EmployeeID] = 24

GO
