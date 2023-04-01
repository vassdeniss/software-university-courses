import { html } from '../../node_modules/lit-html/lit-html.js';
import { register } from '../data/auth.js';
import { createSubmitHandler } from '../util.js';

export function renderRegister(ctx) {
  ctx.render(registerTemplate(createSubmitHandler(onRegister)));

  async function onRegister({ email, password, 'confirm-pass': rePass }) {
    if (!email || !password) {
      return alert('All fields are required!');
    }

    if (rePass != password) {
      return alert('Passwords do not match!');
    }

    await register(email, password);
    ctx.page.redirect('/');
  }
}

const registerTemplate = (handler) => html`<section
  id="register-page"
  class="register"
>
  <form @submit=${handler} id="register-form" action="" method="">
    <fieldset>
      <legend>Register Form</legend>
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
      <p class="field">
        <label for="repeat-pass">Repeat Password</label>
        <span class="input">
          <input
            type="password"
            name="confirm-pass"
            id="repeat-pass"
            placeholder="Repeat Password"
          />
        </span>
      </p>
      <input class="button submit" type="submit" value="Register" />
    </fieldset>
  </form>
</section>`;
