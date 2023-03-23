import { html, nothing } from '../../../node_modules/lit-html/lit-html.js';
import { getMyTeams } from '../data/endpoints.js';
import { teamTemplate } from './common.js';

export async function renderMyTeams(ctx) {
  const teams = await getMyTeams();

  ctx.render(myTeamsTemplate(teams));
}

const myTeamsTemplate = (teams) => html`<section id="my-teams">
  <article class="pad-med">
    <h1>My Teams</h1>
  </article>

  <article class="layout narrow">
    ${teams.length == 0
      ? html` <div class="pad-med">
          <p>You are not a member of any team yet.</p>
          <p>
            <a href="teams">Browse all teams</a> to join one, or use the button
            bellow to cerate your own team.
          </p>
        </div>`
      : nothing}
    <div class=""><a href="create" class="action cta">Create Team</a></div>
  </article>

  ${teams.map(teamTemplate)}
</section>`;
