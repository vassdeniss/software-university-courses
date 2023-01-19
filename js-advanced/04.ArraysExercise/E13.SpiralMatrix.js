function spiral(row, col) {
  let result = [];

  let counter = 1;

  let startCol = 0;
  let endCol = col - 1;

  let startRow = 0;
  let endRow = row - 1;

  for (let i = 0; i < row; i++) {
    result.push([]);
  }

  while (startCol <= endCol && startRow <= endRow) {
    for (let i = startCol; i <= endCol; i++) {
      result[startRow][i] = counter++;
    }

    startRow++;

    for (let i = startRow; i <= endRow; i++) {
      result[i][endCol] = counter++;
    }

    endCol--;

    for (let i = endCol; i >= startCol; i--) {
      result[endRow][i] = counter++;
    }

    endRow--;

    for (let i = endRow; i >= startRow; i--) {
      result[i][startCol] = counter++;
    }

    startCol++;
  }

  result.forEach((row) => console.log(row.join(' ')));
}

spiral(5, 5);
spiral(3, 3);
