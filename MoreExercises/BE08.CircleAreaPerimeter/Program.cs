using System;

namespace BE08.CircleAreaPerimeter {
    class Program {
        static void Main(string[] args) {
            double radius = double.Parse(Console.ReadLine());
            double circleArea = Math.PI * Math.Pow(radius, 2);
            double circlePerimeter = 2 * Math.PI * radius;
            Console.WriteLine($"{circleArea:f2}\n{circlePerimeter:f2}");
        }
    }
}
