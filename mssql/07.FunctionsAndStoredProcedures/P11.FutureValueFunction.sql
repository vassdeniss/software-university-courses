-- Connect to the 'Bank' database for execution of this query
USE [Bank]

GO

-- Create or alter a function
-- Parameters: sum, decimal, 18 digits, 4 after the decimal point
--             yearlyInterestRate, float
--             numberOfYears, int
CREATE OR ALTER FUNCTION [ufn_CalculateFutureValue]
                         (@sum DECIMAL(18, 4)
						 ,@yearlyInterestRate FLOAT
						 ,@numberOfYears INT)

-- Returns a decimal, 18 digits, 4 after the decimal point
RETURNS DECIMAL(18, 4)
AS
BEGIN
	-- Returns the sum multiplied by the sum of the yearly interest rate plus one raised to the power of number of years
	RETURN @sum * (POWER(1 + @yearlyInterestRate, @numberOfYears))
END

GO
