namespace FastFood.Services.Models.Items
{
    public class CreateItemDto
    {
        public string? Name { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public string? CategoryName { get; set; }
    }
}
