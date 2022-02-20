using System;
using System.Collections.Generic;
using System.Linq;

namespace EXAM01.BakeryShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> products = new Dictionary<string, int>();

            double[] waterArray = Console.ReadLine().Split().Select(double.Parse).ToArray();
            double[] flourArray = Console.ReadLine().Split().Select(double.Parse).ToArray();

            Queue<double> water = new Queue<double>(waterArray);
            Stack<double> flour = new Stack<double>(flourArray);

            while (water.Count > 0 && flour.Count > 0)
            {
                double currWater = water.Dequeue();
                double currFlour = flour.Pop();

                double waterPercent = GetWaterPercent(currWater, currFlour);
                switch (waterPercent)
                {
                    case 50:
                        if (!products.ContainsKey("Croissant"))
                        {
                            products.Add("Croissant", 1);
                        }
                        else products["Croissant"]++;
                        break;
                    case 40:
                        if (!products.ContainsKey("Muffin"))
                        {
                            products.Add("Muffin", 1);
                        }
                        else products["Muffin"]++;
                        break;
                    case 30:
                        if (!products.ContainsKey("Baguette"))
                        {
                            products.Add("Baguette", 1);
                        }
                        else products["Baguette"]++;
                        break;
                    case 20:
                        if (!products.ContainsKey("Bagel"))
                        {
                            products.Add("Bagel", 1);
                        }
                        else products["Bagel"]++;
                        break;
                    default:
                        double flourLeft = currFlour - currWater;
                        flour.Push(flourLeft);
                        if (!products.ContainsKey("Croissant"))
                        {
                            products.Add("Croissant", 1);
                        }
                        else products["Croissant"]++;
                        break;
                }
            }

            foreach (KeyValuePair<string, int> product in
                products.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{product.Key}: {product.Value}");
            }
            
            Console.WriteLine(water.Any()
                ? $"Water left: {string.Join(", ", water)}"
                : "Water left: None");

            Console.WriteLine(flour.Any()
                ? $"Flour left: {string.Join(", ", flour)}"
                : "Flour left: None");
        }

        private static double GetWaterPercent(double x, double y) => x * 100 / (x + y);
    }
}
