import { html, nothing } from '../../../node_modules/lit-html/lit-html.js';
import { getTeams } from '../data/endpoints.js';
import { teamTemplate } from './common.js';

export async function renderTeams(ctx) {
  const data = await getTeams();

  ctx.render(pageTemplate(ctx.user, data));
}

const pageTemplate = (user, data) => html`<section id="browse">
  <article class="pad-med">
    <h1>Team Browser</h1>
  </article>

  ${user
    ? html`<article class="layout narrow">
        <div class="pad-small">
          <a href="create" class="action cta">Create Team</a>
        </div>
      </article>`
    : nothing}
  ${data.map(teamTemplate)}
</section>`;
