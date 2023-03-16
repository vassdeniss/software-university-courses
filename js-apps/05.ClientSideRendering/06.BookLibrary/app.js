import { html, render } from '../../node_modules/lit-html/lit-html.js';

const bookTemplate = ([k, v]) => html`<tr>
  <td>${v.title}</td>
  <td>${v.author}</td>
  <td>
    <button id="edit-button" @click=${() => changeToEditForm(k, v)}>
      Edit
    </button>
    <button id="delete-button" @click=${() => deleteBook(k)}>Delete</button>
  </td>
</tr>`;

document.getElementById('loadBooks').addEventListener('click', renderBooks);
document.getElementById('add-form').addEventListener('submit', createBook);
document.getElementById('edit-form').addEventListener('submit', editBook);

async function renderBooks() {
  const books = await request('GET', '/jsonstore/collections/books');

  render(
    Object.entries(books).map(bookTemplate),
    document.getElementById('table-body')
  );
}

async function createBook(event) {
  event.preventDefault();

  const formData = new FormData(event.target);

  const { title, author } = Object.fromEntries(formData.entries());

  event.target.reset();

  if (!title || !author) {
    return;
  }

  await request('POST', '/jsonstore/collections/books', {
    author,
    title,
  });

  await renderBooks();
}

async function editBook(event) {
  event.preventDefault();

  const formData = new FormData(event.target);

  const { id, author, title } = Object.fromEntries(formData.entries());

  event.target.reset();

  if (!author || !title) {
    return;
  }

  await request('PUT', `/jsonstore/collections/books/${id}`, {
    author,
    title,
  });

  document.getElementById('add-form').style.display = 'block';
  document.getElementById('edit-form').style.display = 'none';

  await renderBooks();
}

async function deleteBook(id) {
  await request('DELETE', `/jsonstore/collections/books/${id}`);

  await renderBooks();
}

function changeToEditForm(id, book) {
  document.getElementById('add-form').style.display = 'none';

  const editForm = document.getElementById('edit-form');
  editForm.style.display = 'block';
  editForm.querySelector('input[name="id"]').value = id;
  editForm.querySelector('input[name="title"]').value = book.title;
  editForm.querySelector('input[name="author"]').value = book.author;
}

async function request(method, url, data) {
  try {
    const options = {
      method,
      headers: {},
    };

    if (data) {
      options.headers['Content-Type'] = 'application/json';
      options.body = JSON.stringify(data);
    }

    const response = await fetch(`http://localhost:3030${url}`, options);

    let json;

    if (response.status !== 204) {
      json = await response.json();
    }

    if (!response.ok) {
      const error = json;
      throw error;
    }

    return json;
  } catch (error) {
    alert(error.message);
    throw error;
  }
}
