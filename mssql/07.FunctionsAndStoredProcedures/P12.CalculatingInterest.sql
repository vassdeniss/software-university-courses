-- Connect to the 'Bank' database for execution of this query
USE [Bank]

GO

-- Create or alter a procedure
-- Parameters: accID, int
--             rate, float
CREATE OR ALTER PROC [usp_CalculateFutureValueForAccount]
                     @accID INT
				   , @rate FLOAT
AS
BEGIN
	-- Select the id from the 'AccountHolders' table
	-- Select the first name from the 'AccountHolders' table
	-- Select the last name from the 'AccountHolders' table
	-- Select the balance from the 'Accounts' table
	-- Select the returned value from the ufn 'CalculateFutureValue'
	SELECT [ah].[Id] AS [Account Id]
	     , [ah].[FirstName] AS [First Name]
		 , [ah].[LastName] AS [Last Name]
		 , [a].[Balance] AS [Current Balance]
		 , [dbo].[ufn_CalculateFutureValue]([a].[Balance], @rate, 5) AS [Balance in 5 years]
	  FROM [AccountHolders] AS [ah]

	-- Inner join the 'AccountHolders' table with the 'Accounts' table
	  JOIN [Accounts] AS [a]
	    ON [ah].[Id] = [a].[AccountHolderId]

	-- Filter where the account id matches the @accID argument
	 WHERE [a].[Id] = @accID
END

GO
