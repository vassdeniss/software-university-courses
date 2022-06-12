-- Connect to the 'Bank' database for execution of this query
USE [Bank]

GO

-- Create or alter a procedure
-- Parameters: number, decimal, 18 digits, 4 after the decimal point
CREATE OR ALTER PROC [usp_GetHoldersWithBalanceHigherThan]
                     @number DECIMAL(18, 4)
AS
BEGIN
    -- Select the first and last names from the 'AccountHolders' table
	  SELECT [FirstName]
	       , [LastName]
	    FROM [AccountHolders] AS [ah]

	-- Inner join the 'AccountHolders' table with the 'Accounts' table
	    JOIN [Accounts] AS [a]
	      ON [ah].[Id] = [a].[AccountHolderId]

	-- Group the results by the first name
	-- and the last name
    GROUP BY [FirstName]
	       , [LastName]

	-- Filter where the groups have a sum of the balance higher than the argument
      HAVING SUM(Balance) > @number

	-- Order the results by the first name ascending
	-- then by the last name ascending
	ORDER BY [FirstName] ASC
	       , [LastName] ASC
END

GO
