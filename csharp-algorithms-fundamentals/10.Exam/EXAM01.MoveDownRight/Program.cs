using System;
using System.Collections.Generic;

namespace EXAM01.MoveDownRight
{
    internal class Program
    {
        private static Dictionary<string, long> Cache;

        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            Cache = new Dictionary<string, long>();
            Console.WriteLine(Paths(rows, cols));
        }

        static long Paths(int m, int n)
        {
            if (m == 1 || n == 1) return 1;

            string key = $"{m}, {n}";
            if (Cache.ContainsKey(key)) return Cache[key];

            long result = Paths(m - 1, n) + Paths(m, n - 1);
            Cache.Add(key, result);

            return result;
        }
    }
}
