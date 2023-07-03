const { getErrors } = require('../utils/errorHelper');

module.exports = (err, req, res, next) => {
  res.render('404', { errors: getErrors(err) });
};
