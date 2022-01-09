using System;

namespace ME03.RecurviseFibonacci
{
    class Program
    {
        public static int getFibonacciRecursion(int n)
        {
            if (n == 0 || n == 1)
                return n;
            else
                return getFibonacciRecursion(n - 1) + getFibonacciRecursion(n - 2);
        }

        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            Console.WriteLine(getFibonacciRecursion(input));
        }
    }
}
