import { createTeam } from '../data/endpoints.js';
import { createSubmitHandler, validateTeam } from '../util.js';
import { formTemplate } from './common/formTemplate.js';

export function renderCreate(ctx) {
  ctx.render(formTemplate(createSubmitHandler(onSubmit)));

  async function onSubmit({ name, logoUrl, description }) {
    try {
      validateTeam(name, logoUrl, description);
    } catch (err) {
      ctx.render(formTemplate(createSubmitHandler(onSubmit), err.message));

      return;
    }

    const team = await createTeam(name, logoUrl, description);

    ctx.page.redirect(`/teams/${team._id}`);
  }
}
