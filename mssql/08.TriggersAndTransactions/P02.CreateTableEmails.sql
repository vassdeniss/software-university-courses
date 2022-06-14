-- Connect to the 'Bank' database for execution of this query
USE [Bank]

GO

-- Create a table 'NotificationEmails' into the 'Bank' database
CREATE TABLE [NotificationEmails] (
	[Id] INT PRIMARY KEY IDENTITY -- Primary key column
	, [Recipient] INT FOREIGN KEY REFERENCES [Accounts]([Id]) NOT NULL
	, [Subject] VARCHAR(100)
	, [Body] VARCHAR(500)
)

GO

-- Create a trigger that triggers everytime the 'Logs' table is updated
CREATE TRIGGER [tr_SendEmailNotificationOnLogsUpdate]
ON [Logs] FOR INSERT
AS
	-- Insert into the 'NotificationEmails' table
	INSERT INTO [NotificationEmails]([Recipient], [Subject], [Body])

	-- Select the id and balance from the inserted values
	-- Select the balance from the deleted values
	     SELECT [i].[AccountId]
		      , CONCAT('Balance change for account: ', [i].[AccountId])
			  , CONCAT('On ', FORMAT(GETDATE(), 'MMM dd yyyy hh:mmtt') , ' your balance was changed from ', ROUND([i].[OldSum], 2), ' to ', ROUND([i].[NewSum], 2))
		   FROM [inserted] AS [i]

GO
