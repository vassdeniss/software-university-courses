-- Connect to the 'Gringotts' database for execution of this query
USE [Gringotts]

GO

-- Select the first letter of the first name from the 'WizzardDeposits' table
   SELECT LEFT([FirstName], 1) AS [FirstLetter]
     FROM [WizzardDeposits]

-- Group by the first letter
-- and by the deposit group
 GROUP BY LEFT([FirstName], 1), [DepositGroup]

-- Filter where the groups have the deposit group as 'Troll Chest'
  HAVING [DepositGroup] = 'Troll Chest'

-- Order by the first letter ascending
ORDER BY [FirstLetter] ASC

GO  
