-- Connect to the 'Geography' database for execution of this query
USE [Geography]

GO

 -- Select the continent code, currency code and currency usage
 -- from a subquery as 'CurrencyRankingQuery'
 SELECT [ContinentCode]
	  , [CurrencyCode]
	  , [CurrencyUsage]
 FROM (
			        -- Select everything from a subquery as 'CurrencyUsageRank'
				    -- Create a dense rank over the continent code
				    -- ordered by the cuurency usage descending as 'CurrencyRank'
	                SELECT *,
			    DENSE_RANK() 
			         OVER (
			 PARTITION BY [ContinentCode] 
	             ORDER BY [CurrencyUsage] DESC)
		               AS [CurrencyRank]
			         FROM (
								 -- Select the continent code from the continents table
							     -- Select the currency code from the countries table
							     -- Create a column that counts the currency codes as 'CurrencyUsage'
								     SELECT [c].[ContinentCode]
									      , [co].[CurrencyCode]
								    , COUNT([co].[CurrencyCode]) AS [CurrencyUsage]
								   	   FROM [Continents] AS [c]

							     -- Left join the 'Continents' table with the 'Countries' table
								 LEFT JOIN [Countries] AS [co]
									    ON [c].[ContinentCode] = [co].[ContinentCode]

							     -- Group by the continent code and the currency code
								  GROUP BY [c].[ContinentCode], [co].[CurrencyCode]	
					 ) AS [CurrencyUsageQuery]
	 -- Filter where the currency usage is higher than one
	 WHERE [CurrencyUsage] > 1
    ) AS [CurrencyRankingQuery]

-- Filter where the currency rank is exactly one
   WHERE [CurrencyRank] = 1

-- Order the results by continent code ascending
ORDER BY [ContinentCode] ASC

GO
