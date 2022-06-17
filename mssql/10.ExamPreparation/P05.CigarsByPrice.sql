-- Connect to the 'CigarShop' database for execution of this query
USE [CigarShop]

GO

-- Select the name, price and url from the 'Cigars' table
  SELECT [CigarName]
       , [PriceForSingleCigar]
	   , [ImageURL]
    FROM [Cigars]

-- Order by the price ascending
-- then by name descending
ORDER BY [PriceForSingleCigar] ASC
       , [CigarName] DESC

GO
