using System;
using System.Linq;

namespace L06.EvenOddSubtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            int sumEven = 0, sumOdd = 0;
            int[] intArray = Console.ReadLine().Split().Select(int.Parse).ToArray();

            foreach (int i in intArray)
            {
                if (i % 2 == 0)
                {
                    sumEven += i;
                }
                else
                {
                    sumOdd += i;
                }
            }

            Console.WriteLine($"{sumEven - sumOdd}");
        }
    }
}
