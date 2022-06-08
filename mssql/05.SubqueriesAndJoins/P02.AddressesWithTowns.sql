-- Connect to the 'SoftUni' database for execution of this query
USE [SoftUni]

GO

-- Select the top 50 records including the first and the last name from the 'Employees' table
-- Select the name from the 'Towns' table
-- Select the address text from the 'Addresses' table
SELECT TOP 50
	   	 [e].[FirstName]
	   , [e].[LastName]
	   , [t].[Name]
	   , [a].[AddressText]
    FROM [Employees] AS [e]

-- Inner join the 'Employees' table with the 'Addresses' table
    JOIN [Addresses] AS [a] 
      ON [e].[AddressID] = [a].[AddressID]

-- Inner join the just created table with the 'Towns' table
	JOIN [Towns] AS [t]
	  ON [a].[TownID] = [t].[TownID]

-- Order the results by the first name from the 'Employees' table ascending
-- Then by the last name from the 'Employees' table ascending
ORDER BY [e].[FirstName] ASC
	   , [e].[LastName]  ASC

GO
