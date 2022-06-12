-- Connect to the 'Diablo' database for execution of this query
USE [Diablo]

GO

-- Create or alter a function
-- Parameters: gameName, variable char, length 50
CREATE OR ALTER FUNCTION [ufn_CashInUsersGames]
					     (@gameName VARCHAR(50))

-- Function returns a table
RETURNS TABLE
AS RETURN
(
    -- Select sum of the cash from the subquery
	SELECT SUM([Cash]) AS [SumCash]
	  FROM (
	            -- Select the cash from the 'UsersGames' table
				-- Select a row number column ordered by the cash descending
				SELECT [ug].[Cash]
	                 , ROW_NUMBER() OVER(ORDER BY [ug].[Cash] DESC) AS [RowNumber]
	              FROM [UsersGames] AS [ug]

				-- Inner join the 'UsersGames' table with the 'Games' table
	              JOIN [Games] AS [g]
	                ON [ug].[GameId] = [g].[Id]

			    -- Filter where the game name matches the @gameName argument
	             WHERE [g].[Name] = @gameName
	       ) AS [RowNumberSubquery]

	-- Filter where the row number is an odd number
	 WHERE [RowNumber] % 2 <> 0
)

GO
