-- Connect to the 'Geography' database for execution of this query
USE [Geography]

GO

-- Select the country code from the 'MountainsCountries' table
-- Create a new column that counts the mountain ids as 'MountainRanges' from the 'MountainsCountries' table
  SELECT [CountryCode]
       , COUNT([MountainId]) AS [MountainRanges]
    FROM [MountainsCountries]

-- Filter where the country code is either United States, Russia or Bulgaria
   WHERE [CountryCode] IN ('US', 'RU', 'BG')

-- Group the results by the country code
GROUP BY [CountryCode]

GO
