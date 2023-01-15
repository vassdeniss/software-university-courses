function getSum(array) {
  const first = Number(array[0]);
  const last = Number(array[array.length - 1]);

  console.log(first + last);
}

console.log(getSum(['20', '30', '40']));
console.log(getSum(['5', '10']));
