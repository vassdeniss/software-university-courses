-- Connect to the 'SoftUni' database for execution of this query
USE [SoftUni]

GO

-- Select everything into a new table where the salary is higher than 30000
 SELECT *
   INTO [TempNewTable]
   FROM [Employees]
  WHERE [Salary] > 30000

GO

-- Delete from the new table where the manager id is 42
DELETE FROM [TempNewTable]
	  WHERE [ManagerID] = 42

GO

-- Update the new table and increase the salary by 5000
-- where the department id is 1
UPDATE [TempNewTable]
   SET [Salary] += 5000
 WHERE [DepartmentID] = 1

GO

-- Select the department id from the 'TempNewTable' table
-- Select the average salary from the 'TempNewTable' table
  SELECT [DepartmentID] 
       , AVG(Salary) AS AverageSalary
    FROM [TempNewTable]

-- Group the results by the department id
GROUP BY [DepartmentID]

GO
