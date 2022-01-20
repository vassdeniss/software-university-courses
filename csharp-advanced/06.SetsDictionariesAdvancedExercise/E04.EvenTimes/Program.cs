using System;
using System.Collections.Generic;
using System.Linq;

namespace E04.EvenTimes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> seen = new Dictionary<int, int>();

            int qty = int.Parse(Console.ReadLine());
            for (int i = 0; i < qty; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (!seen.ContainsKey(num)) seen.Add(num, 0);
                seen[num]++;
            }

            Console.WriteLine(seen.First(x => x.Value % 2 == 0).Key);
        }
    }
}
