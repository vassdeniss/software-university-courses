using System;

namespace L06.AreaOfFigures {
    class Program {
        static void Main(string[] args) {
            string figureType = Console.ReadLine();

            if (figureType == "square") {
                double length = double.Parse(Console.ReadLine());
                double result = length * length;
                Console.WriteLine($"{result:F3}");
            } else if (figureType == "rectangle") {
                double lengthOne = double.Parse(Console.ReadLine());
                double lengthTwo = double.Parse(Console.ReadLine());
                double result = lengthOne * lengthTwo;
                Console.WriteLine($"{result:F3}");
            } else if (figureType == "circle") {
                double radius = double.Parse(Console.ReadLine());
                double result = Math.PI * Math.Pow(radius, 2);
                Console.WriteLine($"{result:F3}");
            } else if (figureType == "triangle") {
                double length = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());
                double result = (length * height) / 2;
                Console.WriteLine($"{result:F3}");
            }
        }
    }
}
