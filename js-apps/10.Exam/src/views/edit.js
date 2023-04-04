import { html } from '../../node_modules/lit-html/lit-html.js';
import { editFruit, getFruitById } from '../data/endpoints.js';
import { createSubmitHandler } from '../util.js';

export async function renderEdit(ctx) {
  const id = ctx.params.id;
  const fruit = await getFruitById(id);

  ctx.render(editTemplate(createSubmitHandler(onEdit), fruit));

  async function onEdit({ name, imageUrl, description, nutrition }) {
    if (!name || !imageUrl || !description || !nutrition) {
      return alert('All fields are required!');
    }

    await editFruit({
      id,
      name,
      imageUrl,
      description,
      nutrition,
    });

    ctx.page.redirect(`/details/${id}`);
  }
}

const editTemplate = (handler, fruit) => html`<section id="edit">
  <div class="form">
    <h2>Edit Fruit</h2>
    <form @submit=${handler} class="edit-form">
      <input
        type="text"
        name="name"
        id="name"
        placeholder="Fruit Name"
        .value=${fruit.name}
      />
      <input
        type="text"
        name="imageUrl"
        id="Fruit-image"
        placeholder="Fruit Image URL"
        .value=${fruit.imageUrl}
      />
      <textarea
        id="fruit-description"
        name="description"
        placeholder="Description"
        rows="10"
        cols="50"
        .value=${fruit.description}
      ></textarea>
      <textarea
        id="fruit-nutrition"
        name="nutrition"
        placeholder="Nutrition"
        rows="10"
        cols="50"
        .value=${fruit.nutrition}
      ></textarea>
      <button type="submit">post</button>
    </form>
  </div>
</section>`;
