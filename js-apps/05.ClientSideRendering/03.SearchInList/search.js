import { html, render } from '../../node_modules/lit-html/lit-html.js';
import { towns } from './towns.js';

function search() {
  const townTemplate = (town) => html`<ul>
    <li>${town}</li>
  </ul>`;

  render(towns.map(townTemplate), document.getElementById('towns'));

  document.querySelector('button').addEventListener('click', () => {
    const input = document.getElementById('searchText');

    const count = Array.from(document.querySelectorAll('#towns ul li')).reduce(
      (acc, curr) => {
        if (curr.textContent.includes(input.value)) {
          curr.classList.add('active');
          acc++;
        } else {
          curr.classList.remove('active');
        }

        return acc;
      },
      0
    );

    document.getElementById('result').textContent = `${count} matches found`;
  });
}

search();
