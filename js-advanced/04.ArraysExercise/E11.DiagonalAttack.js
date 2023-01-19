function diagonalAttack(matrix) {
  let mainDiagonal = 0;
  let secondaryDiagonal = 0;

  let mapped = matrix.map((row) => row.split(' ').map(Number));

  for (let i = 0; i < mapped.length; i++) {
    mainDiagonal += mapped[i][i];
    secondaryDiagonal += mapped[i][mapped.length - 1 - i];
  }

  if (mainDiagonal === secondaryDiagonal) {
    for (let i = 0; i < mapped.length; i++) {
      for (let j = 0; j < mapped.length; j++) {
        if (i !== j && i !== mapped.length - 1 - j) {
          mapped[i][j] = mainDiagonal;
        }
      }
    }
  }

  mapped.forEach((arr) => {
    console.log(arr.join(' '));
  });
}

diagonalAttack([
  '5 3 12 3 1',
  '11 4 23 2 5',
  '101 12 3 21 10',
  '1 4 5 2 2',
  '5 22 33 11 1',
]);

diagonalAttack(['1 1 1', '1 1 1', '1 1 0']);
