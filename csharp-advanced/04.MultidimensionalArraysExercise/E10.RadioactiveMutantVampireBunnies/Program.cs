using System;
using System.Collections.Generic;
using System.Linq;

namespace E10.RadioactiveMutantVampireBunnies
{
    internal class Program
    {
        private static bool FirstMove = true;
        private static bool IsAlive = true;

        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().
                Split().Select(int.Parse).ToArray();
            int[] playerPos = new int[2];
            char[,] lair = RegisterMatrix(dimensions[0], dimensions[1], playerPos);

            Queue<char> directions = new Queue<char>();
            string input = Console.ReadLine();
            foreach (char c in input) directions.Enqueue(c);

            Move(lair, playerPos[0], playerPos[1], directions, '-');
        }

        private static void Move(char[,] lair, int r, int c, Queue<char> directions, char currDirection)
        {
            if (!FirstMove)
            {
                if (OutOfBounds(lair, r, c))
                {
                    MultiplyBunnies(lair);
                    PrintLair(lair);
                    if (currDirection == 'U') Console.WriteLine($"won: {r + 1} {c}");
                    if (currDirection == 'D') Console.WriteLine($"won: {r - 1} {c}");
                    if (currDirection == 'L') Console.WriteLine($"won: {r} {c + 1}");
                    if (currDirection == 'R') Console.WriteLine($"won: {r} {c - 1}");
                    return;
                }

                if (lair[r, c] == 'B')
                {
                    MultiplyBunnies(lair);
                    PrintLair(lair);
                    Console.WriteLine($"dead: {r} {c}");
                    return;
                }

                lair[r, c] = 'P';
                MultiplyBunnies(lair);
                if (!IsAlive)
                {
                    PrintLair(lair);
                    Console.WriteLine($"dead: {r} {c}");
                    return;
                }
            }

            if (FirstMove) FirstMove = false;

            lair[r, c] = '.';
            char direction = directions.Dequeue();
            switch (direction)
            {
                case 'U': Move(lair, r - 1, c, directions, direction); break;
                case 'D': Move(lair, r + 1, c, directions, direction); break;
                case 'L': Move(lair, r, c - 1, directions, direction); break;
                case 'R': Move(lair, r, c + 1, directions, direction); break;
            }

            return;
        }

        private static void MultiplyBunnies(char[,] matrix)
        {
            List<int[]> bunnies = new List<int[]>();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 'B')
                    {
                        bunnies.Add(new int[] { i, j });
                    }
                }
            }

            foreach (int[] bun in bunnies)
            {
                int bunRow = bun[0];
                int bunCol = bun[1];

                if (!OutOfBounds(matrix, bunRow - 1, bunCol))
                {
                    if (matrix[bunRow - 1, bunCol] == 'P') IsAlive = false;
                    matrix[bunRow - 1, bunCol] = 'B';
                }
                if (!OutOfBounds(matrix, bunRow + 1, bunCol))
                {
                    if (matrix[bunRow + 1, bunCol] == 'P') IsAlive = false;
                    matrix[bunRow + 1, bunCol] = 'B';
                }
                if (!OutOfBounds(matrix, bunRow, bunCol - 1))
                {
                    if (matrix[bunRow, bunCol - 1] == 'P') IsAlive = false;
                    matrix[bunRow, bunCol - 1] = 'B';
                }
                if (!OutOfBounds(matrix, bunRow, bunCol + 1))
                {
                    if (matrix[bunRow, bunCol + 1] == 'P') IsAlive = false;
                    matrix[bunRow, bunCol + 1] = 'B';
                }
            }
        }

        private static void PrintLair(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]}");
                }

                Console.WriteLine();
            }
        }

        private static bool OutOfBounds(char[,] lair, int r, int c)
        {
            return r < 0 || c < 0 || r >= lair.GetLength(0) || c >= lair.GetLength(1);
        }

        private static char[,] RegisterMatrix(int n, int m, int[] arr)
        {
            char[,] matrix = new char[n, m];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string elements = Console.ReadLine();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = elements[j];
                    if (matrix[i, j] == 'P')
                    {
                        arr[0] = i;
                        arr[1] = j;
                    }
                }
            }

            return matrix;
        }
    }
}
