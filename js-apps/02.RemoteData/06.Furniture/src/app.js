import { request } from './request.js';
import { element as createElement } from './element.js';

const loggedUser = JSON.parse(localStorage.getItem('userData'));

await getFurniture();

const [_, buyButton, orderButton] = document.querySelectorAll('button');
buyButton.addEventListener('click', buyFurniture);
orderButton.addEventListener('click', getOrdersAsync);
document.querySelector('form').addEventListener('submit', createFurnitureAsync);
document.getElementById('logoutBtn').addEventListener('click', logoutUserAsync);

async function getFurniture() {
  const data = await request('/data/furniture', {
    method: 'get',
  });

  Object.values(data).map((furniture) =>
    document
      .querySelector('tbody')
      .appendChild(createFurnitureElement(furniture))
  );
}

function createFurnitureElement(table) {
  return createElement(
    'tr',
    {},
    createElement('td', {}, createElement('img', { src: table.img })),
    createElement('td', {}, createElement('p', {}, table.name)),
    createElement('td', {}, createElement('p', {}, table.price)),
    createElement('td', {}, createElement('p', {}, table.factor)),
    createElement('td', {}, createElement('input', { type: 'checkbox' }))
  );
}

async function createFurnitureAsync(event) {
  event.preventDefault();

  const formData = new FormData(event.target);

  const { name, price, factor, img } = Object.fromEntries(formData.entries());

  if (!name || !price || !factor || !img) {
    alert('All fields are requred!');
    throw new Error('All fields are requred!');
  }

  document
    .querySelector('tbody')
    .appendChild(createFurnitureElement({ name, price, factor, img }));

  event.target.reset();

  await getFurniture();
}

async function logoutUserAsync(event) {
  event.preventDefault();

  await fetch('http://localhost:3030/users/logout', {
    headers: {
      'X-Authorization': loggedUser.token,
    },
  });

  localStorage.clear();

  window.location = './home.html';
}

function buyFurniture() {
  const checkboxes = document.querySelectorAll(
    '.table tbody tr td input[type="checkbox"]:checked'
  );

  if (checkboxes.length === 0) {
    return;
  }

  Array.from(checkboxes).forEach(async (box) => {
    const furniture = box.parentElement.parentElement.children;

    const currentFurniture = Array.from(furniture)
      .map((child) => {
        if (child.firstElementChild.src) {
          return child.firstElementChild.src;
        }

        return child.textContent.trim();
      })
      .filter((child) => child.trim() !== '');

    console.log(currentFurniture);

    const data = {
      img: currentFurniture[0],
      name: currentFurniture[1],
      price: currentFurniture[2],
      factor: currentFurniture[3],
    };

    await request('/data/orders', {
      method: 'post',
      headers: {
        'Content-Type': 'application/json',
        'X-Authorization': loggedUser.token,
      },
      body: JSON.stringify(data),
    });
  });
}

async function getOrdersAsync() {
  const data = await request('/data/orders', {
    method: 'get',
  });

  const ownerOrders = data
    .filter((furniture) => furniture._ownerId == loggedUser.id)
    .map((item) => ({
      name: item.name,
      price: item.price,
    }));

  const [bought, total] = document.querySelectorAll('.orders p span');

  bought.textContent = ownerOrders
    .map((furniture) => furniture.name)
    .join(', ');

  total.textContent = `${ownerOrders
    .map((furniture) => Number(furniture.price))
    .reduce((acc, curr) => acc + curr, 0)}$`;
}
