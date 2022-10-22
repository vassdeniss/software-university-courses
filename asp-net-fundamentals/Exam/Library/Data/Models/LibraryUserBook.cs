using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Data.Models
{
    public class LibraryUserBook
    {
        [Key]
        [ForeignKey(nameof(LibraryUser))]
        public Guid LibraryUserId { get; set; }

        public virtual LibraryUser LibraryUser { get; set; } = null!;

        [Key]
        [ForeignKey(nameof(Book))]
        public int BookId { get; set; }

        public virtual Book Book { get; set; } = null!;
    }
}
