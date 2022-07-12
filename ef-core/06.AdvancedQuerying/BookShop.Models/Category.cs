using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using BookShop.Models.Common;

namespace BookShop.Models
{
    public class Category
    {
        public Category()
        {
            this.CategoryBooks = new HashSet<BookCategory>();
        }

        [Key]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(ValidationConstants.MaxCategoryNameLength)]
        public string Name { get; set; }

        public ICollection<BookCategory> CategoryBooks { get; set; }
    }
}
