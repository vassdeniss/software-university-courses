using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        public Library(params Book[] books)
        {
            Books = books.ToList();
        }

        public List<Book> Books { get; private set; }

        public IEnumerator<Book> GetEnumerator() => new LibraryIterator(Books);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private class LibraryIterator : IEnumerator<Book>
        {
            private readonly List<Book> books;
            private int idx;

            public LibraryIterator(IEnumerable<Book> books)
            {
                idx = -1;
                this.books = new List<Book>(books);
            }

            public Book Current => books[idx];
            public bool MoveNext() => ++idx < books.Count;

            public void Reset() { }
            public void Dispose() { }
            object IEnumerator.Current => Current;
        }
    }
}
