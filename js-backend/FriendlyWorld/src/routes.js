const router = require('express').Router();

const homeController = require('./controllers/homeController');
const userController = require('./controllers/userController');
const postController = require('./controllers/postController');

router.use(homeController);
router.use('/users', userController);
router.use('/posts', postController);

router.get('*', (req, res) => {
  res.redirect('/404');
});

module.exports = router;
