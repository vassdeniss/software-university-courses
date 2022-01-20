using System;
using System.Collections.Generic;

namespace L05.CitiesContinentCountry
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> continents
                = new Dictionary<string, Dictionary<string, List<string>>>();

            int qty = int.Parse(Console.ReadLine());
            for (int i = 0; i < qty; i++)
            {
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string continent = data[0];
                string country = data[1];
                string city = data[2];

                if (!continents.ContainsKey(continent)) 
                    continents.Add(continent, new Dictionary<string, List<string>>());
                if (!continents[continent].ContainsKey(country))
                    continents[continent][country] = new List<string>();

                continents[continent][country].Add(city);
            }

            foreach (KeyValuePair<string, Dictionary<string, List<string>>> continent in continents)
            {
                Console.WriteLine($"{continent.Key}:");
                foreach (KeyValuePair<string, List<string>> country in continent.Value)
                {
                    Console.WriteLine($"{country.Key} -> {string.Join(", ", country.Value)}");
                }
            }
        }
    }
}
