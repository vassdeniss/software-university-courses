function attachEvents() {
  const phonebook = document.getElementById('phonebook');

  document.getElementById('btnLoad').addEventListener('click', getEntriesAsync);
  document
    .getElementById('btnCreate')
    .addEventListener('click', createEntryAsync);

  const url = 'http://localhost:3030/jsonstore/phonebook';

  async function getEntriesAsync() {
    phonebook.textContent = '';

    try {
      const response = await fetch(url);

      if (!response.ok) {
        throw new Error();
      }

      const json = await response.json();

      Object.values(json).forEach((person) => {
        const li = document.createElement('li');
        li.textContent = `${person.person}: ${person.phone}`;

        const button = document.createElement('button');
        button.textContent = 'Delete';
        button.setAttribute('id', person._id);
        button.addEventListener('click', (event) => deleteEntryAsync(event));
        li.appendChild(button);

        phonebook.appendChild(li);
      });

      async function deleteEntryAsync(event) {
        const userId = event.target.id;
        const targetUrl = `${url}/${userId}`;
        const options = {
          method: 'DELETE',
        };

        await fetch(targetUrl, options);
        event.target.parentNode.remove();
      }
    } catch (error) {
      console.log(error.message);
    }
  }

  async function createEntryAsync() {
    const [personInput, phoneInput] = document.querySelectorAll('input');

    if (!personInput.value || !phoneInput.value) {
      return;
    }

    const data = {
      person: personInput.value,
      phone: phoneInput.value,
    };

    const options = {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(data),
    };

    await fetch(url, options);

    await getEntriesAsync();
    personInput.value = '';
    phoneInput.value = '';
  }
}

attachEvents();
