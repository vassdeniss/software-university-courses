ALTER TABLE [Users]
	ADD CONSTRAINT [CK_dbo_Users_Password_CheckPasswordLenght]
	CHECK (LEN([Password]) >= 5)
