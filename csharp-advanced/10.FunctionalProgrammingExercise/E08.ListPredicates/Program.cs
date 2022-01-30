using System;
using System.Collections.Generic;
using System.Linq;

namespace E08.ListPredicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int qty = int.Parse(Console.ReadLine());
            List<int> numbers = Enumerable.Range(1, qty).ToList();
            int[] dividers = Console.ReadLine()
                .Split().Select(int.Parse).ToArray();

            List<Predicate<int>> predicates = new List<Predicate<int>>();
            foreach (int n in dividers) predicates.Add(x => x % n == 0);
            foreach (int n in numbers)
            {
                bool isDivisible = true;
                foreach (Predicate<int> pred in predicates)
                {
                    if (!pred(n))
                    {
                        isDivisible = false;
                        break;
                    }
                }

                if (isDivisible) Console.Write($"{n} ");
            }
        }
    }
}
