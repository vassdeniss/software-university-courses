import { html } from '../../../node_modules/lit-html/lit-html.js';
import { createFurniture } from '../endpoints.js';
import { createSubmitListener } from '../util.js';

let form;

export function showCreate(ctx) {
  ctx.render(createTemplate());
  ctx.update();

  form = document.querySelector('form');
  createSubmitListener(form, ctx, onSubmit);
}

const createTemplate = () => html`<div class="container">
  <div class="row space-top">
    <div class="col-md-12">
      <h1>Create New Furniture</h1>
      <p>Please fill all fields.</p>
    </div>
  </div>
  <form>
    <div class="row space-top">
      <div class="col-md-4">
        <div class="form-group">
          <label class="form-control-label" for="new-make">Make</label>
          <input
            class="form-control valid"
            id="new-make"
            type="text"
            name="make"
          />
        </div>
        <div class="form-group has-success">
          <label class="form-control-label" for="new-model">Model</label>
          <input class="form-control" id="new-model" type="text" name="model" />
        </div>
        <div class="form-group has-danger">
          <label class="form-control-label" for="new-year">Year</label>
          <input class="form-control" id="new-year" type="number" name="year" />
        </div>
        <div class="form-group">
          <label class="form-control-label" for="new-description"
            >Description</label
          >
          <input
            class="form-control"
            id="new-description"
            type="text"
            name="description"
          />
        </div>
      </div>
      <div class="col-md-4">
        <div class="form-group">
          <label class="form-control-label" for="new-price">Price</label>
          <input
            class="form-control"
            id="new-price"
            type="number"
            name="price"
          />
        </div>
        <div class="form-group">
          <label class="form-control-label" for="new-image">Image</label>
          <input class="form-control" id="new-image" type="text" name="img" />
        </div>
        <div class="form-group">
          <label class="form-control-label" for="new-material"
            >Material (optional)</label
          >
          <input
            class="form-control"
            id="new-material"
            type="text"
            name="material"
          />
        </div>
        <input type="submit" class="btn btn-primary" value="Create" />
      </div>
    </div>
  </form>
</div>`;

async function onSubmit(data, ctx) {
  try {
    await createFurniture(data);
    ctx.page.redirect('/06.Routing/catalog.html');
  } catch (error) {
    if (!error.errorInputs) {
      alert(error.message);
      return;
    }

    Array.from(form.querySelectorAll('input')).forEach((input) => {
      if (error.errorInputs.includes(input.name)) {
        input.classList.add('is-invalid');
      } else {
        input.classList.add('is-valid');
      }
    });
  }
}
