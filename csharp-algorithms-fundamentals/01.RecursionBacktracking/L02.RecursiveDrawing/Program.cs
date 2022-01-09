using System;

namespace L02.RecursiveDrawing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            PrintDrawing(n);
        }

        private static void PrintDrawing(int n)
        {
            if (n == 0) return;
            Console.WriteLine(new string('*', n));
            PrintDrawing(n - 1);
            Console.WriteLine(new string('#', n));
        }
    }
}
