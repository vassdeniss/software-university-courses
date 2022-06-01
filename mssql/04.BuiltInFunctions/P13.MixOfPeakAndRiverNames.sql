-- Connect to the 'Geography' database to run this snippet
USE [Geography]

GO

-- Select the peak name from the 'Peaks' table
-- Select the river name from the 'Rivers' table
-- Create column that concats and lowercases the peak name and the river name
-- together but cuts the final letter of the peak name
-- Name the new column 'Mix'
SELECT [p].[PeakName]
    , [r].[RiverName]
    , LOWER(CONCAT
        (
            LEFT([p].[PeakName], LEN([p].[PeakName]) - 1), [r].[RiverName]
        )
    ) AS [Mix]
FROM [Rivers] AS [r]
    , [Peaks] AS [p]
-- Filter where the last letter of the peak name equals the first letter of the river name
WHERE RIGHT([p].[PeakName], 1) = LEFT([r].[RiverName], 1)
-- Order by the mixed names alphabetically
ORDER BY [Mix] ASC

GO
