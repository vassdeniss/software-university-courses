import { showSection } from './router.js';
import { createSubmitListener } from './util.js';
import { createMovie } from './endpoints.js';

const section = document.getElementById('add-movie');

export function showAddMovie() {
  showSection(section);
}

const form = section.querySelector('#add-movie-form');
createSubmitListener(form, onSubmit);

async function onSubmit(data) {
  await createMovie(data);
  form.reset();
}
