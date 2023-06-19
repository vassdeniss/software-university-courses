const mongoose = require('mongoose');

// TODO: setup name
const uri = `mongodb+srv://vassdeniss:${process.env.MONGO_PASSWORD}@maincluster.zmsuenl.mongodb.net/gaming-team`;

async function connectDb() {
  mongoose.connect(uri);
}

module.exports = connectDb;
