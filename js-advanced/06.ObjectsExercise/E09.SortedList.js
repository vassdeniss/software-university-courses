function createSortedList() {
  const collection = [];

  const result = {
    add,
    remove,
    get,
    size: 0,
  };

  return result;

  function add(element) {
    collection.push(element);
    result.size++;
    collection.sort((a, b) => a - b);
  }

  function remove(index) {
    const valid = checkIndex(index);

    if (valid) {
      collection.splice(index, 1);
      result.size--;
    }
  }

  function get(index) {
    const valid = checkIndex(index);

    if (valid) {
      return collection[index];
    }
  }

  function checkIndex(index) {
    return index >= 0 && index < collection.length;
  }
}

let list = createSortedList();
list.add(5);
list.add(6);
list.add(7);
console.log(list.get(1));
list.remove(1);
console.log(list.get(1));
