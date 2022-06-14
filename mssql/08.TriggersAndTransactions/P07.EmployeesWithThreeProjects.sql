-- Connect to the 'SoftUni' database for execution of this query
USE [SoftUni]

GO

-- Create or alter a procedure
CREATE OR ALTER PROC [usp_AssignProject]
                     @emloyeeId INT, @projectID INT
AS
BEGIN TRANSACTION
	-- If the count of projects of @employeeId is equal or higher than 3 rollback and raise error
	IF (
		 SELECT COUNT([ProjectID]) 
		   FROM [EmployeesProjects] 
		  WHERE [EmployeeID] = @emloyeeId
	   ) >= 3 
	BEGIN
		ROLLBACK
		RAISERROR('The employee has too many projects!', 16, 1) 
		RETURN
	END

	-- Insert @employeeId and @projectID into the 'EmployeesProjects' table
	INSERT INTO [EmployeesProjects] 
	VALUES (@emloyeeId, @projectID)
COMMIT

GO
