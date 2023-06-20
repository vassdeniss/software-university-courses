const mongoose = require('mongoose');

const uri = `mongodb+srv://vassdeniss:${process.env.MONGO_PASSWORD}@maincluster.zmsuenl.mongodb.net/petstragram`;

async function connectDb() {
  mongoose.connect(uri);
}

module.exports = connectDb;
