import { html, nothing } from '../../../node_modules/lit-html/lit-html.js';
import { getFurnitureById } from '../endpoints.js';

export async function showDetails(ctx) {
  const data = await getFurnitureById(ctx.params.id);

  const userData = JSON.parse(localStorage.getItem('userData'));
  if (userData) {
    data.isOwner = userData.id === data._ownerId;
  }

  ctx.render(detailsTemplate(data));
  ctx.update();
}

const detailsTemplate = (data) => html`<div class="container">
  <div class="row space-top">
    <div class="col-md-12">
      <h1>Furniture Details</h1>
    </div>
  </div>
  <div class="row space-top">
    <div class="col-md-4">
      <div class="card text-white bg-primary">
        <div class="card-body">
          <img src=${data.img} />
        </div>
      </div>
    </div>
    <div class="col-md-4">
      <p>Make: <span>${data.make}</span></p>
      <p>Model: <span>${data.model}</span></p>
      <p>Year: <span>${data.year}</span></p>
      <p>Description: <span>${data.description}</span></p>
      <p>Price: <span>${data.price}</span></p>
      <p>Material: <span>${data.material}</span></p>
      ${data.isOwner
        ? html`<div>
            <a href="edit/${data._id}" class="btn btn-info">Edit</a>
            <a href="delete/${data._id}" class="btn btn-red">Delete</a>
          </div>`
        : nothing}
    </div>
  </div>
</div>`;
