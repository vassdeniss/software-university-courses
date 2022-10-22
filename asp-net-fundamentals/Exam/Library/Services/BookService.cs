using Library.Data;
using Library.Data.Models;
using Library.Services.Contracts;
using Library.Services.Models;

using Microsoft.EntityFrameworkCore;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryDbContext context;

        public BookService(LibraryDbContext context)
        {
            this.context = context;
        }

        public async Task<ICollection<ServiceCategoryViewModel>> GetCategoriesAsync()
        {
            return await this.context.Categories
                .Select(c => new ServiceCategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
        }

        public async Task AddBookAsync(string title,
            string author,
            string description,
            string imageUrl,
            decimal rating,
            int categoryId)
        {
            Book book = new Book
            {
                Title = title,
                Author = author,
                Description = description,
                ImageUrl = imageUrl,
                Rating = rating,
                CategoryId = categoryId
            };

            await this.context.Books.AddAsync(book);
            await this.context.SaveChangesAsync();
        }

        public async Task<ICollection<ServiceBookViewModel>> GetBooksAsync()
        {
            return await this.context.Books
                .Include(b => b.Category)
                .Select(b => new ServiceBookViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Description = b.Description,
                    Author = b.Author,
                    ImageUrl = b.ImageUrl,
                    Rating = b.Rating,
                    CategoryId = b.CategoryId,
                    Category = b.Category
                })
                .ToListAsync();
        }

        public async Task<ICollection<ServiceBookViewModel>> GetUserBooksAsync(string userId)
        {
            LibraryUser user = await context.Users
                .Where(u => u.Id.ToString() == userId)
                .Include(u => u.LibraryUsersBooks)
                .ThenInclude(lub => lub.Book)
                .ThenInclude(lub => lub.Category)
                .FirstOrDefaultAsync();

            return user.LibraryUsersBooks
                .Select(m => new ServiceBookViewModel()
                {
                    Id = m.BookId,
                    Title = m.Book.Title,
                    Author = m.Book.Author,
                    Description = m.Book.Description,
                    ImageUrl = m.Book.ImageUrl,
                    Rating = m.Book.Rating,
                    CategoryId = m.Book.CategoryId,
                    Category = m.Book.Category,
                })
                .ToList();
        }

        public async Task AddBookToCollectionAsync(int bookId, string userId)
        {
            LibraryUser user = await context.Users
                .Where(u => u.Id.ToString() == userId)
                .Include(u => u.LibraryUsersBooks)
                .FirstOrDefaultAsync();

            Book book = await context.Books
                .FirstOrDefaultAsync(u => u.Id == bookId);
            if (!user.LibraryUsersBooks.Any(m => m.BookId == bookId))
            {
                user.LibraryUsersBooks.Add(new LibraryUserBook
                {
                    LibraryUserId = user.Id,
                    LibraryUser = user,
                    BookId = book.Id,
                    Book = book
                });

                await context.SaveChangesAsync();
            }
        }

        public async Task RemoveBookFromCollectionAsync(int bookId, string userId)
        {
            LibraryUser user = await context.Users
                .Where(u => u.Id.ToString() == userId)
                .Include(u => u.LibraryUsersBooks)
                .FirstOrDefaultAsync();

            LibraryUserBook book = await context.LibraryUsersBooks
                .FirstOrDefaultAsync(u => u.BookId == bookId);
            user.LibraryUsersBooks.Remove(book);

            await this.context.SaveChangesAsync();
        }
    }
}
