using System;

namespace E02.RadiansToDegrees {
    class Program {
        static void Main(string[] args) {
            const double RAD_TO_DEG = 180 / Math.PI;
            double rad = double.Parse(Console.ReadLine());
            double deg = rad * RAD_TO_DEG;
            Console.WriteLine(Math.Round(deg));
        }
    }
}
