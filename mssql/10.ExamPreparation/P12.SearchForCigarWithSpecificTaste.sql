-- Connect to the 'CigarShop' database for execution of this query
USE [CigarShop]

GO

-- Create or alter stored procedure
CREATE OR ALTER PROC [usp_SearchByTaste]
					 @taste VARCHAR(20)
AS
BEGIN
	-- Select the cigar name and price from the 'Cigars' table
	-- Select the taste type from the 'Tastes' table
	-- Select the brand name from the 'Brands' table
	-- Select the length and ring range from the 'Sizes' table
	SELECT [c].[CigarName]
	     , CONCAT('$', [c].[PriceForSingleCigar]) AS [Price]
		 , [t].[TasteType]
		 , [b].[BrandName]
		 , CONCAT([s].[Length], ' ', 'cm') AS [CigarLength]
		 , CONCAT([s].[RingRange], ' ', 'cm') AS [CigarRingRange]
      FROM [Cigars] AS [c]

	-- Inner join the 'Cigars' table with the 'Tastes' table
	  JOIN [Tastes] AS [t] 
	    ON [c].[TastId] = [t].[Id]

	-- Inner join the 'Cigars' table with the 'Brands' table
	  JOIN [Brands] AS [b] 
	    ON [c].[BrandId] = [b].[Id]

	-- Inner join the 'Cigars' table with the 'Sizes' table
	  JOIN [Sizes] AS [s] 
	    ON [c].[SizeId] = [s].[Id]

    -- Filter where the taste type matches the @taste parameter
	 WHERE [t].[TasteType] = @taste

	-- Order the results by the length ascending
	-- then by the ring rande descending
  ORDER BY [s].[Length] ASC
         , [s].[RingRange] DESC
END

GO
