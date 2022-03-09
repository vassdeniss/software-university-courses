using E03.Raiding.Contracts;
using E03.Raiding.Factories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace E03.Raiding.Core
{
    public class Engine : IRunnable
    {
        private readonly List<IHero> heroes;

        public Engine()
        {
            heroes = new List<IHero>();
        }

        public void Run()
        {
            int n = int.Parse(Console.ReadLine());
            while (n > 0)
            {
                try
                {
                    heroes.Add(HeroFactory.CreateHero());
                    n--;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            int bossPower = int.Parse(Console.ReadLine());
            int heroesPower = heroes.Sum(x => x.Power);
            heroes.ForEach(x => Console.WriteLine(x.CastAbility()));
            Console.WriteLine(heroesPower >= bossPower ? "Victory!" : "Defeat...");
        }
    }
}
