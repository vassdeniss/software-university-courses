using System;

namespace L07.RecursiveFibonacci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetFibonacci(int.Parse(Console.ReadLine())));
        }

        private static int GetFibonacci(int n)
        {
            if (n <= 1) return 1;
            return GetFibonacci(n - 1) + GetFibonacci(n - 2);
        }
    }
}
