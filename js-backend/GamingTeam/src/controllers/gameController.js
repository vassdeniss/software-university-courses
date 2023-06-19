const router = require('express').Router();

const { isAuth } = require('../middlewares/authMiddleware');
const gameService = require('../services/gameService');
const { getErrors } = require('../utils/errorHelper');

function test() {
  let n = 0;
}

router.get('/', async (req, res) => {
  const games = await gameService.getAll();

  res.render('game/catalog', { games });
});

router.get('/details/:id', async (req, res, next) => {
  try {
    const game = await gameService.get(req.params.id).lean();
    if (!game) {
      throw new Error('Game not found!');
    }

    const isOwner = game.owner.toString() === req.user?._id;
    const isLogged = req.user !== undefined;
    const isBuyer = game.boughtBy.some((buyer) =>
      buyer._id.equals(req.user._id)
    );

    res.render('game/details', { game, isOwner, isLogged, isBuyer });
  } catch (err) {
    next(err);
  }
});

router.get('/buy/:id', isAuth, async (req, res, next) => {
  try {
    const game = await gameService.get(req.params.id);
    if (!game) {
      throw new Error('Game not found!');
    }

    const isOwner = game.owner.toString() === req.user._id;
    if (isOwner) {
      throw new Error('You are the owner of this game!');
    }

    const isAlreadyBought = game.boughtBy.some((buyer) =>
      buyer._id.equals(req.user._id)
    );
    if (isAlreadyBought) {
      throw new Error('You already own this game!');
    }

    await gameService.buy(req.params.id, req.user._id);
    res.redirect(`/games/details/${game._id}`);
  } catch (err) {
    next(err);
  }
});

router.get('/create', isAuth, (req, res) => {
  res.render('game/create');
});

router.post('/create', isAuth, async (req, res) => {
  const { platform, name, image, price, genre, description } = req.body;

  try {
    await gameService.create({
      platform,
      name,
      image,
      price,
      genre,
      description,
      owner: req.user._id,
    });
    res.redirect('/games');
  } catch (err) {
    res.render('game/create', {
      errors: getErrors(err),
      platform,
      name,
      image,
      price,
      genre,
      description,
    });
  }
});

router.get('/edit/:id', isAuth, async (req, res, next) => {
  try {
    const game = await gameService.get(req.params.id).lean();
    if (!game) {
      throw new Error('Game not found!');
    }

    const isOwner = game.owner.toString() === req.user._id;
    if (!isOwner) {
      throw new Error('You are not the owner of this game!');
    }

    const platforms = getPlatforms(game.platform);

    res.render('game/edit', { game, platforms });
  } catch (err) {
    next(err);
  }
});

router.post('/edit/:id', isAuth, async (req, res) => {
  const { platform, name, image, price, genre, description, ownerId } =
    req.body;
  if (ownerId !== req.user._id) {
    return res.render('404', { errors: ['You dont own this game!'] });
  }

  try {
    await gameService.edit(req.params.id, {
      platform,
      name,
      image,
      price,
      genre,
      description,
    });

    res.redirect(`/games/details/${req.params.id}`);
  } catch (err) {
    res.render('game/edit', {
      errors: getErrors(err),
      platforms: getPlatforms(platform),
      game: {
        platform,
        name,
        image,
        price,
        genre,
        description,
        owner: ownerId,
      },
    });
  }
});

router.get('/delete/:id', isAuth, async (req, res, next) => {
  try {
    const game = await gameService.get(req.params.id);
    if (!game) {
      throw new Error('Game not found!');
    }

    const isOwner = game.owner.toString() === req.user._id;
    if (!isOwner) {
      throw new Error('You are not the owner of this game!');
    }

    await gameService.delete(req.params.id);
    res.redirect('/games');
  } catch (err) {
    next(err);
  }
});

function getPlatforms(platform) {
  const platforms = ['PC', 'Nintendo', 'PS4', 'PS5', 'XBOX'];

  const options = platforms.map((v, i) => ({
    value: v,
    selected: platform === v ? 'selected' : '',
  }));

  return options;
}

module.exports = router;
