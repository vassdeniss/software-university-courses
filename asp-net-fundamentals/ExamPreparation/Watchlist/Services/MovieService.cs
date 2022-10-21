using Microsoft.EntityFrameworkCore;

using Watchlist.Data;
using Watchlist.Data.Models;
using Watchlist.Services.Contracts;
using Watchlist.Services.Models;

namespace Watchlist.Services
{
    public class MovieService : IMovieService
    {
        private readonly WatchlistDbContext context;

        public MovieService(WatchlistDbContext context)
        {
            this.context = context;
        }

        public async Task<ICollection<ServiceMovieViewModel>> GetMoviesAsync()
        {
            return await this.context.Movies
                .Include(m => m.Genre)
                .Select(g => new ServiceMovieViewModel
                {
                    Id = g.Id,
                    Title = g.Title,
                    Director = g.Director,
                    ImageUrl = g.ImageUrl,
                    Rating = g.Rating,
                    GenreId = g.GenreId,
                    Genre = g.Genre
                })
                .ToListAsync(); ;
        }

        public async Task<ICollection<ServiceGenreViewModel>> GetGenresAsync()
        {
            return await this.context.Genres
                .Select(g => new ServiceGenreViewModel
                {
                    Id = g.Id,
                    Name = g.Name
                })
                .ToListAsync();
        }

        public async Task AddMovieAsync(string title,
            string director,
            string imageUrl,
            decimal rating,
            int genreId)
        {
            Movie movie = new Movie
            {
                Title = title,
                Director = director,
                ImageUrl = imageUrl,
                Rating = rating,
                GenreId = genreId
            };

            await this.context.Movies.AddAsync(movie);
            await this.context.SaveChangesAsync();
        }

        public async Task<ICollection<ServiceMovieViewModel>> GetUserMoviesAsync(string userId)
        {
            WatchlistUser user = await context.Users
                .Where(u => u.Id.ToString() == userId)
                .Include(u => u.UsersMovies)
                .ThenInclude(um => um.Movie)
                .ThenInclude(m => m.Genre)
                .FirstOrDefaultAsync();

            return user.UsersMovies
                .Select(m => new ServiceMovieViewModel()
                {
                    Director = m.Movie.Director,
                    Genre = m.Movie.Genre,
                    Id = m.MovieId,
                    ImageUrl = m.Movie.ImageUrl,
                    Title = m.Movie.Title,
                    Rating = m.Movie.Rating,
                })
                .ToList();
        }

        public async Task AddMovieToCollectionAsync(int movieId, string userId)
        {
            WatchlistUser user = await context.Users
                .Where(u => u.Id.ToString() == userId)
                .Include(u => u.UsersMovies)
                .FirstOrDefaultAsync();

            Movie movie = await context.Movies.FirstOrDefaultAsync(u => u.Id == movieId);
            if (!user.UsersMovies.Any(m => m.MovieId == movieId))
            {
                user.UsersMovies.Add(new UserMovie
                {
                    MovieId = movie.Id,
                    UserId = user.Id,
                    Movie = movie,
                    User = user
                });

                await context.SaveChangesAsync();
            }
        }

        public async Task RemoveMovieFromCollectionAsync(int movieId, string userId)
        {
            WatchlistUser user = await context.Users
                .Where(u => u.Id.ToString() == userId)
                .Include(u => u.UsersMovies)
                .FirstOrDefaultAsync();

            UserMovie movie = await context.UsersMovies.FirstOrDefaultAsync(u => u.MovieId == movieId);
            user.UsersMovies.Remove(movie);

            await this.context.SaveChangesAsync();
        }
    }
}
