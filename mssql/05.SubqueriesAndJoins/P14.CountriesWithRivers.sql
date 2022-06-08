-- Connect to the 'Geography' database for execution of this query
USE [Geography]

GO

-- Select the top 5 records with the country name from the 'Countries' table
-- Select the river name from the 'Rivers' table
  SELECT TOP 5
		  [c].[CountryName]
		, [r].[RiverName]
     FROM [Countries] AS [c]

-- Left join the 'Countries' table with the 'CountriesRivers' table
LEFT JOIN [CountriesRivers] AS [cr]
	   ON [c].[CountryCode] = [cr].[CountryCode]

-- Left join the table with the 'Rivers' table
LEFT JOIN [Rivers] AS [r]
       ON [r].[Id] = [cr].[RiverId]

-- Filter where the continent code is Africa
    WHERE [c].[ContinentCode] = 'AF'

-- Order ther results by the country name ascending
 ORDER BY [c].[CountryName] ASC

GO
