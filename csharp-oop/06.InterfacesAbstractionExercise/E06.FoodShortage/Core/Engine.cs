using E06.FoodShortage.Contracts;
using E06.FoodShortage.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace E06.FoodShortage.Core
{
    public class Engine : IRunnable
    {
        private readonly IList<IResident> residents;

        public Engine()
        {
            residents = new List<IResident>();
        }

        public void Run()
        {
            GetResidents();
            BuyFood();
            Console.WriteLine(residents.Sum(x => x.Food));
        }

        private void BuyFood()
        {
            string input = Console.ReadLine();
            while (input != "End")
            {
                IResident resident = residents.FirstOrDefault(x => x.Name == input);

                if (resident is null)
                {
                    input = Console.ReadLine();
                    continue;
                }

                resident.BuyFood();
                input = Console.ReadLine();
            }
        }

        private void GetResidents()
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split();
                IResident resident = data.Length switch
                {
                    4 => new Citizen(data[0], data[1], data[2], data[3]),
                    _ => new Rebel(data[0], data[1], data[2])
                };

                residents.Add(resident);
            }
        }
    }
}
