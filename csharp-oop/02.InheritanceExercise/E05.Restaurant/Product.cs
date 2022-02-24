namespace Restaurant
{
    public class Product
    {
        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; protected set; }
        public decimal Price { get; protected set; }
    }
}
