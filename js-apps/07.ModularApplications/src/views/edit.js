import { editTeam, getTeamById } from '../data/endpoints.js';
import { createSubmitHandler, validateTeam } from '../util.js';
import { formTemplate } from './common/formTemplate.js';

export async function renderEdit(ctx) {
  const team = await getTeamById(ctx.params.id);

  ctx.render(formTemplate(createSubmitHandler(onSubmit), null, team));

  async function onSubmit({ name, logoUrl, description }) {
    try {
      debugger;
      validateTeam(name, logoUrl, description);
    } catch (err) {
      ctx.render(formTemplate(createSubmitHandler(onSubmit), err.message));
      return;
    }

    await editTeam(team._id, name, logoUrl, description);

    ctx.page.redirect(`/teams/${team._id}`);
  }
}
