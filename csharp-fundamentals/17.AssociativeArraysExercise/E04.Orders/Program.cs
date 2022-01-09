using System;
using System.Collections.Generic;

namespace E04.Orders
{
    class Product
    {
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Product> productDictionary = new Dictionary<string, Product>();

            string[] input = Console.ReadLine().Split();
            while (input[0] != "buy")
            {
                string product = input[0];
                decimal price = decimal.Parse(input[1]);
                int qty = int.Parse(input[2]);
                
                if (productDictionary.ContainsKey(product))
                {
                    Product currProduct = productDictionary[product];
                    currProduct.Quantity += qty;
                    if (price != currProduct.Price) currProduct.Price = price;
                }
                else
                {
                    productDictionary.Add(product, new Product()
                    {
                        Price = price, Quantity = qty
                    });
                }

                input = Console.ReadLine().Split();
            }

            foreach (KeyValuePair<string, Product> pair in productDictionary)
            {
                decimal totalPrice = pair.Value.Price * pair.Value.Quantity;
                Console.WriteLine($"{pair.Key} -> {totalPrice:f2}");
            }
        }
    }
}
