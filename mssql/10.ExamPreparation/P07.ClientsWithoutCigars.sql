-- Connect to the 'CigarShop' database for execution of this query
USE [CigarShop]

GO

-- Select the id and email from the 'Cigars' table
-- Select the first and last name concatenated from the 'Clients' table
   SELECT [c].[Id]
        , CONCAT([c].[FirstName], ' ', [c].[LastName]) AS [ClientName]
        , [c].[Email]
     FROM [Clients] AS [c]

-- Left join the 'Cigars' table with the 'ClientsCigars' table
LEFT JOIN [ClientsCigars] AS [cc] 
       ON [c].[Id] = [cc].[ClientId]

-- Filter where the cigar id is null
    WHERE [CigarId] IS NULL

-- Order the results by name ascending
 ORDER BY [ClientName] ASC

GO
