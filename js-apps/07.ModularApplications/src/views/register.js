import { html, nothing } from '../../../node_modules/lit-html/lit-html.js';
import { handleUser } from '../data/auth.js';
import { createSubmitHandler } from '../util.js';

export function renderRegister(ctx) {
  ctx.render(registerTemplate(createSubmitHandler(onSubmit)));

  async function onSubmit({ email, username, password, repass }) {
    try {
      await handleUser(email, username, password, repass);
    } catch (err) {
      ctx.render(registerTemplate(createSubmitHandler(onSubmit), err.message));
    }

    ctx.page.redirect('/my-teams');
  }
}

const registerTemplate = (listener, message) => html` <section id="register">
  <article class="narrow">
    <header class="pad-med">
      <h1>Register</h1>
    </header>
    <form @submit=${listener} id="register-form" class="main-form pad-large">
      ${message ? html`<div class="error">${message}</div>` : nothing}
      <label>E-mail: <input type="text" name="email" /></label>
      <label>Username: <input type="text" name="username" /></label>
      <label>Password: <input type="password" name="password" /></label>
      <label>Repeat: <input type="password" name="repass" /></label>
      <input class="action cta" type="submit" value="Create Account" />
    </form>
    <footer class="pad-small">
      Already have an account?
      <a href="/07.ModularApplications/login" class="invert">Sign in here</a>
    </footer>
  </article>
</section>`;
