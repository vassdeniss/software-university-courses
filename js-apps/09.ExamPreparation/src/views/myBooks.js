import { html } from '../../node_modules/lit-html/lit-html.js';
import { getUserBooks } from '../data/endpoints.js';
import { getUser } from '../util.js';

export async function renderMyBooks(ctx) {
  const user = getUser();
  const books = await getUserBooks(user._id);

  ctx.render(myBooksTemplate(books));
}

const myBooksTemplate = (books) => html`<section
  id="my-books-page"
  class="dashboard"
>
  <h1>Dashboard</h1>
  ${books.length > 0
    ? html`<ul class="my-books-list">
        ${books.map(bookTemplate)}
      </ul>`
    : html`<p class="no-books">No books in database!</p>`}
</section>`;

const bookTemplate = (book) => html`<li class="otherBooks">
  <h3>${book.title}</h3>
  <p>Type: ${book.type}</p>
  <p class="img"><img src=${book.imageUrl} /></p>
  <a class="button" href="/details/${book._id}">Details</a>
</li>`;
