import { showHome } from './home.js';
import { showLogin } from './login.js';
import { showRegister } from './register.js';
import { updatePageForUser } from './util.js';
import { handleUser } from './auth.js';

showHome();

document.getElementById('home-link').addEventListener('click', showHome);
document.getElementById('login-link').addEventListener('click', showLogin);
document
  .getElementById('register-link')
  .addEventListener('click', showRegister);
document.getElementById('logout-link').addEventListener('click', async () => {
  await handleUser();
  showLogin();
  updatePageForUser();
});
