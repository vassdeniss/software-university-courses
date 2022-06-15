-- Connect to the 'Bitbucket' database for execution of this query
USE [Bitbucket]

GO

-- Insert name, size, parent id and commit id into the 'Files' table
INSERT INTO [Files]
     VALUES ('Trade.idk', 2598.0, 1, 1)
     	  , ('menu.net', 9238.31, 2, 2)
     	  , ('Administrate.soshy', 1246.93, 3, 3)
     	  , ('Controller.php', 7353.15, 4, 4)
     	  , ('Find.java', 9957.86, 5, 5)
     	  , ('Controller.json', 14034.87, 3, 6)
     	  , ('Operate.xix', 766.92, 7, 7)

GO

-- Insert title, issue status, repository id and assignee id into the 'Issues' table
INSERT INTO [Issues]
     VALUES ('Critical Problem with HomeController.cs file', 'open', 1, 4)
		  , ('Typo fix in Judge.html', 'open', 4, 3)
		  , ('Implement documentation for UsersService.cs', 'closed', 8, 2)
		  , ('Unreachable code in Index.cs', 'open', 9, 8)

GO
