function getBiggerHalf(array) {
  array.sort((a, b) => a - b);

  const half = array.length / 2;
  return array.slice(half);
}

console.log(getBiggerHalf([4, 7, 2, 5]));
console.log(getBiggerHalf([3, 19, 14, 7, 2, 19, 6]));
