using System;
using System.Collections.Generic;

namespace E03.PeriodicTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedSet<string> elements = new SortedSet<string>();

            int qty = int.Parse(Console.ReadLine());
            for (int i = 0; i < qty; i++)
            {
                string[] chemicals = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                foreach (string chemical in chemicals) elements.Add(chemical);
            }

            Console.WriteLine(string.Join(" ", elements));
        }
    }
}
