-- Connect to the 'CigarShop' database for execution of this query
USE [CigarShop]

GO

-- Select the id, name and price from the 'Cigars' table
-- Select the taste type and strength from the 'Tastes' table
  SELECT [c].[Id]
       , [c].[CigarName]
       , [c].[PriceForSingleCigar]
	   , [t].[TasteType]
	   , [t].[TasteStrength]
    FROM [Cigars] AS [c]

-- Inner join the 'Cigars' table with the 'Tastes' table
    JOIN [Tastes] AS [t]
      ON [c].TastId = [t].[Id]

-- Filter where the taste is either 'Earthy' or 'Woody'
   WHERE [t].[TasteType] = 'Earthy' OR [t].[TasteType] = 'Woody'

-- Order the results by price descending
ORDER BY [c].[PriceForSingleCigar] DESC

GO
