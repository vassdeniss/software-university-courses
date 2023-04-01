import { html } from '../../node_modules/lit-html/lit-html.js';
import { isValidBook } from '../common/validators.js';
import { editBook, getBookById } from '../data/endpoints.js';
import { createSubmitHandler } from '../util.js';

export async function renderEdit(ctx) {
  const id = ctx.params.id;

  const book = await getBookById(id);
  console.log(book);
  ctx.render(editTemplate(createSubmitHandler(onSubmit), book));

  async function onSubmit(editedBook) {
    if (!isValidBook(editedBook)) {
      return alert('All fields are required!');
    }

    await editBook(editedBook, id);
    ctx.page.redirect(`/details/${id}`);
  }
}

const editTemplate = (handler, book) => html`<section
  id="edit-page"
  class="edit"
>
  <form @submit=${handler} id="edit-form" action="#" method="">
    <fieldset>
      <legend>Edit my Book</legend>
      <p class="field">
        <label for="title">Title</label>
        <span class="input">
          <input type="text" name="title" id="title" .value=${book.title} />
        </span>
      </p>
      <p class="field">
        <label for="description">Description</label>
        <span class="input">
          <textarea
            name="description"
            id="description"
            .value=${book.description}
          ></textarea>
        </span>
      </p>
      <p class="field">
        <label for="image">Image</label>
        <span class="input">
          <input
            type="text"
            name="imageUrl"
            id="image"
            .value=${book.imageUrl}
          />
        </span>
      </p>
      <p class="field">
        <label for="type">Type</label>
        <span class="input">
          <select id="type" name="type" .value=${book.type}>
            <option value="Fiction" selected>Fiction</option>
            <option value="Romance">Romance</option>
            <option value="Mistery">Mistery</option>
            <option value="Classic">Clasic</option>
            <option value="Other">Other</option>
          </select>
        </span>
      </p>
      <input class="button submit" type="submit" value="Save" />
    </fieldset>
  </form>
</section>`;
