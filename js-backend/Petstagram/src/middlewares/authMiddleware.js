const jwt = require('../lib/jwt');

exports.auth = () => async (req, res, next) => {
  const token = req.cookies['user-token'];
  if (token) {
    try {
      const user = await jwt.verify(token, process.env.JWT_SECRET);
      req.user = user;
      res.locals.user = user;
      res.locals.isAuth = true;
      next();
    } catch (err) {
      res.clearCookie('user-token');
      res.redirect('/users/login');
    }
  } else {
    next();
  }
};

exports.isAuth = (req, res, next) => {
  if (!req.user) {
    return res.redirect('/users/login');
  }

  next();
};
