const router = require('express').Router();

const { isAuth } = require('../middlewares/authMiddleware');
const animalService = require('../services/animalService');
const { getErrors } = require('../utils/errorHelper');

router.get('/', async (req, res) => {
  const animals = await animalService.getAll().lean();
  res.render('animal/all-posts', { animal: animals });
});

router.get('/details/:id', async (req, res, next) => {
  try {
    const animal = await animalService
      .getWith(req.params.id, ['owner', 'votes'])
      .lean();
    if (!animal) {
      throw new Error('Animal not found!');
    }

    const ownerName = `${animal.owner.firstName} ${animal.owner.lastName}`;
    const isLogged = req.user !== undefined;
    const isOwner = isLogged && animal.owner._id.toString() === req.user._id;
    const hasVoted = animal.votes.some(
      (vote) => vote._id.toString() === req.user._id
    );

    const votes = animal.votes.length;
    const voteEmails = animal.votes.map((vote) => vote.email).join(', ');

    res.render('animal/details', {
      animal,
      ownerName,
      isOwner,
      isLogged,
      hasVoted,
      votes,
      voteEmails,
    });
  } catch (err) {
    next(err);
  }
});

router.get('/details/:id/vote', isAuth, async (req, res, next) => {
  try {
    const animalId = req.params.id;
    const userId = req.user._id;

    await animalService.vote(animalId, userId);
    res.redirect(`/animals/details/${animalId}`);
  } catch (err) {
    next(err);
  }
});

router.get('/create', isAuth, (req, res) => {
  res.render('animal/create');
});

router.post('/create', isAuth, async (req, res) => {
  const { name, species, skinColor, eyeColor, image, description } = req.body;

  try {
    await animalService.create({
      name,
      species,
      skinColor,
      eyeColor,
      image,
      description,
      owner: req.user._id,
    });
    res.redirect('/animals/');
  } catch (err) {
    res.render('animal/create', {
      errors: getErrors(err),
      name,
      species,
      skinColor,
      eyeColor,
      image,
      description,
    });
  }
});

router.get('/edit/:id', isAuth, async (req, res, next) => {
  try {
    const animal = await animalService.get(req.params.id).lean();
    if (!animal) {
      throw new Error('Animal not found!');
    }

    const isOwner = animal.owner.toString() === req.user._id;
    if (!isOwner) {
      throw new Error('You are not the owner of this animal!');
    }

    res.render('animal/edit', { animal });
  } catch (err) {
    next(err);
  }
});

router.post('/edit/:id', isAuth, async (req, res) => {
  const { name, species, skinColor, eyeColor, image, description, owner } =
    req.body;
  if (owner !== req.user._id) {
    return res.render('404', { errors: ['You dont own this animal!'] });
  }

  try {
    await animalService.edit(req.params.id, {
      name,
      species,
      skinColor,
      eyeColor,
      image,
      description,
    });

    res.redirect(`/animals/details/${req.params.id}`);
  } catch (err) {
    res.render('animal/edit', {
      errors: getErrors(err),
      animal: {
        name,
        species,
        skinColor,
        eyeColor,
        image,
        description,
        owner,
      },
    });
  }
});

router.get('/delete/:id', isAuth, async (req, res, next) => {
  try {
    const animal = await animalService.get(req.params.id);
    if (!animal) {
      throw new Error('Animal not found!');
    }

    const isOwner = animal.owner.toString() === req.user._id;
    if (!isOwner) {
      throw new Error('You are not the owner of this animal!');
    }

    await animalService.delete(req.params.id);
    res.redirect('/animals/');
  } catch (err) {
    next(err);
  }
});

module.exports = router;
