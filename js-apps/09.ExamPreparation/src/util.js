const itemName = 'userData';

export function getUser() {
  return JSON.parse(localStorage.getItem(itemName));
}

export function setUser(data) {
  return localStorage.setItem(itemName, JSON.stringify(data));
}

export function clearUser() {
  localStorage.removeItem(itemName);
}

export function createSubmitHandler(callback) {
  return function (event) {
    event.preventDefault();

    const form = event.currentTarget;
    const formData = new FormData(form);
    const data = Object.fromEntries(formData.entries());

    callback(data, form);
  };
}
