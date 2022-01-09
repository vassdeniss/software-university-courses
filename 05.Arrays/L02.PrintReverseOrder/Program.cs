using System;

namespace L02.PrintReverseOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] numberArray = new int[n];

            for (int i = 0; i < n; i++)
            {
                numberArray[i] = int.Parse(Console.ReadLine());
            }

            Array.Reverse(numberArray);

            foreach (int i in numberArray)
            {
                Console.Write($"{i} ");
            }
        }
    }
}
