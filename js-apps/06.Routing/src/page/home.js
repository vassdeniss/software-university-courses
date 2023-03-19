import { html } from '../../../node_modules/lit-html/lit-html.js';
import { furnitureTemplate } from '../common/templates.js';
import { getFurniture } from '../endpoints.js';

export async function showHome(ctx) {
  const data = await getFurniture();

  ctx.render(homeTemplate(data));
  ctx.update();
}

const homeTemplate = (data) => html`<div class="row space-top">
    <div class="col-md-12">
      <h1>Welcome to Furniture System</h1>
      <p>Select furniture from the catalog to view details.</p>
    </div>
  </div>
  <div class="row space-top">${data.map(furnitureTemplate)}</div>`;
