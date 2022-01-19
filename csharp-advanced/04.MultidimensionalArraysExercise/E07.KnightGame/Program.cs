using System;

namespace E07.KnightGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] board = RegisterMatrix(size);

            int removedKnights = 0;
            while (true)
            {
                int[] moves = HasLegalMoves(board);

                int maxAttacks = moves[0];
                int knightRow = moves[1];
                int knightCol = moves[2];

                if (maxAttacks > 0)
                {
                    removedKnights++;
                    board[knightRow, knightCol] = '0';
                }
                else
                {
                    Console.WriteLine(removedKnights);
                    break;
                }
            }
        }

        private static int[] HasLegalMoves(char[,] board)
        {
            int[] data = new int[3];

            int max = 0;
            int kRow = 0;
            int kCol = 0;
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == '0') continue;

                    int attacks = 0;

                    if (IsInRange(board, i - 2, j - 1) && board[i - 2, j - 1] == 'K') attacks++;
                    if (IsInRange(board, i - 2, j + 1) && board[i - 2, j + 1] == 'K') attacks++;

                    if (IsInRange(board, i - 1, j - 2) && board[i - 1, j - 2] == 'K') attacks++;
                    if (IsInRange(board, i + 1, j - 2) && board[i + 1, j - 2] == 'K') attacks++;

                    if (IsInRange(board, i + 2, j - 1) && board[i + 2, j - 1] == 'K') attacks++;
                    if (IsInRange(board, i + 2, j + 1) && board[i + 2, j + 1] == 'K') attacks++;

                    if (IsInRange(board, i - 1, j + 2) && board[i - 1, j + 2] == 'K') attacks++;
                    if (IsInRange(board, i + 1, j + 2) && board[i + 1, j + 2] == 'K') attacks++;

                    if (attacks > max)
                    {
                        max = attacks;
                        kRow = i;
                        kCol = j;
                    }
                }
            }

            data[0] = max;
            data[1] = kRow;
            data[2] = kCol;

            return data;
        }

        private static bool IsInRange(char[,] board, int row, int col)
        {
            return row >= 0 && row < board.GetLength(0) &&
                col >= 0 && col < board.GetLength(1);
        }

        private static char[,] RegisterMatrix(int n)
        {
            char[,] matrix = new char[n, n];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string elements = Console.ReadLine();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = elements[j];
                }
            }

            return matrix;
        }
    }
}
