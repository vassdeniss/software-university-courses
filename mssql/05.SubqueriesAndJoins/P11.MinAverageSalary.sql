-- Connect to the 'SoftUni' database for execution of this query
USE [SoftUni]

GO

-- Select the first record from a custom column that has the average
-- employees salary from all departments as 'AverageSalary' from the 'Employees' table
SELECT TOP 1 
	 AVG([Salary]) AS [AverageSalary]
    FROM [Employees] AS [e] 

-- Inner join the 'Employees' table with the 'Departments' table
    JOIN [Departments] AS [d] 
      ON [d].[DepartmentID] = [e].[DepartmentID]

-- Group the results by the department
GROUP BY [e].[DepartmentID]

-- Order the results by the average salary ascending
ORDER BY [AverageSalary] ASC

GO
