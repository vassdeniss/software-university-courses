USE [zoo]

GO

CREATE OR ALTER FUNCTION [udf_GetVolunteersCountFromADepartment]
                         (@volunteersDepartment VARCHAR(30))
RETURNS INT
AS
BEGIN
	RETURN (
		SELECT COUNT([Id])
		  FROM [Volunteers]
		 WHERE [DepartmentId] = (
		                         SELECT [Id]
								   FROM [VolunteersDepartments]
							      WHERE [DepartmentName] = @volunteersDepartment
								)
	)
END

GO
