const express = require('express');

const addMiddlewares = require('./config/configureMiddlewares');
const useHandlebars = require('./config/configureEngine');
const connectDb = require('./config/configureDatabase');

const routes = require('./routes');

const errorHandler = require('./middlewares/errorHandlerMiddleware');

const app = express();

const PORT = 5000;

connectDb()
  .then(() => console.log('Connected to database'))
  .catch((err) => console.log(`DB error: ${err}`));

addMiddlewares(app);
useHandlebars(app);

app.use(routes);

app.use(errorHandler);

app.listen(PORT, console.log(`Server listening on port ${PORT}...`));
