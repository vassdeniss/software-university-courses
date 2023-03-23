import { getUser, clearUser } from '../util.js';

const host = 'http://localhost';
const port = 3030;

async function request(method, endpoint, data) {
  const options = {
    method,
    headers: {},
  };

  if (data) {
    options.headers['Content-Type'] = 'application/json';
    options.body = JSON.stringify(data);
  }

  const user = getUser();
  if (user) {
    options.headers['X-Authorization'] = user.token;
  }

  try {
    const response = await fetch(`${host}:${port}${endpoint}`, options);

    let json;

    if (response.status !== 204) {
      json = await response.json();
    }

    if (!response.ok) {
      if (response.status === 403) {
        clearUser();
      }

      const error = json;
      throw error;
    }

    return json;
  } catch (error) {
    alert(error.message);
    throw error;
  }
}

export const get = request.bind(this, 'get');
export const post = request.bind(this, 'post');
export const put = request.bind(this, 'put');
export const del = request.bind(this, 'delete');
