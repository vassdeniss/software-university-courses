using System;
using System.Numerics;

namespace L02.BigFactorial
{
    class Program
    {
        static BigInteger Factorial(int n)
        {
            BigInteger factorial = 1;
            for (int i = 1; i <= n; i++) factorial *= i;
            return factorial;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(Factorial(int.Parse(Console.ReadLine())));
        }
    }
}
