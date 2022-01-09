using System;

namespace ME02.PascalTriangle
{
    class Program
    {
        public static void printPascalTriangle(int n)
        {
            for (int line = 1; line <= n; line++)
            {
                int number = 1;
                for (int j = 1; j <= line; j++)
                {
                    Console.Write($"{number} ");
                    number = number * (line - j) / j;
                }
                Console.Write("\n");                
            }
        }

        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            printPascalTriangle(input);
        }
    }
}
