function validate() {
  const field = document.getElementById('email');

  field.addEventListener('change', (event) => {
    if (validateEmail(field.value)) {
      event.target.classList.remove('error');
    } else {
      event.target.classList.add('error');
    }
  });

  function validateEmail(email) {
    if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(email)) {
      return true;
    }

    return false;
  }
}
