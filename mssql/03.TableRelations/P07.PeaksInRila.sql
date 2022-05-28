-- Connect to the 'Geography' database to run this snippet
USE [Geography]

GO

-- Select the mountain range from the [Mountains] table
-- Select the peak name and elevation from the [Peaks] table
SELECT m.[MountainRange]
    , p.[PeakName]
    , p.[Elevation]
FROM [Mountains] AS m
-- Join them on their primary keys only where the primary key is 17
JOIN [Peaks] AS p
    ON m.[Id] = p.[MountainId]
WHERE m.[Id] = 17
-- Order by mountain elevation descending
ORDER BY p.[Elevation] DESC
