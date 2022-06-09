-- Connect to the 'SoftUni' database for execution of this query
USE [SoftUni]

GO

-- Select the count of everything 'Employees' table
SELECT COUNT(*) AS [Count]
  FROM [Employees]

-- Filter where the employees do not have a manager
 WHERE [ManagerID] IS NULL

GO
