import { html } from '../../../node_modules/lit-html/lit-html.js';
import { furnitureTemplate } from '../common/templates.js';
import { getUserFurniture } from '../endpoints.js';

export async function showUserFurniture(ctx) {
  const user = JSON.parse(localStorage.getItem('userData'));

  const data = await getUserFurniture(user.id);

  ctx.render(userTemplate(data));
  ctx.update();
}

const userTemplate = (data) => html` <div class="container">
  <div class="row space-top">
    <div class="col-md-12">
      <h1>My Furniture</h1>
      <p>This is a list of your publications.</p>
    </div>
  </div>
  <div class="row space-top">${data.map(furnitureTemplate)}</div>
</div>`;
