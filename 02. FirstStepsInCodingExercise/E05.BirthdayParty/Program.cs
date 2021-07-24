using System;

namespace E05.BirthdayParty {
    class Program {
        static void Main(string[] args) {
            double hallRent = double.Parse(Console.ReadLine());
            double cakePrice = hallRent * 0.20;
            double drinkPrice = ((100 - 45) * 0.01) * cakePrice;
            double animator = hallRent / 3;
            double total = hallRent + cakePrice + drinkPrice + animator;
            Console.WriteLine(total);
        }
    }
}
