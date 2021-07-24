using System;

namespace L11.CleverLily {
    class Program {
        static void Main(string[] args) {
            int lilyAge = int.Parse(Console.ReadLine());
            double washingMachinePrice = double.Parse(Console.ReadLine());
            double toyPrice = double.Parse(Console.ReadLine());
            int moneyGift = 10;
            int toyQty = 0;
            double total = 0.0;

            for (int i = 1; i <= lilyAge; i++) {
                if (i % 2 == 0) {
                    total += moneyGift - 1;
                    moneyGift += 10;
                } else {
                    toyQty++;
                }
            }

            total += toyQty * toyPrice;

            if (total >= washingMachinePrice) {
                Console.WriteLine($"Yes! {(total - washingMachinePrice):f2}");
            } else if (total < washingMachinePrice) {
                Console.WriteLine($"No! {(washingMachinePrice - total):f2}");
            }
        }
    }
}
