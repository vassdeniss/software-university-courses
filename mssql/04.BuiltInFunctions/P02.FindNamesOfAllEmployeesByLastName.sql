-- Connect to the 'SoftUni' database to run this snippet
USE [SoftUni]

GO

-- Select the first and last names of the employees
-- from the employees table
SELECT [FirstName]
    , [LastName]
FROM [Employees]
-- where the index of 'ei' exists in the last name i.e. is not zero
WHERE CHARINDEX('ei', [LastName]) <> 0

GO
