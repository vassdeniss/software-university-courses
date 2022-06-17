-- Connect to the 'Bitbucket' database for execution of this query
USE [Bitbucket]

GO

-- Create or alter function
CREATE OR ALTER FUNCTION [udf_AllUserCommits]
					     (@username VARCHAR(30)) 
-- Function returns int
RETURNS INT
AS
BEGIN
	-- Return a subquery
	RETURN (
		-- Select the count of everything from the 'Users' table
		SELECT COUNT(*) 
		  FROM [Users] AS [u]

		-- Inner join the 'Users' table with the 'Commits' table
		  JOIN [Commits] AS [c] 
		    ON [u].[Id] = [c].[ContributorId]

		-- Filter where the username matches the @username parameter
		 WHERE [u].[Username] = @username
	)
END

GO
