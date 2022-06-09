-- Connect to the 'SoftUni' database for execution of this query
USE [SoftUni]

GO

-- Select the distinct department id and the salary from the suqbuery 'RankSubquery'
SELECT DISTINCT 
       [DepartmentID]
     , [Salary] AS [ThirdHighestSalary] 
FROM (
      -- Select the department id from the 'Employees' table
      -- Select the salary from the 'Employees' table
      -- Select dense rank over the department id, ordered by the salary descending from the 'Employees' table
      SELECT [DepartmentId]
	       , [Salary]
           , DENSE_RANK() OVER (PARTITION BY [DepartmentId] ORDER BY [Salary] DESC) AS [Rank]
        FROM [Employees]
     ) AS [RankSubquery]

-- Filter where the rank is 3
 WHERE [Rank] = 3

GO  
