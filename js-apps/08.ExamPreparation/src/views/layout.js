import { html } from '../../node_modules/lit-html/lit-html.js';

export const layoutTemplate = (user, content) => html`<header>
    <a id="logo" href="/"
      ><img id="logo-img" src="./images/logo.jpg" alt=""
    /></a>
    <nav>
      <div>
        <a href="/dashboard">Dashboard</a>
      </div>

      ${user
        ? html`<div class="user">
            <a href="/create">Create Offer</a>
            <a href="/logout">Logout</a>
          </div>`
        : html`<div class="guest">
            <a href="/login">Login</a>
            <a href="/register">Register</a>
          </div>`}
    </nav>
  </header>
  <main>${content}</main> `;
