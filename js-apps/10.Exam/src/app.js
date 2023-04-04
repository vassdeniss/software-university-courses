import page from '../node_modules/page/page.mjs';
import { render } from '../node_modules/lit-html/lit-html.js';

import { getUser } from './util.js';
import { logout } from './data/auth.js';

import { layoutTemplate } from './views/layout.js';
import { renderHome } from './views/home.js';
import { renderLogin } from './views/login.js';
import { renderRegister } from './views/register.js';
import { renderDashboard } from './views/dashboard.js';
import { renderAdd } from './views/add.js';
import { renderDetails } from './views/details.js';
import { renderEdit } from './views/edit.js';
import { renderSearch } from './views/search.js';

const root = document.getElementById('wrapper');

page(decorateContext);

page('/index.html', '/');
page('/', renderHome);
page('/login', renderLogin);
page('/register', renderRegister);
page('/logout', logoutAction);
page('/dashboard', renderDashboard);
page('/add', renderAdd);
page('/details/:id', renderDetails);
page('/edit/:id', renderEdit);
page('/search', renderSearch);

page.start();

function decorateContext(ctx, next) {
  ctx.render = renderView;
  next();
}

function renderView(content) {
  const user = getUser();
  render(layoutTemplate(user, content), root);
}

async function logoutAction(ctx) {
  await logout();
  ctx.page.redirect('/');
}
