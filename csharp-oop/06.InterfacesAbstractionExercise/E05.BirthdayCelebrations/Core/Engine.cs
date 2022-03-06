using E05.BirthdayCelebrations.Contracts;
using E05.BirthdayCelebrations.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace E05.BirthdayCelebrations.Core
{
    public class Engine : IRunnable
    {
        private readonly IList<string> birthdates;

        public Engine()
        {
            birthdates = new List<string>();
        }

        public void Run()
        {
            GetBirthdates();
            PrintBirthdates();
        }

        private void PrintBirthdates()
        {
            string year = Console.ReadLine();
            string[] dates = birthdates.Where(x => x.EndsWith(year)).ToArray();
            foreach (string birthdate in dates)
            {
                Console.WriteLine(birthdate);
            }
        }

        private void GetBirthdates()
        {
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] data = input.Split();
                ILiving livingCreature = data[0] switch
                {
                    "Citizen" => new Citizen(data[1], data[2], data[3], data[4]),
                    "Pet" => new Pet(data[1], data[2]),
                    _ => null
                };

                if (livingCreature != null) birthdates.Add(livingCreature.Birthdate);
                input = Console.ReadLine();
            }
        }
    }
}
