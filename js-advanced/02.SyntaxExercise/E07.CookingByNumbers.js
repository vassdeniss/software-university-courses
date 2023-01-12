function cook(input, op1, op2, op3, op4, op5) {
  let num = Number(input);

  function performOp(op) {
    switch (op) {
      case 'chop':
        num /= 2;
        break;
      case 'dice':
        num = Math.sqrt(num);
        break;
      case 'spice':
        num += 1;
        break;
      case 'bake':
        num *= 3;
        break;
      default:
        num -= 0.2 * num;
    }

    console.log(num);
  }

  performOp(op1);
  performOp(op2);
  performOp(op3);
  performOp(op4);
  performOp(op5);
}

cook('32', 'chop', 'chop', 'chop', 'chop', 'chop');
cook('9', 'dice', 'spice', 'chop', 'bake', 'fillet');
