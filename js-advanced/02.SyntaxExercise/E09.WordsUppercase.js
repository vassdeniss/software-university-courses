function makeUppercase(words) {
  return words
    .match(/[A-z0-9]+/g)
    .join(', ')
    .toUpperCase();
}

console.log(makeUppercase('Hi, how are you?'));
console.log(makeUppercase('hello'));
