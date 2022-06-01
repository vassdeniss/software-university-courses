-- Connect to the 'SoftUni' database to run this snippet
USE [SoftUni]

GO

-- Create a view 'V_EmployeesHiredAfter2000'
CREATE VIEW [V_EmployeesHiredAfter2000] AS
-- Select the first and last names from 'Employees'
-- where the hire year is after 2000
SELECT [FirstName]
    , [LastName]
FROM [Employees]
WHERE DATEPART(YEAR, [HireDate]) > 2000

GO
