using System;

namespace E10.Pokemon
{
    class Program
    {
        static void Main(string[] args)
        {
            int pokePower = int.Parse(Console.ReadLine());
            int distance = int.Parse(Console.ReadLine());
            int exhaustionFactor = int.Parse(Console.ReadLine());

            int pokeCount = 0;
            int fiftyPercentPower = (int)(pokePower * 0.5);

            while (pokePower >= distance)
            {
                pokePower -= distance;
                pokeCount++;

                if (pokePower == fiftyPercentPower && exhaustionFactor > 0)
                {
                    pokePower /= exhaustionFactor;
                }
            }

            Console.WriteLine($"{pokePower}\n{pokeCount}");
        }
    }
}
