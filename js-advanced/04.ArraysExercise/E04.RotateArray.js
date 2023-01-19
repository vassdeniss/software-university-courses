function rotate(array, times) {
  for (let i = 0; i < times; i++) {
    array.unshift(array.pop());
  }

  return array.join(' ');
}

console.log(rotate(['1', '2', '3', '4'], 2));
console.log(rotate(['Banana', 'Orange', 'Coconut', 'Apple'], 15));
