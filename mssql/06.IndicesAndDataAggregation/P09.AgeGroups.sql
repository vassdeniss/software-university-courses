-- Connect to the 'Gringotts' database for execution of this query
USE [Gringotts]

GO

-- Select the age group from the subquery and the count of everything from the 'WizzardDeposits' table
 SELECT [AgeGroup]
      , COUNT(*) AS [WizardCount]
   FROM (
            -- Select the age and a case-when column from the 'WizzardDeposits' table
			SELECT [Age]
	             , CASE
		              WHEN [Age] BETWEEN 0 AND 10
			          THEN '[0-10]'
			          WHEN [Age] BETWEEN 11 AND 20
			          THEN '[11-20]'
			          WHEN [Age] BETWEEN 21 AND 30
			          THEN '[21-30]'
			          WHEN [Age] BETWEEN 31 AND 40
			          THEN '[31-40]'
			          WHEN [Age] BETWEEN 41 AND 50
			          THEN '[41-50]'
			          WHEN [Age] BETWEEN 51 AND 60
			          THEN '[51-60]'
			          WHEN [Age] >= 61
			          THEN '[61+]'
		           END AS [AgeGroup]
              FROM [WizzardDeposits]
         ) AS [AgeGroupSub]

-- Group by the age group
GROUP BY [AgeGroup]

GO  
