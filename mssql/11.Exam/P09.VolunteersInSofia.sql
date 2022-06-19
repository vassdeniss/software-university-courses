USE [Zoo]

GO

  SELECT [Name]
       , [PhoneNumber]
	   , LTRIM(SUBSTRING([Address], CHARINDEX(',', [Address]) + 1, LEN([Address]))) AS [Address]
    FROM [Volunteers]
   WHERE [DepartmentId] = (
                           SELECT [Id] 
                             FROM [VolunteersDepartments]
                            WHERE [DepartmentName] = 'Education program assistant' 
						  )
     AND CHARINDEX('Sofia', [Address]) > 0
ORDER BY [Name] ASC

GO
