USE [Zoo]

GO

  SELECT [Name]
	   , [PhoneNumber]
	   , [Address]
	   , [AnimalId]
	   , [DepartmentId]
    FROM [Volunteers]
ORDER BY [Name] ASC
       , [AnimalId] ASC
	   , [DepartmentId] ASC

GO
