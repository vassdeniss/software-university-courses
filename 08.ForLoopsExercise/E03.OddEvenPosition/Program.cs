using System;

namespace E03.OddEvenPosition {
    class Program {
        static void Main(string[] args) {
            double numberQty = double.Parse(Console.ReadLine());
            double sumEven = 0.0;
            double maxEven = double.MinValue;
            double minEven = double.MaxValue;
            double sumOdd = 0.0;
            double maxOdd = double.MinValue;
            double minOdd = double.MaxValue;

            for (int i = 1; i <= numberQty; i++) {
                double number = double.Parse(Console.ReadLine()); 
                if (i % 2 == 0) {
                    sumEven += number;
                    if (number > maxEven) {
                        maxEven = number;
                    }

                    if (number < minEven) {
                        minEven = number;
                    }
                } else {
                    sumOdd += number;
                    if (number > maxOdd) {
                        maxOdd = number;
                    } 
                    
                    if (number < minOdd) {
                        minOdd = number;
                    }
                }
            }

            Console.WriteLine($"OddSum={sumOdd:f2},");
            if (minOdd == double.MaxValue) {
                Console.WriteLine("OddMin=No,");
            } else {
                Console.WriteLine($"OddMin={minOdd:f2},");
            }
            if (maxOdd == double.MinValue) {
                Console.WriteLine("OddMax=No,");
            } else {
                Console.WriteLine($"OddMax={maxOdd:f2},");
            }
            Console.WriteLine($"EvenSum={sumEven:f2},");
            if (minEven == double.MaxValue) {
                Console.WriteLine("EvenMin=No,");
            } else {
                Console.WriteLine($"EvenMin={minEven:f2},");
            }
            if (maxEven == double.MinValue) {
                Console.WriteLine("EvenMax=No");
            } else {
                Console.WriteLine($"EvenMax={maxEven:f2}");
            }
        }
    }
}
