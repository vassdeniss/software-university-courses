const Photo = require('../models/Photo');

exports.getAllWith = (...includes) => {
  let photos = Photo.find();

  for (const include of includes) {
    photos = photos.populate(include);
  }

  return photos;
};

exports.get = (photoId) => Photo.findById(photoId);

exports.getWith = (photoId, include) => {
  let photo = Photo.findById(photoId);

  photo = photo.populate(include);

  return photo;
};

exports.getByUser = (userId) => {
  const photos = Photo.find().where('owner').eq(userId);

  return photos;
};

exports.create = (photoData) => Photo.create(photoData);

exports.edit = (photoId, photoData) =>
  Photo.findByIdAndUpdate(photoId, photoData, { runValidators: true });

exports.delete = (photoId) => Photo.findByIdAndDelete(photoId);

exports.comment = async (photoId, comment) =>
  Photo.findByIdAndUpdate(photoId, { $push: { commentList: comment } });
