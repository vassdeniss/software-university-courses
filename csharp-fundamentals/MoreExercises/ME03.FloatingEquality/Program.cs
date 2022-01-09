using System;

namespace ME03.FloatingEquality
{
    class Program
    {
        static void Main(string[] args)
        {
            const double EPS = 0.000001;

            double a = double.Parse(Console.ReadLine()); 
            double b = double.Parse(Console.ReadLine());

            double difference = Math.Abs(a - b);

            if (difference >= EPS)
            {
                Console.WriteLine("False");
            }
            else
            {
                Console.WriteLine("True");
            }
        }
    }
}
