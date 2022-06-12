-- Connect to the 'SoftUni' database for execution of this query
USE [SoftUni]

GO

-- Create or alter a procedure
-- Parameters: number, decimal, 18 symbols, 4 after the decimal point
CREATE OR ALTER PROC [usp_GetEmployeesSalaryAboveNumber]
                     @number DECIMAL(18, 4)
AS
BEGIN
     -- Select the first name and last name from the 'Employees' table
	 SELECT [FirstName]
	      , [LastName]
       FROM [Employees]

	  -- Filter where the salary is above the number parameter
	  WHERE [Salary] >= @number
END

GO
