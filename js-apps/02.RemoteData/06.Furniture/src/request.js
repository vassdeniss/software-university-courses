const host = 'http://localhost';
const port = 3030;

export async function request(url, options) {
  try {
    const response = await fetch(`${host}:${port}${url}`, options);

    const json = await response.json();

    if (!response.ok) {
      throw new Error(json.message);
    }

    return json;
  } catch (error) {
    console.error(error.message);
    alert(error.message);
  }
}
