-- Connect to the 'Bitbucket' database for execution of this query
USE [Bitbucket]

GO

-- Update the 'Issues' table and set the issue status to 'closed' where the assignee id is 6
UPDATE [Issues]
   SET [IssueStatus] = 'closed'
 WHERE [AssigneeId] = 6

GO
