using System;

namespace E03.DepositCalculator {
    class Program {
        static void Main(string[] args) {
            double depositAmount = double.Parse(Console.ReadLine());
            int monthTerm = int.Parse(Console.ReadLine());
            double interestRate = double.Parse(Console.ReadLine());
            interestRate = interestRate / 100;
            double sum = depositAmount + monthTerm * ((depositAmount * interestRate) / 12);
            Console.WriteLine(sum);
        }
    }
}
