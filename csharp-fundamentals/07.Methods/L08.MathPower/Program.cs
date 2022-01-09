using System;

namespace L08.MathPower
{
    class Program
    {
        static double RaisePower(double number, int power)
        {
            return Math.Pow(number, power);
        }

        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            int power = int.Parse(Console.ReadLine());

            Console.WriteLine(RaisePower(number, power));
        }
    }
}
