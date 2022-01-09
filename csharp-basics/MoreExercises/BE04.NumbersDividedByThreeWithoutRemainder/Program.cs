using System;

namespace BE04.NumbersDividedByThreeWithoutRemainder {
    class Program {
        static void Main(string[] args) {
            int number = 1;
            while (number <= 100) {
                if (number % 3 == 0) {
                    Console.WriteLine(number);
                }
                number++;
            }
        }
    }
}
