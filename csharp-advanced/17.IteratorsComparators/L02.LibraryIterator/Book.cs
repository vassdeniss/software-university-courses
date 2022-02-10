using System.Collections.Generic;
using System.Linq;

namespace IteratorsAndComparators
{
    public class Book
    {
        public Book(string title, int year, params string[] authors)
        {
            Title = title;
            Year = year;
            Authors = authors.ToList();
        }

        public string Title { get; private set; }
        public int Year { get; private set; }
        public List<string> Authors { get; private set; }
    }
}
