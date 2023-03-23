import { html, nothing } from '../../../node_modules/lit-html/lit-html.js';
import {
  approveRequest,
  cancelMembership,
  getRequestsByTeamId,
  getTeamById,
  requestJoin,
} from '../data/endpoints.js';
import { getUser } from '../util.js';

export async function renderDetails(ctx) {
  const teamId = ctx.params.id;

  ctx.render(await populateTemplate(teamId));

  async function populateTemplate(teamId) {
    const user = getUser();

    const [team, requests] = await Promise.all([
      getTeamById(ctx.params.id),
      getRequestsByTeamId(ctx.params.id),
    ]);

    Array.from(requests).forEach((request) => {
      request.approve = (event) => approve(event, request);
      request.decline = (event) => leave(event, request._id);
    });

    const isOwner = user.id === team._ownerId;
    const members = requests.filter((request) => request.status === 'member');
    const pending = requests.filter((request) => request.status === 'pending');

    return renderTemplate(
      team,
      user.id,
      isOwner,
      createControls,
      members,
      pending
    );

    async function approve(event, request) {
      event.target.remove();
      await approveRequest(request);
      ctx.render(await populateTemplate(teamId));
    }

    async function leave(event, id) {
      event.target.remove();
      await cancelMembership(id);
      ctx.render(await populateTemplate(teamId));
    }

    async function join(event) {
      event.target.remove();
      await requestJoin(teamId);
      ctx.render(await populateTemplate(teamId));
    }

    function createControls() {
      if (user.id === null) {
        return nothing;
      }

      if (isOwner) {
        return html`<a
          href=${`/07.ModularApplications/edit/${team._id}`}
          class="action"
          >Edit team</a
        >`;
      }

      const request = requests.find((request) => request._ownerId === user.id);
      if (request && request.status === 'member') {
        return html`<a
          @click=${(event) => leave(event, request._id)}
          href="javascript:void(0)"
          class="action invert"
          >Leave team</a
        >`;
      }

      if (request && request.status === 'pending') {
        return html`Membership pending.
          <a
            @click=${(event) => leave(event, request._id)}
            href="javascript:void(0)"
            >Cancel request</a
          >`;
      }

      return html`<a @click=${join} href="javascript:void(0)" class="action"
        >Join team</a
      >`;
    }
  }
}

const renderTemplate = (
  team,
  userId,
  isOwner,
  createControls,
  members,
  pending
) => html`<section id="team-home">
  <article class="layout">
    <img src=${team.logoUrl} class="team-logo left-col" />
    <div class="tm-preview">
      <h2>${team.name}</h2>
      <p>${team.description}</p>
      <span class="details">${members.length} Members</span>
      <div>${createControls()}</div>
    </div>
    <div class="pad-large">
      <h3>Members</h3>
      <ul class="tm-members">
        ${members.map((member) =>
          memberTemplate(member, isOwner, member._ownerId === userId)
        )}
      </ul>
    </div>
    ${isOwner
      ? html`<div class="pad-large">
          <h3>Membership Requests</h3>
          <ul class="tm-members">
            ${pending.map(pendingMemberTemplate)}
          </ul>
        </div>`
      : nothing}
  </article>
</section>`;

const memberTemplate = (member, isOwner, isSelf) => html`<li>
  ${member.user.username} ${isSelf ? '(You)' : nothing}
  ${isOwner && !isSelf
    ? html` <a
        @click=${member.decline}
        href="javascript:void(0)"
        class="tm-control action"
      >
        Remove from team
      </a>`
    : nothing}
</li>`;

const pendingMemberTemplate = (member) => html`<li>
  ${member.user.username}
  <a
    @click=${member.approve}
    href="javascript:void(0)"
    class="tm-control action"
    >Approve</a
  >
  <a
    @click=${member.decline}
    href="javascript:void(0)"
    class="tm-control action"
    >Decline</a
  >
</li>`;
