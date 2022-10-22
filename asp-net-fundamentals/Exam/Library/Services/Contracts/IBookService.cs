using Library.Services.Models;

namespace Library.Services.Contracts
{
    public interface IBookService
    {
        Task<ICollection<ServiceCategoryViewModel>> GetCategoriesAsync();
        
        Task AddBookAsync(string title,
            string description,
            string author,
            string imageUrl,
            decimal rating,
            int categoryId);

        Task<ICollection<ServiceBookViewModel>> GetBooksAsync();

        Task<ICollection<ServiceBookViewModel>> GetUserBooksAsync(string userId);

        Task AddBookToCollectionAsync(int bookId, string userId);

        Task RemoveBookFromCollectionAsync(int bookId, string userId);
    }
}
