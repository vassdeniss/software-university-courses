function ticTacToe(moves) {
  let board = [
    [false, false, false],
    [false, false, false],
    [false, false, false],
  ];

  const hasRoom = (board) => board.some((arr) => arr.some((cell) => !cell));

  let win = false;
  let currPlayer = 'X';
  for (let row = 0; row < moves.length && hasRoom(board); row++) {
    const [currRow, currCol] = moves[row].split(' ').map(Number);

    if (!board[currRow][currCol]) {
      board[currRow][currCol] = currPlayer;

      if (checkForWinner(board, currPlayer)) {
        win = true;
        break;
      }

      currPlayer = currPlayer === 'X' ? 'O' : 'X';
    } else {
      console.log('This place is already taken. Please choose another!');
    }
  }

  if (win) {
    console.log(`Player ${currPlayer} wins!`);
  } else {
    console.log('The game ended! Nobody wins :(');
  }

  board.forEach((line) => {
    console.log(line.join('\t'));
  });

  function checkForWinner(currentBoard, sign) {
    let isWinner = false;

    for (let i = 0; i < 3; i++) {
      if (
        currentBoard[i][0] === sign &&
        currentBoard[i][1] === sign &&
        currentBoard[i][2] === sign
      ) {
        isWinner = true;
        break;
      }

      if (
        currentBoard[0][i] === sign &&
        currentBoard[1][i] === sign &&
        currentBoard[2][i] === sign
      ) {
        isWinner = true;
        break;
      }
    }

    if (!isWinner) {
      if (
        (currentBoard[0][0] === sign &&
          currentBoard[1][1] === sign &&
          currentBoard[2][2] === sign) ||
        (currentBoard[2][0] === sign &&
          currentBoard[1][1] === sign &&
          currentBoard[0][2] === sign)
      ) {
        isWinner = true;
      }
    }

    return isWinner;
  }
}

ticTacToe([
  '0 1',
  '0 0',
  '0 2',
  '2 0',
  '1 0',
  '1 1',
  '1 2',
  '2 2',
  '2 1',
  '0 0',
]);

ticTacToe([
  '0 0',
  '0 0',
  '1 1',
  '0 1',
  '1 2',
  '0 2',
  '2 2',
  '1 2',
  '2 2',
  '2 1',
]);

ticTacToe([
  '0 1',
  '0 0',
  '0 2',
  '2 0',
  '1 0',
  '1 2',
  '1 1',
  '2 1',
  '2 2',
  '0 0',
]);
