using System;

namespace EXAM01.PCStore {
    class Program {
        static void Main(string[] args) {
            const double DOLLAR_LEV = 1.57;
            double total = 0.0;

            double processorPrice = double.Parse(Console.ReadLine());
            double videoCardPrice = double.Parse(Console.ReadLine());
            double ramPrice = double.Parse(Console.ReadLine());
            int ramQty = int.Parse(Console.ReadLine());
            double percentDiscount = double.Parse(Console.ReadLine());

            double processorPriceTotal = processorPrice * DOLLAR_LEV;
            processorPriceTotal *= (1 - percentDiscount);

            double videoCardPriceTotal = videoCardPrice * DOLLAR_LEV;
            videoCardPriceTotal *= (1 - percentDiscount);

            total += processorPriceTotal
                + videoCardPriceTotal
                + (ramPrice * DOLLAR_LEV) * ramQty;

            Console.WriteLine($"Money needed - {total:f2} leva.");
        }
    }
}
