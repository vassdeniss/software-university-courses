document.getElementById('user').style.display = 'none';

const form = document.querySelector('form');
form.addEventListener('submit', loginUserAsync);

const url = 'http://localhost:3030/users/register';

async function loginUserAsync(event) {
  event.preventDefault();

  const formData = new FormData(event.target);

  const { email, password, rePass } = Object.fromEntries(formData.entries());

  try {
    if ([...formData.values()].some((field) => field === '')) {
      throw new Error('Incorrect input!');
    }

    if (password !== rePass) {
      throw new Error('Passwords dont match!');
    }

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

    const response = await fetch(url, options);

    const json = await response.json();

    if (!response.ok) {
      throw new Error(json.message);
    }

    const user = {
      email: json.email,
      id: json._id,
      token: json.accessToken,
    };

    localStorage.setItem('userData', JSON.stringify(user));
    window.location = './index.html';
  } catch (error) {
    form.reset();
    alert(error.message);
  }
}
