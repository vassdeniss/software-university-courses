using System;

namespace E02.HalfSumElement {
    class Program {
        static void Main(string[] args) {
            int numberQty = int.Parse(Console.ReadLine());
            int maxNumber = int.MinValue;
            int sum = 0;

            for (int i = 0; i < numberQty; i++) {
                int num = int.Parse(Console.ReadLine());
                sum += num;
                if (num > maxNumber) {
                    maxNumber = num;
                }
            }

            int sumWithoutMax = sum - maxNumber;

            if (sumWithoutMax == maxNumber) {
                Console.WriteLine($"Yes\nSum = {sumWithoutMax}");
            } else {
                int diff = Math.Abs(maxNumber - sumWithoutMax);
                Console.WriteLine($"No\nDiff = {diff}");
            }
        }
    }
}
