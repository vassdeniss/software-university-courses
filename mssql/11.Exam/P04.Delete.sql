USE [Zoo]

GO

DELETE FROM [Volunteers]
	  WHERE [DepartmentId] = (
	                          SELECT [Id]
							    FROM [VolunteersDepartments]
							   WHERE [DepartmentName] = 'Education program assistant'
							 )

GO

DELETE FROM [VolunteersDepartments]
	  WHERE [DepartmentName] = 'Education program assistant'

GO
