using System;
using System.Collections.Generic;
using System.Linq;

namespace IteratorsAndComparators
{
    public class Book : IComparable<Book>
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

        public int CompareTo(Book other)
        {
            int result = Year.CompareTo(other.Year);
            return result == 0 ? Title.CompareTo(other.Title) : result;
        }

        public override string ToString()
        {
            return $"{Title} - {Year}";
        }
    }
}
