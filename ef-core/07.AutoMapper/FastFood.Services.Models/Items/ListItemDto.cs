namespace FastFood.Services.Models.Items
{
    public class ListItemDto
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public decimal Price { get; set; }

        public string? CategoryName { get; set; }
    }
}
