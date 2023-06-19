const mongoose = require('mongoose');

const gameSchema = new mongoose.Schema({
  name: {
    type: String,
    required: [true, 'Name is required!'],
    minLength: [4, 'Name should be at least 4 characters!'],
  },
  image: {
    type: String,
    required: [true, 'Image is required!'],
    match: [
      /^http:\/\/|^https:\/\//,
      'Image must start with either http:// or https://',
    ],
  },
  price: {
    type: Number,
    required: [true, 'Price is required!'],
    min: [0, 'Pirce cannot be a negative number!'],
  },
  description: {
    type: String,
    required: [true, 'Description is required!'],
    minLength: [10, 'Description should be at least 10 characters!'],
  },
  genre: {
    type: String,
    required: [true, 'Genre is required!'],
    minLength: [2, 'Gnere should be at least 2 characters!'],
  },
  platform: {
    type: String,
    enum: {
      values: ['PC', 'Nintendo', 'PS4', 'PS5', 'XBOX'],
      message: 'Platform can only be "PC", "Nintendo", "PS4", "PS5" or "XBOX"',
    },
  },
  boughtBy: [
    {
      type: mongoose.Types.ObjectId,
      ref: 'User',
    },
  ],
  owner: {
    type: mongoose.Types.ObjectId,
    ref: 'User',
  },
});

const Game = mongoose.model('Game', gameSchema);

module.exports = Game;
