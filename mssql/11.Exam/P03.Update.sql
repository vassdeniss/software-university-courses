USE [Zoo]

GO

UPDATE [Animals]
   SET [OwnerId] = (
                    SELECT [Id]
                      FROM [Owners]
					 WHERE [Name] = 'Kaloqn Stoqnov'
				   )
 WHERE [OwnerId] IS NULL

 GO
