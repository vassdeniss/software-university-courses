const router = require('express').Router();

const { isAuth } = require('../middlewares/authMiddleware');
const userService = require('../services/userService');
const { getErrors } = require('../utils/errorHelper');

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

  const { email, password, repeatPassword } = req.body;

  try {
    const token = await userService.register({
      email,
      password,
      repeatPassword,
    });
    res.cookie('user-token', token);
    res.redirect('/');
  } catch (err) {
    console.log(err);
    res.render('user/register', { errors: getErrors(err), email });
  }
});

router.get('/logout', isAuth, (req, res) => {
  res.clearCookie('user-token');
  res.redirect('/');
});

router.get('/profile/:id', (req, res) => {
  res.send('test');
});

module.exports = router;
