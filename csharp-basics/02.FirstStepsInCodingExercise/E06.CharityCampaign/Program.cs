using System;

namespace E06.CharityCampaign {
    class Program {
        static void Main(string[] args) {
            const double CAKE_PRICE = 45;
            const double WAFFLE_PRICE = 5.80;
            const double PANCAKE_PRICE = 3.20;

            int campaignDays = int.Parse(Console.ReadLine());
            int confectionersQty = int.Parse(Console.ReadLine());
            int cakeQty = int.Parse(Console.ReadLine());
            int waffleQty = int.Parse(Console.ReadLine());
            int pancakeQty = int.Parse(Console.ReadLine());

            double cakeSum = cakeQty * CAKE_PRICE;
            double waffleSum = waffleQty * WAFFLE_PRICE;
            double pancakeSum = pancakeQty * PANCAKE_PRICE;
            double sumDay = (cakeSum + waffleSum + pancakeSum) * confectionersQty;
            double totalSum = sumDay * campaignDays;
            double totalAfterCosts = totalSum - (totalSum / 8);

            Console.WriteLine(totalAfterCosts);
        }
    }
}
