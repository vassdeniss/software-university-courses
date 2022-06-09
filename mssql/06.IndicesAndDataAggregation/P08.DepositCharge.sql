-- Connect to the 'Gringotts' database for execution of this query
USE [Gringotts]

GO

-- Select the deposit group, the magic wand creator and the minumum deposit charge from the 'WizzardDeposits' table
  SELECT [DepositGroup]
	   , [MagicWandCreator]
	   , MIN([DepositCharge]) AS [MinDepositCharge]
    FROM [WizzardDeposits]

-- Group by the deposit group 
-- and by the magic wand creator
GROUP BY [DepositGroup]
       , [MagicWandCreator]

-- Order by the MagicWandCreator ascending
-- and by the deposit group asending
ORDER BY [MagicWandCreator] ASC
	   , [DepositGroup] ASC

GO  
