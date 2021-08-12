using System;

namespace BE09.SumOfTwoNumbers {
    class Program {
        static void Main(string[] args) {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            int magicNumber = int.Parse(Console.ReadLine());

            int combinations = 0;

            for (int i = start; i <= end; i++) {
                for (int j = start; j <= end; j++) {
                    combinations++;
                    if (i + j == magicNumber) {
                        Console.WriteLine($"Combination N:{combinations} ({i} + {j} = {magicNumber})");
                        return;
                    }
                }
            }

            Console.WriteLine($"{combinations} combinations - neither equals {magicNumber}");
        }
    }
}
