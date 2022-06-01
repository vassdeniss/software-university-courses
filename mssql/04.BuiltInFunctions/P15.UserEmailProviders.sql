-- Connect to the 'Diablo' database to run this snippet
USE [Diablo]

GO

-- Select the usernames from 'Users' table
-- Create column that takes the email provider from the email
-- (everything after the '@'), by taking the index of the '@' adding 1 and
-- calculating the lenght by subtracting the email lenght by the '@' index
-- Name the new column 'Email Provider'
SELECT [Username]
    , SUBSTRING([Email], CHARINDEX('@', [Email]) + 1, LEN([Email]) - CHARINDEX('@', [Email]))
        AS [Email Provider]
FROM [Users]
-- Order the results by email provider alphabetically
-- then by username alphabetically
ORDER BY [Email Provider] ASC
    , [Username] ASC

GO
