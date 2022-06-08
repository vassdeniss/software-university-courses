-- Connect to the 'Geography' database for execution of this query
USE [Geography]

GO

-- Select the country code from the 'Countries' table
-- Select the mountain range from the 'Mountains' table
-- Select the peak name and the elevation from the 'Peaks' table
  SELECT [c].[CountryCode]
	   , [m].[MountainRange]
	   , [p].[PeakName]
	   , [p].[Elevation]
    FROM [Countries] AS [c]

-- Inner join the 'Countries' table with the 'MountainsCountries' table
    JOIN [MountainsCountries] AS [mc] 
      ON [c].[CountryCode] = [mc].[CountryCode]

-- Inner join the joined table with the 'Mountains' table
	JOIN [Mountains] AS [m]
	  ON [mc].[MountainId] = [m].[Id]

-- Inner join the joined table with the 'Peaks' table
	JOIN [Peaks] AS [p]
	  ON [m].[Id] = [p].[MountainId]

-- Filter where the country code is bulgaria
-- and where the elevation is above 2835 meters
   WHERE [c].[CountryCode] = 'BG'
     AND [p].[Elevation] > 2835

-- Order the results by the elevation descending
ORDER BY [p].[Elevation] DESC

GO
