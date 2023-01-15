function getTwoSmallest(array) {
  const result = array.sort((a, b) => a - b);

  return `${result[0]} ${result[1]}`;
}

console.log(getTwoSmallest([30, 15, 50, 5]));
console.log(getTwoSmallest([3, 0, 10, 4, 7, 3]));
