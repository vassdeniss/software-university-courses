using System;
using System.Linq;

namespace L06.JaggedArrayModification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[][] jagged = RegisterJagged(size);

            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] cmd = input.Split();

                int row = int.Parse(cmd[1]);
                int col = int.Parse(cmd[2]);
                int value = int.Parse(cmd[3]);

                if (row < 0 || col < 0 || row >= jagged.Length || col >= jagged[row].Length)
                { 
                    Console.WriteLine("Invalid coordinates");
                    input = Console.ReadLine();
                    continue;
                }

                if (cmd[0] == "Add") jagged[row][col] += value;
                else jagged[row][col] -= value;

                input = Console.ReadLine();
            }

            for (int i = 0; i < jagged.Length; i++)
            {
                for (int j = 0; j < jagged[i].Length; j++)
                {
                    Console.Write($"{jagged[i][j]} ");
                }

                Console.WriteLine();
            }
        }

        private static int[][] RegisterJagged(int n)
        {
            int[][] jagged = new int[n][];

            for (int i = 0; i < n; i++)
                jagged[i] = Console.ReadLine().Split().Select(int.Parse).ToArray();

            return jagged;
        }
    }
}
