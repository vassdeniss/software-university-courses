const Animal = require('../models/Animal');

exports.getAll = (location) => {
  let posts = Animal.find();

  if (location) {
    posts = Animal.find({ location: new RegExp(location, 'i') });
  }

  return posts;
};

exports.get = (psotId) => Animal.findById(psotId);

exports.getLatest = () =>
  Animal.find().sort({ field: 'asc', _id: -1 }).limit(3);

exports.donate = async (postId, userId) =>
  Animal.findByIdAndUpdate(postId, {
    $push: {
      donations: userId,
    },
  });

exports.create = (postData) => Animal.create(postData);

exports.edit = (postId, postData) =>
  Animal.findByIdAndUpdate(postId, postData, { runValidators: true });

exports.delete = (postId) => Animal.findByIdAndDelete(postId);
