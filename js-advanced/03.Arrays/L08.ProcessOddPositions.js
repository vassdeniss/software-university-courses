function processOdd(array) {
  let result = array
    .filter((el, i) => i % 2 !== 0)
    .map((el) => el * 2);

  return result.reverse().join(' ');
}

console.log(processOdd([10, 15, 20, 25]));
console.log(processOdd([3, 0, 10, 4, 7, 3]));
