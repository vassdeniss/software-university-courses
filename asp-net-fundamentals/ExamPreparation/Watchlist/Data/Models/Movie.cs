using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

using static Watchlist.Data.Models.DataConstraints.MovieConstraints;

namespace Watchlist.Data.Models
{
    public class Movie
    {
        public Movie()
        {
            this.UsersMovies = new HashSet<UserMovie>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxTitleLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(MaxDirectorLength)]
        public string Director { get; set; } = null!;

        public string? ImageUrl { get; set; }

        [Required]
        [Precision(4, 2)]
        public decimal Rating { get; set; }

        [Required]
        [ForeignKey(nameof(Genre))]
        public int GenreId { get; set; }

        public virtual Genre Genre { get; set; } = null!;

        public virtual ICollection<UserMovie> UsersMovies { get; set; }
    }
}
