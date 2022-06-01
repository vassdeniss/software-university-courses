-- Connect to the 'SoftUni' database to run this snippet
USE [SoftUni]

GO

-- Select the first and last names of the employees
-- from the employees table
SELECT [FirstName]
    , [LastName]
FROM [Employees]
-- where the first 2 characters of the first name are 'Sa'
WHERE LEFT([FirstName], 2) = 'Sa'

GO
