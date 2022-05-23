GO

USE [SoftUni]

GO

INSERT INTO [Towns] 
VALUES (
    'Sofia'
) , (
    'Plovdiv'
) , (
    'Varna'
) , (
	'Burgas'
)

GO

INSERT INTO [Departments] 
VALUES (
    'Engineering'
) , ( 
	'Sales'
) , (
    'Marketing'
) , (
    'Software Development'
) , (
	'Quality Assurance'
)

GO

INSERT INTO [Employees] 
VALUES (
    'Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '2013-02-01', 3500.00, NULL
) , ( 
	'Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '2004-03-02', 4000.00, NULL
) , (
	'Maria', 'Petrova', 'Ivanova', 'Intern', 5, '2016-08-28', 525.25, NULL
) , (
	'Georgi', 'Teziev', 'Ivanov', 'CEO', 2, '2007-12-09', 3000.00, NULL
) , (
	'Peter', 'Pan', 'Pan', 'Intern', 3, '2016-08-28', 599.88, NULL
)
