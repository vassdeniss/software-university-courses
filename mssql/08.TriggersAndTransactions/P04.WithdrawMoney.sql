-- Connect to the 'Bank' database for execution of this query
USE [Bank]

GO

-- Create or alter stored procedure
CREATE PROC [usp_WithdrawMoney]
		    @accountId INT, @moneyAmount DECIMAL(9, 4)
AS
BEGIN TRANSACTION
	-- Update the accounts and decrease the balance by @moneyAmount
	UPDATE [Accounts]
	   SET [Balance] -= @moneyAmount

	-- Filter where the id equals the @accountId
	WHERE [Id] = @accountId

	-- If the money is equal or lower than zero rollback the transaction
	IF (@moneyAmount <= 0)
	BEGIN
		ROLLBACK
		RETURN
	END
COMMIT

GO
