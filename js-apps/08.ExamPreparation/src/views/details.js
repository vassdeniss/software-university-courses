import { html, nothing } from '../../node_modules/lit-html/lit-html.js';
import {
  addApplicationById,
  deleteOffer,
  getApplicationByUserId,
  getApplicationsById,
  getOfferById,
} from '../data/endpoints.js';
import { getUser } from '../util.js';

export async function renderDetails(ctx) {
  const id = ctx.params.id;

  const offer = await getOfferById(id);
  offer.applications = await getApplicationsById(id);
  offer.isUser = false;
  offer.isOwner = false;
  offer.hasApplied = false;

  const user = getUser();
  if (user) {
    const result = await getApplicationByUserId(id, user._id);

    offer.isUser = true;
    offer.isOwner = user._id === offer._ownerId;
    offer.hasApplied = result > 0;
  }

  ctx.render(detailsTemplate(offer, delOffer, apply));

  async function delOffer() {
    if (confirm('Are you sure you want to delete this offer?')) {
      await deleteOffer(offer._id);
      ctx.page.redirect('/dashboard');
    }
  }

  async function apply() {
    await addApplicationById(id);
    offer.hasApplied = true;
    offer.applications = await getApplicationsById(id);
    ctx.render(detailsTemplate(offer, delOffer, apply));
  }
}

const detailsTemplate = (offer, delOffer, apply) => html`<section id="details">
  <div id="details-wrapper">
    <img id="details-img" src=${offer.imageUrl} alt="example1" />
    <p id="details-title">${offer.title}</p>
    <p id="details-category">
      Category: <span id="categories">${offer.category}</span>
    </p>
    <p id="details-salary">
      Salary: <span id="salary-number">${offer.salary}</span>
    </p>
    <div id="info-wrapper">
      <div id="details-description">
        <h4>Description</h4>
        <span>${offer.description}</span>
      </div>
      <div id="details-requirements">
        <h4>Requirements</h4>
        <span>${offer.requirements}</span>
      </div>
    </div>
    <p>
      Applications: <strong id="applications">${offer.applications}</strong>
    </p>

    ${offer.isOwner
      ? html`<div id="action-buttons">
          <a href="/edit/${offer._id}" id="edit-btn">Edit</a>
          <a @click=${delOffer} href="javascript:void(0)" id="delete-btn"
            >Delete</a
          >
        </div>`
      : nothing}
    ${offer.isUser && !offer.isOwner && !offer.hasApplied
      ? html`<div id="action-buttons">
          <a @click=${apply} href="javascript:void(0)" id="apply-btn">Apply</a>
        </div>`
      : nothing}
  </div>
</section>`;
