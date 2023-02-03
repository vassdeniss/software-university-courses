function solve() {
  const [name, hall, price] = document.getElementsByTagName('input');
  const [addButton, clearButton] = document.getElementsByTagName('button');
  const screenMovies = document.querySelector('#movies ul');
  const archivedMovies = document.querySelector('#archive ul');

  addButton.addEventListener('click', (event) => {
    event.preventDefault();

    if (!name.value || !hall.value || !price.value || isNaN(price.value)) {
      name.value = '';
      hall.value = '';
      price.value = '';
      return;
    }

    const li = document.createElement('li');

    const span = document.createElement('span');
    span.textContent = name.value;

    const strong = document.createElement('strong');
    strong.textContent = `Hall: ${hall.value}`;

    const div = document.createElement('div');

    const strongPrice = document.createElement('strong');
    const priceParsed = Number(price.value);
    strongPrice.textContent = `${priceParsed.toFixed(2)}`;

    const input = document.createElement('input');
    input.placeholder = 'Tickets Sold';

    const button = document.createElement('button');
    button.textContent = 'Archive';
    button.addEventListener('click', archiveMovie);

    div.appendChild(strongPrice);
    div.appendChild(input);
    div.appendChild(button);

    li.appendChild(span);
    li.appendChild(strong);
    li.appendChild(div);

    screenMovies.appendChild(li);

    name.value = '';
    hall.value = '';
    price.value = '';

    function archiveMovie() {
      const tickets = input.value;

      if (!tickets || isNaN(tickets)) {
        return;
      }

      const archiveLi = document.createElement('li');

      const archiveStrong = document.createElement('strong');
      archiveStrong.textContent = `Total amount: ${(
        priceParsed * Number(tickets)
      ).toFixed(2)}`;

      const deleteButton = document.createElement('button');
      deleteButton.textContent = 'Delete';
      deleteButton.addEventListener('click', deleteArchive);

      archiveLi.appendChild(span);
      archiveLi.appendChild(archiveStrong);
      archiveLi.appendChild(deleteButton);

      screenMovies.removeChild(li);
      archivedMovies.appendChild(archiveLi);
    }

    function deleteArchive(event) {
      event.target.parentElement.remove();
    }
  });

  clearButton.addEventListener('click', () => {
    archivedMovies.textContent = '';
  });
}
