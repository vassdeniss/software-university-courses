using System;

namespace BE08.EqualPairs {
    class Program {
        static void Main(string[] args) {
            int pairs = int.Parse(Console.ReadLine());
            int oldPairSum = 0;
            int maxDiff = 0;
            bool sameSum = true;

            for (int i = 0; i < pairs; i++) {
                int numOne = int.Parse(Console.ReadLine()); 
                int numTwo = int.Parse(Console.ReadLine()); 
                int pairSum = numOne + numTwo;
                if (oldPairSum == 0 || pairSum == oldPairSum) {
                    oldPairSum = pairSum;
                } else if (pairSum != oldPairSum) {
                    int diff = Math.Abs(pairSum - oldPairSum);
                    if (diff > maxDiff) { maxDiff = diff; }
                    oldPairSum = pairSum;
                    sameSum = false;
                }
            }

            if (sameSum) {
                Console.WriteLine($"Yes, value={oldPairSum}");
            } else {
                Console.WriteLine($"No, maxdiff={maxDiff}");
            }
        }
    }
}
