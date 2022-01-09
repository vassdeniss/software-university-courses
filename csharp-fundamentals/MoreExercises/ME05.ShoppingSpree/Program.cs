using System;
using System.Collections.Generic;
using System.Linq;

namespace ME05.ShoppingSpree
{
    class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    class Person
    {
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public List<Product> Products { get; set; }

        public Person()
        {
            Products = new List<Product>();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Person> customerList = RegisterCustomer();
            List<Product> productList = RegisterProducts();

            string[] cmd = Console.ReadLine().Split();
            while (cmd[0] != "END")
            {
                Person person = customerList.Find(person => person.Name == cmd[0]);
                Product product = productList.Find(product => product.Name == cmd[1]);
                int personIndex = customerList.IndexOf(person);

                if (person.Balance >= product.Price)
                {
                    person.Balance -= product.Price;
                    person.Products.Add(product);
                    customerList[personIndex] = person;
                    Console.WriteLine($"{person.Name} bought {product.Name}");
                }
                else
                {
                    Console.WriteLine($"{person.Name} can't afford {product.Name}");
                }

                cmd = Console.ReadLine().Split();
            }

            Print(customerList);
        }

        static void Print(List<Person> list)
        {
            foreach (Person person in list)
            {
                if (person.Products.Count > 0)
                {
                    List<string> allProducts = new List<string>();
                    foreach (Product product in person.Products) allProducts.Add(product.Name);
                    Console.WriteLine($"{person.Name} - {string.Join(", ", allProducts)}");
                }
                else if (person.Products.Count <= 0)
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
            }
        }

        static List<Person> RegisterCustomer()
        {
            List<Person> list = new List<Person>();
            List<string> data = Console.ReadLine().Split(new char[] { ';', '=' }).ToList();

            for (int i = 0; i < data.Count - 1; i += 2)
            {
                list.Add(new Person()
                {
                    Name = data[i],
                    Balance = decimal.Parse(data[i + 1])
                });
            }

            return list;
        }

        static List<Product> RegisterProducts()
        {
            List<Product> list = new List<Product>();
            List<string> data = Console.ReadLine().Split(new char[] { ';', '=' }).ToList();

            for (int i = 0; i < data.Count - 1; i += 2)
            {
                list.Add(new Product()
                {
                    Name = data[i],
                    Price = decimal.Parse(data[i + 1])
                });
            }

            return list;
        }
    }
}
