using System.Security.Claims;

using Watchlist.Services.Models;

namespace Watchlist.Services.Contracts
{
    public interface IMovieService
    {
        Task<ICollection<ServiceMovieViewModel>> GetMoviesAsync();

        Task<ICollection<ServiceGenreViewModel>> GetGenresAsync();

        Task AddMovieAsync(string title, string director, string imageUrl, decimal rating, int genreId);

        Task<ICollection<ServiceMovieViewModel>> GetUserMoviesAsync(string userId);

        Task AddMovieToCollectionAsync(int movieId, string userId);

        Task RemoveMovieFromCollectionAsync(int movieId, string userId);
    }
}
