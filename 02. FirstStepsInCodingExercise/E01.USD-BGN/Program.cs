using System;

namespace E01.USD_BGN {
    class Program {
        static void Main(string[] args) {
            const double USD_RATE = 1.79549;
            double bgn = double.Parse(Console.ReadLine());
            double converted = bgn * USD_RATE;
            Console.WriteLine(converted);
        }
    }
}
