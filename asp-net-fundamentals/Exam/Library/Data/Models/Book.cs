using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

using static Library.Data.DataConstraints.BookConstraints;

namespace Library.Data.Models
{
    public class Book
    {
        public Book()
        {
            this.LibraryUsersBooks = new HashSet<LibraryUserBook>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxTitleLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(MaxAuthorLength)]
        public string Author { get; set; } = null!;

        [Required]
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; } = null!;

        [Required]
        [Unicode(false)]
        [MaxLength(MaxUrlLength)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Precision(RatingPrecision, RatingScale)]
        public decimal Rating { get; set; }

        [Required]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; } = null!;

        public virtual ICollection<LibraryUserBook> LibraryUsersBooks { get; set; }
    }
}
