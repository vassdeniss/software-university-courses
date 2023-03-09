import { showSection } from './router.js';
import { createSubmitListener } from './util.js';
import { handleUser } from './auth.js';
import { showHome } from './home.js';

const section = document.getElementById('form-sign-up');

const registerForm = section.querySelector('#register-form');
createSubmitListener(registerForm, onRegister);

export function showRegister() {
  showSection(section);
}

async function onRegister({ email, password, repeatPassword }) {
  await handleUser(email, password, repeatPassword);
  registerForm.reset();
  showHome();
}
