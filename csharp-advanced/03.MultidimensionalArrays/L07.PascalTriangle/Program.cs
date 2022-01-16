using System;

namespace L07.PascalTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long[][] triangle = new long[n][];

            triangle[0] = new long[1] { 1 };
            for (int i = 1; i < n; i++)
            {
                triangle[i] = new long[triangle[i - 1].Length + 1];
                for (int j = 0; j < triangle[i].Length; j++)
                {
                    if (triangle[i - 1].Length > j) triangle[i][j] += triangle[i - 1][j];
                    if (j > 0) triangle[i][j] += triangle[i - 1][j - 1];
                }
            }

            for (int i = 0; i < triangle.Length; i++)
                Console.WriteLine(string.Join(" ", triangle[i]));
        }
    }
}
