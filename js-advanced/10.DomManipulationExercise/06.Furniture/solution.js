function solve() {
  const [input, output] = Array.from(document.getElementsByTagName('textarea'));
  const [generateButton, buyButton] = Array.from(
    document.getElementsByTagName('button')
  );
  const tbody = document.querySelector('tbody');

  generateButton.addEventListener('click', generate);
  buyButton.addEventListener('click', buy);

  const items = [];

  function generate() {
    JSON.parse(input.value).forEach((item) => {
      const row = createRow(item);
      tbody.appendChild(row.element);
      items.push(row);
    });
  }

  function buy() {
    const selectedItems = items
      .filter((item) => item.isChecked())
      .map((item) => item.item);

    const names = selectedItems.map((item) => item.name).join(', ');
    const total = selectedItems.reduce(
      (acc, curr) => acc + Number(curr.price),
      0
    );
    const decFactor = selectedItems.reduce(
      (acc, curr, _, array) => acc + Number(curr.decFactor) / array.length,
      0
    );

    output.textContent = [
      `Bought furniture: ${names}`,
      `Total price: ${total.toFixed(2)}`,
      `Average decoration factor: ${decFactor}`,
    ].join('\n');
  }

  function createRow(item) {
    const row = document.createElement('tr');

    row.appendChild(createCol(createImage(item.img)));
    row.appendChild(createCol(createParagraph(item.name)));
    row.appendChild(createCol(createParagraph(item.price)));
    row.appendChild(createCol(createParagraph(item.decFactor)));

    const check = createCheck();
    row.appendChild(createCol(check));

    return {
      element: row,
      item,
      isChecked,
    };

    function isChecked() {
      return check.checked;
    }
  }

  function create(type, attr, content) {
    const result = document.createElement(type);
    Object.assign(result, attr);

    if (content !== undefined) {
      result.appendChild(content);
    }

    return result;
  }

  const createCol = create.bind(null, 'td', { scope: 'col' });
  const createParagraph = (text) => create('p', { textContent: text });
  const createImage = (src) => create('img', { src });
  const createCheck = create.bind(null, 'input', { type: 'checkbox' });
}
