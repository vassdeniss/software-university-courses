using System;
using System.Linq;

namespace L01.SortEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int, bool> evenChecker = x => x % 2 == 0;
            Func<int, int> intOrderer = x => x;

            int[] nums = Console.ReadLine()
                .Split(", ").Select(int.Parse)
                .Where(x => evenChecker(x))
                .OrderBy(x => intOrderer(x)).ToArray();

            Console.WriteLine(string.Join(", ", nums));
        }
    }
}
