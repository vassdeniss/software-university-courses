-- Connect to the 'Orders' database to run this snippet
USE [Orders]

GO

-- Select the product names and the order dates from the 'Orders' table
-- Create a column 'Pay Due' that adds 3 days to the order date
-- Create a column 'Deliver Due' that adds 1 month to the order date
SELECT [ProductName]
    , [OrderDate]
    , DATEADD(DAY, 3, [OrderDate]) AS [Pay Due]
    , DATEADD(MONTH, 1, [OrderDate]) AS [Deliver Due]
FROM [Orders]

GO
