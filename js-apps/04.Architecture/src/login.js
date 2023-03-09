import { showSection } from './router.js';
import { createSubmitListener } from './util.js';
import { handleUser } from './auth.js';
import { showHome } from './home.js';

const section = document.getElementById('login');

const loginFrom = section.querySelector('form');
createSubmitListener(loginFrom, onLogin);

export function showLogin(event) {
  event.preventDefault();

  showSection(section);
}

async function onLogin({ email, password }) {
  await handleUser(email, password);
  loginFrom.reset();
  showHome();
}
