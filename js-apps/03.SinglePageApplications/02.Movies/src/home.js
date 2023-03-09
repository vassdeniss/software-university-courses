import { showSection } from './router.js';
import { showAddMovie } from './addMovie.js';
import { showMovieDetails } from './movieDetails.js';
import { createElement, updatePageForUser } from './util.js';
import { getMovies } from './endpoints.js';

const section = document.getElementById('home-page');

export async function showHome() {
  showSection(section);
  updatePageForUser();

  const movies = await getMovies();
  section
    .querySelector('#movies-list')
    .replaceChildren(...Object.values(movies).map(createMovieElement));
}

section
  .querySelector('#add-movie-button')
  .addEventListener('click', showAddMovie);

function createMovieElement(movie) {
  const fragment = document.createDocumentFragment();

  const li = createElement('li', '', fragment, {
    class: 'card mb-4',
  });

  createElement('img', '', li, {
    class: 'card-img-top',
    src: movie.img,
    alt: 'Card image cap',
    width: '400',
  });

  const body = createElement('div', '', li, {
    class: 'card-body',
  });

  createElement('h4', movie.title, body, {
    class: 'card-title',
  });

  const footer = createElement('div', '', li, {
    class: 'card-footer',
  });

  const aId = createElement('a', '', footer, {
    'data-id': movie._id,
  });

  const button = createElement('button', 'Details', aId, {
    class: 'btn btn-info',
    type: 'button',
  });

  button.addEventListener('click', showMovieDetails);

  return fragment;
}
