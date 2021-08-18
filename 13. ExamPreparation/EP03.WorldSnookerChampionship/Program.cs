using System;

namespace EP03.WorldSnookerChampionship {
    class Program {
        static void Main(string[] args) {
            string championshipStage = Console.ReadLine();
            string ticketType = Console.ReadLine();
            int ticketQty = int.Parse(Console.ReadLine());
            char trophyPhoto = char.Parse(Console.ReadLine());

            double sum = 0.0;
            bool isTrophy = false;
            bool isDiscount = false;

            switch (ticketType) {
                case "Standard":
                    if (championshipStage == "Quarter final") {
                        sum += 55.50 * ticketQty;
                    } else if (championshipStage == "Semi final") {
                        sum += 75.88 * ticketQty;
                    } else {
                        sum += 110.10 * ticketQty;
                    }
                    break;
                case "Premium":
                    if (championshipStage == "Quarter final") {
                        sum += 105.20 * ticketQty;
                    } else if (championshipStage == "Semi final") {
                        sum += 125.22 * ticketQty;
                    } else {
                        sum += 160.66 * ticketQty;
                    }
                    break;
                case "VIP":
                    if (championshipStage == "Quarter final") {
                        sum += 118.90 * ticketQty;
                    } else if (championshipStage == "Semi final") {
                        sum += 300.40 * ticketQty;
                    } else {
                        sum += 400 * ticketQty;
                    }
                    break;
            }

            if (trophyPhoto == 'Y') { isTrophy = true; }

            if (sum > 4000) {
                isDiscount = true;
                sum *= 0.75;
            } else if (sum > 2500) {
                sum *= 0.9;
            }

            if (isTrophy && !isDiscount) { sum += 40 * ticketQty; }

            Console.WriteLine($"{sum:f2}");
        }
    }
}
