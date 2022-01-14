using System;

namespace E07.MinimumEditDistance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int replaceCost = int.Parse(Console.ReadLine());
            int insertCost = int.Parse(Console.ReadLine());
            int deleteCost = int.Parse(Console.ReadLine());
            string s1 = Console.ReadLine();
            string s2 = Console.ReadLine();

            int[,] matrix = new int[s1.Length + 1, s2.Length + 1];

            for (int i = 1; i < matrix.GetLength(0); i++) matrix[i, 0] = matrix[i - 1, 0] + deleteCost;
            for (int i = 1; i < matrix.GetLength(1); i++) matrix[0, i] = matrix[0, i - 1] + insertCost;

            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (s1[i - 1] == s2[j - 1])
                    {
                        matrix[i, j] = matrix[i - 1, j - 1];
                    }
                    else
                    {
                        int replace = matrix[i - 1, j - 1] + replaceCost;
                        int delete = matrix[i - 1, j] + deleteCost;
                        int insert = matrix[i, j - 1] + insertCost;

                        matrix[i, j] = Math.Min(Math.Min(replace, delete), insert);
                    }
                }
            }

            Console.WriteLine($"Minimum edit distance: {matrix[s1.Length, s2.Length]}");
        }
    }
}
