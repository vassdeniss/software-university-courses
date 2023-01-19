function getSubset(array) {
  let result = [];
  array.reduce((acc, item) => {
    if (item >= acc) {
      acc = item;
      result.push(item);
    }

    return acc;
  }, array[0]);

  return result;
}

console.log(getSubset([1, 3, 8, 4, 10, 12, 3, 2, 24]));
console.log(getSubset([1, 2, 3, 4]));
console.log(getSubset([20, 3, 2, 15, 6, 1]));
