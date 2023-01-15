function processArray(array) {
  let result = [];
  for (let i = 0; i < array.length; i++) {
    const current = array[i];
    if (current < 0) {
      result.unshift(current);
    } else {
      result.push(current);
    }
  }

  console.log(result.join('\n'));
}

processArray([7, -2, 8, 9]);
processArray([3, -2, 0, -1]);
