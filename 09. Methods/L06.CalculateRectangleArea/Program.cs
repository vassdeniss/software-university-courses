using System;

namespace L06.CalculateRectangleArea
{
    class Program
    {
        static int CalculateArea(int a, int b) { return a * b; }

        static void Main(string[] args)
        {
            int inputOne = int.Parse(Console.ReadLine());
            int inputTwo = int.Parse(Console.ReadLine());

            Console.WriteLine(CalculateArea(inputOne, inputTwo));
        }
    }
}
