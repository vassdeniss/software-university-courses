using System;
using System.Collections.Generic;

namespace LongestStringChain
{
    public class StartUp
    {
        public static void Main()
        {
            string[] strings = Console.ReadLine()
                .Split();

            int[] len = new int[strings.Length];
            int[] prev = new int[strings.Length];

            int bestLen = 0;
            int lastIndex = 0;
            for (int i = 0; i < strings.Length; i++)
            {
                prev[i] = -1;

                int currentLength = strings[i].Length;
                int currentBestSequence = 1;

                for (int j = i - 1; j >= 0; j--)
                {
                    int previousLength = strings[j].Length;
                    if (previousLength < currentLength
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

            Stack<string> result = new Stack<string>();
            while (lastIndex != -1)
            {
                result.Push(strings[lastIndex]);
                lastIndex = prev[lastIndex];
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
