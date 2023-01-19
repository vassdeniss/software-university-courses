function addRemove(commands) {
  let result = [];
  commands.reduce((acc, curr) => {
    if (curr === 'add') {
      result.push(acc);
    } else if (curr === 'remove') {
      result.pop();
    }

    return ++acc;
  }, 1);

  return result.length === 0
    ? 'Empty'
    : result.join('\n');
}

console.log(addRemove(['add', 'add', 'add', 'add']));
console.log(addRemove(['add', 'add', 'remove', 'add', 'add']));
console.log(addRemove(['remove', 'remove', 'remove']));
