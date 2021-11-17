using System;

namespace Square_Area {
    class Program {
        static void Main(string[] args) {
            int side = int.Parse(Console.ReadLine());
            int area = side * side;
            Console.WriteLine(area);
        }
    }
}
