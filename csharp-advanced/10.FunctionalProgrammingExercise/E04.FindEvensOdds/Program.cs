using System;
using System.Linq;

namespace E04.FindEvensOdds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] bounds = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string type = Console.ReadLine();

            Action<int> print = x => Console.Write($"{x} ");
            Predicate<int> checker = GetPredicate(type);
            for (int i = bounds[0]; i <= bounds[1]; i++)
            {
                if (checker(i)) print(i);
            }
        }

        private static Predicate<int> GetPredicate(string type)
        {
            if (type == "odd") return x => x % 2 != 0;
            else return x => x % 2 == 0;
        }
    }
}
