using System;
using System.Linq;

namespace E03.ZigZagArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] arrayOne = new int[n];
            int[] arrayTwo = new int[n];

            for (int i = 0; i < n; i++)
            {
                int[] numbersArray = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if (i % 2 == 0)
                {
                    arrayOne[i] = numbersArray[0];
                    arrayTwo[i] = numbersArray[1];
                }
                else
                {
                    arrayOne[i] = numbersArray[1];
                    arrayTwo[i] = numbersArray[0];
                }
            }

            foreach (int i in arrayOne)
            {
                Console.Write($"{i} ");
            }

            Console.WriteLine();

            foreach (int i in arrayTwo)
            {
                Console.Write($"{i} ");
            }
        }
    }
}
