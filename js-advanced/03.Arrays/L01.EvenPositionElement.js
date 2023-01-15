function getEven(array) {
  return array
    .filter((el, i) => i % 2 === 0)
    .join(' ');
}

console.log(getEven(['20', '30', '40', '50', '60']));
console.log(getEven(['5', '10']));
