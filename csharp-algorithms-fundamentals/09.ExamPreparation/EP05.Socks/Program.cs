using System;
using System.Linq;

namespace EP05.Socks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] left = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] right = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[,] lcs = new int[left.Length + 1, right.Length + 1];

            for (int i = 1; i < lcs.GetLength(0); i++)
            {
                for (int j = 1; j < lcs.GetLength(1); j++)
                {
                    if (left[i - 1] == right[j - 1]) lcs[i, j] = lcs[i - 1, j - 1] + 1;
                    else lcs[i, j] = Math.Max(lcs[i, j - 1], lcs[i - 1, j]);
                }
            }

            Console.WriteLine(lcs[left.Length, right.Length]);
        }
    }
}
