-- Connect to the 'Bank' database for execution of this query
USE [Bank]

GO

-- Create or alter a procedure
CREATE OR ALTER PROC [usp_GetHoldersFullName]
AS
BEGIN
    -- Select as concatted the first and last names from the 'AccountHolders' table
	SELECT CONCAT([FirstName], ' ', [LastName]) AS [Full Name]
	  FROM [AccountHolders]
END

GO
