using System;

namespace E08.FactorialDivision
{
    class Program
    {
        static double Factorial(double n)
        {
            for (double i = n - 1; i >= 1; i--) { n *= i; }
            return n;
        }

        static void Main(string[] args)
        {
            int firstInt = int.Parse(Console.ReadLine());
            int secondInt = int.Parse(Console.ReadLine());
            double result = Factorial(firstInt) / Factorial(secondInt);
            Console.WriteLine($"{result:f2}");
        }
    }
}
