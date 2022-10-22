using System.ComponentModel.DataAnnotations;

using static Library.Data.DataConstraints.BookConstraints;

namespace Library.Models
{
    public class AddBookViewModel
    {
        public AddBookViewModel()
        {
            this.Categories = new List<CategoryViewModel>();
        }

        [Required]
        [StringLength(MaxTitleLength, MinimumLength = MinTitleLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(MaxAuthorLength, MinimumLength = MinAuthorLength)]
        public string Author { get; set; } = null!;

        [Required]
        [StringLength(MaxDescriptionLength, MinimumLength = MinDescriptionLength)]
        public string Description { get; set; } = null!;

        [Required]
        [StringLength(MaxUrlLength)]
        [Url]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Range(typeof(decimal), MinRatingLength, MaxRatingLength)]
        public decimal Rating { get; set; }

        public int CategoryId { get; set; }

        public ICollection<CategoryViewModel> Categories { get; set; }
    }
}
