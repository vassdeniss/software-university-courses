-- Connect to the 'SoftUni' database for execution of this query
USE [SoftUni]

GO

-- Select the department id from the 'Employees' table
-- Select the sum of all salaries
  SELECT [DepartmentId]
       , MIN([Salary]) AS [MinimumSalary]
    FROM [Employees]

-- Filter where the hire date is after 1st of January 2000
   WHERE [HireDate] > '01/01/2000'

-- Group by the department id
GROUP BY [DepartmentID]

-- Where the groups have the department id in 2, 5 or 7
  HAVING [DepartmentID] IN (2, 5, 7)

GO  
