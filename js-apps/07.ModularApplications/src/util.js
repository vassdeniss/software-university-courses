export function getUser() {
  return JSON.parse(localStorage.getItem('userData'));
}

export function setUser(user) {
  localStorage.setItem('userData', JSON.stringify(user));
}

export function clearUser() {
  localStorage.removeItem('userData');
}

// TODO: compare with your own
export function createSubmitHandler(callback) {
  return function (event) {
    event.preventDefault();

    const form = event.currentTarget;
    const formData = new FormData(form);
    const data = Object.fromEntries(formData.entries());

    callback(data, form);
  };
}

export function validateTeam(name, logoUrl, description) {
  if (!name || name.length < 4) {
    throw new Error('Invalid team name!');
  }

  if (!logoUrl) {
    throw new Error('Invalid team logo!');
  }

  if (!description || description.length < 10) {
    throw new Error('Invalid team description!');
  }
}
