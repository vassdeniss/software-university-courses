-- Connect to the 'SoftUni' database for execution of this query
USE [SoftUni]

GO

-- Create or alter a function
-- Parameters: setOfLetters, varchar, 20 symbols
--             word, varchar, 20 symbols
CREATE OR ALTER FUNCTION [ufn_IsWordComprised]
                         (@setOfLetters VARCHAR(20)
						 ,@word VARCHAR(20))

-- Returns a bit
RETURNS BIT
AS
BEGIN
	-- Declare 'i' variable for looping
	DECLARE @i INT = 1

	-- Start a while loop from 1 till the length of the word
	WHILE (@i <= LEN(@word))
	BEGIN
		-- Declare 'currLetter' which takes a letter from the word
		DECLARE @currLetter CHAR(1) = SUBSTRING(@word, @i, 1)

		-- If the current letter does not exist in the set
		-- return 0, the word is not composed with letters from the set
		IF (CHARINDEX(@currLetter, @setOfLetters) = 0)
		BEGIN
			RETURN 0
		END

		-- Increment 'i'
		SET @i += 1
	END

	-- If the if statement has not been triggered
	-- return 1, the word is composed with letters from the set
	RETURN 1
END

GO
