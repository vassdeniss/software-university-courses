-- Connect to the 'SoftUni' database for execution of this query
USE [SoftUni]

GO

-- Create or alter a procedure
-- Parameters: startWith, varchar, 30 symbols
CREATE OR ALTER PROC [usp_GetTownsStartingWith]
                     @startWith VARCHAR(30)
AS
BEGIN
     -- Select the town name from the 'Towns' table
	 SELECT [Name]
       FROM [Towns]

	  -- Filter where the town name starts with the startWith parameter
	  WHERE LEFT([Name], LEN(@startWith)) = @startWith
END

GO
