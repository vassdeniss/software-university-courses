using System;
using System.Collections.Generic;
using System.Linq;

namespace LongestZigzagSubsequence
{
    public class StartUp
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[,] dp = new int[2, numbers.Length];

            dp[0, 0] = 1;
            dp[1, 0] = 1;

            int[,] parent = new int[2, numbers.Length];

            parent[0, 0] = -1;
            parent[1, 0] = -1;

            int bestSize = 0;
            int lastRow = 0;
            int lastCol = 0;

            for (int current = 0; current < numbers.Length; current++)
            {
                int currentNumber = numbers[current];

                for (int previous = current - 1; previous >= 0; previous--)
                {
                    int previousNumber = numbers[previous];

                    if (currentNumber > previousNumber
                        && dp[1, previous] + 1 >= dp[0, current])
                    {
                        dp[0, current] = dp[1, previous] + 1;
                        parent[0, current] = previous;
                    }

                    if (currentNumber < previousNumber
                        && dp[0, previous] + 1 >= dp[1, current])
                    {
                        dp[1, current] = dp[0, previous] + 1;
                        parent[1, current] = previous;
                    }
                }

                if (dp[0, current] > bestSize)
                {
                    bestSize = dp[0, current];

                    lastRow = 0;
                    lastCol = current;
                }

                if (dp[1, current] > bestSize)
                {
                    bestSize = dp[1, current];

                    lastRow = 1;
                    lastCol = current;
                }
            }

            Stack<int> zigZagSequence = new Stack<int>();
            while (lastCol != -1)
            {
                zigZagSequence.Push(numbers[lastCol]);

                lastCol = parent[lastRow, lastCol];

                lastRow = lastRow == 0
                    ? 1
                    : 0;
            }

            Console.WriteLine(string.Join(" ", zigZagSequence));
        }
    }
}
