import { html } from '../../../node_modules/lit-html/lit-html.js';
import { createSubmitListener } from '../util.js';
import { handleUser } from '../auth.js';

let form;

export function showLogin(ctx) {
  ctx.render(loginTemplate());
  ctx.update();

  form = document.querySelector('form');
  createSubmitListener(form, ctx, onLogin);
}

const loginTemplate = () => html`<div class="container">
  <div class="row space-top">
    <div class="col-md-12">
      <h1>Login User</h1>
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
        <input type="submit" class="btn btn-primary" value="Login" />
      </div>
    </div>
  </form>
</div>`;

async function onLogin({ email, password }, ctx) {
  await handleUser(email, password);
  ctx.page.redirect('/06.Routing/catalog.html');
}
