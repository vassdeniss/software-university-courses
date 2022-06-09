-- Connect to the 'SoftUni' database for execution of this query
USE [SoftUni]

GO

-- Select the department id from the 'Employees' table
-- Select the sum of all salaries
  SELECT [DepartmentId]
       , SUM([Salary]) AS [TotalSalary]
    FROM [Employees]

-- Group by the department id
GROUP BY [DepartmentID]

-- Order by the department id ascending
ORDER BY [DepartmentID] ASC

GO  
