-- Connect to the 'SoftUni' database for execution of this query
USE [SoftUni]

GO

-- Create or alter a procedure
-- Parameters: townName, varchar, 30 symbols
CREATE OR ALTER PROC [usp_GetEmployeesFromTown]
                     @townName VARCHAR(30)
AS
BEGIN
      -- Select the first and last names from the 'Employees' table
	  SELECT [FirstName]
	       , [LastName]
        FROM [Employees] AS [e]

	  -- Inner join the 'Employees' table with the 'Addresses' table
	   JOIN [Addresses] AS [a]
	     ON [e].[AddressID] = [a].[AddressID]

	  -- Inner join the 'Addresses' table with the 'Towns' table
	   JOIN [Towns] AS [t]
	     ON [a].[TownID] = [t].[TownID]

	  -- Filter where the town name matches with the townName parameter
	  WHERE [t].[Name] = @townName
END

GO
