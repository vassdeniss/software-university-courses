const url = 'http://localhost:3030/jsonstore/collections/books';

document.getElementById('loadBooks').addEventListener('click', getBooksAsync);
document.querySelector('form').addEventListener('submit', processForm);

async function getBooksAsync() {
  try {
    const response = await fetch(url);

    if (!response.ok) {
      throw new Error();
    }

    const json = await response.json();

    document.querySelector('tbody').textContent = '';

    Object.entries(json).forEach(([id, book]) => {
      const tr = document.createElement('tr');

      const title = document.createElement('td');
      title.textContent = book.title;

      const author = document.createElement('td');
      author.textContent = book.author;

      const buttons = document.createElement('td');

      const editButton = document.createElement('button');
      editButton.textContent = 'Edit';
      editButton.addEventListener('click', () => {
        document.querySelector('form h3').textContent = 'Edit FORM';

        document.querySelector('input[name="title"]').value = book.title;
        document.querySelector('input[name="author"]').value = book.author;
        document.querySelector('form button').textContent = 'Save';
        document.querySelector('form button').id = id;
      });

      const deleteButton = document.createElement('button');
      deleteButton.textContent = 'Delete';
      deleteButton.addEventListener('click', () => deleteBookAsync(id));

      buttons.appendChild(editButton);
      buttons.appendChild(deleteButton);

      tr.appendChild(title);
      tr.appendChild(author);
      tr.appendChild(buttons);

      document.querySelector('tbody').appendChild(tr);
    });
  } catch (error) {
    console.log(error.message);
  }
}

async function processForm(event) {
  const button = event.target.querySelector('button');
  if (button.textContent === 'Submit') {
    createBookAsync(event);
  } else if (button.textContent === 'Save') {
    editBookAsync(event);
  }
}

async function createBookAsync(event) {
  event.preventDefault();

  const formData = new FormData(event.target);

  const { title, author } = Object.fromEntries(formData.entries());

  if (!title || !author) {
    return;
  }

  const data = {
    author,
    title,
  };

  const options = {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify(data),
  };

  event.target.reset();

  try {
    const response = await fetch(url, options);

    if (!response.ok) {
      throw new Error();
    }

    getBooksAsync();

    return await response.json();
  } catch (error) {
    console.log(error.message);
  }
}

async function editBookAsync(event) {
  event.preventDefault();

  const id = event.target.querySelector('button').id;

  const formData = new FormData(event.target);

  const { author, title } = Object.fromEntries(formData.entries());

  event.target.querySelector('button').textContent = 'Submit';
  event.target.querySelector('h3').textContent = 'FORM';

  event.target.reset();

  if (!author || !title) {
    return;
  }

  const data = {
    author,
    title,
  };

  const options = {
    method: 'PUT',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify(data),
  };

  try {
    const response = await fetch(`${url}/${id}`, options);

    if (!response.ok) {
      throw new Error();
    }

    getBooksAsync();
  } catch (error) {
    console.log(error.message);
  }
}

async function deleteBookAsync(id) {
  const options = {
    method: 'DELETE',
  };

  try {
    const response = await fetch(`${url}/${id}`, options);

    if (!response.ok) {
      throw new Error();
    }

    getBooksAsync();

    return await response.json();
  } catch (error) {
    console.log(error.message);
  }
}
