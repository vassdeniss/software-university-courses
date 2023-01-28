function addItem() {
  const text = document.getElementById('newItemText');
  const newItem = document.createElement('li');

  newItem.textContent = text.value;

  const list = document.getElementById('items');
  list.appendChild(newItem);

  text.value = '';
}
