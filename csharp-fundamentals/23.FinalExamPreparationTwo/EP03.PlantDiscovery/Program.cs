using System;
using System.Collections.Generic;
using System.Linq;

namespace EP03.PlantDiscovery
{
    class Plant
    {
        public Plant(string name, int rarity)
        {
            Name = name;
            Rarity = rarity;
            Ratings = new List<int>();
        }

        public string Name { get; set; }
        public int Rarity { get; set; }
        public List<int> Ratings { get; set; }

        private double _avgRating = 0;
        public double CalcAvgRating()
        {
            if (Ratings.Count > 0) _avgRating = Ratings.Average();
            return _avgRating;
        }

        public override string ToString()
        {
            return $"- {Name}; Rarity: {Rarity}; Rating: {CalcAvgRating():f2}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Plant> plants = new List<Plant>();

            int plantCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < plantCount; i++)
            {
                string[] info = Console.ReadLine().Split("<->");

                string name = info[0];
                int rarity = int.Parse(info[1]);
                Plant newPlant = new Plant(name, rarity);

                if (plants.Contains(newPlant)) plants.Find(x => x.Name == newPlant.Name).Rarity = rarity;
                else plants.Add(newPlant);
            }

            string input = Console.ReadLine();
            while (input != "Exhibition")
            {
                string[] cmd = input.Split(new[] { ": ", " - " }, StringSplitOptions.None);

                string plant = cmd[1];
                bool isValid = plants.Exists(x => x.Name == plant);

                if (!isValid)
                {
                    Console.WriteLine("error");
                    input = Console.ReadLine(); continue;
                }

                Plant editPlant = plants.Find(x => x.Name == plant);

                if (cmd[0] == "Rate") editPlant.Ratings.Add(int.Parse(cmd[2]));
                else if (cmd[0] == "Update") editPlant.Rarity = int.Parse(cmd[2]);
                else if (cmd[0] == "Reset") editPlant.Ratings.Clear();

                input = Console.ReadLine();
            }

            Console.WriteLine("Plants for the exhibition:");
            plants = plants.OrderByDescending(x => x.Rarity).ThenByDescending(x => x.CalcAvgRating()).ToList();
            plants.ForEach(Console.WriteLine);
        }
    }
}
