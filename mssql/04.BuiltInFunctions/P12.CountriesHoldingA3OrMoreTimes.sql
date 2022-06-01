-- Connect to the 'Geography' database to run this snippet
USE [Geography]

GO

-- Select the country name and the iso code from 'Countries'
SELECT [CountryName]
    , [IsoCode]
FROM [Countries]
-- Filter where the country name contains 'A' atleast 3 times
-- Order by the iso code ascending
WHERE LOWER([CountryName]) LIKE '%a%a%a%'
ORDER BY [IsoCode] ASC

GO
