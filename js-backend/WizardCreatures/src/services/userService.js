const User = require('../models/User');
const bcrypt = require('bcrypt');
const jwt = require('../lib/jwt');
const { JWT_SECRET } = require('../environment');

exports.get = (userId) => User.findById(userId);

exports.login = async (email, password) => {
  const user = await User.findOne({ email });
  if (!user) {
    throw new Error('Invalid email or password!');
  }

  const isValid = await bcrypt.compare(password, user.password);
  if (!isValid) {
    throw new Error('Invalid email or password!');
  }

  return await generateToken(user);
};

exports.register = async (userData) => {
  const user = await User.findOne({ email: userData.email });
  if (user) {
    throw new Error('User already exists!');
  }

  const createdUser = await User.create(userData);

  return await generateToken(createdUser);
};

async function generateToken(user) {
  const payload = {
    _id: user._id,
    email: user.email,
  };

  const token = await jwt.sign(payload, JWT_SECRET, {
    expiresIn: '3d',
  });

  return token;
}
