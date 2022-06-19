USE [zoo]

GO

CREATE OR ALTER PROC [usp_AnimalsWithOwnersOrNot]
                     @animalName VARCHAR(30)
AS
BEGIN
	   SELECT [a].[Name]
	        , CASE
			      WHEN [o].[Name] IS NULL
				  THEN 'For adoption'
				  ELSE [o].[Name]
			  END AS [OwnerName]
	     FROM [Animals] AS [a]
	LEFT JOIN [Owners] AS [o]
	       ON [a].[OwnerId] = [o].[Id]
		WHERE [a].[Name] = @animalName
END

GO
