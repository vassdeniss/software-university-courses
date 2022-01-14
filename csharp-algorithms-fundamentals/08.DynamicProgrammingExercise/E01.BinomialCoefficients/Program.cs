using System;
using System.Collections.Generic;

namespace E01.BinomialCoefficients
{
    internal class Program
    {
        private static Dictionary<string, long> Cache;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            Cache = new Dictionary<string, long>();
            Console.WriteLine(Binom(n, k));
        }

        private static long Binom(int row, int col)
        {
            if (col == 0 || col == row) return 1;

            string key = $"{row}, {col}";
            if (Cache.ContainsKey(key)) return Cache[key];

            long result = Binom(row - 1, col) + Binom(row - 1, col - 1);
            Cache.Add(key, result);

            return result;
        }
    }
}
