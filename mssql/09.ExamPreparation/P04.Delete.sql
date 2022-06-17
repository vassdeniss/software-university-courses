-- Connect to the 'Bitbucket' database for execution of this query
USE [Bitbucket]

GO

-- Delete from the 'RepositoriesContributors' table where the repository is 'Softuni-Teamwork'
DELETE FROM [RepositoriesContributors]
      WHERE [RepositoryId] = 3

-- Delete from the 'Issues' table where the repository is 'Softuni-Teamwork'
DELETE FROM [Issues]
      WHERE [RepositoryId] = 3
	  
-- Delete from the 'Files' table where the commit id is in the list of commit ids where the repository id is 3
DELETE FROM [Files]
      WHERE [CommitId] IN (
						   SELECT [Id] 
						     FROM [Commits] 
						    WHERE [RepositoryId] = 3
						  )

-- Delete from the 'Commits' table where the repository is 'Softuni-Teamwork'
DELETE FROM [Commits]
      WHERE [RepositoryId] = 3

-- Delete from the 'Repositories' table where the repository is 'Softuni-Teamwork'
DELETE FROM [Repositories]
      WHERE [Id] = 3

GO
