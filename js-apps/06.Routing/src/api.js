const host = 'http://localhost';
const port = 3030;

export async function request(method, endpoint, data) {
  debugger;
  try {
    const options = {
      method,
      headers: {},
    };

    if (data) {
      options.headers['Content-Type'] = 'application/json';
      options.body = JSON.stringify(data);
    }

    const user = JSON.parse(localStorage.getItem('userData'));
    if (user) {
      options.headers['X-Authorization'] = user.token;
    }

    const response = await fetch(`${host}:${port}${endpoint}`, options);

    let json;

    if (response.status !== 204) {
      json = await response.json();
    }

    if (!response.ok) {
      if (response.status === 403) {
        localStorage.removeItem('userData');
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
