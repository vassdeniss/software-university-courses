import { html } from '../../node_modules/lit-html/lit-html.js';
import { getOffersOrdered } from '../data/endpoints.js';

export async function renderDashboard(ctx) {
  const data = await getOffersOrdered();

  ctx.render(dashboardTemplate(data));
}

const dashboardTemplate = (data) => html`<section id="dashboard">
  <h2>Job Offers</h2>

  ${data.length > 0 ? data.map(offerTemplate) : html`<h2>No offers yet.</h2>`}
</section>`;

const offerTemplate = (offer) => html`<div class="offer">
  <img src=${offer.imageUrl} alt="example1" />
  <p><strong>Title: </strong><span class="title">${offer.title}</span></p>
  <p><strong>Salary:</strong><span class="salary">${offer.salary}</span></p>
  <a class="details-btn" href="/dashboard/${offer._id}">Details</a>
</div>`;
