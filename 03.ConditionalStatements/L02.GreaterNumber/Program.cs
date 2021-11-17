using System;

namespace L02.GreaterNumber {
    class Program {
        static void Main(string[] args) {
            int numberOne = int.Parse(Console.ReadLine());
            int numberTwo = int.Parse(Console.ReadLine());
            Console.WriteLine(Math.Max(numberOne, numberTwo));
        }
    }
}
