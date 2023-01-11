function aggregateElements(array) {
  const numbersArray = array.map(Number);

  const sum = numbersArray.reduce((acc, current) => acc + current, 0);
  const inverseSum = numbersArray.reduce(
    (acc, current) => acc + 1 / current,
    0
  );
  const stringConcat = numbersArray.join('');

  console.log(sum);
  console.log(inverseSum);
  console.log(stringConcat);
}

aggregateElements([1, 2, 3]);
aggregateElements([2, 4, 8, 16]);
