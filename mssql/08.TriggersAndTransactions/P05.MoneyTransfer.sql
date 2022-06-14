-- Connect to the 'Bank' database for execution of this query
USE [Bank]

GO

-- Create or alter stored procedure
CREATE PROC [usp_TransferMoney]
		    @senderId INT, @receiverId INT, @moneyAmount DECIMAL(9, 4)
AS
BEGIN
	-- Update the accounts and decrease the balance by @moneyAmount
	-- where the id equals @senderId
	EXEC [dbo].[usp_WithdrawMoney] @senderId, @moneyAmount

	-- Update the accounts and increase the balance by @moneyAmount
	-- where the id equals @receiverId
	EXEC [dbo].[usp_DepositMoney] @receiverId, @moneyAmount
END

GO
