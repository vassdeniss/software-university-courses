using System;
using System.Linq;

namespace E09.MagicSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int magicNumber = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputArray.Length; i++)
            {
                for (int j = i + 1; j < inputArray.Length; j++)
                {
                    if (inputArray[i] + inputArray[j] == magicNumber)
                    {
                        Console.Write($"{inputArray[i]} {inputArray[j]}\n");
                    }
                }
            }
        }
    }
}
