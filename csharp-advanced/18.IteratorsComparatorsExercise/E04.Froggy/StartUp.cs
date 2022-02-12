using System;
using System.Collections.Generic;
using System.Linq;

namespace E04.Froggy
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split(", ").Select(int.Parse).ToList();

            Lake lake = new Lake(list);
            Console.WriteLine($"{string.Join(", ", lake)}");
        }
    }
}
