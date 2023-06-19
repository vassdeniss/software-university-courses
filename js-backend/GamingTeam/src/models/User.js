const mongoose = require('mongoose');
const bcrypt = require('bcrypt');

const userSchema = new mongoose.Schema({
  username: {
    type: String,
    required: [true, 'Username is required!'],
    unique: true,
    minLength: [5, 'Username should be at least 5 characters!'],
  },
  email: {
    type: String,
    required: [true, 'Email is required!'],
    minLength: [10, 'Email should be at least 10 characters!'],
  },
  password: {
    type: String,
    required: [true, 'Password is required!'],
    minLength: [4, 'Password should be at least 4 characters!'],
  },
});

userSchema.virtual('repeatPassword').set(function (value) {
  if (!value) {
    this.invalidate('repeatPassword', 'Repeat password is required!');
  }

  if (value !== this.password) {
    this.invalidate('repeatPassword', 'Password mismatch!');
  }
});

userSchema.pre('save', async function () {
  this.password = await bcrypt.hash(this.password, 10);
});

const User = mongoose.model('User', userSchema);

module.exports = User;
