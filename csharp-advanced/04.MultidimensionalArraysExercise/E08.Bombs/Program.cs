using System;
using System.Linq;
using System.Text;

namespace E08.Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] field = RegisterMatrix(size);

            int[] bombs = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < bombs.Length; i += 2)
            {
                int row = bombs[i];
                int col = bombs[i + 1];

                if (field[row, col] <= 0) continue;

                int explosion = field[row, col];
                ExplodeBomb(field, row, col, explosion);
                field[row, col] = 0;
            }

            int alive = 0;
            int sum = 0;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    sb.Append($"{field[i, j]} ");
                    if (field[i, j] > 0)
                    {
                        alive++;
                        sum += field[i, j];
                    }
                }
                sb.Append("\n");
            }

            Console.WriteLine($"Alive cells: {alive}");
            Console.WriteLine($"Sum: {sum}");
            Console.WriteLine(sb.ToString());
        }

        private static void ExplodeBomb(int[,] field, int row, int col, int explosion)
        {
            if (IsInRange(field, row - 1, col) 
                && field[row - 1, col] > 0) 
                    field[row - 1, col] -= explosion;

            if (IsInRange(field, row + 1, col) 
                && field[row + 1, col] > 0) 
                    field[row + 1, col] -= explosion;

            if (IsInRange(field, row, col - 1) 
                && field[row, col - 1] > 0) 
                    field[row, col - 1] -= explosion;

            if (IsInRange(field, row, col + 1) 
                && field[row, col + 1] > 0) 
                    field[row, col + 1] -= explosion;

            if (IsInRange(field, row - 1, col - 1) 
                && field[row - 1, col - 1] > 0) 
                    field[row - 1, col - 1] -= explosion;

            if (IsInRange(field, row + 1, col - 1) 
                && field[row + 1, col - 1] > 0) 
                    field[row + 1, col - 1] -= explosion;

            if (IsInRange(field, row - 1, col + 1) 
                && field[row - 1, col + 1] > 0) 
                    field[row - 1, col + 1] -= explosion;

            if (IsInRange(field, row + 1, col + 1) 
                && field[row + 1, col + 1] > 0) 
                    field[row + 1, col + 1] -= explosion;
        }

        private static bool IsInRange(int[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                col >= 0 && col < matrix.GetLength(1);
        }

        private static int[,] RegisterMatrix(int n)
        {
            int[,] matrix = new int[n, n];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] nums = Console.ReadLine()
                    .Split().Select(int.Parse).ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = nums[j];
                }
            }

            return matrix;
        }
    }
}
