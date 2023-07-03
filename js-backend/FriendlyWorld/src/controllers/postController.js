const router = require('express').Router();

const { isAuth } = require('../middlewares/authMiddleware');
const postService = require('../services/postService');
const { getErrors } = require('../utils/errorHelper');

router.get('/', async (req, res) => {
  const posts = await postService.getAll().lean();

  res.render('post/dashboard', { posts });
});

router.get('/details/:id', async (req, res, next) => {
  try {
    const post = await postService.get(req.params.id).lean();
    if (!post) {
      throw new Error('Post not found!');
    }

    const isOwner = post.owner.toString() === req.user?._id;
    const isLoggedNotOwner = req.user !== undefined && !isOwner;
    const isDonator = post.donations.some((donator) =>
      donator._id.equals(req.user._id)
    );

    res.render('post/details', { post, isOwner, isLoggedNotOwner, isDonator });
  } catch (err) {
    next(err);
  }
});

router.get('/details/:id/donate', isAuth, async (req, res, next) => {
  try {
    const post = await postService.get(req.params.id);
    if (!post) {
      throw new Error('Post not found!');
    }

    const isOwner = post.owner.toString() === req.user._id;
    if (isOwner) {
      throw new Error('You are the owner of this game!');
    }

    const isAlreadyBought = post.donations.some((donator) =>
      donator._id.equals(req.user._id)
    );
    if (isAlreadyBought) {
      throw new Error('You have already donated!');
    }

    await postService.donate(req.params.id, req.user._id);
    res.redirect(`/posts/details/${post._id}`);
  } catch (err) {
    next(err);
  }
});

router.get('/create', isAuth, (req, res) => {
  res.render('post/create');
});

router.post('/create', isAuth, async (req, res) => {
  const { name, years, kind, image, need, location, description } = req.body;

  try {
    await postService.create({
      name,
      years,
      kind,
      image,
      need,
      location,
      description,
      owner: req.user._id,
    });
    res.redirect('/posts');
  } catch (err) {
    res.render('post/create', {
      errors: getErrors(err),
      name,
      years,
      kind,
      image,
      need,
      location,
      description,
    });
  }
});

router.get('/edit/:id', isAuth, async (req, res, next) => {
  try {
    const post = await postService.get(req.params.id).lean();
    if (!post) {
      throw new Error('Post not found!');
    }

    const isOwner = post.owner.toString() === req.user._id;
    if (!isOwner) {
      throw new Error('You are not the owner of this post!');
    }

    res.render('post/edit', { post });
  } catch (err) {
    next(err);
  }
});

router.post('/edit/:id', isAuth, async (req, res) => {
  const { name, years, kind, image, need, location, description, ownerId } =
    req.body;
  if (ownerId !== req.user._id) {
    return res.render('404', { errors: ['You dont own this post!'] });
  }

  try {
    await postService.edit(req.params.id, {
      name,
      years,
      kind,
      image,
      need,
      location,
      description,
    });

    res.redirect(`/posts/details/${req.params.id}`);
  } catch (err) {
    res.render('post/edit', {
      errors: getErrors(err),
      post: {
        name,
        years,
        kind,
        image,
        need,
        location,
        description,
        owner: ownerId,
      },
    });
  }
});

router.get('/delete/:id', isAuth, async (req, res, next) => {
  try {
    const post = await postService.get(req.params.id);
    if (!post) {
      throw new Error('Post not found!');
    }

    const isOwner = post.owner.toString() === req.user._id;
    if (!isOwner) {
      throw new Error('You are not the owner of this post!');
    }

    await postService.delete(req.params.id);
    res.redirect('/posts');
  } catch (err) {
    next(err);
  }
});

module.exports = router;
