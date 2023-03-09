import { get, post } from './api.js';

export async function handleUser(email, password, rePass) {
  let endpoint = '/users/login';
  let data = {
    email,
    password,
  };

  try {
    if (email === undefined && password === undefined && rePass === undefined) {
      await get('/users/logout');
      localStorage.clear();
      return;
    }

    if (!email || !password) {
      throw new Error('Empty fields!');
    }

    if (password.length < 6) {
      throw new Error('Password must be longer than 6 characters!');
    }

    if (rePass !== undefined) {
      if (!rePass || password !== rePass) {
        throw new Error('Passwords dont match!');
      }

      endpoint = '/users/register';
      data.rePass = rePass;
    }
  } catch (error) {
    alert(error.message);
    throw error;
  }

  const userData = await post(endpoint, data);

  localStorage.setItem(
    'userData',
    JSON.stringify({
      email: userData.email,
      id: userData._id,
      token: userData.accessToken,
    })
  );
}
