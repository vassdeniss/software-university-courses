using System;

namespace E01.SmallestThreeNumbers
{
    class Program
    {
        static void MinNumber(int a, int b, int c)
        {
            Console.WriteLine(Math.Min(a, Math.Min(b, c)));
        }

        static void Main(string[] args)
        {
            int numOne = int.Parse(Console.ReadLine());
            int numTwo = int.Parse(Console.ReadLine());
            int numThree = int.Parse(Console.ReadLine());
            MinNumber(numOne, numTwo, numThree);
        }
    }
}
