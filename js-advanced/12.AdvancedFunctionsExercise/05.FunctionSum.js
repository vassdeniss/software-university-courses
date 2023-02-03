function add(num) {
  let sum = num;

  function calc(num2) {
    sum += num2;
    return calc;
  }

  calc.toString = () => sum;

  return calc;
}

console.log(add(1).toString());
console.log(add(1)(6)(-3).toString());
