using System;
using System.Linq;

namespace E06.ConnectingCables
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[] positions = Enumerable.Range(1, nums.Length).ToArray();

            int[,] dp = new int[nums.Length + 1, nums.Length + 1];
            for (int i = 1; i < dp.GetLength(0); i++)
            {
                for (int j = 1; j < dp.GetLength(1); j++)
                {
                    if (nums[i - 1] == positions[j - 1]) dp[i, j] = dp[i - 1, j - 1] + 1;
                    else dp[i, j] = Math.Max(dp[i, j - 1], dp[i - 1, j]);
                }
            }

            Console.WriteLine($"Maximum pairs connected: {dp[nums.Length, positions.Length]}");
        }
    }
}
