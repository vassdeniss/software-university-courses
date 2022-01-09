using System;

namespace L07.MinNumber {
    class Program {
        static void Main(string[] args) {
            int minNumber = int.MaxValue;
            string input = Console.ReadLine();

            while (input != "Stop") {
                int inputNumber = int.Parse(input);
                if (inputNumber < minNumber) { minNumber = inputNumber; }
                input = Console.ReadLine();
            }

            Console.WriteLine(minNumber);
        }
    }
}
