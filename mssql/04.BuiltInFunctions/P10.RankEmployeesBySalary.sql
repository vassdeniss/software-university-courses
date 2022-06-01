-- Connect to the 'SoftUni' database to run this snippet
USE [SoftUni]

GO

-- Select the id, first name, last name and salary from the 'Employees' table
-- Make a dense rank that partitions by salary and orders by the employee id
SELECT [EmployeeID]
    , [FirstName]
    , [LastName]
    , [Salary]
    , DENSE_RANK() OVER(PARTITION BY [Salary] ORDER BY [EmployeeID])
FROM [Employees]
-- Filter where the salary is between 10000 and 50000
-- Order by salary descending
WHERE [Salary] BETWEEN 10000 AND 50000
ORDER BY [Salary] DESC

GO
