function getBiggest(array2D) {
  let max = Number.NEGATIVE_INFINITY;

  for (let row = 0; row < array2D.length; row++) {
    for (let col = 0; col < array2D[row].length; col++) {
      if (array2D[row][col] > max) {
        max = array2D[row][col];
      }
    }
  }

  return max;
}

console.log(
  getBiggest([
    [20, 50, 10],
    [8, 33, 145],
  ])
);

console.log(
  getBiggest([
    [3, 5, 7, 12],
    [-1, 4, 33, 2],
    [8, 3, 0, 4],
  ])
);
