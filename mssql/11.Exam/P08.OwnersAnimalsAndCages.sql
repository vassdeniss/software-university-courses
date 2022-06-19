USE [Zoo]

GO

  SELECT CONCAT([o].[Name], '-', [a].[Name]) AS [OwnersAnimals]
       , [o].[PhoneNumber]
	   , [ac].[CageId]
    FROM [Animals] AS [a]
    JOIN [Owners] AS [o]
      ON [a].[OwnerId] = [o].[Id]
	JOIN [AnimalsCages] AS [ac]
	  ON [a].[Id] = [ac].[AnimalId]
	JOIN [AnimalTypes] AS [at]
	  ON [a].[AnimalTypeId] = [at].[Id]
   WHERE [at].[AnimalType] = 'Mammals'
ORDER BY [o].[Name] ASC
       , [a].[Name] DESC

GO
