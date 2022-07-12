using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using BookShop.Models.Common;
using BookShop.Models.Enums;

namespace BookShop.Models
{
    public class Book
    {
        public Book()
        {
            this.BookCategories = new HashSet<BookCategory>();
        }

        [Key]
        public int BookId { get; set; }

        [Required]
        [MaxLength(ValidationConstants.MaxBookTitleLength)]
        public string Title { get; set; }

        [Required]
        [MaxLength(ValidationConstants.MaxBookDescriptionLength)]
        public string Description { get; set; }

        public EditionType EditionType { get; set; }

        public decimal Price { get; set; }

        public int Copies { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public AgeRestriction AgeRestriction { get; set; }

        [ForeignKey(nameof(Author))]
        public int AuthorId { get; set; }

        public Author Author { get; set; }

        public ICollection<BookCategory> BookCategories { get; set; }
    }
}
