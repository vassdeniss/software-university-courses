using System;

namespace BE03.Flowers {
    class Program {
        static void Main(string[] args) {
            double springSummerChrysanthemumsPrice = 2;
            double autumnWinterChrysanthemumsPrice = 3.75;
            double springSummerRosesPrice = 4.10;
            double autumnWinterRosesPrice = 4.50;
            double springSummerTulipPrice = 2.50;
            double autumnWinterTulipPrice = 4.15;
            const double BOUQUET_PRICE = 2;

            int chrysanthemumQty = int.Parse(Console.ReadLine());
            int rosesQty = int.Parse(Console.ReadLine());
            int tulipsQty = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string isHoliday = Console.ReadLine();

            int totalFlowers = chrysanthemumQty + rosesQty + tulipsQty;
            double total = 0.0;

            switch (season) {
                case "Autumn":
                case "Winter":
                    total += autumnWinterChrysanthemumsPrice * chrysanthemumQty
                        + autumnWinterRosesPrice * rosesQty
                        + autumnWinterTulipPrice * tulipsQty;
                    if (isHoliday == "Y") {
                        total *= 1.15;
                    }
                    if (season == "Winter" && rosesQty >= 10) {
                        total *= 0.9;
                    }
                    if (totalFlowers > 20) {
                        total *= 0.8;
                    }
                    total += BOUQUET_PRICE;
                    break;
                case "Spring":
                case "Summer":
                    total += springSummerChrysanthemumsPrice * chrysanthemumQty
                        + springSummerRosesPrice * rosesQty
                        + springSummerTulipPrice * tulipsQty;
                    if (isHoliday == "Y") {
                        total *= 1.15;
                    }
                    if (season == "Spring" && tulipsQty > 7) {
                        total *= 0.95;
                    }
                    if (totalFlowers > 20) {
                        total *= 0.8;
                    }
                    total += BOUQUET_PRICE;
                    break;
            }

            Console.WriteLine($"{total:f2}");
        }
    }
}
