const mongoose = require('mongoose');

const photoSchema = new mongoose.Schema({
  name: {
    type: String,
    required: [true, 'Name is required!'],
    minLength: [2, 'Name should be at least 2 characters!'],
  },
  image: {
    type: String,
    required: [true, 'Image is required!'],
    match: [
      /^http:\/\/|^https:\/\//,
      'Image must start with either http:// or https://',
    ],
  },
  age: {
    type: Number,
    required: [true, 'Age is required!'],
    min: [1, 'Age must be between 1 and 100 characters!'],
    max: [100, 'Age must be between 1 and 100 characters!'],
  },
  description: {
    type: String,
    required: [true, 'Description is required!'],
    minLength: [5, 'Description must be between 5 and 50 characters!'],
    maxLength: [50, 'Description must be between 5 and 50 characters!'],
  },
  location: {
    type: String,
    required: [true, 'Location is required!'],
    minLength: [5, 'Location must be between 5 and 50 characters!'],
    maxLength: [50, 'Location must be between 5 and 50 characters!'],
  },
  commentList: [
    {
      user: {
        type: mongoose.Types.ObjectId,
        ref: 'User',
        required: [true, 'Owner is required!'],
      },
      comment: {
        type: String,
        required: [true, 'Comment is required!'],
      },
    },
  ],
  owner: {
    type: mongoose.Types.ObjectId,
    ref: 'User',
    required: [true, 'Owner is required!'],
  },
});

const Photo = mongoose.model('Photo', photoSchema);

module.exports = Photo;
