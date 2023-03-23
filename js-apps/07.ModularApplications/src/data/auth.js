import { clearUser, setUser } from '../util.js';
import { get, post } from './api.js';

export async function handleUser(email, username, password, rePass) {
  let endpoint = '/users/login';
  const data = {
    email,
    password,
  };

  if (
    email === undefined &&
    username === undefined &&
    password === undefined &&
    rePass === undefined
  ) {
    await get('/users/logout');
    clearUser();
    return;
  }

  if (!email || !password) {
    throw new Error('Empty fields!');
  }

  const emailPattern = /^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/g;
  if (!emailPattern.test(email)) {
    throw new Error('Invalid email!');
  }

  if (password.length < 3) {
    throw new Error('Password must be longer than 3 characters!');
  }

  if (rePass !== undefined) {
    if (!rePass || password !== rePass) {
      throw new Error('Passwords dont match!');
    }

    endpoint = '/users/register';
  }

  const userData = await post(endpoint, data);

  setUser({
    email: userData.email,
    id: userData._id,
    token: userData.accessToken,
  });
}
