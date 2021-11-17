using System;

namespace L06.MaxNumber {
    class Program {
        static void Main(string[] args) {
            int maxNumber = int.MinValue;
            string input = Console.ReadLine();

            while (input != "Stop") {
                int inputNumber = int.Parse(input);
                if (inputNumber > maxNumber) { maxNumber = inputNumber; }
                input = Console.ReadLine();
            }

            Console.WriteLine(maxNumber);
        }
    }
}

