-- Connect to the 'Gringotts' database for execution of this query
USE [Gringotts]

GO

-- Select the deposit group and the sum of the deposit amounts from the 'WizzardDeposits' table
  SELECT [DepositGroup]
	   , SUM([DepositAmount]) AS [TotalSum]
    FROM [WizzardDeposits]

-- Group by the deposit groups and by the magic wand creator
GROUP BY [DepositGroup]
	   , [MagicWandCreator]

-- Filter the the groups have the creator as 'Ollivander family'
-- and where the total sum is lower than 150000
  HAVING [MagicWandCreator] = 'Ollivander family'
     AND SUM([DepositAmount]) < 150000

-- Order by the total sum descending
ORDER BY [TotalSum] DESC

GO  
