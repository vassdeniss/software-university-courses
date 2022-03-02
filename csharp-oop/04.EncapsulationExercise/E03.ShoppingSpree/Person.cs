using System;
using System.Collections.Generic;
using System.Linq;

namespace E03.ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;

        private Person()
        {
            products = new List<Product>();
        }

        public Person(string name, decimal money) : this()
        {
            Name = name;
            Money = money;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                name = value;
            }
        }

        public decimal Money
        {
            get => money;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                money = value;
            }
        }

        public IReadOnlyCollection<Product> Products => products.AsReadOnly();

        public void BuyProduct(Product product)
        {
            if (product.Cost > money)
            {
                Console.WriteLine($"{name} can't afford {product.Name}");
                return;
            }

            Console.WriteLine($"{name} bought {product.Name}");
            products.Add(product);
            money -= product.Cost;
        }

        public override string ToString()
        {
            if (!products.Any())
            {
                return $"{name} - Nothing bought";
            }
            else
            {
                return $"{name} - {string.Join(", ", products.Select(x => x.Name))}";
            }
        }
    }
}
