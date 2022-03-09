using E03.Raiding.Contracts;
using E03.Raiding.Models.Heroes;
using System;

namespace E03.Raiding.Factories
{
    public static class HeroFactory
    {
        public static IHero CreateHero()
        {
            string name = Console.ReadLine();
            string type = Console.ReadLine();

            IHero hero = type switch
            {
                "Druid" => new Druid(name),
                "Paladin" => new Paladin(name),
                "Rogue" => new Rogue(name),
                "Warrior" => new Warrior(name),
                _ => throw new ArgumentException("Invalid hero!"),
            };

            return hero;
        }
    }
}
