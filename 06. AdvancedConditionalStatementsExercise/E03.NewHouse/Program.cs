using System;

namespace E03.NewHouse {
    class Program {
        static void Main(string[] args) {
            const double ROSES_PRICE = 5;
            const double DAHLIA_PRICE = 3.80;
            const double TULIP_PRICE = 2.80;
            const double NARCISSUS_PRICE = 3;
            const double GLADIOLUS_PRICE = 2.50;

            string flowerType = Console.ReadLine();
            int flowerQuantity = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            double total = 0.0;

            switch (flowerType) {
                case "Roses": 
                    total += flowerQuantity * ROSES_PRICE;
                    if (flowerQuantity > 80) { total *= 0.9; }
                    break;
                case "Dahlias":
                    total += flowerQuantity * DAHLIA_PRICE;
                    if (flowerQuantity > 90) { total *= 0.85; }
                    break;
                case "Tulips":
                    total += flowerQuantity * TULIP_PRICE;
                    if (flowerQuantity > 80) { total *= 0.85; }
                    break;
                case "Narcissus":
                    total += flowerQuantity * NARCISSUS_PRICE;
                    if (flowerQuantity < 120) { total *= 1.15; }
                    break;
                case "Gladiolus":
                    total += flowerQuantity * GLADIOLUS_PRICE;
                    if (flowerQuantity < 80) { total *= 1.20; }
                    break;
            }

            if (budget >= total) {
                Console.WriteLine($"Hey, you have a great garden with {flowerQuantity} {flowerType} and {(budget - total):f2} leva left.");
            } else if (budget < total) {
                Console.WriteLine($"Not enough money, you need {(total - budget):f2} leva more.");
            }
        }
    }
}
