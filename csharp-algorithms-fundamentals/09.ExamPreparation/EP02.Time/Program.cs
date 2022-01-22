using System;
using System.Collections.Generic;
using System.Linq;

namespace EP02.Time
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] timelineOne = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] timelineTwo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[,] timeline = new int[timelineOne.Length + 1, timelineTwo.Length + 1];

            for (int i = 1; i < timeline.GetLength(0); i++)
            {
                for (int j = 1; j < timeline.GetLength(1); j++)
                {
                    if (timelineOne[i - 1] == timelineTwo[j - 1]) timeline[i, j] = timeline[i - 1, j - 1] + 1;
                    else timeline[i, j] = Math.Max(timeline[i, j - 1], timeline[i - 1, j]);
                }
            }

            int row = timelineOne.Length;
            int col = timelineTwo.Length;
            Stack<int> sequence = new Stack<int>();
            while (row > 0 && col > 0)
            {
                if (timelineOne[row - 1] == timelineTwo[col - 1])
                {
                    sequence.Push(timelineOne[row - 1]);
                    row--;
                    col--;
                }
                else if (timeline[row - 1, col] > timeline[row, col - 1])
                {
                    row--;
                }
                else
                {
                    col--;
                }
            }

            Console.WriteLine(string.Join(" ", sequence));
            Console.WriteLine(sequence.Count);
        }
    }
}
