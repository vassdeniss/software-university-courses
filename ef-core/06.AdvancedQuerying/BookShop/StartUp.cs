using System;
using System.Globalization;
using System.Linq;
using System.Text;

using BookShop.Data;

using BookShop.Initializer;
using BookShop.Models;
using BookShop.Models.Enums;

using Microsoft.EntityFrameworkCore;

namespace BookShop
{
    public class StartUp
    {
        public static void Main()
        {
            using BookShopContext db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            string ageRestrict = Console.ReadLine();
            Console.WriteLine(GetBooksByAgeRestriction(db, ageRestrict));

            Console.WriteLine(GetGoldenBooks(db));

            Console.WriteLine(GetBooksByPrice(db));

            int year = int.Parse(Console.ReadLine());
            Console.WriteLine(GetBooksNotReleasedIn(db, year));

            string categories = Console.ReadLine();
            Console.WriteLine(GetBooksByCategory(db, categories));

            string date = Console.ReadLine();
            Console.WriteLine(GetBooksReleasedBefore(db, date));

            string endsWith = Console.ReadLine();
            Console.WriteLine(GetAuthorNamesEndingIn(db, endsWith));

            string toContain = Console.ReadLine();
            Console.WriteLine(GetBookTitlesContaining(db, toContain));

            string startsWith = Console.ReadLine();
            Console.WriteLine(GetBooksByAuthor(db, startsWith));

            int length = int.Parse(Console.ReadLine());
            Console.WriteLine(CountBooks(db, length));

            Console.WriteLine(CountCopiesByAuthor(db));

            Console.WriteLine(GetTotalProfitByCategory(db));

            Console.WriteLine(GetMostRecentBooks(db));

            IncreasePrices(db);

            Console.WriteLine(RemoveBooks(db));
        }

        // Problem 02 - Age Restriction  
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            AgeRestriction ageRestriction = Enum.Parse<AgeRestriction>(command, true);

            string[] bookTitles = context.Books
                .Where(x => x.AgeRestriction == ageRestriction)
                .Select(x => x.Title)
                .OrderBy(x => x)
                .AsNoTracking()
                .ToArray();

            return string.Join(Environment.NewLine, bookTitles);
        }

        // Problem 03 - Golden Books
        public static string GetGoldenBooks(BookShopContext context)
        {
            string[] goldenBookTitles = context.Books
                .Where(x => x.EditionType == EditionType.Gold
                       && x.Copies < 5000)
                .OrderBy(x => x.BookId)
                .Select(x => x.Title)
                .ToArray();

            return string.Join(Environment.NewLine, goldenBookTitles);
        }

        // Problem 04 - Books by Price
        public static string GetBooksByPrice(BookShopContext context)
        {
            var bookPrices = context.Books
                .Where(x => x.Price > 40)
                .OrderByDescending(x => x.Price)
                .Select(x => new
                {
                    x.Title,
                    x.Price
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var book in bookPrices)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:f2}");
            }

            return sb.ToString().Trim();
        }

        // Problem 05 - Not Released In
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            string[] bookTitles = context.Books
                .Where(x => x.ReleaseDate.Value.Year != year)
                .OrderBy(x => x.BookId)
                .Select(x => x.Title)
                .ToArray();

            return string.Join(Environment.NewLine, bookTitles);
        }

        // Problem 06 - Book Titles by Category
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input.ToLower().Split();

            string[] bookTitles = context.Books
                .Where(x => x.BookCategories.Any(x => categories.Contains(x.Category.Name.ToLower())))
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToArray();

            return string.Join(Environment.NewLine, bookTitles);
        }

        // Problem 07 - Released Before Date
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime time = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(x => x.ReleaseDate.Value < time)
                .OrderByDescending(x => x.ReleaseDate)
                .Select(x => new
                {
                    x.Title,
                    x.EditionType,
                    x.Price
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");
            }

            return sb.ToString().Trim();
        }

        // Problem 08 - Author Search
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authorNames = context.Authors
                .Where(x => x.FirstName.EndsWith(input))
                .Select(x => new
                {
                    FullName = $"{x.FirstName} {x.LastName}"
                })
                .OrderBy(x => x.FullName)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var author in authorNames)
            {
                sb.AppendLine(author.FullName);
            }

            return sb.ToString().Trim();
        }

        // Problem 09 - Book Search
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            string[] bookTitles = context.Books
                .Where(x => x.Title.ToLower().Contains(input.ToLower()))
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToArray();

            return string.Join(Environment.NewLine, bookTitles);
        }

        // Problem 10 - Book Search by Author
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(x => x.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(x => x.BookId)
                .Select(x => new
                {
                    x.Title,
                    AuthorFirstName = x.Author.FirstName,
                    AuthorLastName = x.Author.LastName
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} ({book.AuthorFirstName} {book.AuthorLastName})");
            }

            return sb.ToString().Trim();
        }

        // Problem 11 - Count Books
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            int bookCount = context.Books
                .Where(x => x.Title.Length > lengthCheck)
                .AsNoTracking()
                .ToArray()
                .Length;

            return bookCount;
        }

        // Problem 12 - Total Book Copies
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authorsBookCopies = context.Authors
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    TotalBooks = x.Books.Sum(x => x.Copies)
                })
                .OrderByDescending(x => x.TotalBooks)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var author in authorsBookCopies)
            {
                sb.AppendLine($"{author.FirstName} {author.LastName} - {author.TotalBooks}");
            }

            return sb.ToString().Trim();
        }

        // Problem 13 - Profit by Categories 
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categories = context.Categories
                .Select(x => new
                {
                    x.Name,
                    Profit = x.CategoryBooks.Sum(x => x.Book.Price * x.Book.Copies)
                })
                .OrderByDescending(x => x.Profit)
                .ThenBy(x => x.Name)
                .ToArray();

            return string.Join(Environment.NewLine, categories.Select(x => $"{x.Name} ${x.Profit:f2}"));
        }

        // Problem 14 - Most Recent Books
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var booksPerCategory = context.Categories
                .OrderBy(x => x.Name)
                .Select(x => new
                {
                    CategoryName = x.Name,
                    CategoryBooks = x.CategoryBooks
                        .Select(x => new
                        {
                            x.Book.Title,
                            x.Book.ReleaseDate
                        })
                        .OrderByDescending(x => x.ReleaseDate)
                        .Take(3)
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var category in booksPerCategory)
            {
                sb.AppendLine($"--{category.CategoryName}");
                foreach (var book in category.CategoryBooks)
                {
                    sb.AppendLine($"{book.Title} ({book.ReleaseDate.Value.Year})");
                }
            }

            return sb.ToString().Trim();
        }

        // Problem 15 - Increase Prices
        public static void IncreasePrices(BookShopContext context)
        {
            int yearLessThan = 2010;

            IQueryable<Book> booksToUpdate = context.Books
                .Where(x => x.ReleaseDate.Value.Year < yearLessThan);

            int priceToIncrease = 5;
            foreach (Book book in booksToUpdate)
            {
                book.Price += priceToIncrease;
            }

            context.SaveChanges();
        }

        // Problem 16 - Remove Books
        public static int RemoveBooks(BookShopContext context)
        {
            int copiesLessThan = 4200;

            IQueryable<Book> booksToDelete = context.Books
                .Where(x => x.Copies < copiesLessThan);

            int deletedBooks = booksToDelete.Length;

            context.Books.RemoveRange(booksToDelete);
            context.SaveChanges();

            return deletedBooks;
        }
    }
}
