using System;
using System.Linq;
using System.Text;

namespace L05.SquareMaximumSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[,] matrix = RegisterMatrix(size[0], size[1]);

            int[] maxSquarePos = new int[4];
            int max = FindMaxSquare(matrix, maxSquarePos);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{maxSquarePos[0]} {maxSquarePos[1]}");
            sb.AppendLine($"{maxSquarePos[2]} {maxSquarePos[3]}");
            sb.AppendLine(max.ToString());

            Console.WriteLine(sb);
        }

        private static int FindMaxSquare(int[,] matrix, int[] maxSquarePos)
        {
            int max = int.MinValue;

            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    int sum =
                        matrix[i, j] + matrix[i, j + 1]
                        + matrix[i + 1, j] + matrix[i + 1, j + 1];

                    if (sum > max)
                    {
                        max = sum;
                        maxSquarePos[0] = matrix[i, j];
                        maxSquarePos[1] = matrix[i, j + 1];
                        maxSquarePos[2] = matrix[i + 1, j];
                        maxSquarePos[3] = matrix[i + 1, j + 1];
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
                int[] nums = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = nums[j];
                }
            }

            return matrix;
        }
    }
}
