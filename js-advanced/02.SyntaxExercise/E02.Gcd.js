function getGcd(a, b) {
  if (a === 0) {
    return b;
  }

  return getGcd(b % a, a);
}

console.log(getGcd(15, 5));
console.log(getGcd(2154, 458));
