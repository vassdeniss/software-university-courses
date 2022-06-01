-- Connect to the 'Diablo' database to run this snippet
USE [Diablo]

GO

-- Select the names as 'Game' from the 'Games' table
SELECT [Name] AS [Game]
    -- Create a column as 'Part of the Day' based on the starting hour
    , CASE 
        WHEN DATEPART(HOUR, [Start])
            BETWEEN 0 AND 11
            THEN 'Morning'
        WHEN DATEPART(HOUR, [Start])
            BETWEEN 12 AND 17
            THEN 'Afternoon'
        ELSE 'Evening'
    END AS [Part of the Day]
    -- Create a column as 'Duration' based on the duration of the game
    , CASE 
        WHEN [Duration] <= 3 
            THEN 'Extra Short'
        WHEN [Duration]
            BETWEEN 4 AND 6
            THEN 'Short'
        WHEN [Duration] > 6
            THEN 'Long'
        ELSE 'Extra Long'
    END AS [Duration]
FROM [Games] AS [g]
-- Order the table by name alphabetically
-- then by duration ascending
-- then by part of the day ascending
ORDER BY [g].[Name] ASC
    , [Duration] ASC
    , [Part of the Day] ASC

GO
