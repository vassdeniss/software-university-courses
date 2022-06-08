-- Connect to the 'Geography' database for execution of this query
USE [Geography]

GO

-- Select 5 records
-- Select the country name from the 'Countries' table
-- Select the highest peak elevation from the 'Peaks' table
-- Select the longest river length from the 'Rivers' table
SELECT TOP 5 
          [c].[CountryName]
        , MAX([p].[Elevation]) AS [HighestPeakElevation]
        , MAX([r].[Length]) AS [LongestRiverLength]
	 FROM [Countries] AS [c]

-- Left join the 'Countries' table with the 'MountainsCountries' table
LEFT JOIN [MountainsCountries] AS [mc]
	   ON [c].[CountryCode] = [mc].[CountryCode]

-- Left join the 'MountainsCountries' table with the 'Mountains' table
LEFT JOIN [Mountains] AS [m]
	   ON [mc].[MountainId] = [m].[Id]

-- Left join the 'Mountains' table with the 'Peaks' table
LEFT JOIN [Peaks] AS [p]
	   ON [m].[Id] = [p].[MountainId]

-- Left join the 'Countries' table with the 'CountriesRivers' table
LEFT JOIN [CountriesRivers] AS [cr]
	   ON [c].[CountryCode] = [cr].[CountryCode]

-- Left join the 'CountriesRivers' table with the 'Rivers' table
LEFT JOIN [Rivers] AS [r]
       ON [cr].[RiverId] = [r].[Id]

-- Group the results by the country name
 GROUP BY [c].[CountryName]

-- Order the results by highest peak elevation descending
-- and by the longest river length descending
-- and by the country name ascending
 ORDER BY [HighestPeakElevation] DESC
        , [LongestRiverLength] DESC
		, [CountryName] ASC

GO
