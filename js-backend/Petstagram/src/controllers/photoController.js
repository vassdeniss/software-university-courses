const router = require('express').Router();

const { isAuth } = require('../middlewares/authMiddleware');
const photoService = require('../services/photoService');
const { getErrors } = require('../utils/errorHelper');

router.get('/', async (req, res) => {
  const photos = await photoService.getAllWith('owner').lean();

  res.render('photo/catalog', { photos });
});

router.get('/details/:id', async (req, res, next) => {
  try {
    const photo = await photoService
      .getWith(req.params.id, ['owner', 'commentList.user'])
      .lean();
    if (!photo) {
      throw new Error('Photo not found!');
    }

    const isOwner = photo.owner._id.toString() === req.user?._id;
    const isLoggedNotOwner = req.user !== undefined && !isOwner;

    res.render('photo/details', { photo, isLoggedNotOwner, isOwner });
  } catch (err) {
    next(err);
  }
});

router.post('/details/:id/comment', isAuth, async (req, res, next) => {
  const { comment, isOwner } = req.body;

  try {
    if (isOwner === true) {
      throw new Error('You are the owner of the photo!');
    }

    const photoId = req.params.id;
    const user = req.user._id;

    await photoService.comment(photoId, { user, comment });
    res.redirect(`/photos/details/${photoId}`);
  } catch (err) {
    next(err);
  }
});

router.get('/create', isAuth, (req, res) => {
  res.render('photo/create');
});

router.post('/create', isAuth, async (req, res) => {
  const { name, age, description, location, image } = req.body;

  try {
    await photoService.create({
      name,
      age,
      description,
      location,
      image,
      owner: req.user._id,
    });
    res.redirect('/photos');
  } catch (err) {
    res.render('photo/create', {
      errors: getErrors(err),
      name,
      age,
      description,
      location,
      image,
    });
  }
});

router.get('/edit/:id', isAuth, async (req, res, next) => {
  try {
    const photo = await photoService.get(req.params.id).lean();
    if (!photo) {
      throw new Error('Photo not found!');
    }

    const isOwner = photo.owner.toString() === req.user._id;
    if (!isOwner) {
      throw new Error('You are not the owner of this photo!');
    }

    res.render('photo/edit', { photo });
  } catch (err) {
    next(err);
  }
});

router.post('/edit/:id', isAuth, async (req, res) => {
  const { name, age, description, location, image, owner } = req.body;
  if (owner !== req.user._id) {
    return res.render('404', { errors: ['You dont own this photo!'] });
  }

  try {
    await photoService.edit(req.params.id, {
      name,
      age,
      description,
      location,
      image,
    });

    res.redirect(`/photos/details/${req.params.id}`);
  } catch (err) {
    res.render('photo/edit', {
      errors: getErrors(err),
      photo: {
        name,
        age,
        description,
        location,
        image,
        owner,
      },
    });
  }
});

router.get('/delete/:id', isAuth, async (req, res, next) => {
  try {
    const photo = await photoService.get(req.params.id);
    if (!photo) {
      throw new Error('Photo not found!');
    }

    const isOwner = photo.owner.toString() === req.user._id;
    if (!isOwner) {
      throw new Error('You are not the owner of this photo!');
    }

    await photoService.delete(req.params.id);
    res.redirect('/photos');
  } catch (err) {
    next(err);
  }
});

module.exports = router;
