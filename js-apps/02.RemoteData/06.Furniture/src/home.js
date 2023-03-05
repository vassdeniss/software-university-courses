import { request } from './request.js';
import { element as createElement } from './element.js';

(async function getFurniture() {
  const data = await request('/data/furniture', {
    method: 'GET',
  });

  Object.values(data).map((furniture) => {
    const table = createElement(
      'tr',
      {},
      createElement('td', {}, createElement('img', { src: furniture.img })),
      createElement('td', {}, createElement('p', {}, furniture.name)),
      createElement('td', {}, createElement('p', {}, furniture.price)),
      createElement('td', {}, createElement('p', {}, furniture.factor)),
      createElement(
        'td',
        {},
        createElement('input', { type: 'checkbox', disabled: true })
      )
    );

    const tablePage = document.querySelector('tbody');

    tablePage.innerHTML = '';

    return tablePage.appendChild(table);
  });
})();
