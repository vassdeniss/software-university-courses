using System;

namespace L11.MathOperations
{
    class Program
    {
        static double Calculate(int a, string s, int b)
        {
            double result = 0.0;
            switch(s)
            {
                case "+": result = a + b; break;
                case "-": result = a - b; break;
                case "*": result = a * b; break;
                case "/": result = a / b; break;
            }
            return result;
        }

        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            string mathOperator = Console.ReadLine();
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine(Calculate(a, mathOperator, b));
        }
    }
}
