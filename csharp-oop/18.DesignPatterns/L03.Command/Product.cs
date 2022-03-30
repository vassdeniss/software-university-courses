using System;

namespace L03.Command
{
    public class Product
    {
        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; private set; }

        public decimal Price { get; private set; }

        public void IncreasePrice(decimal amount)
        {
            Price += amount;
            Console.WriteLine($"The price of the {Name} has been increased by {amount:f2}.");
        }

        public void DecreasePrice(decimal amount)
        {
            Price -= amount;
            Console.WriteLine($"The price of the {Name} has been decreased by {amount:f2}.");
        }

        public override string ToString() => $"Current price of the {Name} is {Price:f2}.";
    }
}
