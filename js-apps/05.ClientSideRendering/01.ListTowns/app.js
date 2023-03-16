import { html, render } from '../../node_modules/lit-html/lit-html.js';

document.querySelector('.content').addEventListener('submit', (event) => {
  event.preventDefault();

  const formData = new FormData(event.target);

  const data = Object.fromEntries(formData.entries());
  const splitted = Object.values(data)[0].split(', ');

  const renderTown = (town) =>
    html` <ul>
      <li>${town}</li>
    </ul>`;

  render(splitted.map(renderTown), document.getElementById('root'));

  event.target.reset();
});
