import { editMovie } from './endpoints.js';
import { showMovieDetails } from './movieDetails.js';
import { showSection } from './router.js';
import { createSubmitListener } from './util.js';

const section = document.getElementById('edit-movie');

const form = section.querySelector('form');
createSubmitListener(form, onSubmit);

let id;

export function showEditMovie(movie) {
  const title = form.querySelector('#title');
  const description = form.querySelector('textarea[name="description"]');
  const image = form.querySelector('#imageUrl');

  title.value = movie.title;
  description.value = movie.description;
  image.value = movie.img;
  id = movie._id;

  showSection(section);
}

async function onSubmit({ title, description, img }) {
  await editMovie({
    title,
    description,
    img,
    id,
  });

  showMovieDetails(null, id);
}
