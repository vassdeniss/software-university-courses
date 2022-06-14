-- Connect to the 'SoftUni' database for execution of this query
USE [SoftUni]

GO

-- Create a table 'Deleted_Employees' into the 'SoftUni' database
CREATE TABLE [Deleted_Employees] (
	[EmployeeId] INT PRIMARY KEY IDENTITY -- Primary key column
	, [FirstName] VARCHAR(50) NOT NULL
	, [LastName] VARCHAR(50) NOT NULL
	, [MiddleName] VARCHAR(50)
	, [JobTitle] VARCHAR(50) NOT NULL
	, [DepartmentId] INT NOT NULL
	, [Salary] MONEY NOT NULL
)

GO

-- Create a trigger that triggers everytime the 'Employees' table is being deleted from
CREATE TRIGGER [tr_AddDeletedEmployeeInformation]
ON [Employees] FOR DELETE
AS
	-- Insert into the 'Deleted_Employees' table
	INSERT INTO [Deleted_Employees]([FirstName], [LastName], [MiddleName], [JobTitle], [DepartmentId], [Salary])

	-- Select the first, last, middle names, the job title, the department id and the salary from the deleted entries
	     SELECT [FirstName]
			  , [LastName]
			  , [MiddleName]
			  , [JobTitle]
			  , [DepartmentID]
			  , [Salary]
		   FROM [deleted]

GO
