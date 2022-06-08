-- Connect to the 'Geography' database for execution of this query
USE [Geography]

GO

-- Select the total number of country codes from the 'Countries' table
   SELECT COUNT([c].[CountryCode]) AS [Count]
     FROM [Countries] AS [c]

-- Left join the 'Countries' table with the 'MountainsCountries' table
LEFT JOIN [MountainsCountries] AS [mc]
       ON [c].[CountryCode] = [mc].[CountryCode]

-- Filter where the mountain ID is null
    WHERE [mc].[MountainId] IS NULL

GO
