class LibraryCollection {
  constructor(capacity) {
    this.capacity = capacity;
    this.books = [];
  }

  addBook(name, author) {
    if (this.capacity === this.books.length) {
      throw new Error('Not enough space in the collection.');
    }

    this.books.push({
      name,
      author,
      paid: false,
    });

    return `The ${name}, with an author ${author}, collect.`;
  }

  payBook(name) {
    const book = this.books.find((book) => book.name === name);

    if (!book) {
      throw new Error(`${name} is not in the collection.`);
    }

    if (book.paid) {
      throw new Error(`${name} has already been paid.`);
    }

    book.paid = true;
    return `${name} has been successfully paid.`;
  }

  removeBook(name) {
    this.books.forEach((book) => {});

    const book = this.books.find((book) => book.name === name);

    if (!book) {
      throw new Error('The book, you\'re looking for, is not found.');
    }

    if (!book.paid) {
      throw new Error(
        `${name} need to be paid before removing from the collection.`
      );
    }

    this._removeFromCollection(book);

    return `${name} remove from the collection.`;
  }

  getStatistics(author) {
    const result = [];

    let arr;

    if (!author) {
      result.push(
        `The book collection has ${
          this.capacity - this.books.length
        } empty spots left.`
      );
      arr = this.books.sort((a, b) => a.name.localeCompare(b.name));
    } else {
      arr = this._findBooksByAuthor(author);
    }

    for (const book of arr) {
      result.push(
        `${book.name} == ${book.author} - ${
          book.paid ? 'Has Paid' : 'Not Paid'
        }.`
      );
    }

    return result.join('\n');
  }

  _removeFromCollection(book) {
    const index = this.books.indexOf(book);

    this.books.splice(index, 1);
  }

  _findBooksByAuthor(author) {
    const books = this.books.filter((book) => book.author === author);

    if (books.length <= 0) {
      throw new Error(`${author} is not in the collection.`);
    }

    return books;
  }
}
