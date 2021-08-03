using System;

namespace BE02.ReportSystem {
    class Program {
        static void Main(string[] args) {
            int requiredAmount = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            double moneyRecievedCash = 0.0;
            double moneyRecievedCard = 0.0;
            int cashUsed = 0;
            int cardUsed = 0;
            int counter = 1;

            while (input != "End") {
                int itemPrice = int.Parse(input);

                if (counter % 2 == 0) {
                    if (itemPrice < 10) {
                        Console.WriteLine("Error in transaction!");
                    } else {
                        cardUsed++;
                        moneyRecievedCard += itemPrice;
                        Console.WriteLine("Product sold!");
                    }
                } else {
                    if (itemPrice > 100) {
                        Console.WriteLine("Error in transaction!");
                    } else {
                        cashUsed++;
                        moneyRecievedCash += itemPrice;
                        Console.WriteLine("Product sold!");
                    }
                }

                double totalMoney = moneyRecievedCard + moneyRecievedCash;

                if (totalMoney >= requiredAmount) {
                    double averageCash = moneyRecievedCash / cashUsed;
                    double averageCard = moneyRecievedCard / cardUsed;
                    Console.WriteLine($"Average CS: {averageCash:f2}");
                    Console.WriteLine($"Average CC: {averageCard:f2}");
                    return;
                }

                counter++;
                input = Console.ReadLine();
            }

            Console.WriteLine("Failed to collect required money for charity.");
        }
    }
}