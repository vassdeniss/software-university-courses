using System;

namespace ME03.LongerLine
{
    class Program
    {
        static void LongerLine(double x, double y,
                               double x1, double y1,
                               double x2, double y2,
                               double x3, double y3,
                               double one, double two)
        {
            if (one >= two)
            {
                double pointOne = Math.Abs(x) + Math.Abs(y);
                double pointTwo = Math.Abs(x1) + Math.Abs(y1);

                if (pointOne <= pointTwo)
                    Console.WriteLine($"({string.Join(", ", x, y)})({string.Join(", ", x1, y1)})");
                else
                    Console.WriteLine($"({string.Join(", ", x1, y1)})({string.Join(", ", x, y)})");
            }
            else
            {
                double pointOne = Math.Abs(x2) + Math.Abs(y2);
                double pointTwo = Math.Abs(x3) + Math.Abs(y3);

                if (pointOne <= pointTwo)
                    Console.WriteLine($"({string.Join(", ", x2, y2)})({string.Join(", ", x3, y3)})");
                else
                    Console.WriteLine($"({string.Join(", ", x3, y3)})({string.Join(", ", x2, y2)})");
            }
        }

        static double DistanceFormula(double x, double y,
                                      double x1, double y1)
        {
            return Math.Sqrt(Math.Pow(x1 - x, 2) + Math.Pow(y1 - y, 2));
        }

        static void Main(string[] args)
        {
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());

            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double x3 = double.Parse(Console.ReadLine());
            double y3 = double.Parse(Console.ReadLine());

            double lineOneLength = DistanceFormula(x, y, x1, y1);
            double lineTwoLength = DistanceFormula(x2, y2, x3, y3);

            LongerLine(x, y, x1, y1, x2, y2, x3, y3, lineOneLength, lineTwoLength);
        }
    }
}
