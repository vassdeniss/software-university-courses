function solve() {
  const firstNameInput = document.getElementById('fname');
  const lastNameInput = document.getElementById('lname');
  const emailInput = document.getElementById('email');
  const dobInput = document.getElementById('birth');
  const positionInput = document.getElementById('position');
  const salaryInput = document.getElementById('salary');

  const sum = document.getElementById('sum');

  document.getElementById('add-worker').addEventListener('click', (event) => {
    const firstName = firstNameInput.value;
    const lastName = lastNameInput.value;
    const email = emailInput.value;
    const dob = dobInput.value;
    const position = positionInput.value;
    const salary = salaryInput.value;

    if (!firstName || !lastName || !email || !dob || !position || !salary) {
      clearFields();
      return;
    }

    event.preventDefault();

    const tr = createElement('tr');

    createElement('td', firstName, tr);
    createElement('td', lastName, tr);
    createElement('td', email, tr);
    createElement('td', dob, tr);
    createElement('td', position, tr);
    createElement('td', salary, tr);

    const td = createElement('td', '', tr);
    const fireButton = createElement('button', 'Fired', td);
    fireButton.classList.add('fired');
    const editButton = createElement('button', 'Edit', td);
    editButton.classList.add('edit');

    editButton.addEventListener('click', (event) => {
      event.preventDefault();

      firstNameInput.value = firstName;
      lastNameInput.value = lastName;
      emailInput.value = email;
      dobInput.value = dob;
      positionInput.value = position;
      salaryInput.value = salary;

      sum.textContent = Math.abs(
        Number(sum.textContent) - Number(salary)
      ).toFixed(2);

      tr.remove();
    });

    fireButton.addEventListener('click', (event) => {
      event.preventDefault();

      sum.textContent = Math.abs(
        Number(sum.textContent) - Number(salary)
      ).toFixed(2);

      tr.remove();
    });

    document.getElementById('tbody').appendChild(tr);

    sum.textContent = (Number(sum.textContent) + Number(salary)).toFixed(2);

    clearFields();
  });

  function clearFields() {
    firstNameInput.value = '';
    lastNameInput.value = '';
    emailInput.value = '';
    dobInput.value = '';
    positionInput.value = '';
    salaryInput.value = '';
  }

  function createElement(type, content, parent) {
    const element = document.createElement(type);
    element.textContent = content;
    if (parent) {
      parent.appendChild(element);
    }

    return element;
  }
}

solve();
