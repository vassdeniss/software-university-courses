-- Connect to the 'Gringotts' database for execution of this query
USE [Gringotts]

GO

-- Select the count of the ids from the 'WizzardDeposits' table
SELECT COUNT([Id]) AS [Count]
  FROM [WizzardDeposits]

GO  
