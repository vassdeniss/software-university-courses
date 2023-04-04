import { html } from '../../node_modules/lit-html/lit-html.js';
import { getFruits } from '../data/endpoints.js';

export async function renderDashboard(ctx) {
  const fruits = await getFruits();

  ctx.render(dashboardTemplate(fruits));
}

const dashboardTemplate = (fruits) => html`<h2>Fruits</h2>
  <section id="dashboard">
    ${fruits.length > 0
      ? html`${fruits.map(fruitTemplate)}`
      : html`<h2>No fruit info yet.</h2>`}
  </section>`;

const fruitTemplate = (fruit) => html` <div class="fruit">
  <img src=${fruit.imageUrl} alt="example1" />
  <h3 class="title">${fruit.name}</h3>
  <p class="description">${fruit.description}</p>
  <a class="details-btn" href="/details/${fruit._id}">More Info</a>
</div>`;
