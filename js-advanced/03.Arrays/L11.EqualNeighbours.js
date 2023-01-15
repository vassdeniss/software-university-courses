function getEqualNeighbours(matrix) {
  let counter = 0;

  for (let i = 0; i < matrix.length - 1; i++) {
    for (let j = 1; j < matrix[i].length; j++) {
      if (matrix[i][j] === matrix[i + 1][j]) {
        counter++;
      }

      if (matrix[i][j] === matrix[i][j - 1]) {
        counter++;
      }
    }
  }

  const last = matrix.length - 1;
  for (let i = 0; i < matrix[last].length; i++) {
    if (matrix[last][i] === matrix[last][i + 1]) {
      counter++;
    }
  }

  for (let i = 0; i < last; i++) {
    if (matrix[i][0] === matrix[i + 1][0]) {
      counter++;
    }
  }

  return counter;
}

console.log(
  getEqualNeighbours([
    ['2', '3', '4', '7', '0'],
    ['4', '0', '5', '3', '4'],
    ['2', '3', '5', '4', '2'],
    ['9', '8', '7', '5', '4'],
  ])
);

console.log(
  getEqualNeighbours([
    ['test', 'yes', 'yo', 'ho'],
    ['well', 'done', 'yo', '6'],
    ['not', 'done', 'yet', '5'],
  ])
);
