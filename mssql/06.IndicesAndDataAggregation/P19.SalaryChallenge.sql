-- Connect to the 'SoftUni' database for execution of this query
USE [SoftUni]

GO

-- Select the top 10 records
-- Select the first name from the 'Employees' table
-- Select the last name from the 'Employees' table
-- Select the department id from the 'Employees' table
  SELECT TOP 10
         [FirstName]
       , [LastName]
	   , [DepartmentId]
    FROM [Employees] AS [e]

-- Filter where the salary is higher than the subquery,
-- the subquery returns the average salary of the current employees department
   WHERE [Salary] > (  SELECT AVG([Salary]) 
                         FROM [Employees] 
					    WHERE [e].[DepartmentID] = [DepartmentID]
                     GROUP BY [DepartmentID]
					)

GO
