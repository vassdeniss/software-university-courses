-- Connect to the 'Gringotts' database for execution of this query
USE [Gringotts]

GO

-- Select the deposit group, the deposit flag and the average deposit interest from the 'WizzardDeposits' table
  SELECT [DepositGroup]
       , [IsDepositExpired]
	   , AVG([DepositInterest]) AS [AverageInterest]
    FROM [WizzardDeposits]

-- Filter where the start date is after 01/01/1985
   WHERE [DepositStartDate] > '01/01/1985'

-- Group by the deposit group
-- and by the deposit flag
GROUP BY [DepositGroup]
       , [IsDepositExpired]

-- Order by the deposit group descending
-- then by the deposit flag ascending
ORDER BY [DepositGroup] DESC
	   , [IsDepositExpired] ASC

GO  
