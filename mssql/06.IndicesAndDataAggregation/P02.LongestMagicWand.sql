-- Connect to the 'Gringotts' database for execution of this query
USE [Gringotts]

GO

-- Select the largest wand size from the 'WizzardDeposits' table
SELECT MAX([MagicWandSize]) AS [LongestMagicWand]
  FROM [WizzardDeposits]

GO  
