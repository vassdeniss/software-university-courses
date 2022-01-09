using System;

namespace BE04.VegetableMarket {
    class Program {
        static void Main(string[] args) {
            const double EUR_RATE = 1.94;

            double vegetablesPrice = double.Parse(Console.ReadLine());
            double fruitsPrice = double.Parse(Console.ReadLine());
            double vegetablesPriceEuro = vegetablesPrice / EUR_RATE;
            double fruitsPriceEuro = fruitsPrice / EUR_RATE;

            int vegetablesKg = int.Parse(Console.ReadLine());
            int fruitsKg = int.Parse(Console.ReadLine());

            double vegetableTotal = vegetablesPriceEuro * vegetablesKg;
            double fruitsTotal = fruitsPriceEuro * fruitsKg;
            double total = vegetableTotal + fruitsTotal;
            Console.WriteLine($"{total:f2}");
        }
    }
}
