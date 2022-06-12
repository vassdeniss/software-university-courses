-- Connect to the 'SoftUni' database for execution of this query
USE [SoftUni]

GO

-- Create or alter a procedure
CREATE OR ALTER PROC [usp_GetEmployeesSalaryAbove35000]
AS
BEGIN
     -- Select the first name and last name from the 'Employees' table
	 SELECT [FirstName]
	      , [LastName]
       FROM [Employees]

	  -- Filter where the salary is above 35000
	  WHERE [Salary] > 35000
END

GO
