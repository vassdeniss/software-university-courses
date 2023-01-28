function deleteByEmail() {
  const email = document.getElementsByName('email')[0].value;

  const emails = document.querySelectorAll('#customers tr td:nth-child(2)');
  const result = document.getElementById('result');
  for (const td of emails) {
    if (td.textContent === email) {
      const row = td.parentElement;
      row.parentElement.removeChild(row);
      result.textContent = 'Deleted';
      break;
    }
  }

  result.textContent = 'Not found.';
}
