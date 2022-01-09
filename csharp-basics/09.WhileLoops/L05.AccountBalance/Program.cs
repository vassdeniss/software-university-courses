using System;

namespace L05.AccountBalance {
    class Program {
        static void Main(string[] args) {
            string input = Console.ReadLine();
            double total = 0.0;

            while (input != "NoMoreMoney") {
                double inputToDouble = double.Parse(input);
                
                if (inputToDouble < 0) {
                    Console.WriteLine("Invalid operation!");
                    break;
                }

                total += inputToDouble;
                Console.WriteLine($"Increase: {inputToDouble:f2}");
                input = Console.ReadLine();
            }

            Console.WriteLine($"Total: {total:f2}");
        }
    }
}
