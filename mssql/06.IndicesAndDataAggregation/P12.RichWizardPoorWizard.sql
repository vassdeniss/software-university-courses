-- Connect to the 'Gringotts' database for execution of this query
USE [Gringotts]

GO

-- Select the whole sum of the difference
SELECT SUM([Difference])
  FROM (
			-- Select everything from the subquery
			-- Select the host wizard deposit minus the guest wizard deposit
			SELECT *
				 , [Host Wizard Deposit] - [Guest Wizard Deposit] AS [Difference]
			  FROM (
						-- Select the first name from the 'WizzardDeposits' table
						-- Select the deposit amount from the 'WizzardDeposits' table
						-- Select the first name by skipping one from the 'WizzardDeposits' table
						-- Select the deposit amount by skipping one from the 'WizzardDeposits' table
						  SELECT [FirstName] AS [Host Wizard]
							   , [DepositAmount] AS [Host Wizard Deposit]
							   , LEAD([FirstName]) OVER (ORDER BY [Id]) AS [Guest Wizard]
							   , LEAD([DepositAmount]) OVER (ORDER BY [Id]) AS [Guest Wizard Deposit]
							FROM [WizzardDeposits]
			  ) AS [DepositSubquery]

			-- Filter where the guest wizard is not null
			 WHERE [Guest Wizard] IS NOT NULL
  ) AS [FilterDepositSubquery]

GO  
