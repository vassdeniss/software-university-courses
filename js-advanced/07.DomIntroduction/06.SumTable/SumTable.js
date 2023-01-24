function sumTable() {
  const columns = Array.from(
    document.querySelectorAll('table tr td:nth-child(even):not(#sum)')
  );

  const sum = document.getElementById('sum');

  sum.textContent = columns.reduce(
    (acc, curr) => acc + Number(curr.textContent),
    0
  );
}
