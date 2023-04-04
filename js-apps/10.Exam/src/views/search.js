import { html, nothing } from '../../node_modules/lit-html/lit-html.js';
import { getFruitsByName } from '../data/endpoints.js';
import { createSubmitHandler } from '../util.js';

export function renderSearch(ctx) {
  update();

  function update(fruits) {
    ctx.render(searchTemplate(createSubmitHandler(onSearch), fruits));
  }

  async function onSearch({ search }) {
    if (!search) {
      return alert('All fields are required!');
    }

    const fruits = await getFruitsByName(search);
    update(fruits);
  }
}

const searchTemplate = (handler, fruits) => html`<section id="search">
  <div class="form">
    <h2>Search</h2>
    <form @submit=${handler} class="search-form">
      <input type="text" name="search" id="search-input" />
      <button class="button-list">Search</button>
    </form>
  </div>
  <h4>Results:</h4>
  ${fruits
    ? html` <div class="search-result">
        ${fruits.length > 0
          ? html`${fruits.map(fruitTemplate)}`
          : html`<p class="no-result">No result.</p>`}
      </div>`
    : nothing};
</section>`;

const fruitTemplate = (fruit) => html`<div class="fruit">
    <img src=${fruit.imageUrl} alt="example1" />
    <h3 class="title">${fruit.name}</h3>
    <p class="description">
      ${fruit.description}
    </p>
    <a class="details-btn" href="/details/${fruit._id}">More Info</a>
  </div>
</div>`;
