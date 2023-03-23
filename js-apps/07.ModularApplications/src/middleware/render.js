import { render } from '../../../node_modules/lit-html/lit-html.js';
import { layoutTemplate } from '../views/layout.js';

const body = document.body;

export function addRender(ctx, next) {
  ctx.render = renderView.bind(null, ctx.user);
  next();
}

function renderView(user, content) {
  render(layoutTemplate(content, user), body);
}
