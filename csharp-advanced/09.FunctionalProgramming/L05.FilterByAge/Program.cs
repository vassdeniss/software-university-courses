using System;
using System.Collections.Generic;
using System.Linq;

namespace L05.FilterByAge
{
    class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            int qty = int.Parse(Console.ReadLine());
            for (int i = 0; i < qty; i++)
            {
                string[] data = Console.ReadLine().Split(", ");
                people.Add(new Person(data[0], int.Parse(data[1])));
            }

            string filterInput = Console.ReadLine();
            int ageInput = int.Parse(Console.ReadLine());
            string formatInput = Console.ReadLine();

            Func<Person, int, bool> filter = GetFilter(filterInput);
            Action<Person> printer = GetPrinter(formatInput);

            people = people.Where(x => filter(x, ageInput)).ToList();
            people.ForEach(printer);
        }

        private static Action<Person> GetPrinter(string formatInput)
        {
            return formatInput switch
            {
                "name" => x => Console.WriteLine(x.Name),
                "age" => x => Console.WriteLine(x.Age),
                "name age" => x => Console.WriteLine($"{x.Name} - {x.Age}"),
                _ => null
            };
        }

        private static Func<Person, int, bool> GetFilter(string inputFilter)
        {
            return inputFilter switch
            {
                "younger" => (p, a) => p.Age < a,
                "older" => (p, a) => p.Age > a,
                _ => null
            };
        }
    }
}
