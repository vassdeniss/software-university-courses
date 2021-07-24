using System;

namespace E07.FruitMarket {
    class Program {
        static void Main(string[] args) {
            double strawberriesPrice = double.Parse(Console.ReadLine());
            double raspberryPrice = ((100 - 50) * 0.01) * strawberriesPrice;
            double orangesPrice = ((100 - 40) * 0.01) * raspberryPrice;
            double bananasPrice = ((100 - 80) * 0.01) * raspberryPrice;

            double bananasKg = double.Parse(Console.ReadLine());
            double orangesKg = double.Parse(Console.ReadLine());
            double raspberryKg = double.Parse(Console.ReadLine());
            double strawberriesKg = double.Parse(Console.ReadLine());

            double strawberriesTotal = strawberriesKg * strawberriesPrice;
            double bananasTotal = bananasKg * bananasPrice;
            double orangesTotal = orangesKg * orangesPrice;
            double raspberryTotal = raspberryKg * raspberryPrice;

            double total = strawberriesTotal + bananasTotal + orangesTotal + raspberryTotal;

            Console.WriteLine($"{total:f2}");
        }
    }
}
