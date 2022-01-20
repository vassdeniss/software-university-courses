using System;
using System.Collections.Generic;

namespace L04.ProductShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, double>> shops 
                = new SortedDictionary<string, Dictionary<string, double>>();

            string input = Console.ReadLine();
            while (input != "Revision")
            {
                string[] data = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string shop = data[0];
                string product = data[1];
                double price = double.Parse(data[2]);

                if (!shops.ContainsKey(shop)) shops.Add(shop, new Dictionary<string, double>());
                if (!shops[shop].ContainsKey(product)) shops[shop].Add(product, price);
                else shops[shop][product] = price;

                input = Console.ReadLine();
            }

            foreach (KeyValuePair<string, Dictionary<string, double>> supermarket in shops)
            {
                Console.WriteLine($"{supermarket.Key}->");
                foreach (KeyValuePair<string, double> product in supermarket.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
