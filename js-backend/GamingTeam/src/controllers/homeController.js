const router = require('express').Router();

const gameService = require('../services/gameService');

router.get('/', (req, res) => {
  res.render('home');
});

router.get('/404', (req, res) => {
  res.render('404');
});

router.get('/search', async (req, res) => {
  const games = await gameService.getAll();
  res.render('search', { games });
});

router.post('/search', async (req, res) => {
  const { name, platform } = req.body;

  const games = await gameService.getAll(name, platform);
  res.render('search', { games });
});

module.exports = router;
