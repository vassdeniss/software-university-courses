import { showSection } from './router.js';
import { createSubmitListener } from './util.js';
import { createIdea } from './endpoints.js';
import { showDashboard } from './dashboard.js';

const section = document.getElementById('create-idea');

export function showCreate(event) {
  event.preventDefault();

  showSection(section);
}

const form = section.querySelector('form');
createSubmitListener(form, onSubmit);

async function onSubmit(data) {
  await createIdea(data);
  form.reset();
  showDashboard();
}
