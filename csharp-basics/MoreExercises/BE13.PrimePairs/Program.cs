using System;

namespace BE13.PrimePairs {
    class Program {
        static void Main(string[] args) {
            int fistPairStartValue = int.Parse(Console.ReadLine());
            int secondPairStartValue = int.Parse(Console.ReadLine());
            int fistPairDifference = int.Parse(Console.ReadLine());
            int secondPairDifference = int.Parse(Console.ReadLine());

            for (int i = fistPairStartValue; i <= fistPairStartValue + fistPairDifference; i++) {
                for (int j = secondPairStartValue; j <= secondPairStartValue + secondPairDifference; j++) {
                    bool isFirstPairPrime = isPrime(i);
                    bool isSecondPairPrime = isPrime(j);

                    if (isFirstPairPrime && isSecondPairPrime) {
                        Console.WriteLine($"{i}{j}");
                    }
                }
            }
        }

        static bool isPrime(int n) {
            // Corner case
            if (n <= 1)
                return false;

            // Check from 2 to n-1
            for (int i = 2; i < n; i++)
                if (n % i == 0)
                    return false;

            return true;
        }
    }
}
