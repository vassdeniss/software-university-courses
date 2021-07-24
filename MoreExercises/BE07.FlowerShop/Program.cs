using System;

namespace BE07.FlowerShop {
    class Program {
        static void Main(string[] args) {
            const double TAXES_PERCENT = 0.05;
            const double MAGNOLIAS_PRICE = 3.25;
            const double HYACINTHS_PRICE = 4;
            const double ROSES_PRICE = 3.50;
            const double CACTUS_PRICE = 8;

            int magnoliasQty = int.Parse(Console.ReadLine()); 
            int hyacinthsQty = int.Parse(Console.ReadLine()); 
            int rosesQty = int.Parse(Console.ReadLine()); 
            int cactusesQty = int.Parse(Console.ReadLine());
            double presentPrice = double.Parse(Console.ReadLine());

            double totalMoneyEarned = magnoliasQty * MAGNOLIAS_PRICE + hyacinthsQty * HYACINTHS_PRICE
                + rosesQty * ROSES_PRICE + cactusesQty * CACTUS_PRICE;
            double totalMoney = totalMoneyEarned - (totalMoneyEarned * TAXES_PERCENT);

            if (totalMoney >= presentPrice) {
                double moneyLeft = Math.Floor(totalMoney - presentPrice);
                Console.WriteLine($"She is left with {moneyLeft} leva.");
            } else {
                double moneyLeft = Math.Ceiling(presentPrice - totalMoney);
                Console.WriteLine($"She will have to borrow {moneyLeft} leva.");
            }
        }
    }
}
