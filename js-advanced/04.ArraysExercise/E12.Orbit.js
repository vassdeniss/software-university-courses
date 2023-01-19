function buildOrbit(params) {
  const rows = params[0];
  const cols = params[1];
  const starRow = params[2];
  const starCol = params[3];

  let matrix = [];
  for (let i = 0; i < rows; i++) {
    matrix.push([]);
  }

  for (let row = 0; row < rows; row++) {
    for (let col = 0; col < cols; col++) {
      matrix[row][col] =
        Math.max(Math.abs(row - starRow), Math.abs(col - starCol)) + 1;
    }
  }

  return matrix.map((row) => row.join(' ')).join('\n');
}

console.log(buildOrbit([4, 4, 0, 0]));
console.log(buildOrbit([5, 5, 2, 2]));
console.log(buildOrbit([3, 3, 2, 2]));
