-- Connect to the 'Diablo' database to run this snippet
USE [Diablo]

GO

-- Select the usernames and IP addresses from the 'Users' table
SELECT [Username] 
    , [IpAddress]
FROM [Users]
-- Filter where the IP address matches '___.1%.%.___'
WHERE [IpAddress] LIKE '___.1%.%.___'
-- Order the results by username alphabetically
ORDER BY [Username] ASC

GO
