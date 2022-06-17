-- Connect to the 'CigarShop' database for execution of this query
USE [CigarShop]

GO

-- Select the name, price and url from the 'Cigars' table
   SELECT TOP 5
         [CigarName]
       , [PriceForSingleCigar]
	   , [ImageURL]
    FROM [Cigars] AS [c]

-- Inner join the 'Cigars' table with the 'Sizes' table
    JOIN [Sizes] AS [s] 
      ON [c].[SizeId] = [s].[Id]

-- Filter where the length is at least 12cm long
-- Filter where the name contain 'ci' or the price is bigger than $50 
-- Filter where the ring range is bigger than 2.55
    WHERE [s].[Length] >= 12
	  AND ([c].[CigarName] LIKE '%ci%' OR [c].[PriceForSingleCigar] > 50)
	  AND [s].[RingRange] > 2.55

-- Order the results by name ascending
-- then by price descending
 ORDER BY [c].[CigarName] ASC
        , [c].[PriceForSingleCigar] DESC

GO
