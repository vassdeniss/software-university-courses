using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using BookShop.Models.Common;

#nullable enable

namespace BookShop.Models
{
    public class Author
    {
        public Author()
        {
            this.Books = new HashSet<Book>();
        }

        [Key]
        public int AuthorId { get; set; }

        [MaxLength(ValidationConstants.MaxAuthorFirstNameLength)]
        public string? FirstName { get; set; }

        [Required]
        [MaxLength(ValidationConstants.MaxAuthorLastNameLength)]
        public string LastName { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
