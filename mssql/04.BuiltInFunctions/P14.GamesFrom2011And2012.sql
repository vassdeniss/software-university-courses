-- Connect to the 'Diablo' database to run this snippet
USE [Diablo]

GO

-- Select the top 50 game names 
-- and start dates (formatted yyyy-MM-dd) from the 'Games' table
SELECT TOP 50 
    [Name]
    , FORMAT([g].[Start], 'yyyy-MM-dd') AS [Start]
FROM [Games] as [g]
-- Filter where the start date year is either 2011 or 2012
WHERE DATEPART(YEAR, [g].[Start]) IN (2011, 2012)
-- Order the results by start date then by name alphabetically
ORDER BY [Start] ASC
    , [Name] ASC

GO
