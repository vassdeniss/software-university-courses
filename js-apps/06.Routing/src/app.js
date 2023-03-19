import page from '../../node_modules/page/page.mjs';
import { showHome } from './page/home.js';
import { showRegister } from './page/register.js';
import { showLogin } from './page/login.js';
import { showCreate } from './page/create.js';
import { render } from '../../node_modules/lit-html/lit-html.js';
import { updatePageForUser } from './util.js';
import { handleUser } from './auth.js';
import { showUserFurniture } from './page/userFurniture.js';
import { showDetails } from './page/details.js';
import { showEdit } from './page/edit.js';
import { deleteFurniture } from './endpoints.js';

const root = document.querySelector('.container');

updatePageForUser();

page(addRendererMiddleware);
page('/06.Routing/', showHome);
page('/06.Routing/index.html', showHome);
page('/06.Routing/catalog.html', showHome);
page('/06.Routing/register.html', showRegister);
page('/06.Routing/login.html', showLogin);
page('/06.Routing/create.html', showCreate);
page('/06.Routing/my-furniture.html', showUserFurniture);
page('/06.Routing/:id', showDetails);
page('/06.Routing/edit/:id', showEdit);
page('/06.Routing/delete/:id', async (ctx) => {
  await deleteFurniture(ctx.params.id);
  ctx.page.redirect('/06.Routing/');
});
page('*', showHome);

page.start();

document.getElementById('logoutBtn').addEventListener('click', async () => {
  await handleUser();
  updatePageForUser();
});

function addRendererMiddleware(ctx, next) {
  ctx.render = (context) => render(context, root);
  ctx.update = updatePageForUser;

  next();
}
