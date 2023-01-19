function sortByTwo(array) {
  console.log(array
    .sort((a, b) => a.length - b.length 
          || a.localeCompare(b))
    .join('\n'));
}

sortByTwo(['alpha', 'beta', 'gamma']);
sortByTwo(['Isacc', 'Theodor', 'Jack', 'Harrison', 'George']);
sortByTwo(['test', 'Deny', 'omen', 'Default']);
