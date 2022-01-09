using System;
using System.Collections.Generic;

namespace L06.EightQueensPuzzle
{
    internal class Program
    {
        private static List<int> attackingCols = new List<int>();
        private static List<int> attackingDiagonalsLeft = new List<int>();
        private static List<int> attackingDiagonalsRight = new List<int>();

        static void Main(string[] args) => PutQueen(new bool[8, 8], 0);

        private static void PutQueen(bool[,] board, int row)
        {
            if (row >= board.GetLength(0)) Print(board);

            for (int col = 0; col < board.GetLength(1); col++)
            {
                if (CanPlaceQueen(row, col))
                {
                    OccupyTile(board, row, col);
                    PutQueen(board, row + 1);
                    FreeTile(board, row, col);
                }
            }
        }

        private static void OccupyTile(bool[,] board, int row, int col)
        {
            board[row, col] = true;
            attackingCols.Add(col);
            attackingDiagonalsLeft.Add(row - col);
            attackingDiagonalsRight.Add(row + col);
        }

        private static void FreeTile(bool[,] board, int row, int col)
        {
            board[row, col] = false;
            attackingCols.Remove(col);
            attackingDiagonalsLeft.Remove(row - col);
            attackingDiagonalsRight.Remove(row + col);
        }

        private static bool CanPlaceQueen(int row, int col)
        {
            return !attackingCols.Contains(col)
                && !attackingDiagonalsLeft.Contains(row - col) 
                && !attackingDiagonalsRight.Contains(row + col);
        }

        private static void Print(bool[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j]) Console.Write("* ");
                    else Console.Write("- ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
