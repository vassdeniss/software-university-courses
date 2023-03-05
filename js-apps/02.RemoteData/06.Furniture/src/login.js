import { request } from './request.js';

const [registerForm, loginForm] = document.querySelectorAll('form');

registerForm.addEventListener('submit', registerUserAsync);
loginForm.addEventListener('submit', loginUserAsync);

async function registerUserAsync(event) {
  event.preventDefault();

  const formData = new FormData(event.target);

  const { email, password, rePass } = Object.fromEntries(formData.entries());

  if (!email || !password) {
    alert('Invalid username or password!');
    throw new Error('Invalid username or password!');
  }

  if (password !== rePass) {
    throw new Error('Passwords dont match!');
  }

  event.target.reset();

  const data = {
    email,
    password,
    rePass,
  };

  const options = {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify(data),
  };

  const json = await request('/users/register', options);

  const user = {
    email: json.email,
    id: json._id,
    token: json.accessToken,
  };

  localStorage.setItem('userData', JSON.stringify(user));

  window.location = './homeLogged.html';
}

async function loginUserAsync(event) {
  event.preventDefault();

  const formData = new FormData(event.target);

  const { email, password } = Object.fromEntries(formData.entries());

  if (!email || !password) {
    alert('Incorrect input!');
    throw new Error('Incorrect input!');
  }

  event.target.reset();

  const data = {
    email,
    password,
  };

  const options = {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify(data),
  };

  const json = await request('/users/login', options);

  const user = {
    email: json.email,
    id: json._id,
    token: json.accessToken,
  };

  localStorage.setItem('userData', JSON.stringify(user));
  window.location = './homeLogged.html';
}
