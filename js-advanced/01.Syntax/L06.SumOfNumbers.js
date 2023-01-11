function getSum(n, m) {
  const numOne = Number(n);
  const numTwo = Number(m);

  let result = 0;
  for (let i = numOne; i <= numTwo; i++) {
    result += i;
  }

  return result;
}

console.log(getSum('1', '5'));
console.log(getSum('-8', '20'));
