-- Connect to the 'Geography' database for execution of this query
USE [Geography]

GO

-- Select the country name, highest peak name, 
-- highest peak elevation and mountain range from a subquery
SELECT TOP 5 
     [c].[CountryName]
   , [c].[Highest Peak Name]
   , [c].[Highest Peak Elevation]
   , [c].[Mountain]
FROM (
			-- Select the country name from the 'Countries' table
			-- Create custom columns each checking diffrent columns for nulls
			-- that replace the null with a custom value if they are indeed null
			-- Run a dense rank by partitioning by country name and ordering by the highest elevation descending
		       SELECT [csub].[CountryName]
			        , ISNULL([p].[PeakName], '(no highest peak)') AS [Highest Peak Name]
			        , ISNULL(MAX([p].[Elevation]), 0) AS [Highest Peak Elevation]
			        , ISNULL([m].[MountainRange], '(no mountain)') AS [Mountain]
			        , DENSE_RANK() OVER(PARTITION BY [csub].[CountryName] ORDER BY MAX([p].[Elevation]) DESC) AS [Ranked]
			     FROM [Countries] AS [csub]

			-- Left join the 'Countries' table with the 'MountainsCountries' table
			LEFT JOIN [MountainsCountries] AS [mc]
			       ON [csub].[CountryCode] = [mc].[CountryCode]

			-- Left join the 'MountainsCountries' table with the 'Mountains' table
			LEFT JOIN [Mountains] AS [m]
			       ON [mc].[MountainId] = [m].[Id]

			-- Left join the 'Mountains' table with the 'Peaks' table
			LEFT JOIN [Peaks] AS [p]
			       ON [m].[Id] = [p].[MountainId]

			-- Group the results by the country name, peak name and mountain range
			 GROUP BY [csub].[CountryName], [p].[PeakName], [m].[MountainRange]
     ) AS [c]

-- Filter where the dense rank is one
-- so we can find the highest peak
    WHERE [Ranked] = 1

-- Order the results by country name ascending
-- and by highest peak name ascending
 ORDER BY [CountryName] ASC
	    , [Highest Peak Name] ASC

GO
