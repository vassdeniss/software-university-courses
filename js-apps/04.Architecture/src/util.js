export function createSubmitListener(form, callback) {
  form.addEventListener('submit', onSubmit);

  function onSubmit(event) {
    event.preventDefault();

    const formData = new FormData(form);
    const data = Object.fromEntries(formData.entries());

    callback(data);
  }
}

export function updatePageForUser() {
  const userData = JSON.parse(localStorage.getItem('userData'));

  if (userData) {
    Array.from(document.getElementsByClassName('user')).forEach(
      (el) => (el.style.display = 'inline-block')
    );

    Array.from(document.getElementsByClassName('guest')).forEach(
      (el) => (el.style.display = 'none')
    );
  } else {
    Array.from(document.getElementsByClassName('user')).forEach(
      (el) => (el.style.display = 'none')
    );

    Array.from(document.getElementsByClassName('guest')).forEach(
      (el) => (el.style.display = 'inline-block')
    );
  }
}

export function createElement(type, content, parent, attributes) {
  const element = document.createElement(type);
  element.textContent = content;

  if (parent) {
    parent.appendChild(element);
  }

  for (const [key, value] of Object.entries(attributes)) {
    element.setAttribute(key, value);
  }

  return element;
}
