using System;

namespace E07.NxNMatrix
{
    class Program
    {
        static void PrintMatrix(int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{n} ");
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            PrintMatrix(int.Parse(Console.ReadLine()));
        }
    }
}
