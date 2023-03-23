import { html, nothing } from '../../../../node_modules/lit-html/lit-html.js';

export const formTemplate = (listener, message, team) => html`<section
  id="create"
>
  <article class="narrow">
    <header class="pad-med">
      ${team ? html`<h1>New Team</h1>` : html`<h1>Edit Team</h1>`}
    </header>
    <form @submit=${listener} id="create-form" class="main-form pad-large">
      ${message ? html`<div class="error">${message}</div>` : nothing}
      <label
        >Team name:
        <input type="text" name="name" .value=${team ? team.name : nothing}
      /></label>
      <label
        >Logo URL:
        <input
          type="text"
          name="logoUrl"
          .value=${team ? team.logoUrl : nothing}
      /></label>
      <label
        >Description:
        <textarea
          name="description"
          .value=${team ? team.description : nothing}
        ></textarea>
      </label>
      <input
        class="action cta"
        type="submit"
        .value=${team ? 'Save Changes' : 'Crate Team'}
      />
    </form>
  </article>
</section>`;
