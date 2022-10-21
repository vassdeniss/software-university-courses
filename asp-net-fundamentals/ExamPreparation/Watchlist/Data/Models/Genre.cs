using System.ComponentModel.DataAnnotations;

using static Watchlist.Data.Models.DataConstraints.GenreConstraints;

namespace Watchlist.Data.Models
{
    public class Genre
    {
        public Genre()
        {
            Movies = new HashSet<Movie>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxNameLength)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
