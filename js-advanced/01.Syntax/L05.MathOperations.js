function performOperation(a, b, operator) {
  let result;
  switch (operator) {
    case '+':
      result = a + b;
      break;
    case '-':
      result = a - b;
      break;
    case '*':
      result = a * b;
      break;
    case '/':
      result = a / b;
      break;
    case '%':
      result = a % b;
      break;
    case '**':
      result = a ** b;
      break;
  }

  console.log(result);
}

performOperation(5, 6, '+');
performOperation(3, 5.5, '*');
