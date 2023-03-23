import page from '../../node_modules/page/page.mjs';
import { handleUser } from './data/auth.js';
import { addQuery } from './middleware/query.js';
import { addRender } from './middleware/render.js';
import { addSession } from './middleware/session.js';
import { renderCreate } from './views/create.js';
import { renderDetails } from './views/details.js';
import { renderEdit } from './views/edit.js';
import { renderHome } from './views/home.js';
import { renderLogin } from './views/login.js';
import { renderMyTeams } from './views/myTeams.js';
import { renderRegister } from './views/register.js';
import { renderTeams } from './views/teams.js';

page(addSession);
page(addRender);
page(addQuery);

page('/', '/07.ModularApplications/');
page('/index.html', '/07.ModularApplications/');
page('/07.ModularApplications/', renderHome);
page('/07.ModularApplications/register', renderRegister);
page('/07.ModularApplications/login', renderLogin);
page('/07.ModularApplications/logout', async () => {
  await handleUser();
  page('/');
});
page('/07.ModularApplications/teams', renderTeams);
page('/07.ModularApplications/teams/:id', renderDetails);
page('/07.ModularApplications/create', renderCreate);
page('/07.ModularApplications/my-teams', renderMyTeams);
page('/07.ModularApplications/edit/:id', renderEdit);

//page('*', renderHome);

page.start();
