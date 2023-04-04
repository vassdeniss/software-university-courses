import { html } from '../../node_modules/lit-html/lit-html.js';

export function renderHome(ctx) {
  ctx.render(homeTemplate());
}

const homeTemplate = () => html`<section id="home">
  <h1>Learn more about your favorite fruits</h1>
  <img
    src="./images/pexels-pixabay-161559-dImkWBDHz-transformed (1).png"
    alt="home"
  />
</section>`;
