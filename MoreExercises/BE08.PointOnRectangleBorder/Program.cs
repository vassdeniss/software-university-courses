using System;

namespace BE08.PointOnRectangleBorder {
    class Program {
        static void Main(string[] args) {
            double x1 = double.Parse(Console.ReadLine()); 
            double y1 = double.Parse(Console.ReadLine()); 
            double x2 = double.Parse(Console.ReadLine()); 
            double y2 = double.Parse(Console.ReadLine()); 
            double x = double.Parse(Console.ReadLine()); 
            double y = double.Parse(Console.ReadLine());

            if ((x > x1 && y > y1 && x < x2 && y < y2) 
                || (x < x1 || y < y1 || x > x2 || y > y2)) {
                Console.WriteLine("Inside / Outside");
            } else if ((x == x1 || x == x2 && y >= y1 && y <= y2)
                    || (y == y1 || y == y2 && x >= x1 && x <= x2)) {
                Console.WriteLine("Border");
            }
        }
    }
}
