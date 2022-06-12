-- Connect to the 'SoftUni' database for execution of this query
USE [SoftUni]

GO

-- Create or alter a procedure
-- Parameters: salaryLevel, varchar, 7 symbols
CREATE OR ALTER PROC [usp_EmployeesBySalaryLevel]
                     @salaryLevel VARCHAR(7)
AS
BEGIN
      -- Select the first and last names from the 'Employees' table
	  SELECT [FirstName]
	       , [LastName]
        FROM [Employees]

	  -- Filter where the result of the user function 'GetSalaryLevel' equals the argument
	  WHERE [dbo].[ufn_GetSalaryLevel]([Salary]) = @salaryLevel
END

GO
