-- Connect to the 'Bank' database for execution of this query
USE [Bank]

GO

-- Create a table 'Logs' into the 'Bank' database
CREATE TABLE [Logs] (
	[LogId] INT PRIMARY KEY IDENTITY -- Primary key column
	, [AccountId] INT FOREIGN KEY REFERENCES [Accounts]([Id]) NOT NULL
	, [OldSum] DECIMAL (6, 2) NOT NULL
	, [NewSum] DECIMAL (6, 2) NOT NULL
)

GO

-- Create a trigger that triggers everytime the 'Accounts' table is updated
CREATE TRIGGER [tr_UpdateLogsOnAccountUpdate]
ON [Accounts] FOR UPDATE
AS
	-- Insert into the 'Logs' table
	INSERT INTO [Logs](AccountId, OldSum, NewSum)

	-- Select the id and balance from the inserted values
	-- Select the balance from the deleted values
	     SELECT [i].[Id]
		      , [d].[Balance]
			  , [i].[Balance]
		   FROM [inserted] AS [i]

	-- Inner join the inserted values with the deleted values
		   JOIN [deleted] AS [d] 
		     ON [i].[Id] = [d].[Id]

	-- Filter where the balance does not match
		  WHERE [i].[Balance] <> [d].[Balance]

GO
