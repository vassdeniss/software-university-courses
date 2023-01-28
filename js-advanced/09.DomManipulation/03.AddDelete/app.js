function addItem() {
  const text = document.getElementById('newItemText');
  const newItem = document.createElement('li');

  newItem.textContent = text.value;

  const remove = document.createElement('a');
  remove.textContent = '[Delete]';
  remove.href = '#';
  remove.addEventListener('click', () => {
    newItem.remove();
  });

  newItem.appendChild(remove);

  const list = document.getElementById('items');
  list.appendChild(newItem);

  text.value = '';
}
