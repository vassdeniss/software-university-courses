const { ValidationError } = require('mongoose').Error;

exports.getErrors = (error) => {
  if (error instanceof ValidationError) {
    return Object.values(error.errors).map((err) => err.message);
  } else if (error instanceof Error) {
    return [error.message];
  } else {
    return [];
  }
};
