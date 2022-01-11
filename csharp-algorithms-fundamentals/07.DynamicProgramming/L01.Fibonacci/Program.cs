using System;
using System.Collections.Generic;

namespace L01.Fibonacci
{
    internal class Program
    {
        private static Dictionary<int, long> Cache = new Dictionary<int, long>();

        static void Main(string[] args)
        {
            Console.WriteLine(Fibonacci(int.Parse(Console.ReadLine())));
        }

        private static long Fibonacci(int n)
        {
            if (Cache.ContainsKey(n)) return Cache[n];
            if (n < 2) return n;

            long result = Fibonacci(n - 1) + Fibonacci(n - 2);
            Cache.Add(n, result);

            return result;
        }
    }
}
