-- Connect to the 'Diablo' database for execution of this query
USE [Diablo]

-- I am not commenting this
-- Code from github.com/IvaSabotinova

GO

DECLARE @StamatId INT = (SELECT Id FROM Users WHERE Username = 'Stamat') 
DECLARE @GameSafflowerId INT = (SELECT Id FROM Games WHERE [Name] = 'Safflower')
DECLARE @AvailableCash MONEY = (SELECT Cash FROM UsersGames WHERE UserId = (SELECT Id FROM Users WHERE Username = 'Stamat') AND GameId = (SELECT Id FROM Games WHERE [Name] = 'Safflower'))
DECLARE @TotalPriceItemsWithLevel11_12 MONEY = (SELECT Sum(Price) FROM Items WHERE MinLevel BETWEEN 11 AND 12)
DECLARE @StamatSafflowerUserGameId INT = (SELECT Id FROM UsersGames WHERE UserId = (SELECT Id FROM Users WHERE Username = 'Stamat')  AND GameId = (SELECT Id FROM Games WHERE [Name] = 'Safflower'))

BEGIN TRANSACTION
IF @AvailableCash >= @TotalPriceItemsWithLevel11_12
BEGIN
	UPDATE UsersGames
	SET Cash -= @TotalPriceItemsWithLevel11_12
	WHERE UserId = @StamatId AND GameId = @GameSafflowerId

	INSERT INTO UserGameItems (ItemId, UserGameId)
	SELECT Id, @StamatSafflowerUserGameId FROM Items WHERE MinLevel BETWEEN 11 AND 12
END
COMMIT

DECLARE @StamatId1 INT = (SELECT Id FROM Users WHERE Username = 'Stamat')
DECLARE @GameSafflowerId1 INT = (SELECT Id FROM Games WHERE [Name] = 'Safflower')
DECLARE @AvailableCash1 MONEY = (SELECT Cash FROM UsersGames WHERE UserId = (SELECT Id FROM Users WHERE Username = 'Stamat') AND GameId = (SELECT Id FROM Games WHERE [Name] = 'Safflower'))
DECLARE @TotalPriceItemsWithLevel19To21 MONEY= (SELECT Sum(Price) FROM Items WHERE MinLevel BETWEEN 19 AND 21)
DECLARE @StamatSafflowerUserGameId1 INT = (SELECT Id FROM UsersGames WHERE UserId = @StamatId1 AND GameId = @GameSafflowerId1)


BEGIN TRANSACTION
IF @AvailableCash1 >= @TotalPriceItemsWithLevel19To21
BEGIN
	UPDATE UsersGames
	SET Cash -= @TotalPriceItemsWithLevel19To21
	WHERE UserId = @StamatId1 AND GameId = @GameSafflowerId1

	INSERT INTO UserGameItems (ItemId, UserGameId)
	SELECT Id, @StamatSafflowerUserGameId1 FROM Items WHERE MinLevel BETWEEN 19 AND 21
END
COMMIT

DECLARE @StamatSafflowerUserGameIdNew INT = (SELECT Id FROM UsersGames WHERE UserId = (SELECT Id FROM Users WHERE Username = 'Stamat') 
									AND GameId = (SELECT Id FROM Games WHERE [Name] = 'Safflower'))
							
SELECT i.[Name] AS [Item Name] FROM UserGameItems AS ugi
JOIN Items AS i ON ugi.ItemId = i.Id
WHERE UserGameId = @StamatSafflowerUserGameIdNew
ORDER BY i.[Name]

GO
