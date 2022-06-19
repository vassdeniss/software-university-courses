USE [Zoo]

GO

  SELECT [a].[Name]
       , DATEPART(YEAR, [a].[BirthDate]) AS [BirthYear]
  	   , [at].[AnimalType]
    FROM [Animals] AS [a]
    JOIN [AnimalTypes] AS [at]
      ON [a].[AnimalTypeId] = [at].[Id]
   WHERE [OwnerId] IS NULL
     AND [AnimalTypeId] <> (
                            SELECT [Id]
						      FROM [AnimalTypes]
						     WHERE [AnimalType] = 'Birds'
						   )
     AND [BirthDate] > '01-01-2018'
ORDER BY [a].[Name] ASC

GO
