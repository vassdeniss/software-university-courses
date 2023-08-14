const router = require('express').Router();

const { isAuth } = require('../middlewares/authMiddleware');
const { getErrors } = require('../utils/errorHelper');
const userService = require('../services/userService');
const animalService = require('../services/animalService');

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

  const { email, password } = req.body;

  try {
    const token = await userService.login(email, password);
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

  const { firstName, lastName, email, password, repeatPassword } = req.body;

  try {
    const token = await userService.register({
      firstName,
      lastName,
      email,
      password,
      repeatPassword,
    });
    res.cookie('user-token', token);
    res.redirect('/');
  } catch (err) {
    res.render('user/register', {
      errors: getErrors(err),
      firstName,
      lastName,
      email,
    });
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

    const animals = await animalService.getByUser(req.user._id).lean();
    const ownerName = `${user.firstName} ${user.lastName}`;

    res.render('user/my-posts', {
      animals,
      ownerName,
    });
  } catch (err) {
    next(err);
  }
});

module.exports = router;
