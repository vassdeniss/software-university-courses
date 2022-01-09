using System;
using System.Linq;

namespace E06.EqualSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputArray = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < inputArray.Length; i++)
            {
                int leftSum = 0;
                for (int k = i - 1; k >= 0; k--)
                {
                    leftSum += inputArray[k];
                }

                int rightSum = 0;
                for (int j = i + 1; j < inputArray.Length; j++)
                {
                    rightSum += inputArray[j];
                }

                if (leftSum == rightSum)
                {
                    Console.WriteLine(i);
                    return;
                }
            }
            Console.WriteLine("no");
        }
    }
}
