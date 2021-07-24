using System;

namespace BE03.Harvest {
    class Program {
        static void Main(string[] args) {
            const double PERCENT_FOR_WINE = 0.4;
            const double KILOS_PER_LITER = 2.5;
            int farmArea = int.Parse(Console.ReadLine());
            double grapePerSquareMeter = double.Parse(Console.ReadLine()); 
            int neededGrape = int.Parse(Console.ReadLine());
            int workersQty = int.Parse(Console.ReadLine());

            double grapeArea = farmArea * PERCENT_FOR_WINE;
            double grapeKilos = grapeArea * grapePerSquareMeter;
            double totalLitersWine = grapeKilos / KILOS_PER_LITER;

            if (totalLitersWine < neededGrape) {
                double wineNeeded = Math.Floor(neededGrape - totalLitersWine);
                Console.WriteLine($"It will be a tough winter! More {wineNeeded} liters wine needed.");
            } else if (totalLitersWine >= neededGrape) {
                double total = Math.Floor(totalLitersWine);
                double remainingWineLiters = Math.Ceiling(totalLitersWine - neededGrape);
                double winePerWorker = Math.Ceiling(remainingWineLiters / workersQty);
                Console.WriteLine($"Good harvest this year! Total wine: {total} liters.");
                Console.WriteLine($"{remainingWineLiters} liters left -> {winePerWorker} liters per person.");
            }
        }
    }
}
