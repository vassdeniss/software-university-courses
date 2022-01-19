using System;
using System.Linq;

namespace E06.JaggedArrayManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            double[][] jagged = RegisterJagged(rows);

            AnalyzeJagged(jagged);
            ModifyJagged(jagged);
            PrintJagged(jagged);
        }

        private static void AnalyzeJagged(double[][] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i].Length == arr[i + 1].Length)
                {
                    arr[i] = arr[i].Select(x => x * 2).ToArray();
                    arr[i + 1] = arr[i + 1].Select(x => x * 2).ToArray();
                }
                else
                {
                    arr[i] = arr[i].Select(x => x / 2).ToArray();
                    arr[i + 1] = arr[i + 1].Select(x => x / 2).ToArray();
                }
            }
        }

        private static void ModifyJagged(double[][] arr)
        {
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] cmd = input.Split();

                int row = int.Parse(cmd[1]);
                int col = int.Parse(cmd[2]);
                int value = int.Parse(cmd[3]);

                if (row < 0 || col < 0 || row >= arr.Length || col >= arr[row].Length)
                {
                    input = Console.ReadLine();
                    continue;
                }

                if (cmd[0] == "Add") arr[row][col] += value;
                else arr[row][col] -= value;

                input = Console.ReadLine();
            }
        }

        private static void PrintJagged(double[][] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write($"{arr[i][j]} ");
                }

                Console.WriteLine();
            }
        }

        private static double[][] RegisterJagged(int n)
        {
            double[][] jagged = new double[n][];

            for (int i = 0; i < n; i++)
            {
                jagged[i] = Console.ReadLine()
                    .Split().Select(double.Parse).ToArray();
            }

            return jagged;
        }
    }
}
