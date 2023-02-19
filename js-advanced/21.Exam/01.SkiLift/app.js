window.addEventListener('load', solve);

function solve() {
  const firstNameInput = document.getElementById('first-name');
  const lastNameInput = document.getElementById('last-name');
  const peopleCountInput = document.getElementById('people-count');
  const fromDateInput = document.getElementById('from-date');
  const daysCountInput = document.getElementById('days-count');

  const nextButton = document.getElementById('next-btn');

  nextButton.addEventListener('click', (event) => {
    event.preventDefault();

    const firstName = firstNameInput.value;
    const lastName = lastNameInput.value;
    const peopleCount = peopleCountInput.value;
    const fromDate = fromDateInput.value;
    const daysCount = daysCountInput.value;

    if (!firstName || !lastName || !peopleCount || !fromDate || !daysCount) {
      return;
    }

    const li = document.createElement('li');
    li.classList.add('ticket');

    const article = document.createElement('article');

    const h3Name = document.createElement('h3');
    h3Name.textContent = `Name: ${firstName} ${lastName}`;

    const pStart = document.createElement('p');
    pStart.textContent = `From date: ${fromDate}`;

    const pDays = document.createElement('p');
    pDays.textContent = `For ${daysCount} days`;

    const pPeople = document.createElement('p');
    pPeople.textContent = `For ${peopleCount} people`;

    const editButton = document.createElement('button');
    editButton.classList.add('edit-btn');
    editButton.textContent = 'Edit';
    editButton.addEventListener('click', editTicket);

    const continueButton = document.createElement('button');
    continueButton.classList.add('continue-btn');
    continueButton.textContent = 'Continue';
    continueButton.addEventListener('click', continueTicket);

    article.appendChild(h3Name);
    article.appendChild(pStart);
    article.appendChild(pDays);
    article.appendChild(pPeople);

    li.appendChild(article);
    li.appendChild(editButton);
    li.appendChild(continueButton);

    document.getElementsByClassName('ticket-info-list')[0].appendChild(li);

    clearFields();
    nextButton.disabled = true;

    function editTicket() {
      firstNameInput.value = firstName;
      lastNameInput.value = lastName;
      peopleCountInput.value = peopleCount;
      fromDateInput.value = fromDate;
      daysCountInput.value = daysCount;

      nextButton.disabled = false;

      li.remove();
    }

    function continueTicket() {
      const confirmButton = document.createElement('button');
      confirmButton.classList.add('confirm-btn');
      confirmButton.textContent = 'Confirm';
      confirmButton.addEventListener('click', confirmTicket);

      const cancelButton = document.createElement('button');
      cancelButton.classList.add('cancel-btn');
      cancelButton.textContent = 'Cancel';
      cancelButton.addEventListener('click', cancelTicket);

      li.removeChild(editButton);
      li.removeChild(continueButton);
      li.appendChild(confirmButton);
      li.appendChild(cancelButton);

      document.getElementsByClassName('confirm-ticket')[0].appendChild(li);
    }

    function confirmTicket() {
      document.getElementById('main').remove();

      const h1 = document.createElement('h1');
      h1.id = 'thank-you';
      h1.textContent = 'Thank you, have a nice day!';

      const backButton = document.createElement('button');
      backButton.id = 'back-btn';
      backButton.textContent = 'Back';
      backButton.addEventListener('click', refreshPage);

      document.body.appendChild(h1);
      document.body.appendChild(backButton);
    }

    function refreshPage() {
      window.location.reload();
    }

    function cancelTicket() {
      nextButton.disabled = false;
      li.remove();
    }
  });

  function clearFields() {
    firstNameInput.value = '';
    lastNameInput.value = '';
    peopleCountInput.value = '';
    fromDateInput.value = '';
    daysCountInput.value = '';
  }
}
