using System.ComponentModel.DataAnnotations;

using Watchlist.Data.Models;

using static Watchlist.Data.Models.DataConstraints.MovieConstraints;

namespace Watchlist.Models
{
    public class AddMovieViewModel
    {
        public AddMovieViewModel()
        {
            this.Genres = new List<GenreViewModel>();
        }

        [Required]
        [StringLength(MaxTitleLength, MinimumLength = MinTitleLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(MaxDirectorLength, MinimumLength = MinDirectorLength)]
        public string Director { get; set; } = null!;

        public string? ImageUrl { get; set; }

        [Required]
        [Range(typeof(decimal), MinRatingLength, MaxRatingLength)]
        public decimal Rating { get; set; }

        public int GenreId { get; set; }

        public ICollection<GenreViewModel> Genres { get; set; }
    }
}
