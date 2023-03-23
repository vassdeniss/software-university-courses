import { html } from '../../../node_modules/lit-html/lit-html.js';

export const teamTemplate = (team) => html`<article class="layout">
  <img src=${team.logoUrl} class="team-logo left-col" />
  <div class="tm-preview">
    <h2>${team.name}</h2>
    <p>${team.description}</p>
    <span class="details">${team.memberCount} Members</span>
    <div><a href="teams/${team._id}" class="action">See details</a></div>
  </div>
</article>`;
