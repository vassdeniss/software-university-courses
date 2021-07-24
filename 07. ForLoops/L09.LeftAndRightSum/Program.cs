using System;

namespace L09.LeftAndRightSum {
    class Program {
        static void Main(string[] args) {
            int num = int.Parse(Console.ReadLine()); 
            int sumOne = 0;
            int sumTwo = 0;

            for (int i = 0; i < num; i++) {
                sumOne += int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < num; i++) {
                sumTwo += int.Parse(Console.ReadLine());
            }

            int diff = Math.Abs(sumOne - sumTwo);

            if (sumOne == sumTwo) {
                Console.WriteLine($"Yes, sum = {sumOne}");
            } else {
                Console.WriteLine($"No, diff = {diff}");
            }
        }
    }
}
