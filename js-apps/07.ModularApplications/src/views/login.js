import { html, nothing } from '../../../node_modules/lit-html/lit-html.js';
import { handleUser } from '../data/auth.js';
import { createSubmitHandler } from '../util.js';

export function renderLogin(ctx) {
  ctx.render(loginTemplate(createSubmitHandler(onSubmit)));

  async function onSubmit({ email, username, password, repass }) {
    try {
      await handleUser(email, username, password, repass);
    } catch (err) {
      ctx.render(loginTemplate(createSubmitHandler(onSubmit), err.message));
    }

    ctx.page.redirect('/my-teams');
  }
}

const loginTemplate = (listener, message) => html`<section id="login">
  <article class="narrow">
    <header class="pad-med">
      <h1>Login</h1>
    </header>
    <form @submit=${listener} id="login-form" class="main-form pad-large">
      ${message ? html`<div class="error">${message}</div>` : nothing}
      <label>E-mail: <input type="text" name="email" /></label>
      <label>Password: <input type="password" name="password" /></label>
      <input class="action cta" type="submit" value="Sign In" />
    </form>
    <footer class="pad-small">
      Don't have an account?
      <a href="/07.ModularApplications/register" class="invert">Sign up here</a>
    </footer>
  </article>
</section>`;
