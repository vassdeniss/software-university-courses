-- Connect to the 'SoftUni' database to run this snippet
USE [SoftUni]

GO

-- Select the first and last names of the employees
-- from the employees table
SELECT [FirstName]
    , [LastName]
FROM [Employees]
-- where the job title does not contain engineer in it
WHERE [JobTitle] NOT LIKE '%engineer%'

GO
