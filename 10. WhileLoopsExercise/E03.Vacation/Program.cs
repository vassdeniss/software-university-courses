using System;

namespace E03.Vacation {
    class Program {
        static void Main(string[] args) {
            double vacationMoney = double.Parse(Console.ReadLine());
            double avaliableMoney = double.Parse(Console.ReadLine());
            int spendingSpree = 0;
            int days = 0;

            while (true) {
                string action = Console.ReadLine();
                double spendingMoney = double.Parse(Console.ReadLine());
                days++;

                if (action == "spend") {
                    spendingSpree++;
                    avaliableMoney -= spendingMoney;
                    if (avaliableMoney < 0) { avaliableMoney = 0; }
                }

                if (action == "save") {
                    spendingSpree = 0;
                    avaliableMoney += spendingMoney;
                }

                if (spendingSpree == 5) {
                    Console.WriteLine("You can't save the money.");
                    Console.WriteLine(days);
                    return;
                }

                if (avaliableMoney >= vacationMoney) {
                    Console.WriteLine($"You saved the money for {days} days.");
                    return;
                }
            }
        }
    }
}
