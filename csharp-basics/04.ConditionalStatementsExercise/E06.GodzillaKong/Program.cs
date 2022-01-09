using System;

namespace E06.GodzillaKong {
    class Program {
        static void Main(string[] args) {
            const double DECOR_RATE = 0.10;
            const double CLOTHING_DISCOUNT = 0.10;
            double movieBudget = double.Parse(Console.ReadLine());
            int extrasQty = int.Parse(Console.ReadLine());
            double clothingPrice = double.Parse(Console.ReadLine());
            double neededMoney = 0.0;
            neededMoney += movieBudget * DECOR_RATE;
            if (extrasQty > 150)
                clothingPrice = clothingPrice - (clothingPrice * CLOTHING_DISCOUNT);
            neededMoney += clothingPrice * extrasQty; 
            if (movieBudget < neededMoney) {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {neededMoney - movieBudget:f2} leva more.");
            } else if (movieBudget >= neededMoney) {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {movieBudget - neededMoney:f2} leva left.");
            }
        }
    }
}
