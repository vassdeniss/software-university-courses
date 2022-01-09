using System;

namespace ME02.CenterPoint
{
    class Program
    {
        static void Center(double x1, double y1, double x2, double y2)
        {
            double pointOne = Math.Abs(x1) + Math.Abs(y1);
            double pointTwo = Math.Abs(x2) + Math.Abs(y2);

            if (pointOne < pointTwo)
                Console.WriteLine($"({string.Join(", ", x1, y1)})");
            else
                Console.WriteLine($"({string.Join(", ", x2, y2)})");
        }

        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            Center(x1, y1, x2, y2);
        }
    }
}
