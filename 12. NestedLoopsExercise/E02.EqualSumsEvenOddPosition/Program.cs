using System;

namespace E02.EqualSumsEvenOddPosition {
    class Program {
        static void Main(string[] args) {
            int numOne = int.Parse(Console.ReadLine());
            int numTwo = int.Parse(Console.ReadLine());

            int evenSum = 0;
            int oddSum = 0;

            for (int i = numOne; i <= numTwo; i++) {
                string currentNum = i.ToString();

                for (int j = 0; j < currentNum.Length; j++) {
                    int counter = 1;

                    if (j % 2 == 0) {
                        evenSum += currentNum[j];
                    } else {
                        oddSum += currentNum[j];
                    }

                    counter++;
                }

                if (evenSum == oddSum) {
                    Console.Write($"{currentNum} ");
                }

                evenSum = 0;
                oddSum = 0;
            }
        }
    }
}
