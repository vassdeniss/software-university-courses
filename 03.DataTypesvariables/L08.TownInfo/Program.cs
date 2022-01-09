using System;

namespace L08.TownInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            string townName = Console.ReadLine();
            long population = long.Parse(Console.ReadLine());
            short area = short.Parse(Console.ReadLine());
            Console.WriteLine($"Town {townName} has population of {population} and area {area} square km.");
        }
    }
}
