function addDelimeter(array, delimeter) {
  return array.join(delimeter);
}

console.log(addDelimeter(['One', 'Two', 'Three', 'Four', 'Five'], '-'));
console.log(
  addDelimeter(['How about no?', 'I', 'will', 'not', 'do', 'it!'], '_')
);
