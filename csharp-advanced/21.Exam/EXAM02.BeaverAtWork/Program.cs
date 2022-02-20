using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace EXAM02.BeaverAtWork
{
    class Beaver
    {
        public Beaver()
        {
            Branches = new LinkedList<char>();
        }

        public int Row { get; set; }
        public int Col { get; set; }
        public int TotalBranches { get; set; }
        public LinkedList<char> Branches { get; set; }

        public bool IsAtLastIndex(char[,] field, string direction)
        {
            Direction check = GetDirection(direction);
            if (check == Direction.UP && Row == 0) return true;
            else if (check == Direction.DOWN && Row == field.GetLength(0)) return true;
            else if (check == Direction.LEFT && Col == 0) return true;
            else if (check == Direction.RIGHT && Col == field.GetLength(1)) return true;

            return false;
        }

        public bool WouldBeOutOfBounds(char[,] field, string direction)
        {
            Direction check = GetDirection(direction);
            if (check == Direction.UP && IsOutOfBounds(field, Row - 1, Col)) return true;
            else if (check == Direction.DOWN && IsOutOfBounds(field, Row + 1, Col)) return true;
            else if (check == Direction.LEFT && IsOutOfBounds(field, Row, Col - 1)) return true;
            else if (check == Direction.RIGHT && IsOutOfBounds(field, Row, Col + 1)) return true;

            return false;
        }

        public void Swim(char[,] matrix, SwimDirection swimDirection, string direction)
        {
            Direction check = GetDirection(direction);
            
            if (swimDirection == SwimDirection.OPPOSITE)
            {
                switch (check)
                {
                    case Direction.UP: Row = matrix.GetLength(0) - 1; break;
                    case Direction.DOWN: Row = 0; break;
                    case Direction.LEFT: Col = matrix.GetLength(1) - 1; break;
                    case Direction.RIGHT: Col = 0; break;
                }

                return;
            }

            switch (check)
            {
                case Direction.UP: Row = 0; break;
                case Direction.DOWN: Row = matrix.GetLength(0) - 1; break;
                case Direction.LEFT: Col = 0; break;
                case Direction.RIGHT: Col = matrix.GetLength(1) - 1; break;
            }
        }

        public void Move(string direction)
        {
            Direction check = GetDirection(direction);
            switch (check)
            {
                case Direction.UP: Row--; break;
                case Direction.DOWN: Row++; break;
                case Direction.LEFT: Col--; break;
                case Direction.RIGHT: Col++; break;
            }
        }

        private Direction GetDirection(string direction)
        {
            return direction switch
            {
                "up" => Direction.UP,
                "down" => Direction.DOWN,
                "left" => Direction.LEFT,
                "right" => Direction.RIGHT,
                _ => Direction.INVALID
            };
        }

        private bool IsOutOfBounds(char[,] field, int row, int col)
        {
            return row < 0 || row >= field.GetLength(0) || col < 0 || col >= field.GetLength(1);
        }
    }

    enum SwimDirection
    {
        NORMAL,
        OPPOSITE
    }

    enum Direction
    {
        UP,
        DOWN,
        LEFT,
        RIGHT,
        INVALID
    }

    internal class Program
    {
        private const char DEFAULT_MAZE_SYMBOL = '-';
        private const char BEAVER_MAZE_SYMBOL = 'B';

        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            Beaver beaver = new Beaver();
            int brachesInPound = 0;
            char[,] matrix = RegisterMatrix(size, beaver, ref brachesInPound);

            string command = Console.ReadLine();
            while (command != "end")
            {
                matrix[beaver.Row, beaver.Col] = DEFAULT_MAZE_SYMBOL;

                if (beaver.WouldBeOutOfBounds(matrix, command))
                {
                    if (beaver.Branches.Any())
                    {
                        beaver.Branches.RemoveLast();
                        beaver.TotalBranches =
                            beaver.TotalBranches == 0
                            ? 0
                            : beaver.TotalBranches -= 1;
                    }

                    matrix[beaver.Row, beaver.Col] = BEAVER_MAZE_SYMBOL;
                    command = Console.ReadLine();
                    continue;
                }

                beaver.Move(command);

                if (matrix[beaver.Row, beaver.Col] == 'F')
                {
                    matrix[beaver.Row, beaver.Col] = DEFAULT_MAZE_SYMBOL;
                    SwimDirection swimDirection = beaver.IsAtLastIndex(matrix, command)
                        ? SwimDirection.OPPOSITE : SwimDirection.NORMAL;

                    beaver.Swim(matrix, swimDirection, command);
                }

                if (char.IsLower(matrix[beaver.Row, beaver.Col]))
                {
                    beaver.TotalBranches++;
                    beaver.Branches.AddLast(matrix[beaver.Row, beaver.Col]);
                    brachesInPound--;
                }

                matrix[beaver.Row, beaver.Col] = BEAVER_MAZE_SYMBOL;
                if (brachesInPound == 0) break;
                command = Console.ReadLine();
            }

            Console.WriteLine(brachesInPound == 0
                ? $"The Beaver successfully collect {beaver.TotalBranches} wood branches: {string.Join(", ", beaver.Branches)}."
                : $"The Beaver failed to collect every wood branch. There are {brachesInPound} branches left.");

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(char[,] matrix)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    sb.Append($"{matrix[i, j]} ");
                }

                sb = new StringBuilder(sb.ToString().TrimEnd());
                sb.AppendLine();
            }

            Console.WriteLine(sb);
        }

        private static char[,] RegisterMatrix(int size, Beaver beaver, ref int branches)
        {
            char[,] matrix = new char[size, size];
            
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string elements = Regex.Replace(Console.ReadLine(), @"\s", "");
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = elements[j];

                    if (elements[j] == 'B')
                    {
                        beaver.Row = i;
                        beaver.Col = j;
                    }

                    if (char.IsLower(elements[j]))
                    {
                        branches++;
                    }
                }
            }

            return matrix;
        }
    }
}
