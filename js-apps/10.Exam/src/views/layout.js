import { html } from '../../node_modules/lit-html/lit-html.js';

export const layoutTemplate = (user, content) => html`<header>
    <a id="logo" href="/"
      ><img id="logo-img" src="./images/logo.png" alt=""
    /></a>

    <nav>
      <div>
        <a href="/dashboard">Fruits</a>
        <a href="/search">Search</a>
      </div>

      ${user
        ? html` <div class="user">
            <a href="/add">Add Fruit</a>
            <a href="/logout">Logout</a>
          </div>`
        : html`<div class="guest">
            <a href="/login">Login</a>
            <a href="/register">Register</a>
          </div>`}
    </nav>
  </header>
  <main>${content}</main> `;
