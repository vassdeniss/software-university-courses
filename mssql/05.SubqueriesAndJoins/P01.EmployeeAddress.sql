-- Connect to the 'SoftUni' database for execution of this query
USE [SoftUni]

GO

-- Select the top 5 records including the employee id and the job title from the 'Employees' table
-- and the address id and the address text from the 'Addresses' table
SELECT TOP 5
	   	 [e].[EmployeeID]
	   , [e].[JobTitle]
	   , [a].[AddressID]
	   , [a].[AddressText]
    FROM [Employees] AS [e]

-- Inner join the 'Addresses' table on the PK/FK
    JOIN [Addresses] AS [a] 
      ON [e].[AddressID] = [a].[AddressID]

-- Order the results by the address id ascending
ORDER BY [a].[AddressID] ASC

GO

  
