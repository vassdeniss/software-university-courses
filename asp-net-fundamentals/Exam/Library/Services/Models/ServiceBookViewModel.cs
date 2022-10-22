using Library.Data.Models;

namespace Library.Services.Models
{
    public class ServiceBookViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Author { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public decimal Rating { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; } = null!;
    }
}
