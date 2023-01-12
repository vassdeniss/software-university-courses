function checkCoordinates(x1, y1, x2, y2) {
  function isValid(x1, y1, x2, y2) {
    const distance = Math.sqrt(Math.pow(x1 - x2, 2) + Math.pow(y1 - y2, 2));

    const isValid = Number.isInteger(distance) ? 'valid' : 'invalid';

    console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is ${isValid}`);
  }

  isValid(x1, y1, 0, 0);
  isValid(x2, y2, 0, 0);
  isValid(x1, y1, x2, y2);
}

checkCoordinates(3, 0, 0, 4);
checkCoordinates(2, 1, 1, 1);
