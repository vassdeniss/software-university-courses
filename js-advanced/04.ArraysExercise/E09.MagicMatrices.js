function isMagical(matrix) {
  let rowSum = 0;
  let colSum = 0;

  for (let i = 0; i < matrix.length; i++) {
    for (let j = 0; j < matrix[i].length; j++) {
      rowSum += matrix[i][j];
      colSum += matrix[i][0];
    }
  }

  return rowSum === colSum;
}

console.log(
  isMagical([
    [4, 5, 6],
    [6, 5, 4],
    [5, 5, 5],
  ])
);

console.log(
  isMagical([
    [11, 32, 45],
    [21, 0, 1],
    [21, 1, 1],
  ])
);

console.log(
  isMagical([
    [1, 0, 0],
    [0, 0, 1],
    [0, 1, 0],
  ])
);
