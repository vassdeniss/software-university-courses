-- Connect to the 'SoftUni' database for execution of this query
USE [SoftUni]

GO

-- Create or alter a procedure
-- Parameters: departmnetId, int
CREATE OR ALTER PROC [usp_DeleteEmployeesFromDepartment]
                     @departmentId INT
AS
BEGIN
	-- Alter column 'ManagerID' from 'Departments' table and make it nullable
	 ALTER TABLE [Departments]
	ALTER COLUMN [ManagerID] INT NULL

	-- Delete from the 'EmployeesProjects' table
	 DELETE FROM [EmployeesProjects]

	-- Filter where the employee id is in the subquery
           WHERE [EmployeeID] IN (
		                          -- Select the employee id
								  -- from the 'Employees' table
								  -- where the department id matches the argument
		                          SELECT [EmployeeID] 
								    FROM [Employees] 
								   WHERE [DepartmentID] = @departmentId
								 )

	-- Update the 'Employees' table
	-- set every manager id to null
	-- where the employee id is in the subquery
	UPDATE [Employees]
	   SET [ManagerID] = NULL
	 WHERE [EmployeeID] IN (
		                   -- Select the employee id
						   -- from the 'Employees' table
						   -- where the department id matches the argument
		                   SELECT [EmployeeID] 
						     FROM [Employees] 
						    WHERE [DepartmentID] = @departmentId
						  )

	-- Update the 'Employees' table
	-- set every manager id to null
	-- where the manager id is in the subquery
	UPDATE [Employees]
	   SET [ManagerID] = NULL
	 WHERE [ManagerID] IN (
		                   -- Select the employee id
						   -- from the 'Employees' table
						   -- where the department id matches the argument
		                   SELECT [EmployeeID] 
						     FROM [Employees] 
						    WHERE [DepartmentID] = @departmentId
						  )

	-- Update the 'Departments' table
	-- set every manager id to null
	-- where the manager id is in the subquery
	UPDATE [Departments]
	   SET [ManagerID] = NULL
	 WHERE [ManagerID] IN (
		                   -- Select the employee id
						   -- from the 'Employees' table
						   -- where the department id matches the argument
		                   SELECT [EmployeeID] 
						     FROM [Employees] 
						    WHERE [DepartmentID] = @departmentId
						  )

	-- Delete entries from the 'Employees' table
	-- where the department id is equal to the argument
	DELETE FROM [Employees]
          WHERE [DepartmentID] = @departmentId

	-- Delete entries from the 'Departments' table
	-- where the department id is equal to the argument
	DELETE FROM [Departments]
          WHERE [DepartmentID] = @departmentId

	-- Select every entry from the 'Employees' table
	-- where the department id is equal to the argument
	SELECT COUNT(*) 
      FROM [Employees]
     WHERE [DepartmentID] = @departmentId
END

GO
