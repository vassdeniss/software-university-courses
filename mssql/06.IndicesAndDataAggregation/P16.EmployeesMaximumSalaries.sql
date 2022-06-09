-- Connect to the 'SoftUni' database for execution of this query
USE [SoftUni]

GO

-- Select the department id from the 'Employees' table
-- Select the max salary of all departments
  SELECT [DepartmentId]
       , MAX([Salary]) AS [MaxSalary]
    FROM [Employees]

-- Group by the department id
GROUP BY [DepartmentID]

-- Filter where the groups have salaries that are not between 30k and 70k
  HAVING MAX([Salary]) NOT BETWEEN 30000 AND 70000

GO
