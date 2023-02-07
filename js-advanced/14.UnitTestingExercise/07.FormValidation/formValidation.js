function validate() {
  const check = document.getElementById('company');
  check.addEventListener('change', function () {
    document.getElementById('companyInfo').style.display = this.checked
      ? 'block'
      : 'none';
  });

  const submit = document.getElementById('submit');
  submit.addEventListener('click', (event) => {
    event.preventDefault();

    let isValid = true;
    const username = document.getElementById('username');
    if (!username.value.match(/^[a-zA-Z0-9]{3,20}$/)) {
      username.style.borderColor = 'red';
      isValid = false;
    } else {
      username.style.border = 'none';
    }

    const email = document.getElementById('email');
    if (!email.value.match(/.*@.*\..*/)) {
      email.style.borderColor = 'red';
      isValid = false;
    } else {
      email.style.border = 'none';
    }

    const password = document.getElementById('password');
    const confirm = document.getElementById('confirm-password');
    if (
      !password.value.match(/^[\w]{5,15}$/) ||
      password.value !== confirm.value
    ) {
      password.style.borderColor = 'red';
      confirm.style.borderColor = 'red';
      isValid = false;
    } else {
      password.style.border = 'none';
      confirm.style.border = 'none';
    }

    if (document.getElementById('company').checked) {
      const number = document.getElementById('companyNumber');
      if (number.value < 1000 || number.value > 9999) {
        number.style.borderColor = 'red';
        isValid = false;
      } else {
        number.style.border = 'none';
      }
    }

    document.getElementById('valid').style.display = isValid ? 'block' : 'none';
  });
}
