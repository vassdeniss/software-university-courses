using System;
using System.Linq;

namespace E05.TopIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputArray = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < inputArray.Length; i++)
            {
                bool isBigger = true;

                for (int j = i + 1; j < inputArray.Length; j++)
                {
                    if (inputArray[i] <= inputArray[j])
                    {
                        isBigger = false;
                    }
                }

                if (isBigger) Console.Write($"{inputArray[i]} ");
            }
        }
    }
}
