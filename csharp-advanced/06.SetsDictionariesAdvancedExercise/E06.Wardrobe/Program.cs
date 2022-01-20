using System;
using System.Collections.Generic;

namespace E06.Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> wardrobe 
                = new Dictionary<string, Dictionary<string, int>>();

            int qty = int.Parse(Console.ReadLine());
            for (int i = 0; i < qty; i++)
            {
                string[] color = Console.ReadLine().Split(" -> ");
                if (!wardrobe.ContainsKey(color[0])) wardrobe.Add(color[0], new Dictionary<string, int>());

                string[] clothes = color[1].Split(",");
                foreach (string piece in clothes)
                {
                    if (!wardrobe[color[0]].ContainsKey(piece)) wardrobe[color[0]].Add(piece, 0);
                    wardrobe[color[0]][piece]++;
                }
            }

            string[] find = Console.ReadLine().Split();
            string searchColor = find[0];
            string searchPiece = find[1];

            foreach (KeyValuePair<string, Dictionary<string, int>> kvp in wardrobe)
            {
                Console.WriteLine($"{kvp.Key} clothes:");
                foreach (KeyValuePair<string, int> innerKvp in kvp.Value)
                {
                    if (kvp.Key == searchColor && innerKvp.Key == searchPiece)
                        Console.WriteLine($"* {innerKvp.Key} - {innerKvp.Value} (found!)");
                    else
                        Console.WriteLine($"* {innerKvp.Key} - {innerKvp.Value}");
                }
            }
        }
    }
}
