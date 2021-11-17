using System;

namespace L07.ToyShop {
    class Program {
        static void Main(string[] args) {
            const double PUZZLE_PRICE = 2.60;
            const double TALKING_DOLL_PRICE = 3;
            const double PLUSHIE_PRICE = 4.10;
            const double MINION_PRICE = 8.20;
            const double TRUCK_PRICE = 2;

            double vacationPrice = double.Parse(Console.ReadLine());

            int puzzlesQty = int.Parse(Console.ReadLine()); 
            int talkingDollsQty = int.Parse(Console.ReadLine());
            int plushiesQty = int.Parse(Console.ReadLine());
            int minionsQty = int.Parse(Console.ReadLine());
            int trucksQty = int.Parse(Console.ReadLine());

            int totalQty = puzzlesQty + talkingDollsQty + plushiesQty + minionsQty + trucksQty;
            double totalMoney =
                puzzlesQty * PUZZLE_PRICE +
                talkingDollsQty * TALKING_DOLL_PRICE +
                plushiesQty * PLUSHIE_PRICE +
                minionsQty * MINION_PRICE +
                trucksQty * TRUCK_PRICE;

            if (totalQty >= 50) { totalMoney = totalMoney * 0.75; }

            totalMoney = totalMoney * 0.9;

            if (totalMoney >= vacationPrice) {
                double moneyLeft = totalMoney - vacationPrice;
                Console.WriteLine($"Yes! {moneyLeft:F2} lv left.");
            } else {
                double moneyNeeded = vacationPrice - totalMoney;
                Console.WriteLine($"Not enough money! {moneyNeeded:F2} lv needed.");
            }
        }
    }
}
