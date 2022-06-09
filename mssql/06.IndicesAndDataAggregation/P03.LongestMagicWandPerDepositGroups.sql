-- Connect to the 'Gringotts' database for execution of this query
USE [Gringotts]

GO

-- Select the deposit group and the largest wand size from the 'WizzardDeposits' table
  SELECT [DepositGroup]
       , MAX([MagicWandSize]) AS [LongestMagicWand]
    FROM [WizzardDeposits]

-- Group by the deposit groups
GROUP BY [DepositGroup]

GO  
