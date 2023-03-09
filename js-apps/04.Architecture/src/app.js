import { showHome } from './home.js';
import { showDashboard } from './dashboard.js';
import { showCreate } from './create.js';
import { showLogin } from './login.js';
import { showRegister } from './register.js';
import { handleUser } from './auth.js';

showHome();

document
  .getElementById('register-link')
  .addEventListener('click', showRegister);
document.getElementById('login-link').addEventListener('click', showLogin);
document.getElementById('logout-link').addEventListener('click', async () => {
  await handleUser();
  showHome();
});
document
  .getElementById('dashboard-link')
  .addEventListener('click', showDashboard);
document.getElementById('create-link').addEventListener('click', showCreate);
