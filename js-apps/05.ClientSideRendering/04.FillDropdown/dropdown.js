import { html, render } from '../../node_modules/lit-html/lit-html.js';

const url = 'http://localhost:3030/jsonstore/advanced/dropdown';

async function addItem() {
  document.querySelector('form').addEventListener('submit', onSubmit);

  const itemTemplate = (item) =>
    html`<option value=${item._id}>${item.text}</option>`;

  await updateList();

  async function getItems() {
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

  async function onSubmit(event) {
    event.preventDefault();

    const formData = new FormData(event.target);
    const { itemText } = Object.fromEntries(formData.entries());

    try {
      const data = {
        text: itemText,
      };

      const options = {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(data),
      };

      const response = await fetch(url, options);

      if (!response.ok) {
        throw await response.json();
      }

      await updateList();
    } catch (error) {
      alert(error.message);
    }

    event.target.reset();
  }

  async function updateList() {
    const data = await getItems();

    render(
      Object.values(data).map(itemTemplate),
      document.getElementById('menu')
    );
  }
}

addItem();
