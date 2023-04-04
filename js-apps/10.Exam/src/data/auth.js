import { clearUser, setUser } from '../util.js';
import { get, post } from './api.js';

const endpoints = {
  login: '/users/login',
  register: '/users/register',
  logout: '/users/logout',
};

export async function login(email, password) {
  const result = await post(endpoints.login, {
    email,
    password,
  });

  setUser(result);
}

export async function register(email, password) {
  const result = await post(endpoints.register, {
    email,
    password,
  });

  setUser(result);
}

export async function logout() {
  await get(endpoints.logout);
  clearUser();
}
