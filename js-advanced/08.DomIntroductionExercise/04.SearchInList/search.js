function search() {
  const itemList = Array.from(document.querySelectorAll('#towns li'));
  const input = document.getElementById('searchText');
  const result = document.getElementById('result');

  const count = itemList.reduce((acc, curr) => {
    if (curr.textContent.toLowerCase().includes(input.value.toLowerCase())) {
      curr.style.fontWeight = 'bold';
      curr.style.textDecoration = 'underline';
      acc++;
    } else {
      curr.style.fontWeight = 'normal';
      curr.style.textDecoration = 'none';
    }

    return acc;
  }, 0);

  result.textContent = `${count} matches found`;
}
