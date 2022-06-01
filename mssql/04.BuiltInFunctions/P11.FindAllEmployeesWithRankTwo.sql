-- Connect to the 'SoftUni' database to run this snippet
USE [SoftUni]

GO

-- Select everything from the subquery
SELECT *

FROM 
(
    -- Select the id, first name, last name and salary from the 'Employees' table
    -- Make a dense rank that partitions by salary and orders by the employee id
    SELECT [EmployeeID]
        , [FirstName]
        , [LastName]
        , [Salary]
        , DENSE_RANK() OVER
        (
            PARTITION BY [Salary] 
            ORDER BY [EmployeeID]
        ) 
        AS [Rank]
    FROM [Employees]
    -- Filter where the salary is between 10000 and 50000
    WHERE [Salary] 
        BETWEEN 10000 AND 50000
) 
AS [RankingSubquery]
-- Filter where the rank is 2
WHERE [Rank] = 2
-- Order by salary descending
ORDER BY [Salary] DESC

GO
