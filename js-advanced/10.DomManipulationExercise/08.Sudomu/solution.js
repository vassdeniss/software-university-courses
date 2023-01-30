function solve() {
  const inputs = document.getElementsByTagName('input');
  const [check, clear] = document.getElementsByTagName('button');

  const table = document.querySelector('table');
  const checkResult = document.querySelector('#check p');

  clear.addEventListener('click', () => {
    [...inputs].forEach((cell) => (cell.value = ''));
    checkResult.textContent = '';
    table.style.border = 'none';
  });

  check.addEventListener('click', () => {
    const field = [
      [inputs[0].value, inputs[1].value, inputs[2].value],
      [inputs[3].value, inputs[4].value, inputs[5].value],
      [inputs[6].value, inputs[7].value, inputs[8].value],
    ];

    const isSudomu = field.every((row, index, arr) => {
      const col = arr.map((row) => row[index]);

      if (
        col.length != [...new Set(col)].length ||
        row.length != [...new Set(row)].length
      ) {
        return false;
      }

      return true;
    });

    if (isSudomu) {
      table.style.border = '2px solid green';
      checkResult.style.color = 'green';
      checkResult.textContent = 'You solve it! Congratulations!';
    } else {
      table.style.border = '2px solid red';
      checkResult.style.color = 'red';
      checkResult.textContent = 'NOP! You are not done yet...';
    }
  });
}
