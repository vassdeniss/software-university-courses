using System;

namespace BE06.Fishland {
    class Program {
        static void Main(string[] args) {
            double mackerelPrice = double.Parse(Console.ReadLine()); 
            double spratPrice = double.Parse(Console.ReadLine());
            double bonitoPrice = mackerelPrice + (mackerelPrice * 0.60);
            double horseMackerelPrice = spratPrice + (spratPrice * 0.80);
            double clamPrice = 7.50;

            double bonitoKg = double.Parse(Console.ReadLine());
            double horseMackerelKg = double.Parse(Console.ReadLine());
            int clamKg = int.Parse(Console.ReadLine());

            double total = (bonitoKg * bonitoPrice) + (horseMackerelKg * horseMackerelPrice) + (clamKg * clamPrice);
            Console.WriteLine($"{total:f2}");
        }
    }
}
