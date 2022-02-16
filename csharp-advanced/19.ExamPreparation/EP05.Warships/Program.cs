using System;
using System.Linq;

namespace EP05.Warships
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[] attacks = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int playerOne = 0;
            int playerTwo = 0;
            string[,] field = RegisterMatrix(size, ref playerOne, ref playerTwo);

            int total = playerOne + playerTwo;
            for (int i = 0; i < attacks.Length; i += 2)
            {
                int row = attacks[i];
                int col = attacks[i + 1];

                if (!IsInRange(field, row, col)) continue;

                if (field[row, col] == "<")
                {
                    playerOne--;
                    field[row, col] = "X";
                } 

                if (field[row, col] == ">")
                {
                    playerTwo--;
                    field[row, col] = "X";
                }

                if (field[row, col] == "#")
                { 
                    BlowMine(field, row - 1, col, ref playerOne, ref playerTwo);
                    BlowMine(field, row + 1, col, ref playerOne, ref playerTwo);
                    BlowMine(field, row, col - 1, ref playerOne, ref playerTwo);
                    BlowMine(field, row, col + 1, ref playerOne, ref playerTwo);
                    BlowMine(field, row - 1, col - 1, ref playerOne, ref playerTwo);
                    BlowMine(field, row - 1, col + 1, ref playerOne, ref playerTwo);
                    BlowMine(field, row + 1, col - 1, ref playerOne, ref playerTwo);
                    BlowMine(field, row + 1, col + 1, ref playerOne, ref playerTwo);
                }

                if (playerOne == 0 || playerTwo == 0) break;
            }

            Console.WriteLine(playerOne > 0 && playerTwo > 0
                ? $"It's a draw! Player One has {playerOne} ships left. Player Two has {playerTwo} ships left."
                : playerOne > 0
                    ? $"Player One has won the game! {total - (playerOne + playerTwo)} ships have been sunk in the battle."
                    : $"Player Two has won the game! {total - (playerOne + playerTwo)} ships have been sunk in the battle.");
        }

        private static void BlowMine(string[,] arr, int row, int col, ref int first, ref int second)
        {
            if (!IsInRange(arr, row, col)) return;

            if (arr[row, col] == "<") first--;
            if (arr[row, col] == ">") second--;
            arr[row, col] = "X";
        }

        private static bool IsInRange(string[,] arr, int row, int col)
            => row >= 0 && row < arr.GetLength(0)
            && col >= 0 && col < arr.GetLength(1);

        private static string[,] RegisterMatrix(int size, ref int one, ref int two)
        {
            string[,] matrix = new string[size, size];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string[] elements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = elements[j];

                    if (matrix[i, j] == "<") one++;
                    if (matrix[i, j] == ">") two++;
                }
            }

            return matrix;
        }
    }
}
