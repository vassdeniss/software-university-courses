using System;

namespace EP01.OscarsCeremony {
    class Program {
        static void Main(string[] args) {
            int hallRate = int.Parse(Console.ReadLine());

            double figurinesPrice = hallRate * 0.7;
            double caretingPrice = figurinesPrice * 0.85;
            double soundPrice = caretingPrice / 2;

            double sum = hallRate + figurinesPrice
                + caretingPrice + soundPrice;

            Console.WriteLine($"{sum:f2}");
        }
    }
}
