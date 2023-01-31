function process(array) {
  let collection = [];

  for (const pair of array) {
    const [command, value] = pair.split(' ');

    if (command === 'add') {
      collection.push(value);
    } else if (command === 'remove') {
      collection = collection.filter((item) => item !== value);
    } else {
      console.log(collection.join(','));
    }
  }
}

process(['add hello', 'add again', 'remove hello', 'add again', 'print']);
process(['add pesho', 'add george', 'add peter', 'remove peter', 'print']);
