using System;
using System.Collections.Generic;
using System.Linq;

namespace E03.ShoppingSpree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>(); 
            List<Product> products = new List<Product>();

            string[] peopleData = Console.ReadLine().Split(
                new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < peopleData.Length - 1; i += 2)
            {
                try
                {
                    people.Add(new Person(peopleData[i], decimal.Parse(peopleData[i + 1])));
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }

            string[] productsData = Console.ReadLine().Split(
                new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < productsData.Length - 1; i += 2)
            {
                try
                {
                    products.Add(new Product(productsData[i], decimal.Parse(productsData[i + 1])));
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }

            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] tokens = input.Split();
                Person person = people.FirstOrDefault(x => x.Name == tokens[0]);
                Product product = products.FirstOrDefault(x => x.Name == tokens[1]);
                person.BuyProduct(product);
                input = Console.ReadLine();
            }

            people.ForEach(Console.WriteLine);
        }
    }
}
