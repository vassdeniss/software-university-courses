function colorize() {
  const evenRows = document.querySelectorAll('table tr:nth-child(even)');

  for (const row of Array.from(evenRows)) {
    row.style.backgroundColor = 'teal';
  }
}
