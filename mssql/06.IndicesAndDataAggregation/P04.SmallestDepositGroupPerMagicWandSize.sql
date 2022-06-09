-- Connect to the 'Gringotts' database for execution of this query
USE [Gringotts]

GO

-- Select the deposit group from the 'WizzardDeposits' table
  SELECT TOP 2
	     [DepositGroup]
    FROM [WizzardDeposits]

-- Group by the deposit groups
GROUP BY [DepositGroup]

-- Order the results by the average wand size ascending
ORDER BY AVG([MagicWandSize]) ASC

GO  
