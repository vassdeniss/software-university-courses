const Creature = require('../models/Creature');

exports.getAll = () => Creature.find();

exports.get = (animalId) => Creature.findById(animalId);

exports.getWith = (animalId, include) => {
  let animal = Creature.findById(animalId);

  animal = animal.populate(include);

  return animal;
};

exports.getByUser = (userId) => {
  const animals = Creature.find().where('owner').eq(userId);
  return animals;
};

exports.create = (animalData) => Creature.create(animalData);

exports.edit = (animalId, animalData) =>
  Creature.findByIdAndUpdate(animalId, animalData, { runValidators: true });

exports.delete = (animalId) => Creature.findByIdAndDelete(animalId);

exports.vote = async (animalId, userId) =>
  Creature.findByIdAndUpdate(animalId, { $push: { votes: userId } });
