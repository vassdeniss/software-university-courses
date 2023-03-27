import { html } from '../../node_modules/lit-html/lit-html.js';
import { editOffer, getOfferById } from '../data/endpoints.js';
import { createSubmitHandler } from '../util.js';

export async function renderEdit(ctx) {
  const id = ctx.params.id;
  const offer = await getOfferById(id);

  ctx.render(editTemplate(createSubmitHandler(onSubmit), offer));

  async function onSubmit({
    title,
    imageUrl,
    category,
    description,
    requirements,
    salary,
  }) {
    if (
      !title ||
      !imageUrl ||
      !category ||
      !description ||
      !requirements ||
      !salary
    ) {
      return alert('All fields are mandatory!');
    }

    await editOffer(
      id,
      title,
      imageUrl,
      category,
      description,
      requirements,
      salary
    );

    ctx.page.redirect(`/dashboard/${id}`);
  }
}

const editTemplate = (handler, offer) => html`<section id="edit">
  <div class="form">
    <h2>Edit Offer</h2>
    <form @submit=${handler} class="edit-form">
      <input
        type="text"
        name="title"
        id="job-title"
        placeholder="Title"
        .value=${offer.title}
      />
      <input
        type="text"
        name="imageUrl"
        id="job-logo"
        placeholder="Company logo url"
        .value=${offer.imageUrl}
      />
      <input
        type="text"
        name="category"
        id="job-category"
        placeholder="Category"
        .value=${offer.category}
      />
      <textarea
        id="job-description"
        name="description"
        placeholder="Description"
        rows="4"
        cols="50"
        .value=${offer.description}
      ></textarea>
      <textarea
        id="job-requirements"
        name="requirements"
        placeholder="Requirements"
        rows="4"
        cols="50"
        .value=${offer.requirements}
      ></textarea>
      <input
        type="text"
        name="salary"
        id="job-salary"
        placeholder="Salary"
        .value=${offer.salary}
      />

      <button type="submit">post</button>
    </form>
  </div>
</section>`;
