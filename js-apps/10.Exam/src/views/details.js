import { html, nothing } from '../../node_modules/lit-html/lit-html.js';
import { deleteFruit, getFruitById } from '../data/endpoints.js';
import { getUser } from '../util.js';

export async function renderDetails(ctx) {
  const fruit = await getFruitById(ctx.params.id);

  const user = getUser();
  fruit.isOwner = user && user._id === fruit._ownerId;
  fruit.onDelete = onDelete;

  ctx.render(detailsTemplate(fruit));

  async function onDelete() {
    if (confirm('Are you sure you want to delete this fruit?')) {
      await deleteFruit(fruit._id);
      ctx.page.redirect('/dashboard');
    }
  }
}

const detailsTemplate = (fruit) => html`<section id="details">
  <div id="details-wrapper">
    <img id="details-img" src=${fruit.imageUrl} alt="example1" />
    <p id="details-title">${fruit.name}</p>
    <div id="info-wrapper">
      <div id="details-description">
        <p>${fruit.description}</p>
        <p id="nutrition">Nutrition</p>
        <p id="details-nutrition">${fruit.nutrition}</p>
      </div>

      ${fruit.isOwner
        ? html` <div id="action-buttons">
            <a href="/edit/${fruit._id}" id="edit-btn">Edit</a>
            <a
              @click=${fruit.onDelete}
              href="javascript:void(0)"
              id="delete-btn"
              >Delete</a
            >
          </div>`
        : nothing}
    </div>
  </div>
</section>`;
