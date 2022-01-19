using System;
using System.Linq;
using System.Text;

namespace E03.MaximalSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[,] matrix = RegisterMatrix(size[0], size[1]);

            int[] maxSquarePos = new int[9];
            int sum = FindMaxSquare(matrix, maxSquarePos);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Sum = {sum}");
            sb.AppendLine($"{maxSquarePos[0]} {maxSquarePos[1]} {maxSquarePos[2]}");
            sb.AppendLine($"{maxSquarePos[3]} {maxSquarePos[4]} {maxSquarePos[5]}");
            sb.AppendLine($"{maxSquarePos[6]} {maxSquarePos[7]} {maxSquarePos[8]}");

            Console.WriteLine(sb);
        }

        private static int FindMaxSquare(int[,] matrix, int[] maxSquarePos)
        {
            int max = int.MinValue;

            for (int i = 0; i < matrix.GetLength(0) - 2; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 2; j++)
                {
                    int sum =
                        matrix[i, j] + matrix[i, j + 1] + matrix[i, j + 2]
                        + matrix[i + 1, j] + matrix[i + 1, j + 1] + matrix[i + 1, j + 2]
                        + matrix[i + 2, j] + matrix[i + 2, j + 1] + matrix[i + 2, j + 2];

                    if (sum > max)
                    {
                        max = sum;
                        maxSquarePos[0] = matrix[i, j];
                        maxSquarePos[1] = matrix[i, j + 1];
                        maxSquarePos[2] = matrix[i, j + 2];
                        maxSquarePos[3] = matrix[i + 1, j];
                        maxSquarePos[4] = matrix[i + 1, j + 1];
                        maxSquarePos[5] = matrix[i + 1, j + 2];
                        maxSquarePos[6] = matrix[i + 2, j];
                        maxSquarePos[7] = matrix[i + 2, j + 1];
                        maxSquarePos[8] = matrix[i + 2, j + 2];
                    }
                }
            }

            return max;
        }

        private static int[,] RegisterMatrix(int r, int c)
        {
            int[,] matrix = new int[r, c];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] nums = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = nums[j];
                }
            }

            return matrix;
        }
    }
}
