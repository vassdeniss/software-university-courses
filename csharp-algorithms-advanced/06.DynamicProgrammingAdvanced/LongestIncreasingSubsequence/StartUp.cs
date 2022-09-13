using System;
using System.Collections.Generic;
using System.Linq;

namespace LongestIncreasingSubsequence
{
    public class StartUp
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] len = new int[numbers.Length];
            int[] prev = new int[numbers.Length];

            int bestLen = 0;
            int lastIndex = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                prev[i] = -1;

                int currentNumber = numbers[i];
                int currentBestSequence = 1;

                for (int j = i - 1; j >= 0; j--)
                {
                    int previousNumber = numbers[j];
                    if (previousNumber < currentNumber
                        && len[j] + 1 >= currentBestSequence)
                    {
                        currentBestSequence = len[j] + 1;
                        prev[i] = j;
                    }
                }

                if (currentBestSequence > bestLen)
                {
                    bestLen = currentBestSequence;
                    lastIndex = i;
                }

                len[i] = currentBestSequence;
            }

            Stack<int> result = new Stack<int>();
            while (lastIndex != -1)
            {
                result.Push(numbers[lastIndex]);
                lastIndex = prev[lastIndex];
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
