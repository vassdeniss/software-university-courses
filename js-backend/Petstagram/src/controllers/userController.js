const router = require('express').Router();

const { isAuth } = require('../middlewares/authMiddleware');
const { getErrors } = require('../utils/errorHelper');
const userService = require('../services/userService');
const photoService = require('../services/photoService');

router.get('/login', (req, res) => {
  if (req.user) {
    return res.render('404', { errors: ['User already logged in!'] });
  }

  res.render('user/login');
});

router.post('/login', async (req, res) => {
  if (req.user) {
    return res.render('404', { errors: ['User already logged in!'] });
  }

  const { username, password } = req.body;

  try {
    const token = await userService.login(username, password);
    res.cookie('user-token', token);
    res.redirect('/');
  } catch (err) {
    res.render('user/login', { errors: getErrors(err) });
  }
});

router.get('/register', (req, res) => {
  if (req.user) {
    return res.render('404', { errors: ['User already logged in!'] });
  }

  res.render('user/register');
});

router.post('/register', async (req, res) => {
  if (req.user) {
    return res.render('404', { errors: ['User already logged in!'] });
  }

  const { username, email, password, repeatPassword } = req.body;

  try {
    const token = await userService.register({
      username,
      email,
      password,
      repeatPassword,
    });
    res.cookie('user-token', token);
    res.redirect('/');
  } catch (err) {
    res.render('user/register', { errors: getErrors(err), username, email });
  }
});

router.get('/logout', isAuth, (req, res) => {
  res.clearCookie('user-token');
  res.redirect('/');
});

router.get('/profile', isAuth, async (req, res, next) => {
  try {
    const user = await userService.get(req.user._id).lean();
    if (!user) {
      throw new Error('User not found!');
    }

    const photos = await photoService.getByUser(req.user._id).lean();

    res.render('user/profile', { user, count: photos.length, photos });
  } catch (err) {
    next(err);
  }
});

module.exports = router;
