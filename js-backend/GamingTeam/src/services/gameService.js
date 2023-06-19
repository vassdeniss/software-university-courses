const Game = require('../models/Game');

exports.getAll = async (name, platform) => {
  let games = await Game.find().lean();

  if (name) {
    games = games.filter((game) =>
      game.name.toLowerCase().includes(name.toLowerCase())
    );
  }

  if (platform) {
    games = games.filter(
      (game) => game.platform.toLowerCase() === platform.toLowerCase()
    );
  }

  return games;
};

exports.get = (gameId) => Game.findById(gameId);

exports.buy = async (gameId, userId) =>
  Game.findByIdAndUpdate(gameId, {
    $push: {
      boughtBy: userId,
    },
  });

exports.create = (gameData) => Game.create(gameData);

exports.edit = (gameId, gameData) =>
  Game.findByIdAndUpdate(gameId, gameData, { runValidators: true });

exports.delete = (gameId) => Game.findByIdAndDelete(gameId);
