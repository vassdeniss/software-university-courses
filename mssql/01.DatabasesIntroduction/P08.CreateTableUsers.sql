CREATE TABLE [Users] (
    [Id] BIGINT PRIMARY KEY IDENTITY
    , [Username] VARCHAR(30) UNIQUE NOT NULL
    , [Password] VARCHAR(26) NOT NULL
    , [ProfilePicture] VARBINARY(MAX)
    , CHECK (DATALENGTH([ProfilePicture]) <= 900000)
    , [LastLoginTime] DATETIME2
    , [IsDeleted] BIT NOT NULL
)

INSERT INTO [Users] (
    [Username]
	, [Password]
	, [IsDeleted]
)
VALUES (
    'Kevin', 111444, 1
) , (
    'Ben', 12212, 1
) , (
    'Denis', 123321, 0
) , (
    'Andrej', 321123, 0
) , (
    'Narumaki', 01230221347, 1
)
