class List {
  #list;

  constructor() {
    this.#list = [];
    this.size = 0;
  }

  //? Judge doesn't support properties?
  // get size() {
  //   return this.#list.length;
  // }

  add(element) {
    this.#list.push(element);
    this.size = this.#list.length;
    this._sortList();
  }

  remove(index) {
    this._checkIndex(index);

    this.#list.splice(index, 1);
    this.size = this.#list.length;
    this._sortList();
  }

  get(index) {
    this._checkIndex(index);

    return this.#list[index];
  }

  //! JUDGE DOESN'T SUPPORT PRIVATE METHODS
  // #checkIndex(index) {}
  _checkIndex(index) {
    if (index < 0 || index >= this.#list.length) {
      throw new Error('Index out of bounds');
    }
  }

  // #sortList() {}
  _sortList() {
    this.#list.sort((a, b) => a - b);
  }
}

let list = new List();
list.add(5);
list.add(6);
list.add(7);
console.log(list.get(1));
list.remove(1);
console.log(list.get(1));
