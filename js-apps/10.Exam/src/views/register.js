import { html } from '../../node_modules/lit-html/lit-html.js';
import { register } from '../data/auth.js';
import { createSubmitHandler } from '../util.js';

export function renderRegister(ctx) {
  ctx.render(registerTemplate(createSubmitHandler(onRegister)));

  async function onRegister({ email, password, 're-password': rePass }) {
    if (!email || !password) {
      return alert('All fields are required!');
    }

    if (rePass !== password) {
      return alert('Passwords do not match!');
    }

    await register(email, password);
    ctx.page.redirect('/');
  }
}

const registerTemplate = (handler) => html`<section id="register">
  <div class="form">
    <h2>Register</h2>
    <form @submit=${handler} class="register-form">
      <input type="text" name="email" id="register-email" placeholder="email" />
      <input
        type="password"
        name="password"
        id="register-password"
        placeholder="password"
      />
      <input
        type="password"
        name="re-password"
        id="repeat-password"
        placeholder="repeat password"
      />
      <button type="submit">register</button>
      <p class="message">Already registered? <a href="/login">Login</a></p>
    </form>
  </div>
</section>`;
