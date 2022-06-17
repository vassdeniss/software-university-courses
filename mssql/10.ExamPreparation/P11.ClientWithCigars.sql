-- Connect to the 'CigarShop' database for execution of this query
USE [CigarShop]

GO

-- Create or alter function
CREATE OR ALTER FUNCTION [udf_ClientWithCigars]
					     (@name NVARCHAR(30)) 
-- Function returns int
RETURNS INT
AS
BEGIN
	-- Return a subquery
	RETURN (
	        
		    -- Select the count of everything from the 'Users' table
		    SELECT COUNT([cc].[CigarId]) 
		      FROM [Clients] AS [c]

		    -- Inner join the 'Clients' table with the 'ClientsCigars' table
		      JOIN [ClientsCigars] AS [cc] 
		        ON [c].[Id] = [cc].[ClientId]

		    -- Filter where the first name matches the @name parameter
		     WHERE [c].[FirstName] = @name
	)
END

GO
