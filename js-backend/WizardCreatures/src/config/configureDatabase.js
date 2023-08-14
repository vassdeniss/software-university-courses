const mongoose = require('mongoose');

const uri = 'mongodb://127.0.0.1:27017/wizard-creatures';

async function connectDb() {
  mongoose.connect(uri);
}

module.exports = connectDb;
