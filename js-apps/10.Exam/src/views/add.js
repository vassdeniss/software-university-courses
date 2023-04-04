import { html } from '../../node_modules/lit-html/lit-html.js';
import { addFruit } from '../data/endpoints.js';
import { createSubmitHandler } from '../util.js';

export function renderAdd(ctx) {
  ctx.render(addTemplate(createSubmitHandler(onCreate)));

  async function onCreate({ name, imageUrl, description, nutrition }) {
    if (!name || !imageUrl || !description || !nutrition) {
      return alert('All fields are required!');
    }

    await addFruit({
      name,
      imageUrl,
      description,
      nutrition,
    });

    ctx.page.redirect('/dashboard');
  }
}

const addTemplate = (handler) => html`<section id="create">
  <div class="form">
    <h2>Add Fruit</h2>
    <form @submit=${handler} class="create-form">
      <input type="text" name="name" id="name" placeholder="Fruit Name" />
      <input
        type="text"
        name="imageUrl"
        id="Fruit-image"
        placeholder="Fruit Image"
      />
      <textarea
        id="fruit-description"
        name="description"
        placeholder="Description"
        rows="10"
        cols="50"
      ></textarea>
      <textarea
        id="fruit-nutrition"
        name="nutrition"
        placeholder="Nutrition"
        rows="10"
        cols="50"
      ></textarea>
      <button type="submit">Add Fruit</button>
    </form>
  </div>
</section>`;
