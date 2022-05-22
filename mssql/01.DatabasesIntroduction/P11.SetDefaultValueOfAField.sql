ALTER TABLE [Users]
	ADD CONSTRAINT [DF_dbo_Users_LastLoginTime]
	DEFAULT GETDATE() FOR [LastLoginTime]
