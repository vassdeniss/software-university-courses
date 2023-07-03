const mongoose = require('mongoose');

const animalSchema = new mongoose.Schema({
  name: {
    type: String,
    required: [true, 'Name is required!'],
    minLength: [2, 'Name should be at least 2 characters!'],
  },
  years: {
    type: Number,
    required: [true, 'Years is required!'],
    min: [1, 'Years must be between 1 and 100 characters!'],
    max: [100, 'Years must be between 1 and 100 characters!'],
  },
  kind: {
    type: String,
    required: [true, 'Kind is required!'],
    minLength: [3, 'Kind must be at least 3 characters!'],
  },
  image: {
    type: String,
    required: [true, 'Image is required!'],
    match: [
      /^http:\/\/|^https:\/\//,
      'Image must start with either http:// or https://',
    ],
  },
  need: {
    type: String,
    required: [true, 'Need is required!'],
    minLength: [3, 'Need must be between 3 and 20 characters!'],
    maxLength: [20, 'Need must be between 3 and 20 characters!'],
  },
  location: {
    type: String,
    required: [true, 'Location is required!'],
    minLength: [5, 'Location must be between 5 and 15 characters!'],
    maxLength: [15, 'Location must be between 5 and 15 characters!'],
  },
  description: {
    type: String,
    required: [true, 'Description is required!'],
    minLength: [5, 'Description must be between 5 and 50 characters!'],
    maxLength: [50, 'Description must be between 5 and 50 characters!'],
  },
  donations: [
    {
      type: mongoose.Types.ObjectId,
      ref: 'User',
      required: [true, 'Owner is required!'],
    },
  ],
  owner: {
    type: mongoose.Types.ObjectId,
    ref: 'User',
    required: [true, 'Owner is required!'],
  },
});

const Animal = mongoose.model('Animal', animalSchema);

module.exports = Animal;
