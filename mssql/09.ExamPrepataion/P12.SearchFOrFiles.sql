-- Connect to the 'Bitbucket' database for execution of this query
USE [Bitbucket]

GO

-- Create or alter stored procedure
CREATE OR ALTER PROC [usp_SearchForFiles]
                     @fileExtension VARCHAR(70)
AS
BEGIN
	-- Select the id, the name and concat the size with 'KB' from the 'Files' table
	SELECT [Id]
	     , [Name]
		 , CONCAT([Size], 'KB') AS [Size] 
	  FROM [Files]

	-- Filter where the file name contains '.@fileExtension'
	 WHERE CHARINDEX(CONCAT('.', @fileExtension), [Name]) <> 0

	-- Order by the id ascending
	-- then by the name ascending
	-- then by the size descending
	ORDER BY [Id] ASC 
	       , [Name] ASC
		   , [Size] DESC
END

GO
