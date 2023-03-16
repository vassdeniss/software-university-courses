import { html, render } from '../../node_modules/lit-html/lit-html.js';
import { cats } from './catSeeder.js';

const catTemplate = (cat) => html`<ul>
  <li>
    <img
      src="./images/${cat.imageLocation}.jpg"
      wdith="250"
      height="250"
      alt="Card image cap"
    />
    <div class="info">
      <button class="showBtn" @click=${onClick}>Show status code</button>
      <div class="status" style="display: none" id=${cat.id}>
        <h4>Status Code: ${cat.statusCode}</h4>
        <p>${cat.statusMessage}</p>
      </div>
    </div>
  </li>
</ul>`;

render(cats.map(catTemplate), document.getElementById('allCats'));

function onClick(event) {
  const block = event.target.parentElement.querySelector('.status');
  console.log(block);

  if (event.target.textContent === 'Show status code') {
    event.target.textContent = 'Hide status code';
    block.style.display = 'block';
  } else {
    event.target.textContent = 'Show status code';
    block.style.display = 'none';
  }
}
