import { html } from '../../node_modules/lit-html/lit-html.js';
import { login } from '../data/auth.js';
import { createSubmitHandler } from '../util.js';

export function renderLogin(ctx) {
  ctx.render(loginTemplate(createSubmitHandler(onLogin)));

  async function onLogin({ email, password }) {
    if (!email || !password) {
      return alert('All fields are required!');
    }

    await login(email, password);
    ctx.page.redirect('/');
  }
}

const loginTemplate = (handler) => html`<section id="login-page" class="login">
  <form @submit=${handler} id="login-form" action="" method="">
    <fieldset>
      <legend>Login Form</legend>
      <p class="field">
        <label for="email">Email</label>
        <span class="input">
          <input type="text" name="email" id="email" placeholder="Email" />
        </span>
      </p>
      <p class="field">
        <label for="password">Password</label>
        <span class="input">
          <input
            type="password"
            name="password"
            id="password"
            placeholder="Password"
          />
        </span>
      </p>
      <input class="button submit" type="submit" value="Login" />
    </fieldset>
  </form>
</section>`;
