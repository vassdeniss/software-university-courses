using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace EP02.AdAstra
{
    class Food
    {
        public Food(string name, string expirationDate, int calories)
        {
            Name = name;
            ExpirationDate = expirationDate;
            Calories = calories;
        }

        public string Name { get; set; }
        public string ExpirationDate { get; set; }
        public int Calories { get; set; }

        public override string ToString()
        {
            return $"Item: {Name}, Best before: {ExpirationDate}, Nutrition: {Calories}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Regex extractor = new Regex(@"(?<symbol>[|#])(?<name>[A-Za-z\s]+)\k<symbol>(?<expire>\d{2}\/\d{2}\/\d{2})\k<symbol>(?<calories>\d+)\k<symbol>");
            string input = Console.ReadLine();

            List<Food> foodItems = new List<Food>();
            MatchCollection matches = extractor.Matches(input);
            foreach (Match match in matches)
            {
                foodItems.Add(
                    new Food(
                        match.Groups["name"].Value,
                        match.Groups["expire"].Value,
                        int.Parse(match.Groups["calories"].Value)
                    )
                );
            }

            int totalCalories = 0;
            foodItems.ForEach(x => totalCalories += x.Calories);
            Console.WriteLine($"You have food to last you for: {totalCalories / 2000} days!");
            foodItems.ForEach(Console.WriteLine);
        }
    }
}
