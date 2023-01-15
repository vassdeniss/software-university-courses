function getDiagonalSum(array2d) {
  let mainDiagonal = 0;
  let secondaryDiagonal = 0;

  for (let i = 0; i < array2d.length; i++) {
    mainDiagonal += array2d[i][i];
    secondaryDiagonal += array2d[i][array2d.length - 1 - i];
  }

  console.log(mainDiagonal, secondaryDiagonal);
}

getDiagonalSum([
  [20, 40],
  [10, 60],
]);

getDiagonalSum([
  [3, 5, 17],
  [-1, 7, 14],
  [1, -8, 89],
]);
