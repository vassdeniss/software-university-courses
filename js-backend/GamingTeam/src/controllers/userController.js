const router = require('express').Router();

const { isAuth } = require('../middlewares/authMiddleware');
const userService = require('../services/userService');
const { getErrors } = require('../utils/errorHelper');

router.get('/login', (req, res) => {
  res.render('user/login');
});

router.post('/login', async (req, res) => {
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
  res.render('user/register');
});

router.post('/register', async (req, res) => {
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

module.exports = router;
