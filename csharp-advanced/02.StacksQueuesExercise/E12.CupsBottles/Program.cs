using System;
using System.Collections.Generic;
using System.Linq;

namespace E12.CupsBottles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] cupsArr = Console.ReadLine()
                .Split().Select(int.Parse).ToArray();
            int[] bottlesArr = Console.ReadLine()
                .Split().Select(int.Parse).ToArray();

            Queue<int> cups = new Queue<int>(cupsArr);
            Stack<int> bottles = new Stack<int>(bottlesArr);

            int waste = 0;
            while (cups.Count > 0 && bottles.Count > 0)
            {
                int bottle = bottles.Pop();
                int cup = cups.Dequeue();

                if (bottle - cup >= 0)
                {
                    waste += bottle - cup;
                    continue;
                }

                cup -= bottle;
                while (bottles.Count > 0)
                {
                    int newBottle = bottles.Pop();
                    if (newBottle - cup >= 0)
                    {
                        waste += newBottle - cup;
                        break;
                    }

                    cup -= newBottle;
                }
            }

            if (cups.Count <= 0) Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            else Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            Console.WriteLine($"Wasted litters of water: {waste}");
        }
    }
}
