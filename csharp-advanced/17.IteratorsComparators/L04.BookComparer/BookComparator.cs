using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class BookComparator : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            int result = x.Title.CompareTo(y.Title);
            return result == 0 ? y.Year.CompareTo(x.Year) : result;
        }
    }
}
