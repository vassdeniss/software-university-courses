function calculator() {
  let sumElement1;
  let sumElement2;
  let resultElement;

  return {
    init: (selector1, selector2, resultSelector) => {
      sumElement1 = document.querySelector(selector1);
      sumElement2 = document.querySelector(selector2);
      resultElement = document.querySelector(resultSelector);
    },
    add: () => {
      resultElement.value = +sumElement1.value + +sumElement2.value;
    },
    subtract: () => {
      resultElement.value = +sumElement1.value - +sumElement2.value;
    },
  };
}
