function isOddOrEven(str) {
  if (typeof str !== 'string') {
    return undefined;
  }

  if (str.length % 2 !== 0) {
    return 'odd';
  }

  return 'even';
}

module.exports = {
  isOddOrEven,
};
