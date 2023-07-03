const router = require('express').Router();

const postService = require('../services/postService');

router.get('/', async (req, res) => {
  const posts = await postService.getLatest().lean();
  res.render('home', { posts });
});

router.get('/404', (req, res) => {
  res.render('404');
});

router.get('/search', async (req, res) => {
  const posts = await postService.getAll().lean();
  res.render('search', { posts });
});

router.post('/search', async (req, res) => {
  const { location } = req.body;

  const posts = await postService.getAll(location).lean();
  res.render('search', { posts });
});

module.exports = router;
