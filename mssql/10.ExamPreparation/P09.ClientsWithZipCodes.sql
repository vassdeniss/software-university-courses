-- Connect to the 'CigarShop' database for execution of this query
USE [CigarShop]

GO

-- Select the full name from the 'Clients' table
-- Select the country and zip code from the 'Addresses' table
-- Select the price from the 'Cigars' table
  SELECT CONCAT([c].[FirstName], ' ', [c].[LastName]) AS [FullName]
       , [a].[Country]
	   , [a].[ZIP]
	   , CONCAT('$', MAX([ci].[PriceForSingleCigar])) AS CigarPrice
    FROM [Clients] AS [c]

-- Inner join the 'Clients' table with the 'Addresses' table
    JOIN [Addresses] AS [a] 
      ON [c].[AddressId] = [a].[Id]

-- Inner join the 'Clients' table with the 'ClientsCigars' table
	JOIN [ClientsCigars] AS [cc] 
      ON [c].[Id] = [cc].[ClientId]

-- Inner join the 'ClientsCigars' table with the 'Cigars' table
	JOIN [Cigars] AS [ci] 
      ON [cc].[CigarId] = [ci].[Id]

-- Filter where the the zip code does not contain letters
   WHERE [a].[ZIP] NOT LIKE '%[A-Z]%'

-- Group the results by first name, last name, country anz zip code
GROUP BY [c].[FirstName]
       , [c].[LastName]
	   , [a].[Country]
	   , [a].[ZIP]

-- Order the results by name ascending
ORDER BY [FullName] ASC

GO
