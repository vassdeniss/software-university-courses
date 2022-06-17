-- Connect to the 'CigarShop' database for execution of this query
USE [CigarShop]

GO

-- Delete from the 'ClientsCigars' table where the client id matches a client who lives in a country starting wtih 'C'
DELETE FROM [ClientsCigars]
      WHERE [ClientId] IN (
	                       SELECT [Id] 
						     FROM [Clients]
                            WHERE [AddressId] IN (
							                      SELECT [Id] 
												    FROM [Addresses]
                                                   WHERE [Country] LIKE 'C%'
												 )
						  )

GO

-- Delete from the 'Clients' table where the address id matches a country starting wtih 'C'
DELETE FROM [Clients]
      WHERE [AddressId] IN (
						    SELECT [Id] 
							  FROM [Addresses]
                             WHERE [Country] LIKE 'C%'
						   )
	  
GO

-- Delete from the 'Addresses' table where the country starts wtih 'C'
DELETE FROM [Addresses]
      WHERE [Country] LIKE 'C%'

GO
