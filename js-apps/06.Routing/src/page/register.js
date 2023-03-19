import { html } from '../../../node_modules/lit-html/lit-html.js';
import { createSubmitListener } from '../util.js';
import { handleUser } from '../auth.js';

let form;

export function showRegister(ctx) {
  ctx.render(registerTemplate());
  ctx.update();

  form = document.querySelector('form');
  createSubmitListener(form, ctx, onRegister);
}

const registerTemplate = () => html`<div class="row space-top">
    <div class="col-md-12">
      <h1>Register New User</h1>
      <p>Please fill all fields.</p>
    </div>
  </div>
  <form>
    <div class="row space-top">
      <div class="col-md-4">
        <div class="form-group">
          <label class="form-control-label" for="email">Email</label>
          <input class="form-control" id="email" type="text" name="email" />
        </div>
        <div class="form-group">
          <label class="form-control-label" for="password">Password</label>
          <input
            class="form-control"
            id="password"
            type="password"
            name="password"
          />
        </div>
        <div class="form-group">
          <label class="form-control-label" for="rePass">Repeat</label>
          <input
            class="form-control"
            id="rePass"
            type="password"
            name="rePass"
          />
        </div>
        <input type="submit" class="btn btn-primary" value="Register" />
      </div>
    </div>
  </form>`;

async function onRegister({ email, password, rePass }, ctx) {
  await handleUser(email, password, rePass);
  ctx.page.redirect('/06.Routing/catalog.html');
}
