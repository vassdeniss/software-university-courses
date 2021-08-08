using System;

namespace L06.SpecialNumbers {
    class Program {
        static void Main(string[] args) {
            int number = int.Parse(Console.ReadLine());
            int start = 1111;
            int end = 9999;

            for (int i = start; i <= end; i++) {
                string currentNumber = i.ToString();
                int counter = 0;

                for (int j = 0; j < currentNumber.Length; j++) {
                    int moduloNumber = (int)Char.GetNumericValue(currentNumber[j]);
                    if (moduloNumber == 0) { continue; }
                    if (number % moduloNumber == 0) { counter++; }
                }

                if (counter == 4) { Console.Write($"{i} "); }
            }
        }
    }
}
