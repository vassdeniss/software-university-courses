import { html, render } from '../../node_modules/lit-html/lit-html.js';

async function solve() {
  document.querySelector('#searchBtn').addEventListener('click', onClick);

  const url = 'http://localhost:3030/jsonstore/advanced/table';

  const data = await getTableData();

  const rowTemplate = (student) => html`<tr>
    <td>${student.firstName} ${student.lastName}</td>
    <td>${student.email}</td>
    <td>${student.course}</td>
  </tr>`;

  render(Object.values(data).map(rowTemplate), document.querySelector('tbody'));

  async function getTableData() {
    try {
      const response = await fetch(url);
      const data = await response.json();

      if (!response.ok) {
        const error = data;
        throw error;
      }

      return data;
    } catch (error) {
      alert(error.message);
    }
  }

  function onClick() {
    const input = document.getElementById('searchField');

    Array.from(document.querySelectorAll('tbody tr')).forEach((row) => {
      if (
        row.textContent
          .toLowerCase()
          .trim()
          .includes(input.value.toLowerCase().trim())
      ) {
        row.classList.add('select');
      } else {
        row.classList.remove('select');
      }
    });

    input.value = '';
  }
}

solve();
