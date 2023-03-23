import { html } from '../../../node_modules/lit-html/lit-html.js';

export const layoutTemplate = (content, user) => html`<div id="content">
  <header id="titlebar" class="layout">
    <a href="/" class="site-logo">Team Manager</a>
    <nav>
      <a href="teams" class="action">Browse Teams</a>
      ${user
        ? html`<a href="my-teams" class="action">My Teams</a
            ><a href="logout" class="action user">Logout</a>`
        : html`<a href="login" class="action">Login</a
            ><a href="register" class="action">Register</a>`}
    </nav>
  </header>

  <main>${content}</main>

  <footer id="footer">SoftUni &copy; 2014-2021</footer>
</div> `;
