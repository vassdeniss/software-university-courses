import { showSection } from './router.js';
import {
  deleteMovie,
  getMovieById,
  getMovieLikes,
  hasUserLikedMovie,
  likeMovie,
} from './endpoints.js';
import { createElement } from './util.js';
import { showEditMovie } from './editMovie.js';
import { showHome } from './home.js';

const section = document.getElementById('movie-example');

export async function showMovieDetails(event, givenId) {
  event?.preventDefault();

  let id;
  if (event) {
    id = event.target.parentElement.dataset.id;
  } else {
    id = givenId;
  }

  const [movie, likes] = await Promise.all([
    getMovieById(id),
    getMovieLikes(id),
  ]);

  const userData = JSON.parse(localStorage.getItem('userData'));
  const hasLiked = userData && (await hasUserLikedMovie(id, userData.id));
  const isOwner = userData && userData.id === movie._ownerId;

  section.replaceChildren(
    createMovieDetailsElement(movie, likes, hasLiked, isOwner)
  );

  showSection(section);
}

function createMovieDetailsElement(movie, likes, hasLiked, isOwner) {
  const fragment = document.createDocumentFragment();

  const container = createElement('div', '', fragment, {
    class: 'container',
  });

  const row = createElement('div', '', container, {
    class: 'row bg-light text-dark',
  });

  createElement('h1', `Movie title: ${movie.title}`, row, {});

  const col8 = createElement('div', '', row, {
    class: 'col-md-8',
  });

  createElement('img', '', col8, {
    class: 'img-thumbnail',
    src: movie.img,
    alt: 'Movie',
  });

  const col4 = createElement('div', '', row, {
    class: 'col-md-4 text-center',
  });

  createElement('h3', 'Movie Description', col4, {
    class: 'my-3',
  });

  createElement('p', movie.description, col4, {});

  createControls(movie, likes, isOwner, hasLiked, col4);

  return fragment;
}

function createControls(movie, likes, isOwner, hasLiked, col4) {
  if (isOwner) {
    const deleteBtn = createElement('a', 'Delete', col4, {
      href: '#',
      class: 'btn btn-danger',
    });
    deleteBtn.addEventListener('click', async () => {
      await deleteMovie(movie._id);
      showHome();
    });

    const editBtn = createElement('a', 'Edit', col4, {
      href: '#',
      class: 'btn btn-warning',
    });
    editBtn.addEventListener('click', () => showEditMovie(movie));
  } else if (!isOwner && !hasLiked) {
    const likeBtn = createElement('a', 'Like', col4, {
      href: '#',
      class: 'btn btn-primary',
    });
    likeBtn.addEventListener('click', async () => {
      await likeMovie(movie._id);
      span.textContent = `Liked ${likes + 1}`;
      likeBtn.style.display = 'none';
      span.style.display = 'inline-block';
    });
  }

  const span = createElement('span', `Liked ${likes}`, col4, {
    class: 'enrolled-span',
  });
}
