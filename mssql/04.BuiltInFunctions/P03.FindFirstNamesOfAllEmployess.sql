-- Connect to the 'SoftUni' database to run this snippet
USE [SoftUni]

GO

-- Select the first name of the employees
-- from the employees table
SELECT [FirstName]
FROM [Employees]
-- where the department id is 3 or 10
-- and the year of the hire date is between 1995 and 2005
WHERE [DepartmentID] = 3 
    OR [DepartmentID] = 10
    AND DATEPART(YEAR, [HireDate])
        BETWEEN 1995 AND 2005

GO
