-- Connect to the 'SoftUni' database for execution of this query
USE [SoftUni]

GO

-- Create or alter a function
-- Parameters: salary, decimal, 18 symbols, 4 after the decimal point
CREATE OR ALTER FUNCTION [ufn_GetSalaryLevel]
                         (@salary DECIMAL(18, 4))

-- Returns character of length 7
RETURNS VARCHAR(7)
AS
BEGIN
    -- Declare a variable of length 7 called 'level'
	DECLARE @level VARCHAR(7)

	-- If the salary is higher than 30k
	-- return 'Low'
	IF (@salary < 30000)
	BEGIN
		RETURN 'Low'
	END

	-- If the salary is between 30k and 50k inclusive
	-- return 'Average'
	IF (@salary BETWEEN 30000 AND 50000)
	BEGIN
		RETURN 'Average'
	END

	-- Else return 'High'
	RETURN 'High'
END

GO
