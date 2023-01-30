function addItem() {
  const itemText = document.getElementById('newItemText');
  const itemValue = document.getElementById('newItemValue');

  const newItem = document.createElement('option');
  newItem.textContent = itemText.value;
  newItem.value = itemValue.value;

  const menu = document.getElementById('menu');
  menu.appendChild(newItem);

  itemText.value = '';
  itemValue.value = '';
}
