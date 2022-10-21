using Watchlist.Data.Models;

namespace Watchlist.Services.Models
{
    public class ServiceMovieViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Director { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public decimal Rating { get; set; }

        public int GenreId { get; set; }

        public Genre Genre { get; set; } = null!;
    }
}
