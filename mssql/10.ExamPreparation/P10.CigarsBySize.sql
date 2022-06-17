-- Connect to the 'CigarShop' database for execution of this query
USE [CigarShop]

GO

-- Select last name from the 'Clients' table
-- Select the country and zip code from the 'Addresses' table
-- Select the price from the 'Cigars' table
  SELECT [c].[LastName]
       , AVG([s].[Length]) AS [CigarLength]
       , CEILING(AVG([s].[RingRange])) AS [CigarRingRange]
    FROM [Clients] AS [c]

-- Inner join the 'Clients' table with the 'ClientsCigars' table
    JOIN [ClientsCigars] AS [cc] 
      ON [c].[Id] = [cc].[ClientId]

-- Inner join the 'ClientsCigars' table with the 'Cigars' table
    JOIN [Cigars] AS [cig] 
      ON [cc].[CigarId] = [cig].[Id]

-- Inner join the 'Cigars' table with the 'Sizes' table
    JOIN [Sizes] AS [s] 
      ON [cig].[SizeId] = [s].[Id]

-- Group the results by the last name
GROUP BY [LastName]

-- Order the results by the average cigar length descending
ORDER BY AVG([s].[Length]) DESC

GO
