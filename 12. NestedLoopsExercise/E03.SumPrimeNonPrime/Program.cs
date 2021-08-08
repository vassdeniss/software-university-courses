using System;

namespace E03.SumPrimeNonPrime {
    class Program {
        static void Main(string[] args) {
            int primeSum = 0;
            int nonPrimeSum = 0;

            while (true) {
                string input = Console.ReadLine();

                if (input == "stop") { break; }

                int number = int.Parse(input);

                if (number < 0) { 
                    Console.WriteLine("Number is negative.");
                    continue;
                } else if (number <= 1) { 
                    nonPrimeSum += number;
                    continue;
                }

                bool flag = false;

                for (int i = 2; i <= number / 2; i++) {
                    if (number % i == 0) {
                        nonPrimeSum += number;
                        flag = true;
                        break;
                    }
                }

                if (!flag) { primeSum += number; }
            }

            Console.WriteLine($"Sum of all prime numbers is: {primeSum}");
            Console.WriteLine($"Sum of all non prime numbers is: {nonPrimeSum}");
        }
    }
}
