using System;
using System.Linq;

namespace ME05.LongestIncreasingSubsequences
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] len = new int[inputArray.Length];
            int[] prev = new int[inputArray.Length];
            int prevIndex = -1;
            int maxLength = 0;

            for (int i = 0; i < inputArray.Length; i++)
            {
                len[i] = 1;
                prev[i] = -1;

                for (int j = 0; j < i; j++)
                {
                    if (inputArray[j] < inputArray[i] && len[j] + 1 > len[i])
                    {
                        len[i] = len[j] + 1;
                        prev[i] = j;
                    }
                }

                if (len[i] > maxLength)
                {
                    maxLength = len[i];
                    prevIndex = i;
                }
            }

            int[] lis = new int[maxLength];

            for (int i = 0; i < maxLength; i++)
            {
                lis[i] = inputArray[prevIndex];
                prevIndex = prev[prevIndex];
            }

            Array.Reverse(lis);

            Console.WriteLine(string.Join(" ", lis));
        }
    }
}
