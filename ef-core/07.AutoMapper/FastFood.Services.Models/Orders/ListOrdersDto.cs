namespace FastFood.Services.Models.Orders
{
    public class ListOrdersDto
    {
        public int OrderId { get; set; }

        public string? Customer { get; set; }

        public string? Employee { get; set; }
                     
        public string? DateTime { get; set; }
    }
}
