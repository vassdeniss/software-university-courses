const router = require('express').Router();

const homeController = require('./controllers/homeController');
const userController = require('./controllers/userController');
const gameController = require('./controllers/gameController');

router.use(homeController);
router.use('/users', userController);
router.use('/games', gameController);

router.get('*', (req, res) => {
  res.redirect('/404');
});

module.exports = router;
