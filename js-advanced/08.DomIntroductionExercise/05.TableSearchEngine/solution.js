function solve() {
  document.querySelector('#searchBtn').addEventListener('click', onClick);

  const field = document.getElementById('searchField');
  const table = document.querySelectorAll('tbody tr');

  function onClick() {
    Array.from(table).forEach((row) => {
      if (
        row.textContent.toLowerCase().includes(field.value.toLowerCase().trim())
      ) {
        debugger;
        row.classList.add('select');
      } else {
        row.classList.remove('select');
      }
    });

    field.value = '';
  }
}
