ALTER TABLE [Users]
	DROP CONSTRAINT [PK_dbo_Users_IdUsername]

ALTER TABLE [Users]
	ADD CONSTRAINT [PK_dbo_Users_Id]
	PRIMARY KEY ([Id])

ALTER TABLE [Users]
	ADD CONSTRAINT [CK_dbo_Users_Username_UsernameLenght]
	CHECK(LEN(Username) >= 3)
