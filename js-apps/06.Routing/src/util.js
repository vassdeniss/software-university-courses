export function createSubmitListener(form, ctx, callback) {
  form.addEventListener('submit', onSubmit);

  function onSubmit(event) {
    event.preventDefault();

    const formData = new FormData(form);
    const data = Object.fromEntries(formData.entries());

    callback(data, ctx);
  }
}

export function updatePageForUser() {
  const userData = JSON.parse(localStorage.getItem('userData'));

  if (userData) {
    document.getElementById('user').style.display = 'inline-block';
    document.getElementById('guest').style.display = 'none';
  } else {
    document.getElementById('user').style.display = 'none';
    document.getElementById('guest').style.display = 'inline-block';
  }
}
